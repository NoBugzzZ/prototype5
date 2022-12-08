using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    public float minForce = 10;
    public float maxForce = 15;
    public float xRange = 4;
    public float yPos = -1;
    public float maxTorgue = 10;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameObject.transform.position = RandomPos();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), yPos, 0);
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorgue, maxTorgue);
    }
}
