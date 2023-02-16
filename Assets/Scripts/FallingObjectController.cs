using UnityEngine;

public class FallingObjectController : MonoBehaviour
{
    private static int diamondCount, goldCount, silverCount, tinCount, coalCount;
    private new Rigidbody2D rigidbody;
    public float speed;
    public static string objectTag;
    public static GameObject collidedObject;
    private int boundBorder = -6;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        UpdateSpeed();
        BasketHandler.Instance.OnObjectCollect += UpdateSpeed;
        BasketHandler.Instance.OnObjectCollect += DestroyCollidedObject;
    }

    private void OnDestroy()
    {
        BasketHandler.Instance.OnObjectCollect -= UpdateSpeed;
        BasketHandler.Instance.OnObjectCollect -= DestroyCollidedObject;
    }
    
    public static void SetCount()
    {
        diamondCount = 0;
        goldCount = 0;
        silverCount = 0;
        tinCount = 0;
        coalCount = 0;
    }

    public static int GetCount(string tag)
    {
        switch (tag)
        {
            case "Diamond":
                return diamondCount;
            case "Gold":
                return goldCount;
            case "Silver":
                return silverCount;
            case "Tin":
                return tinCount;
            case "Coal":
                return coalCount;
            default:
                return 0;
        }
    }   

    public void UpdateSpeed() // Not only updates the speed but also increments the counter variable of objects.
    {
        if(collidedObject == gameObject) // This check prevents other active falling objects to increase the speed more than once.
        {
            switch (objectTag)
            {
                case "Diamond":
                    GameManager.Instance.diamondSpeed += GameManager.Instance.diamondAcc;
                    diamondCount++;
                    break;
                case "Gold":
                    GameManager.Instance.goldSpeed += GameManager.Instance.goldAcc;
                    goldCount++;
                    break;
                case "Silver":
                    GameManager.Instance.silverSpeed += GameManager.Instance.silverAcc;
                    silverCount++;
                    break;
                case "Tin":
                    GameManager.Instance.tinSpeed += GameManager.Instance.tinAcc;
                    tinCount++;
                    break;
                case "Coal":
                    GameManager.Instance.coalSpeed += GameManager.Instance.coalAcc;
                    coalCount++;
                    break;
            }
        }

        switch (gameObject.tag)
        {
            case "Diamond":
                speed = GameManager.Instance.diamondSpeed;
                break;
            case "Gold":
                speed = GameManager.Instance.goldSpeed;
                break;
            case "Silver":
                speed = GameManager.Instance.silverSpeed;
                break;
            case "Tin":
                speed = GameManager.Instance.tinSpeed;
                break;
            case "Coal":
                speed = GameManager.Instance.coalSpeed;
                break;
        }

        rigidbody.velocity = new Vector2(0f, -speed);
    }

    private void DestroyCollidedObject()
    {
        Destroy(collidedObject);
    }

    private void Update()
    {
        DestroyMissedObject();    
    }
    private void DestroyMissedObject()
    {
        if (gameObject.transform.position.y < boundBorder)
            Destroy(gameObject);
    }
}
