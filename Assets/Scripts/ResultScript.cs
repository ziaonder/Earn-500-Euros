using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class ResultScript : MonoBehaviour
{
    public static ResultScript Instance;
    public event Action OnSceneChange;
    private void Awake()
    {
        Instance = this;
    }
    public void CallEnableResult()
    {
        StartCoroutine(EnableResult());
    }
    private IEnumerator EnableResult()
    {
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<UnityEngine.UI.Image>().enabled = true;
        gameObject.GetComponentInChildren<TextMeshProUGUI>().enabled = true;
        TextResultScript.Instance.CalculateMoney();
        StartCoroutine(Scene4());
    }

    private IEnumerator Scene4()
    {
        yield return new WaitForSeconds(2f);
        OnSceneChange?.Invoke();
    }
}
