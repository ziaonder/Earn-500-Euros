using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour
{
    [SerializeField] private GameObject[] imageGameObjects;
    [SerializeField] private GameObject function, functionUI, informationUI, attentionWarning;

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
        SceneManager.LoadScene("Scene 1");        
    }

    public void DisableAttentionWarning()
    {
        attentionWarning.SetActive(false);
    }
    

    public void EnableFunctionUI()
    {
        functionUI.SetActive(true);
    }

    public void EnableInformationUI()
    {
        informationUI.SetActive(true);
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

    private IEnumerator EnableButton()
    {
        yield return new WaitForSeconds(.6f);
        gameObject.GetComponent<Button>().interactable = true;
    }
}
