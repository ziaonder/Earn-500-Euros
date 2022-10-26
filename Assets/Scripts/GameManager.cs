using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public float diamondSpeed = 1f, goldSpeed = 1f, silverSpeed = 1f, tinSpeed = 1f, coalSpeed = 1f;
    public float diamondAcc = .5f, goldAcc = .5f, silverAcc = .5f, tinAcc = .5f, coalAcc = .5f;
    // Acc means acceleration here
}
