using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RSplayer : MonoBehaviour
{

    public Rigidbody rb;


    public float speed;
    public float speedX;
    public float speedY;

    public bool bounce;

    public int bounceCount;

    public Animator anim;

    public int animCount;
    public bool animating;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //move forward

        /*
         * rb.AddForce(new Vector3(0, 0, 0.01f));

         if (Input.GetKey(KeyCode.LeftArrow))
         {
             rb.AddRelativeForce(new Vector3(-0.01f, 0, 0));
         }

         if (Input.GetKey(KeyCode.RightArrow))
         {
             rb.AddRelativeForce(new Vector3(0.01f, 0, 0));
         }
        */

        transform.position = transform.position + new Vector3(0, 0, speed);

        //always rotate 000

        transform.rotation = new Quaternion(0,0,0,0);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + new Vector3(-speedX, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + new Vector3(speedX, 0, 0);
        }


        if (bounce == true)
        {
            bounceCount++;

            if (bounceCount < 30)
            {
                //rb.AddRelativeForce(new Vector3(0, speedY, 0));

                 rb.velocity = (new Vector3(0, speedY, 0));
                transform.position = transform.position + new Vector3(0, 0, speed*5);

                //rb.velocity = (new Vector3(0, speedY, 0));

                // transform.position = new Vector3(transform.position.x, 20, transform.position.z);   //transform.position + new Vector3(0, speedY, 0);
            }

            else
            {
                bounce = false;
                bounceCount = 0;
              //  anim.SetInteger("action", 0);
            }
        }

        if (animating == true)
        {
            animCount++;

        }

        if (animCount < 100)
        {
          //  anim.SetInteger("action", 0);
        }

        else
        {
            anim.SetInteger("action", 0);
            animating = false;
            animCount = 0;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bouncepad")
        {
            // launch in air
            //up force

            //  rb.AddRelativeForce(new Vector3(0, speedY, 0));

            bounce = true;
            Debug.Log("bounce");

            //action = 1

            anim.SetInteger("action", 1);
            animating = true;
        }
    }
}
