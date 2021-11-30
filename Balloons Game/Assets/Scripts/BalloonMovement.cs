using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    private Rigidbody balloonRb;
    private GameManager gameManager;

    private float maxTorque = 100,
                  destroyBoundRange = 15;
                  
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        balloonRb = GetComponent<Rigidbody>();
        balloonRb.AddTorque(0, RandomTorque(), 0);
    }

    // Update is called once per frame
    void Update()
    {
        balloonRb.AddForce(Vector3.up * gameManager.GetForce());

        if(transform.position.y > destroyBoundRange || transform.position.y < -destroyBoundRange)
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }





}
