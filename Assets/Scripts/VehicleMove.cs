using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMove : MonoBehaviour
{

    public float speed; //0.02 base

    public int dir;

    public bool levels = false;

    public GameObject identifier;

    public float[] speeds;

    public int resetCount;
    // Start is called before the first frame update
    void Start()
    {
        //speed calculation code?

        //get scene name

        //for now, set levels to true
        levels = true;

        //speeds = [0.1f,0.01f];

        /*
        speeds[1] = 0.01f;
        speeds[2] = 0.015f;
        speeds[3] = 0.02f;
        speeds[4] = 0.025f;
        speeds[5] = 0.03f;

        speeds[6] = 0.04f;
        */

        resetCount = Practice.ResetCount;
    }

    // Update is called once per frame
    void Update()
    {
        //if dir 1, left to right
        if (!Practice.isPaused)
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

            if (transform.position.x > 50 || transform.position.x < -50)
            {
                Destroy(gameObject);
            }

            if (levels == true)
            {
                if (Gen.level == 1) //if first level
                {

                }
            }
        }


        if (resetCount != Practice.ResetCount)
        {
            Destroy(gameObject);
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "road")
        {
            identifier = other.gameObject;  //saves the road car is on

         //   if (Gen.level == 1)
         /*
            {
                if (other.gameObject.name == "Road")
                {
                    speed = 0.06f;// speeds[1];  //2nd speed option
                }


                if (other.gameObject.name == "Road (1)")
                {
                    speed = speeds[1];  //2nd speed option
                }

                if (other.gameObject.name == "Road (2)")
                {
                    speed = speeds[2];  //3rd speed option - default
                }
                if (other.gameObject.name == "Road (3)")
                {
                    speed = speeds[0];  //1st speed option
                }
            }
            */
        }
    }
}
