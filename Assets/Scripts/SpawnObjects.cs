using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] fallableObjects;
    private double leftEdge = -2.5f, rightEdge = 2.5f;
    private float spawnPoint;
    private float spawnTime = 1.5f;
    private double scaleTimes;
    private float desktopResolutionWidth;
    private Vector2 initialScale = new Vector2(0.4f, 0.4f);

    enum Device
    {
        mobile,
        desktop
    }
    private void Awake()
    {
        // This if statement extends the borders of spawn point if the device is desktop.
        if(Screen.currentResolution.width > Screen.currentResolution.height)
        {
            leftEdge *= 2;
            rightEdge *= 2;
        }

        Device currentlyUsedDevice = GetDevice();
        desktopResolutionWidth = 1920f;
        Resolution resolution = Screen.currentResolution;
        Debug.Log(resolution);
        scaleTimes = resolution.width / desktopResolutionWidth;
        scaleTimes = Math.Round(scaleTimes, 1);
        leftEdge *= scaleTimes;
        rightEdge *= scaleTimes;

        foreach(GameObject i in fallableObjects)
        {
            if (currentlyUsedDevice == Device.mobile)
            {
                i.transform.localScale = initialScale / 2;
            }
            else
                i.transform.localScale = initialScale;
        }
    }

    private Device GetDevice()
    {
        if(Screen.currentResolution.width > Screen.currentResolution.height)
        {
            return Device.desktop;
        }
        else
        return Device.mobile;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjectsInTime());   
    }
    
    public IEnumerator SpawnObjectsInTime()
    {
        while (!Counter.Instance.isGameOver)
        {
            Instantiate(fallableObjects[CreateIndex()], new Vector3(CreateSpawnPoint(), transform.position.y),
                Quaternion.identity);
            if(spawnTime > .5f)
            {
                spawnTime -= .05f;
            }
            yield return new WaitForSeconds(spawnTime);
        }
    }

    // Creates a spawn point for fallableObjects
    private float CreateSpawnPoint()
    {
        spawnPoint = Random.Range((float)leftEdge, (float)rightEdge + 1);
        if (spawnPoint % 2 == 0)
            return spawnPoint;
        else if(spawnPoint < 0) // If its an odd number and below zero add 1 to it to be inside of the edges.
            return spawnPoint + 1;
        else        
            return spawnPoint - 1;
    }

    // Creates an index number that will later be used with fallableObjects array.
    private int CreateIndex() 
    {
         return Random.Range(0, fallableObjects.Length);
    }
}
