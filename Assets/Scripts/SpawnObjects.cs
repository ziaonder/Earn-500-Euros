using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] fallableObjects;
    private int leftEdge = -7, rightEdge = 7;
    private int spawnPoint;
    private float spawnTime = 1.5f;

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

    //Creates a spawn point for fallableObjects
    private float CreateSpawnPoint()
    {
        spawnPoint = Random.Range(leftEdge, rightEdge + 1);
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
