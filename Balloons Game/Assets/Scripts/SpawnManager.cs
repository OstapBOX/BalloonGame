using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] balloonPrefabs;

    private GameManager gameManager;
    private float xSpawnRange = 10.0f,
                  ySpawnPosition = -10.0f,
                  zSpawnMaxPosition = 3.0f;

    
                  
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InvokeRepeating("SpawnBalloon", gameManager.GetDelay(), gameManager.GetInterval());
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.isGameActive)
        {
            CancelInvoke("SpawnBalloon");
        }
        
    }

    private void SpawnBalloon()
    {
        float xSpawnPosition = Random.Range(-xSpawnRange, xSpawnRange),
              zSpawnPosition = Random.Range(0, zSpawnMaxPosition);

        int randomBalloonIndex = Random.Range(0, balloonPrefabs.Length);

        Vector3 spawnPosition = new Vector3(xSpawnPosition, ySpawnPosition, zSpawnPosition);

        Instantiate(balloonPrefabs[randomBalloonIndex], spawnPosition, balloonPrefabs[randomBalloonIndex].transform.rotation);

    }
}
