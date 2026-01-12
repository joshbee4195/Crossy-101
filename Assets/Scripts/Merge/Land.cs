using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{

    public int ID;
    public int ID2;

    public bool Occupied;

    public GameObject character;
    public GameObject characterStatus;  //check new frame of character

    // Start is called before the first frame update
    void Start()
    {
        if (ID == 1 || ID == 2) //first 2
        {
          //  Occupied = true;
        }

        if (ID > 12 && ID < 25) //2nd layer
        {

            ID2 = ID - 12;
            //Merge.Layer2BLocks[0] = gameObject;

            //Merge.Layer2BLocks[ID2-1] = gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
       // if (character != null && characterStatus == null)   //character was there last frame but not this one
       if (character == null)
        {
            Occupied = false;   //character no longer there
        }

        
    }

    public void LateUpdate()
    {
       // if (character != null)  // && characterStatus != null)
        {
          //  characterStatus = character;
        }
    }
    void OnMouseDown()
    {
        if (Merge.obj1 != null && Merge.Conv == true)   //selected object and moving from conveyor
        {
            if (Occupied == false)
            {
                Merge.obj1.transform.position = transform.position;
                Merge.Conv = false;
                Merge.obj1 = null;

                Occupied = true;

            }
            //for loop

           // if (ID == 1)
            {
                //spacesOcc 1 = true;

             //   MergeMaster.spaceOcc[1] = true;
            }
        }
    }

    public void OnTriggerStay(Collider other)
    {
        //if (other.gameObject.tag == "land")
        {
            character = other.gameObject;   //registers character object
            Occupied = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.tag == "land")
        {
            // character = other.gameObject;

            Occupied = false;
        }
    }
}
