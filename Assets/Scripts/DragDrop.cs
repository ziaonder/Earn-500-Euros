using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    private Vector3 initialPosition;
    public static bool isDraggable;

    private void Start()
    {
        StartCoroutine(SetTransform());
        //isDraggable = false;
    }

    //public void Drag(BaseEventData data)
    //{
    //    if (isDraggable)
    //    {
    //        PointerEventData pointerData = (PointerEventData)data;

    //        Vector2 position;
    //        RectTransformUtility.ScreenPointToLocalPointInRectangle(
    //            (RectTransform)canvas.transform, pointerData.position, canvas.worldCamera, out position);

    //        transform.position = canvas.transform.TransformPoint(position);
    //    }
    //}

    //public void Drop()
    //{
    //    //Debug.Log("fuck you");
    //}

    private IEnumerator SetTransform()
    {
        yield return new WaitForSeconds(1f);
        initialPosition = transform.TransformPoint(Vector3.zero);
        //Debug.Log(initialPosition);
    }

    public void ResetPosition()
    {
        transform.position = initialPosition;
    }
}
