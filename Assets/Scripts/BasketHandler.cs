using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketHandler : MonoBehaviour
{
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
        FallingObjectController.objectTag = collision.gameObject.tag;
        FallingObjectController.collidedObject = collision.gameObject;
        OnObjectCollect?.Invoke();
        UpdateScoreboard?.Invoke();
    }
}


