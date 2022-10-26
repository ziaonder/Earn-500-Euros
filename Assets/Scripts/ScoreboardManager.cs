using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreboardManager : MonoBehaviour
{
    private TextMeshProUGUI TMPro;
    private string _name;

    private void Start()
    {
        FallingObjectController.SetCount();
        TMPro = GetComponent<TextMeshProUGUI>();
        GetName();
        UpdateScoreboard();
        BasketHandler.Instance.UpdateScoreboard += UpdateScoreboard;
    }
    private void GetName()
    {
        if (gameObject.tag == "Diamond")
            _name = "Diamond: ";
        else if (gameObject.tag == "Gold")
            _name = "Gold: ";
        else if (gameObject.tag == "Silver")
            _name = "Silver: ";
        else if (gameObject.tag == "Tin")
            _name = "Tin: ";
        else
            _name = "Coal: ";
    }

    public void UpdateScoreboard()
    {
        TMPro.text = _name + FallingObjectController.GetCount(gameObject.tag);
    }
}
