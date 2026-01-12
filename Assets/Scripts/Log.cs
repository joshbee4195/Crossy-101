using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{

    public float speed;

    public int dir;

    public int identifier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dir == 1)
        {
            transform.position = transform.position + new Vector3(speed, 0, 0);
        }

        //if dir 2, right to left
        if (dir == 2)
        {
            transform.position = transform.position + new Vector3(-speed, 0, 0);
        }

        if (transform.position.x > 20 || transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }
}
