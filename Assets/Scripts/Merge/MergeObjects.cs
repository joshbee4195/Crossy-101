using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeObjects : MonoBehaviour
{

    public GameObject[] levels;

    public GameObject character;
    public GameObject[] characters; //characters in order, start with chicken

    public bool OnConveyor = false;
    public float speed;


    public Collider landCheck;  //used for checking occupied ground
    public GameObject land;
    public GameObject lands;

    public float end = 7.6f;

    public int moveCount = 0;   //how many times attempted to move to layer 2

    public Vector3 startpoint = new Vector3(-1.072332f, 0.9866538f, -0.7071136f);

    public float convTurn1 = -3.5f;
    public float convTurn2 = 10.7f;
    public float convTurn3 = 12f;

    public bool turned = false;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "lvl4")
        {
            //transform.position = transform.position + new Vector3(5, 0, 0);     //Merge.Layer2BLocks[0].transform.position;

            //transform position relative to block 1?
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Merge.obj1);
        Debug.Log(Merge.obj2);

        if (OnConveyor == true)
        {
            //if x / z coords specific numbers, move specific way

            if (transform.position.z > convTurn1 && turned == false)
            {
                transform.position = transform.position += new Vector3(0, 0, -speed);
            }

            else if (transform.position.z <= convTurn1 && transform.position.x < convTurn2)
            {
                transform.position = transform.position += new Vector3(speed, 0, 0);
                turned = true;
            }

            else if (transform.position.z <= convTurn3 && transform.position.x >= convTurn2)    //if z is further forward then end point - transform.position.z <= convTurn1
            {
                transform.position = transform.position += new Vector3(0, 0, speed);
            }



            // transform.position = transform.position += new Vector3(speed, 0, 0);
            //change so moves along whole of conveyor
        }


        if (transform.position.x > end)
        {
            //Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        // this object was clicked - do something

        if (OnConveyor == true)
        {
            //move position
            //onConveyor false
            Merge.obj1 = gameObject;
            OnConveyor = false;
            Merge.Conv = true;

        }

        else if (OnConveyor == false)
        {
            Merge.Conv = false;

            if (Merge.obj1 == null)
            {
                Merge.obj1 = gameObject;
                Merge.Conv = true;  //

                //change land of 1
            }

            else if (Merge.obj2 == null)
            {
                Merge.obj2 = gameObject;
            }

            if (Merge.obj2.tag == Merge.obj1.tag && Merge.obj2 != null)
            {
                if (Merge.obj2 != Merge.obj1)
                {
                    //merge objects
                    //instantiate next level object
                    //change land status of obj 1 to false

                    if (Merge.obj1 == gameObject)   //if first object merged
                    {
                        //change that land to false

                        //Instantiate(lands, transform.position,Quaternion.identity);
                        //lands needs to copy ID setting
                    }


                    if (Merge.obj1.tag == "lvl1")   //if merging level 1 character (chicken)
                    {
                        //2nd character
                        Instantiate(characters[1], Merge.obj2.transform.position, Quaternion.identity);

                        Merge.xp += 1;

                        if (Merge.highestChar <= 2)
                        {
                            Merge.highestChar = 2;
                        }
                    }

                    else if (Merge.obj1.tag == "lvl2")  //if selected 2 level 2s
                    {
                        Instantiate(characters[2], Merge.obj2.transform.position, Quaternion.identity);
                        Merge.xp += 2;

                        // Instantiate(characters[2], Merge.obj2.transform.position, Quaternion.identity); //change to chars[8]

                        if (Merge.highestChar <= 3)
                        {
                            Merge.highestChar = 3;
                        }

                    }

                    else if (Merge.obj1.tag == "lvl3")
                    {
                        Instantiate(characters[3], Merge.obj2.transform.position, Quaternion.identity);
                        Merge.xp += 3;

                        if (Merge.highestChar <= 4)
                        {
                            Merge.highestChar = 4;
                        }
                    }

                    else if (Merge.obj1.tag == "lvl4")
                    {
                        Instantiate(characters[4], Merge.obj2.transform.position, Quaternion.identity);
                        Merge.xp += 4;

                        if (Merge.highestChar <= 5)
                        {
                            Merge.highestChar = 5;
                        }
                    }


                    Destroy(Merge.obj2);
                    Destroy(Merge.obj1);
                }

                else
                {
                    //reset if selected twice
                }
                {
                    //if obj1 and 2 are same object
                    Merge.obj1 = null;
                    Merge.obj2 = null;
                }
            }

                    //etc.

                   /*else if (Merge.obj1.tag == "lvl2")  //next area //change to 8
                    {

                        //give xp

                        Merge.xp += 8;
                    //spawn in next area
                    //need to check land spaces for free space

                    //if merge.layer2land[0] = false, spawn on pos 1, set to true
                    //else if [1] = false, do same
                    //else all occupied, say next level maxed out
                    // Instantiate(characters[4], Merge.obj2.transform.position, Quaternion.identity);
                    //Merge.xp += 4;

                    //Instantiate(characters[2], Merge.obj2.transform.position, Quaternion.identity); //change to chars[8]
                    for (int i = 0; i < 12; i++)
                    {
                        // Code to be repeated.
                        if (Merge.Layer2Land[i] == false)   //not occupied
                        {
                            //spawn
                            //Instantiate(characters[2], Merge.Layer2BLocks[0].transform.position, Quaternion.identity); //change to chars[8]
                            // Instantiate(characters[4], Merge.obj2.transform.position, Quaternion.identity); //change to chars[8]
                            //Instantiate(characters[4], startpoint + new Vector3(20, 0, 0), Quaternion.identity); //change to chars[8]
                            Instantiate(characters[4], startpoint, Quaternion.identity); //change to chars[8]
                            Merge.Layer2Land[i] = true;

                            break;

                        }

                        else
                        {
                            moveCount++;
                        }
                        //else if occupied, move to next
                    }

                    if (moveCount >= 12)
                    {
                        //all occupied
                        //display message can't move
                    }   */

                


                    //Destroy(Merge.obj2);
                    //Destroy(Merge.obj1);
        }

                else
                {
                    //deselect, don't merge

                    Merge.obj1 = null;
                    Merge.obj2 = null;

                    //if merge obj1 and 2 .tag are max level, deselect too?"
                }
    }
        


    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "land")
        {
            land = other.gameObject;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "log")  //reach death box
        {
            Destroy(gameObject);
        }
    }
}
