using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBalloon : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    private GameManager gameManager;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.ExplodeSound();
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            if (gameObject.CompareTag("BlueBalloon"))
            {
                gameManager.UpdateBlueScore(1);
            }
            else if (gameObject.CompareTag("PinkBalloon"))
            {
                gameManager.UpdatePinkScore(1);
            }
            else if (gameObject.CompareTag("PurpleBalloon"))
            {
                gameManager.UpdatePurpleScore(1);
            }
        }
        
    }

   
}
