using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public bool isDown = false;
    private Camera main;
    // Start is called before the first frame update
    void Start()
    {
        main = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDown)
        {
            Vector3 pos = main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(pos.x,pos.y,0);
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
