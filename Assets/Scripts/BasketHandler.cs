using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class BasketHandler : MonoBehaviour
{
    [SerializeField] private GameObject badEffectObject, goodEffectObject;
    [SerializeField] private AudioSource winSound, warningSound;
    public static float additionalScore;
    public static BasketHandler Instance;
    public event Action OnObjectCollect;
    public event Action UpdateScoreboard;
    private bool mousePressed = true;
    Vector3 mouseWorldPosition;
    private float initialEdge = 12.5f;
    private float leftEdge, rightEdge;
    private Vector2 initialScale = new Vector2(0.34f, 0.34f);

    private void Awake()
    {
        winSound.volume = 0.3f;
        gameObject.transform.localScale = initialScale;
        leftEdge = -initialEdge;
        rightEdge = initialEdge;
        
        Instance = this;
    }
    #region WebGL is on Mobile Check

    [DllImport("__Internal")]
    private static extern bool IsMobile();

    public bool isMobile()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
return IsMobile();
#endif
        return false;
    }

#endregion
    void Update()
    {
#region PlayerController

        if (mousePressed == true)
        {
            if(isMobile() == false)
                mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            else
                mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            if (mouseWorldPosition.x < leftEdge)
            {
                mouseWorldPosition.x = leftEdge;
            } 

            if(mouseWorldPosition.x > rightEdge)
            {
                mouseWorldPosition.x = rightEdge;
            }
            
            transform.position = new Vector3(mouseWorldPosition.x, transform.position.y, transform.position.z); 
        }
#endregion
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coal")
        {
            warningSound.Play();
            badEffectObject.GetComponent<ParticleSystem>().Play();
            additionalScore = -2;
        }
        else if(collision.gameObject.tag == "Tin")
        {
            warningSound.Play();
            badEffectObject.GetComponent<ParticleSystem>().Play();
            additionalScore = -5;
        }
        else if(collision.gameObject.tag == "Diamond")
        {
            winSound.Play();
            goodEffectObject.GetComponent<ParticleSystem>().Play();
            additionalScore = 10;
        }
        else if(collision.gameObject.tag == "Gold")
        {
            winSound.Play();
            goodEffectObject.GetComponent<ParticleSystem>().Play();
            additionalScore = 5;
        }
        else if(collision.gameObject.tag == "Silver")
        {
            winSound.Play();
            goodEffectObject.GetComponent<ParticleSystem>().Play();
            additionalScore = 2;
        }
        FallingObjectController.objectTag = collision.gameObject.tag;
        FallingObjectController.collidedObject = collision.gameObject;
        OnObjectCollect?.Invoke();
        UpdateScoreboard?.Invoke();
    }
}


