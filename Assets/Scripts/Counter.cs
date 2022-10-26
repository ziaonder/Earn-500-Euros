using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;
    private int counter = 90;
    // Start is called before the first frame update
    void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>(); 
        StartCoroutine(DecreaseCounter());
    }

    // Update is called once per frame
    void Update()
    {
        _textMeshPro.text = counter.ToString();
    }

    IEnumerator DecreaseCounter()
    {
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
    }
}
