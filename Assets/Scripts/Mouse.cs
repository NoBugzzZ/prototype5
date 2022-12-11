using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public bool isDown = false;
    private Camera main;
    private TrailRenderer trail;
    // Start is called before the first frame update
    void Start()
    {
        main = Camera.main;
        trail = GetComponent<TrailRenderer>();
        trail.enabled = isDown;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(pos.x, pos.y, 0);
        if (Input.GetMouseButtonDown(0))
        {
            isDown = true;
            trail.enabled = isDown;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDown = false;
            trail.enabled = isDown;
        }
    }
}
