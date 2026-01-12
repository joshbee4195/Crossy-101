using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCarSpawner : MonoBehaviour
{

    public int level;
    public int identifier;

    public GameObject car;
    public GameObject carYel;
    public GameObject carBlue;
    public GameObject carGre;
    public GameObject carPur;

    public GameObject car2;
    public GameObject carYel2;
    public GameObject carBlue2;
    public GameObject carGre2;
    public GameObject carPur2;

    public Transform spawnLeft;
    public Transform spawnRight;

    public int dir;

    public int type;
    public int count;

    public int interval;


    // Start is called before the first frame update
    void Start()
    {
        dir = Random.Range(1, 3);   //1 is left to right, 2 is right to left

        //find spawn

        spawnLeft = this.transform.Find("spawn (1)");
        spawnRight = this.transform.Find("spawn (2)");
    }

    // Update is called once per frame
    void Update()
    {
        count += 1;

        if (Gen.level == 1)
        {
            level = 1;
        }

        //if (level == 1) //first level cars      //1 car at a time
        {
            if (identifier == 1)    //first road in level 1
            {
                if (count == 900)
                {
                    //spawn car, left to right

                    GameObject p1 = Instantiate(car, spawnLeft.transform.position, Quaternion.identity);

                    //set spawned cars speed

                    
                    count = 0;
                }    

                   
            }

            else if (identifier == 2)       //3 cars then gap
            {
                //2nd road in level 1

                if (count == (interval*2))
                {
                    //spawn car, left to right

                    Instantiate(carYel, spawnLeft.transform.position, Quaternion.identity);
                    //Instantiate(car2, spawnRight.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));

                    //set spawned cars direction

                    //p1.dir = 1;
                    //count = 0;
                }

                if (count == (interval*3))
                {
                    //spawn car, left to right
                    Instantiate(carYel, spawnLeft.transform.position, Quaternion.identity);
                    //Instantiate(car2, spawnRight.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
                }

                if (count == (interval * 4))
                {
                    //spawn car, left to right
                    Instantiate(carYel, spawnLeft.transform.position, Quaternion.identity);
                    //Instantiate(car2, spawnRight.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
                    count = 0;
                }
            }

            else if (identifier == 3)    //third road   //2 cars then gap
            {
                //2nd road in level 1

                if (count == (interval * 2))
                {
                    //spawn car, left to right

                    Instantiate(carBlue2, spawnRight.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
                    //Instantiate(car2, spawnRight.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));

                    //set spawned cars direction

                    //p1.dir = 1;
                    //count = 0;
                }

                if (count == (interval * 3))
                {
                    //spawn car, left to right
                    Instantiate(carBlue2, spawnRight.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));

                    //Instantiate(car2, spawnRight.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
                    count = 0;
                }

              
            }

            else if (identifier == 4)    //fourth road   //4/5 cars then gap
            {
                //2nd road in level 1

                if (count == (interval * 2))
                {
                    //spawn car, left to right

                    Instantiate(carPur, spawnLeft.transform.position, Quaternion.identity);
                    //Instantiate(car2, spawnRight.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));

                    //set spawned cars direction

                    //p1.dir = 1;
                    //count = 0;
                }

                if (count == (interval * 3))
                {
                    //spawn car, left to right
                    Instantiate(carPur, spawnLeft.transform.position, Quaternion.identity);

                    //Instantiate(car2, spawnRight.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
                //    count = 0;
                }

                if (count == (interval * 4))
                {
                    //spawn car, left to right
                    Instantiate(carPur, spawnLeft.transform.position, Quaternion.identity);

                    //Instantiate(car2, spawnRight.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
                  //  count = 0;
                }

                if (count == (interval * 5))
                {
                    //spawn car, left to right
                    Instantiate(carPur, spawnLeft.transform.position, Quaternion.identity);

                    //Instantiate(car2, spawnRight.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
                    count = 0;
                }




            }

            else if (identifier == 5)
            {

            }


            else if (identifier == 6)
            {

            }


            else if (identifier == 7)
            {

            }
        }

      /*  if (level == 2)
        {
            if (identifier == 1)    //first new road    //4/5 cars then gap
            {

                if (count == (interval * 2))
                {
                    //spawn car, left to right

                    Instantiate(carPur2, spawnRight.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
                    //Instantiate(car2, spawnRight.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));

                    //set spawned cars direction

                    //p1.dir = 1;
                    //count = 0;
                }

                if (count == (interval * 3))
                {
                    //spawn car, left to right
                    Instantiate(carPur2, spawnRight.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));

                    //Instantiate(car2, spawnRight.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
                    count = 0;
                }

            } 
      
       }
      */
        

            /*
            //if type = 1{}
            if (count == 600)
            {
                //spawn car
                if (dir == 1)
                {
                    GameObject p1 = Instantiate(car, spawnLeft.transform.position, Quaternion.identity);

                    //set spawned cars direction

                    //p1.dir = 1;
                }

                if (dir == 2)
                {
                    Instantiate(car2, spawnRight.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
                }

                count = 0;
            }

            */
        }
}
