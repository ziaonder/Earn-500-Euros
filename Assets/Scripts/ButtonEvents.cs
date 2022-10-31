using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour
{
    [SerializeField] private GameObject[] imageGameObjects;
    [SerializeField] private GameObject function;
    public void SetDraggable()
    {
        DraggableItem.isDraggable = true;
    }

    public void EnableFunction()
    {
        function.SetActive(true);
    }

    public void SetImageActive()
    {
        if (imageGameObjects != null)
        {
            foreach (GameObject image in imageGameObjects)
            {
                image.SetActive(true);
            }
        }
    }
    public void DisableButton()
    {
        gameObject.GetComponent<Button>().interactable = false;
    }

    public void ResetPositions()
    {
        foreach(var obj in FindObjectsOfType<DragDrop>())
        {
            obj.ResetPosition();
        }
        
    }
}
