using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLPlayer : MonoBehaviour
{

    public float speed;

    public bool pressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed == true)
        {
            transform.position = transform.position + new Vector3(-speed, 0, speed);
        }

        else if (pressed == false)
        {
            transform.position = transform.position + new Vector3(speed, 0, speed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pressed = !pressed;
        }
    }
}
