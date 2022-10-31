using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreboardManager : MonoBehaviour
{
    private TextMeshProUGUI TMPro;

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "Scene 2")
        {
            FallingObjectController.SetCount();
            BasketHandler.Instance.UpdateScoreboard += UpdateScoreboard;
        }
        TMPro = GetComponent<TextMeshProUGUI>(); 
        UpdateScoreboard();
    }

    public void UpdateScoreboard()
    {
        TMPro.text = FallingObjectController.GetCount(gameObject.tag).ToString();
    }

    public void SetAlpha()
    {
        gameObject.GetComponent<CanvasRenderer>().SetAlpha(.5f);
    }
}
