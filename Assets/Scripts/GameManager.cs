using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public float diamondSpeed = 3.5f, goldSpeed = 3f, silverSpeed = 2.5f, tinSpeed = 3f, coalSpeed = 5f;
    public float diamondAcc = .2f, goldAcc = .2f, silverAcc = .2f, tinAcc = .2f, coalAcc = .2f;
    // Acc means acceleration here
}
