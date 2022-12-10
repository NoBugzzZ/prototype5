using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    private bool isDown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDown)
        {
            Debug.Log(Input.mousePosition);
        }
        if (Input.GetMouseButtonDown(0))
        {
            isDown = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDown = false;
        }
    }
}
