using System;
using System.Collections;
using System.Collections.Generic;
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
    private float leftEdge = -7.7f, rightEdge = 7.7f;

    private void Awake()
    {
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


