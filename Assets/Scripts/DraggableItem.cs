using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public static string itemSlotName;
    public static bool isDragging;
    private Vector3 initialPosition;
    private CanvasGroup canvasGroup;
    RectTransform rectTransform;
    [SerializeField] Canvas canvas;
    public static bool isDraggable;
    private bool isClicked;
    //private static GameObject draggedGameObject;
    private void Start()
    {
        isDraggable = false;
        itemSlotName = null;
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        StartCoroutine(SetTransform());
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDraggable)
            isDragging = true;
            transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        isDragging = false;
    }

    private IEnumerator SetTransform()
    {
        yield return new WaitForSeconds(1f);
        initialPosition = transform.TransformPoint(Vector3.zero);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StartCoroutine(ResetObject());
        StartCoroutine(TakeObject());
    }

    public void DropObject()
    {
        if (itemSlotName == gameObject.tag)
        {
            gameObject.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            gameObject.GetComponentInChildren<UnityEngine.UI.Image>().enabled = false;
            ItemSlot.SetTakens(gameObject.tag);
        }
        else
        {
            gameObject.transform.position = initialPosition;
            // Warning sound
        }
    }

    private IEnumerator ResetObject()
    {
        yield return new WaitForSeconds(1);
        isClicked = false;
    }

    private IEnumerator TakeObject()
    {
        yield return new WaitForSeconds(.01f);
        if (isDraggable)
            DropObject();
    }
}
