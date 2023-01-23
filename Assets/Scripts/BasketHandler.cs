using System;
using UnityEngine;

public class BasketHandler : MonoBehaviour
{
    [SerializeField] private GameObject badEffectObject, goodEffectObject;
    [SerializeField] private AudioSource winSound, warningSound;
    public static float additionalScore;
    public static BasketHandler Instance;
    public event Action OnObjectCollect;
    public event Action UpdateScoreboard;
    private bool mousePressed;
    Vector3 mouseWorldPosition;
    private float initialEdge = 7.5f;
    private float leftEdge = -7.5f, rightEdge = 7.5f;
    private Vector2 initialScale = new Vector2(0.34f, 0.34f);

    private void Awake()
    {
        if (Screen.currentResolution.width > Screen.currentResolution.height)
        {
            gameObject.transform.localScale = initialScale;
            leftEdge = -initialEdge;
            rightEdge = initialEdge;
        }
        else
        {
            gameObject.transform.localScale = initialScale / 2;
        }
        
        Instance = this;

    }

    void Update()
    {
        #region PlayerController
        if (Input.GetMouseButtonDown(0))
        {
            mousePressed = true;    
        }

        if(mousePressed == true)
        {
            mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
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


