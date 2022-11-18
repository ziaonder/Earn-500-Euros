using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextResultScript : MonoBehaviour
{
    public static TextResultScript Instance;
    [SerializeField] private GameObject[] buttons;
    private void Awake()
    {
        Instance = this;
    }
    private TextMeshProUGUI TMPro;
    private int diamondValue = 10, goldValue = 5, silverValue = 2, tinValue = -5, coalValue = -2;
    private static int TotalGainedMoney;

    private void Start()
    {
        TMPro = GetComponent<TextMeshProUGUI>();
        if(SceneManager.GetActiveScene().name == "Scene 3")
            TotalGainedMoney = 0;
        if(SceneManager.GetActiveScene().name == "Scene 4")
        {
            if(TotalGainedMoney >= 500)
            {
                TMPro.text = $"You Win! \n\nYou collected €{TotalGainedMoney} today!";
                buttons[1].SetActive(true);
            }
            else
            {
                TMPro.text = "You Lost!";
                buttons[0].SetActive(true);
                buttons[1].SetActive(true);
            }
        }
    }

    public void CalculateMoney()
    {
        TotalGainedMoney = diamondValue * FallingObjectController.GetCount("Diamond") +
            goldValue * FallingObjectController.GetCount("Gold") + silverValue * FallingObjectController.GetCount("Silver") +
            tinValue * FallingObjectController.GetCount("Tin") + coalValue * FallingObjectController.GetCount("Coal");

        TMPro.text = "€" + TotalGainedMoney.ToString();
    }
}
