using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour
{
    [SerializeField] private GameObject[] imageGameObjects;
    [SerializeField] private GameObject function;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Scene 3")
        {
            gameObject.GetComponent<Button>().interactable = false;
            StartCoroutine(EnableButton());
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
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

    private IEnumerator EnableButton()
    {
        yield return new WaitForSeconds(.6f);
        gameObject.GetComponent<Button>().interactable = true;
    }
}
