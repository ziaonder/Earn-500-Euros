using System;
using System.Collections;
using System.Collections.Generic;
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
    private int counter = 5;
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
