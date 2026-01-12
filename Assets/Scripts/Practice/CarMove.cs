using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{

    public float speed; //0.02 base

    public int dir;

    public GameObject identifier;

    public float[] speeds;

    // public float carSpeed;

    public int resetCount;

    // Start is called before the first frame update
    void Start()
    {
        //speed calculation code?

        //get scene name

        
        CarSpawn car = GetComponentInParent<CarSpawn>();

        if (gameObject.tag == "vehicle")
        {
            speed = car.carSpeed;
        }

        else
        {
            speed = car.policeSpeed;
        }

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
                transform.position = transform.position + new Vector3(speed, 0, 0) * Time.deltaTime;
            }

            //if dir 2, right to left
            if (dir == 2)
            {
                transform.position = transform.position + new Vector3(-speed, 0, 0) * Time.deltaTime;
            }

            if (transform.position.x > 20 || transform.position.x < -20)
            {

                //OLD
                Destroy(gameObject);



                //NEW - move away for reuse

                //   transform.position = new Vector3(0, 100, 0);

                //   gameObject.SetActive(false);
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

           
        }
    }
}
