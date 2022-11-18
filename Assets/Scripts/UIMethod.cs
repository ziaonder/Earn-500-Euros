using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMethod : MonoBehaviour
{
    private static TextMeshProUGUI TMPro;
    private static string diamond, gold, silver, tin, coal;
    private static string _string;
    private void Start()
    {
        diamond = "diamond"; gold = "gold"; silver = "silver"; tin = "tin"; coal = "coal";
        _string = "CalculateMoney(int diamond, int gold, int silver, int tin, int coal){\r\n\ttotalScore = "
        + $"({diamond}*10) + ({gold}*5) + ({silver}*2) + \n" + "        " + $"({tin}*-5) + ({coal}*-2);\r\n\treturn; \r\n}}";
        
        TMPro = GetComponent<TextMeshProUGUI>();
        TMPro.text = _string;
    }

    public static void SetNewValues()
    {
        diamond = FallingObjectController.GetCount("Diamond").ToString();
        gold = FallingObjectController.GetCount("Gold").ToString();   
        silver = FallingObjectController.GetCount("Silver").ToString(); 
        tin = FallingObjectController.GetCount("Tin").ToString();
        coal = FallingObjectController.GetCount("Coal").ToString();
        
        _string = "CalculateMoney(int diamond, int gold, int silver, int tin, int coal){\r\n\ttotalScore = "
        + $"({diamond}*10) + ({gold}*5) + ({silver}*2) + \n" + "        " + $"({tin}*-5) + ({coal}*-2);\r\n\treturn; \r\n}}";
        TMPro.text = _string;
    }
}