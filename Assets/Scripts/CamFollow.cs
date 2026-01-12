using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    public GameObject target;

    public Vector3 offset;
    public Vector3 playerOffset;

    public float speed;

    public int closestPos;

    public float distAdjust;
    public float distAdjusted;

    public float bonusSpeed;
    public float boostSpeed;

    // Start is called before the first frame update
    void Start()
    {
       // transform.position = target.transform.position + offset; //forward and up but not along

        //looks at player
        transform.LookAt(target.transform);

    }

    // Update is called once per frame
    void Update()
    {

        //only moves camera once player has done input

        if (Gen.start == true)
        {
            if (!Practice.isPaused)
            {
                closestPos = (int)transform.position.z;

                CamMove();

            }


            //need to slow cam a bit


            /*
            // transform.LookAt(target.transform);


            closestPos = (int)transform.position.z;
            transform.position = transform.position + new Vector3(0, 0, speed);

            //  if (closestPos < target.transform.position.z)
            {

            }


           //currently works by making camera move at set speeds of range

            if (target.transform.position.z > transform.position.z + 5 && (target.transform.position.z < transform.position.z + 10)) //in front
            {
                //PlayerMove.Die();
                transform.position = transform.position + new Vector3(0, 0, speed * 1.2f);   //speed change to percentage based

            }

            if (target.transform.position.z > transform.position.z + 10 && (target.transform.position.z < transform.position.z + 15)) //further in front
            {
                //PlayerMove.Die();
                transform.position = transform.position + new Vector3(0, 0, speed * 3);   //speed change to percentage based

            }

            if (target.transform.position.z > transform.position.z + 15) //player too far behind
            {
                //PlayerMove.Die();
                transform.position = transform.position + new Vector3(0, 0, speed * 10);   //speed change to percentage based

            }




            // transform.position = target.transform.position + new Vector3 (0,offset.y,offset.z); //forward and up but not along


            //transform.position = target.transform.position + new Vector3(0, 0, playerOffset.z); //forward and up but not along

            if (target.transform.position.z < transform.position.z) //player too far behind
            {
                //PlayerMove.Die();
            }

            */
        }
    }


    public void CamMove()
    {
        //need to:

        //always keep up with player
        //move fast to catch up
        //slow to scroll


        //base speed
        transform.position = transform.position + new Vector3(0, 0, speed * Time.deltaTime);


        //bonus speed


        if (target.transform.position.z > transform.position.z)
        {

          
             float dist = Vector3.Distance(target.transform.position, transform.position);

             float dist2  = target.transform.position.z - transform.position.z;

            Debug.Log("Dist:" + dist2);

             distAdjusted = dist / distAdjust;

            bonusSpeed = speed * distAdjusted;

            if (dist2 > 7 && dist2 < 11)
            {
                transform.position = transform.position + new Vector3(0, 0, boostSpeed * Time.deltaTime);
            }

            if (dist2 > 15)
            {
                transform.position = transform.position + new Vector3(0, 0, boostSpeed * 4 * Time.deltaTime);
            }

            if (dist2 > 11 && dist2 < 15)
            {
                transform.position = transform.position + new Vector3(0, 0, boostSpeed * 2.5f * Time.deltaTime);
            }

            // transform.position = transform.position + new Vector3(0, 0, bonusSpeed);   //speed change to percentage based

        }


        if (target.transform.position.z > transform.position.z + 15) //player too far behind
        {
            //PlayerMove.Die();
          //  transform.position = transform.position + new Vector3(0, 0, speed * 30);   //speed change to percentage based

        }

        if (target.transform.position.z < transform.position.z + 0.5f) //player too far behind
        {

            CrossyPlayer p = target.GetComponent<CrossyPlayer>();

            p.Die();

           // CrossyPlayer.Die();
            //  transform.position = transform.position + new Vector3(0, 0, speed * 30);   //speed change to percentage based

        }
    }
}
