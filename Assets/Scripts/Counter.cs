using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public static Counter Instance;

    private void Awake()
    {
        Instance = this;    
    }

    public event Action OnTimeElapse;
    public bool isGameOver;
    private TextMeshProUGUI _textMeshPro;
    private int counter = 90;

    void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>(); 
        StartCoroutine(DecreaseCounter());
    }

    void Update()
    {
        _textMeshPro.text = counter.ToString();
        if(!isGameOver)
            CheckTime();
    }
    IEnumerator DecreaseCounter()
    {
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
    }
    public void CheckTime()
    {
        if(counter <= 0)
        {
            isGameOver = true;
            OnTimeElapse?.Invoke();
        }
    }
}
