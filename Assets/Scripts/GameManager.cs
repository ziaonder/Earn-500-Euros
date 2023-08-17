using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public float diamondSpeed = 3.5f, goldSpeed = 3f, silverSpeed = 2.5f, tinSpeed = 3f, coalSpeed = 5f;
    public float diamondAcc = .5f, goldAcc = .5f, silverAcc = .5f, tinAcc = .5f, coalAcc = .5f;
    // Acc means acceleration here
}
