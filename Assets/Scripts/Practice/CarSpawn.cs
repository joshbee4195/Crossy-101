using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{

    public int level;
    public int identifier;


    public Transform spawnLeft;
    public Transform spawnRight;

    public int dir;

   
    public int count;

    public int interval;

    public GameObject[] cars; //add all cars to array - all left spawning, then all right spawning
    public GameObject thisCar;
    public int chosenCar;
    public int cycle;

    public bool PoliceLane;
    public bool PoliceCycleSpawned;

    public float carSpeed; //currently 0.01-0.04 with 0.005 intervals


    //public VehicleMove car;
    public CarMove car;

    public float policeSpeed;
    public GameObject[] policeCar;
    public float policeInterval;

    public bool cycleEnd;


    public int policeCycleStage;    //1 is regular car, 2 is police car


    public List<GameObject> spawnedCars;    // = new List<GameObject>();

    public bool firstCycleDone;

    public bool random = true;
    // Start is called before the first frame update
    void Start()
    {
        policeCycleStage = 1;

        if (gameObject.tag == "road")
        {
            random = true;
        }

        else if (gameObject.tag == "randRoad")
        {
            random = false;
        }

        //road cycle

        if (random)
        {
            cycle = Random.Range(1, 5); //makes cycle 1-4 cars

            //car type
            chosenCar = Random.Range(0, cars.Length);
            thisCar = cars[chosenCar];  // cars[Random.Range(0, cars.Length)];


            if (chosenCar < cars.Length / 2) //in first half
            {
                dir = 1;
            }

            else
            {
                dir = 2;
            }

            //car speed - random for some scenarios

            //if (scenario is x,y,z)
            // carSpeed = Random.Range(0.01f, 0.04f);

            carSpeed = Random.Range(3f, 8.5f);


            float speedPercent = (carSpeed / 8.5f); // * 100;


            float maxInterval = 1000;


            float percentInterval = speedPercent * maxInterval;


            interval = (int)(maxInterval - percentInterval);


            //fix low intervals

            float minInterval = 400f;  // smallest allowed gap
           // float maxInt = 1200f;    // largest allowed gap

            interval = (int)Mathf.Lerp(maxInterval, minInterval, speedPercent);

            Debug.Log("speed: " + carSpeed + ", percent:" + speedPercent + ", maxInterval: " + maxInterval + ", percentInterval: " + percentInterval);

        }

        //interval = (int)(interval * 1.3f);



        policeInterval = interval * Random.Range(3, 6.5f);

        policeInterval = Mathf.RoundToInt(policeInterval);

        //other scenarios, car speed is set manually


        //old road direction
        //dir = Random.Range(1, 3);   //1 is left to right, 2 is right to left



        //find spawn

        spawnLeft = this.transform.Find("spawn (1)");
        spawnRight = this.transform.Find("spawn (2)");

        //Practice.Scenario = 1;

        //  count = 0;

        if (count == 0)
        {
            count = interval - 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!Practice.newPolice)
        {
            if (policeCycleStage == 3)
            {
                if (count > interval * 1.5)
                {
                    policeCycleStage = 1;

                    count = 0;
                }
            }
        }

        if (!Practice.isPaused)
        {

            if (count == 0)
            {
                //   firstCycleDone = true;
            }

            count += 1;


            CarSpawner();


            if (Practice.Scenario < 4) //1, 2 or 3 - police scenario
            {
                PoliceSpawner();
            }

        }
           
    }

    public void PoliceSpawner()
    {
        if (PoliceLane)
        {
            //police spawn pattern

            // if (PoliceCycleSpawned)

            //newPolice

            //if (policeCycleStage == 2)
            {
                //do police car


                if (count == policeInterval) //spawn interval
                {
                    //spawn car
                    SpawnPoliceDirection();


                    count = 0;
                }


                //PoliceCycleSpawned = false;
            }
        }
    }


    public void CarSpawner()
    {
        //spawns the cars

        //based on cycle

      //  if (!firstCycleDone)//(spawnedCars.Count == 0)
        {

            if (!PoliceLane)
            {
                //if (!PoliceCycleSpawned)    //PoliceLane
                // if (policeCycleStage == 1)    //PoliceLane
                {
                    //one cycle

                    if (cycle == 1)
                    {
                        SpawnOneCycle();
                    }

                    else if (cycle == 2)
                    {
                        SpawnTwoCycle();
                    }

                    else if (cycle == 3)
                    {
                        SpawnThreeCycle();
                    }

                    else if (cycle == 4)
                    {
                        SpawnFourCycle();
                    }


                    //newPolice
                    /*
                    if (PoliceLane && cycleEnd)
                    {
                        Debug.Log("Police");

                        PoliceCycleSpawned = true;
                    }

                    */
                }
            }
        }

     //   else
        {
            //recycle cars

        //    Recycle();
        }
    }

    public void SpawnOneCycle()
    {
        if (count == interval) //spawn interval
        {
            //spawn car
            SpawnCarDirection();
            //set spawned cars speed?


          //  count = 0;

          
            //cycleEnd = true;
        }

        if (count > interval)
        {
            if (policeCycleStage == 1 && PoliceLane)
            {
                policeCycleStage = 2;
            }

            count = 0;
        }
    }

    public void SpawnTwoCycle()
    {

        if (count == (interval * 2))
        {
            SpawnCarDirection();

        }

        if (count == (interval * 3))
        {

            SpawnCarDirection();

         //   count = 0;

        }

        if (count > interval * 3)
        {
            if (policeCycleStage == 1 && PoliceLane)
            {
                policeCycleStage = 2;
            }

            count = 0;
        }
    }

    public void SpawnThreeCycle()
    {

        if (count == (interval * 2))
        {
            SpawnCarDirection();

        }

        if (count == (interval * 3))
        {
            SpawnCarDirection();

        }

        if (count == (interval * 4))
        {

            SpawnCarDirection();

         //   count = 0;

           
        }

        if (count > interval * 4)
        {
            if (policeCycleStage == 1 && PoliceLane)
            {
                policeCycleStage = 2;
            }

            count = 0;
        }
    }

    public void SpawnFourCycle()
    {

        if (count == (interval * 2))
        {
            SpawnCarDirection();

        }

        if (count == (interval * 3))
        {
            SpawnCarDirection();

        }

        if (count == (interval * 4))
        {
            SpawnCarDirection();

        }

        if (count == (interval * 5))
        {

            SpawnCarDirection();

          //  count = 0;

            
        }

        if (count > interval * 5)
        {
            if (policeCycleStage == 1 && PoliceLane)
            {
                policeCycleStage = 2;
            }

            count = 0;
        }
    }

    public void SpawnCarDirection()
    {
        if (dir == 1)
        {
            //GameObject p1 = Instantiate(cars[chosenCar], spawnLeft.transform.position, Quaternion.identity);
            GameObject p1 = Instantiate(thisCar, spawnLeft.transform.position, Quaternion.identity);
            p1.transform.parent = gameObject.transform;

            //get carmove script (currently vehiclemove) and assign speed to car speed 

            // CarMove car = p1.GetComponent<CarMove>();

            //car.carSpeed = carSpeed;

            //CarMove.carSpeed = carSpeed;


            //car = p1.GetComponent<VehicleMove>();
            car = p1.GetComponent<CarMove>();

          //  car.speed = carSpeed;


            spawnedCars.Add(p1);

        }

        else if (dir == 2)
        {
           // GameObject p1 = Instantiate(cars[chosenCar], spawnRight.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
            GameObject p1 = Instantiate(thisCar, spawnRight.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
            p1.transform.parent = gameObject.transform;


            car = p1.GetComponent<CarMove>();

       //     car.speed = carSpeed;

            spawnedCars.Add(p1);
        }
    }


    public void SpawnPoliceDirection()
    {

        //carSpeed = Random.Range(0.01f, 0.04f);

        //policeSpeed = Random.Range(0.15f, 0.4f);

        //policeSpeed = Random.Range(10f, 20f);

        policeSpeed = Random.Range(15f, 30f);


        if (dir == 1)
        {
            GameObject p1 = Instantiate(policeCar[0], spawnLeft.transform.position, Quaternion.identity);
            p1.transform.parent = gameObject.transform;

            car = p1.GetComponent<CarMove>();

            car.speed = policeSpeed;


        }

        else if (dir == 2)
        {
            GameObject p1 = Instantiate(policeCar[1], spawnRight.transform.position, Quaternion.Euler(new Vector3(0, 180, 0)));
            p1.transform.parent = gameObject.transform;


            car = p1.GetComponent<CarMove>();

            car.speed = policeSpeed;
        }

        //PoliceCycleSpawned = false;

        policeCycleStage = 3;
       // cycleEnd = false;
      //  count = 1;
    }

}
