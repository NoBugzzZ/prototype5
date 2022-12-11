using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DestoryTarget : MonoBehaviour
{
    private GameManager gameManager;
    public int scoreValue;
    public ParticleSystem particle;
    private Mouse mouse;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        mouse = GameObject.Find("Mouse").GetComponent<Mouse>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        DestoryObj();
    }

    private void OnMouseEnter()
    {
        DestoryObj();
    }

    private void DestoryObj()
    {
        if (mouse.isDown && gameManager.isGameActive && !EventSystem.current.IsPointerOverGameObject())
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
                gameManager.MinusLives(1);
            }
        }
    }
}
