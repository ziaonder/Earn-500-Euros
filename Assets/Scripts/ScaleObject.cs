using System.Collections;
using UnityEngine;
using System;

public class ScaleObject : MonoBehaviour
{
    [SerializeField] private GameObject[] buttons;
    private Vector3 targetScale = new Vector3(2f, 2f);
    private Vector3 additionScale = new Vector3(.05f, .05f);

    private void Start()
    {
        StartCoroutine(scaleObject());
    }
    private IEnumerator scaleObject()
    { 
        while(gameObject.transform.localScale.x <= targetScale.x)
        {
            gameObject.transform.localScale += additionScale;
            yield return new WaitForSeconds(.025f);
        }

        yield return new WaitForSeconds(.2f);

        foreach(var button in buttons)
        {
            button.SetActive(true);
        }
    }
}
