using System;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private static bool checkIfAllTaken;
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
        {
            IsAllTaken();
        }
    }

    private void IsAllTaken()
    {
        if (isdiamondTaken == true && isGoldTaken == true && isSilverTaken == true && isTinTaken == true && isCoalTaken == true)
        {
            checkIfAllTaken = true;
            Debug.Log("hepsi true");
            UIMethod.SetNewValues();
            // Sahne Degisimi
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
