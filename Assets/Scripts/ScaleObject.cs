using System.Collections;
using UnityEngine;
using System;

public class ScaleObject : MonoBehaviour
{
    [SerializeField] private GameObject button;
    private Vector3 targetScale = new Vector3(1.4f, 1.4f);
    private Vector3 additionDesktopScale = new Vector3(.05f, .05f);

    private void Start()
    {
        StartCoroutine(scaleObject());
    }
    private IEnumerator scaleObject()
    { 
        while(gameObject.transform.localScale.x <= targetScale.x)
        {
            gameObject.transform.localScale += additionDesktopScale;
            yield return new WaitForSeconds(.025f);
        }

        yield return new WaitForSeconds(.2f);
        button.SetActive(true);
    }
}
