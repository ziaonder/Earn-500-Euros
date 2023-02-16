using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private static bool checkIfAllTaken;
    [SerializeField] private GameObject[] highlights;
    [SerializeField] private GameObject informationUI;
    [SerializeField] private string slotName;
    public static bool isdiamondTaken, isGoldTaken, isSilverTaken, isTinTaken, isCoalTaken;
    private bool[] isAllTaken = new bool[] { isdiamondTaken, isGoldTaken, isSilverTaken, isTinTaken, isCoalTaken };

    private void Start()
    {
        checkIfAllTaken = false;
        isdiamondTaken = false;
        isGoldTaken = false;
        isSilverTaken = false;
        isTinTaken = false; 
        isCoalTaken = false;
    }

    private void Update()
    {
        if (!checkIfAllTaken)
            IsAllTaken();
    }

    private void IsAllTaken()
    {
        if (isdiamondTaken == true && isGoldTaken == true && isSilverTaken == true && isTinTaken == true && isCoalTaken == true)
        {
            informationUI.SetActive(false);
            DisableImage();
            checkIfAllTaken = true;
            UIMethod.SetNewValues();
            StartCoroutine(EnableHighlightImages());
        }
    }

    private void DisableImage()
    {
        ItemSlot[] objects = FindObjectsOfType<ItemSlot>();
        foreach(ItemSlot obj in objects)
        {
            obj.GetComponent<UnityEngine.UI.Image>().enabled = false;
            obj.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
        }
    }

    public static void SetTakens(string tag)
    {
        switch (tag)
        {
            case "Diamond":
                isdiamondTaken = true;
                break;
            case "Gold":
                isGoldTaken = true;
                break;
            case "Silver":
                isSilverTaken = true;
                break;
            case "Tin":
                isTinTaken = true;
                break;
            case "Coal":
                isCoalTaken = true;
                break;
        }
    }

    private IEnumerator EnableHighlightImages()
    {
        for(int i = 0; i < highlights.Length; i++)
        {
            yield return new WaitForSeconds(.8f);
            highlights[i].GetComponent<UnityEngine.UI.Image>().enabled = true;
            yield return new WaitForSeconds(.8f);
            highlights[i].GetComponent<UnityEngine.UI.Image>().enabled = false;
        }
        FindObjectOfType<ResultScript>().CallEnableResult();
    }
    public void OnDrop(PointerEventData eventData)
    {
        DraggableItem.itemSlotName = slotName;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(DraggableItem.isDragging)
            gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.cyan;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.white;
    }
}
