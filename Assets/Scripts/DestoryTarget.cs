using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryTarget : MonoBehaviour
{
    private GameManager gameManager;
    public int scoreValue;
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(scoreValue);
            Instantiate(particle, transform.position, transform.rotation);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sensor")
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("Good")&&gameManager.isGameActive)
            {
                gameManager.UpdateScore(-scoreValue);
            }
        }
    }
}
