using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class GameControl : MonoBehaviour
{
    public TextMeshProUGUI score;

    public GameObject[] lanes;


    public GameObject[] dropdownsOLD;
    public GameObject[] dropdowns;


    public TMP_Dropdown dropdown;

    public TMP_Dropdown policeDropdown;
    public TMP_Dropdown cycleDropdown;
    public TMP_Dropdown priorityDropdown;



    public GameObject spawnPoint;


    public GameObject[] laneChunks;

    public int spawnedLanes;

    public GameObject menu;
    public GameObject pause;

    public CarSpawn[] roads;
    public CarSpawn[] roadsGood;

    public TrainSpawner[] trains;
    public TrainSpawner[] trainsGood;


    public TextMeshProUGUI pauseText;


    public List<GameObject> spawnedChunks;

    public CrossyPlayer player1;


    public GameObject startScreen;
    public int startCount;
    public int startThresh;



    public int randLane;


    public GameObject newStartScreen;

    // Start is called before the first frame update
    void Start()
    {

        dropdowns[0].SetActive(true);

        dropdowns[1].SetActive(false);
        dropdowns[2].SetActive(false);

       // startScreen.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

        if (startScreen.activeSelf && Practice.Scenario > 0)
        {
            startCount++;

            if (startCount >= startThresh)
            {
                startScreen.SetActive(false);
                startCount = 0;

                pause.SetActive(true);
            }
        }



        spawnedLanes = Practice.SectionsSpawned;


        score.SetText(Gen.score.ToString());

        if (Gen.pureScore > Gen.score)
        {
            Gen.score = Gen.pureScore;
        }


        policeDropdown = dropdowns[0].GetComponent<TMP_Dropdown>();

        cycleDropdown = dropdowns[1].GetComponent<TMP_Dropdown>();

        priorityDropdown = dropdowns[2].GetComponent<TMP_Dropdown>();
    }


    public void LaneSpawns()
    {
        roads = new CarSpawn[] { };
        roadsGood = new CarSpawn[] { };

        if (Practice.Scenario == 1)
        {
            randLane = Random.Range(0, 4);
        }

        else if (Practice.Scenario == 2)
        {
            randLane = Random.Range(0, 6);
        }

        else if (Practice.Scenario == 3)
        {
            randLane = Random.Range(6, 10);
        }

        else if (Practice.Scenario == 4)
        {
            randLane = Random.Range(11, 14);
        }

        if (Practice.Scenario == 5) //consecutive 4s
        {
            //randLane = Random.Range(11, 14);

            randLane = Random.Range(14, 17);
        }


        if (Practice.Scenario == 6)
        {
            randLane = Random.Range(21, 24);
        }

        if (Practice.Scenario == 7)
        {
            randLane = Random.Range(11, 14); //change to right lane configs
        }

        if (Practice.Scenario == 8 || Practice.Scenario == 9)
        {
            randLane = Random.Range(17, 21);
        }


        if (Practice.Scenario < 8) //within first 7, need roads
        {
            GetRoads();
        }
        else //last 2, need trains
        {
            GetTrains();
        }

        if (Practice.Scenario == 1 || Practice.Scenario == 3)
        {
          
            int randPolice = Random.Range(0, roadsGood.Length - 1);

            CarSpawn PoliceRoad = roadsGood[randPolice].GetComponent<CarSpawn>();

            PoliceRoad.PoliceLane = true;
        }


        else if (Practice.Scenario == 2)
        {
            PoliceLanes();

            //choose 2 lanes for double police lane

            int randPolice = Random.Range(0, roadsGood.Length - 2);

            Debug.Log(randPolice);

            CarSpawn PoliceRoad = roadsGood[randPolice].GetComponent<CarSpawn>();
            CarSpawn PoliceRoad2 = roadsGood[randPolice + 1].GetComponent<CarSpawn>();

            PoliceRoad.PoliceLane = true;
            PoliceRoad2.PoliceLane = true;
        }


        //cycles and lane priority

        else if (Practice.Scenario == 4) //car walls
        {
            //manipulate speeds / cycles of cars to give wall pattern
            // Cycles();

            CarWall();

        }

        else if (Practice.Scenario == 5) //consec 4 cycles
        {
            //  Cycles();

            Consec4s();
        }

        else if (Practice.Scenario == 6) //AB cycles
        {
            //  Cycles();

            ABs();
        }


        else if (Practice.Scenario == 7)    // || Practice.Scenario == 8 || Practice.Scenario == 9) //
        {
            //Priority();

            SlowLane();
        }

        else if (Practice.Scenario == 8)    // || Practice.Scenario == 8 || Practice.Scenario == 9) //
        {
            //Priority();

            trainStalls();
        }

        else if (Practice.Scenario == 9)    // || Practice.Scenario == 8 || Practice.Scenario == 9) //
        {
            //Priority();

            multiTrain();
        }
    }


    public void SpawnLanes()
    {
        roads = new CarSpawn[] { };
        roadsGood = new CarSpawn[] { };

        //spawn diff lanes depending on scenario (eg police need police cars, some need trains etc)


        //10 lane chunks

        //^prefab chunks?

        //eg 5 police lanes, spawn random from those 5


        //Simplify police

        if (Practice.Scenario == 1)
        {
            PoliceLanes();

            int randPolice = Random.Range(0, roadsGood.Length - 1);

            CarSpawn PoliceRoad = roadsGood[randPolice].GetComponent<CarSpawn>();

            PoliceRoad.PoliceLane = true;
        }


        else if (Practice.Scenario == 2)
        {
            PoliceLanes();

            //choose 2 lanes for double police lane

            int randPolice = Random.Range(0, roadsGood.Length - 2);

            Debug.Log(randPolice);

            CarSpawn PoliceRoad = roadsGood[randPolice].GetComponent<CarSpawn>();
            CarSpawn PoliceRoad2 = roadsGood[randPolice + 1].GetComponent<CarSpawn>();

            PoliceRoad.PoliceLane = true;
            PoliceRoad2.PoliceLane = true;
        }

        else if (Practice.Scenario == 3) //police train pressure
        {
            PoliceLanes();

            int randPolice = Random.Range(0, roadsGood.Length - 1);

            CarSpawn PoliceRoad = roadsGood[randPolice].GetComponent<CarSpawn>();

            PoliceRoad.PoliceLane = true;
        }

    
        else if (Practice.Scenario == 4) //car walls
        {
            //manipulate speeds / cycles of cars to give wall pattern
            Cycles();

        }

        else if (Practice.Scenario == 5) //consec 4 cycles
        {
            Cycles();
        }

        else if (Practice.Scenario == 6) //AB cycles
        {
            Cycles();
        }


        else if (Practice.Scenario == 7 || Practice.Scenario == 8 || Practice.Scenario == 9) //
        {
            Priority();
        }


    }

    public void GetRoads()
    {
       

        GameObject p1 = Instantiate(laneChunks[randLane], spawnPoint.transform.position, Quaternion.identity);

        spawnPoint.transform.position += new Vector3(0, 0, 20);

        roads = FindObjectsOfType<CarSpawn>();

        List<CarSpawn> roadOptions = new List<CarSpawn>();

        Debug.Log("roads parent name:" + roads[0].transform.parent.name + ", lane chunks name: " + p1.gameObject.name);  //laneChunks[randLane].name);

        for (int i = 0; i < roads.Length; i++)
        {
            if (roads[i].transform.parent.name == p1.gameObject.name)  //laneChunks[randLane].name) //.Replace("(Clone)", "")
            {


                if (spawnedChunks.Count == 0)   //null) //first road, so add
                {
                    roadOptions.Add(roads[i]);
                }

                else //has some previous chunks in
                {
                   
                    if (!spawnedChunks.Contains(roads[i].transform.parent.gameObject))       //roads[i].transform.parent != spawnedChunks[spawnedChunks.Count].gameObject)  //spawnedChunks[j]
                    {
                        roadOptions.Add(roads[i]);

                        Debug.Log("good road");
                    }
                }

            }
        }

        roadsGood = roadOptions.ToArray();

        spawnedChunks.Add(p1);
    }

    public void GetTrains()
    {
        GameObject p1 = Instantiate(laneChunks[randLane], spawnPoint.transform.position, Quaternion.identity);

        spawnPoint.transform.position += new Vector3(0, 0, 20);


        trains = FindObjectsOfType<TrainSpawner>();

        List<TrainSpawner> trainOptions = new List<TrainSpawner>();

        //  Debug.Log("roads parent name:" + trains[0].transform.parent.name + ", lane chunks name: " + p1.gameObject.name);  //laneChunks[randLane].name);

        for (int i = 0; i < trains.Length; i++)
        {
            if (trains[i].transform.parent.name == p1.gameObject.name)  //laneChunks[randLane].name) //.Replace("(Clone)", "")
            {


                if (spawnedChunks.Count == 0)   //null) //first road, so add
                {
                    trainOptions.Add(trains[i]);
                }

                else //has some previous chunks in
                {
                    // if (roads[i].transform.parent != spawnedChunks[spawnedChunks.Count].gameObject)  //spawnedChunks[j]
                    if (!spawnedChunks.Contains(trains[i].transform.parent.gameObject))       //roads[i].transform.parent != spawnedChunks[spawnedChunks.Count].gameObject)  //spawnedChunks[j]
                    {
                        trainOptions.Add(trains[i]);

                        Debug.Log("good road");
                    }
                }

            }
        }

        trainsGood = trainOptions.ToArray();

        spawnedChunks.Add(p1);
    }



    public void Priority() //slow lane, train stalls and multi train
    {
        int randLane = 1;


        if (Practice.Scenario == 7)
        {
            randLane = Random.Range(11, 14); //change to right lane configs
        }

        if (Practice.Scenario == 8 || Practice.Scenario == 9)
        {
            randLane = Random.Range(17, 21);
        }


        GameObject p1 = Instantiate(laneChunks[randLane], spawnPoint.transform.position, Quaternion.identity);

        spawnPoint.transform.position += new Vector3(0, 0, 20);


        //add to spawned chunks

        //  spawnedChunks.Add(p1);


        //set cycles
        if (Practice.Scenario == 7)
        {
            roads = FindObjectsOfType<CarSpawn>();

            List<CarSpawn> roadOptions = new List<CarSpawn>();

            Debug.Log("roads parent name:" + roads[0].transform.parent.name + ", lane chunks name: " + p1.gameObject.name);  //laneChunks[randLane].name);

            for (int i = 0; i < roads.Length; i++)
            {
                if (roads[i].transform.parent.name == p1.gameObject.name)  //laneChunks[randLane].name) //.Replace("(Clone)", "")
                {


                    if (spawnedChunks.Count == 0)   //null) //first road, so add
                    {
                        roadOptions.Add(roads[i]);
                    }

                    else //has some previous chunks in
                    {
                        // if (roads[i].transform.parent != spawnedChunks[spawnedChunks.Count].gameObject)  //spawnedChunks[j]
                        if (!spawnedChunks.Contains(roads[i].transform.parent.gameObject))       //roads[i].transform.parent != spawnedChunks[spawnedChunks.Count].gameObject)  //spawnedChunks[j]
                        {
                            roadOptions.Add(roads[i]);

                            Debug.Log("good road");
                        }
                    }

                }
            }

            roadsGood = roadOptions.ToArray();

            spawnedChunks.Add(p1);
        }

        else // trains
        {
            trains = FindObjectsOfType<TrainSpawner>();

            List<TrainSpawner> trainOptions = new List<TrainSpawner>();

          //  Debug.Log("roads parent name:" + trains[0].transform.parent.name + ", lane chunks name: " + p1.gameObject.name);  //laneChunks[randLane].name);

            for (int i = 0; i < trains.Length; i++)
            {
                if (trains[i].transform.parent.name == p1.gameObject.name)  //laneChunks[randLane].name) //.Replace("(Clone)", "")
                {


                    if (spawnedChunks.Count == 0)   //null) //first road, so add
                    {
                        trainOptions.Add(trains[i]);
                    }

                    else //has some previous chunks in
                    {
                        // if (roads[i].transform.parent != spawnedChunks[spawnedChunks.Count].gameObject)  //spawnedChunks[j]
                        if (!spawnedChunks.Contains(trains[i].transform.parent.gameObject))       //roads[i].transform.parent != spawnedChunks[spawnedChunks.Count].gameObject)  //spawnedChunks[j]
                        {
                            trainOptions.Add(trains[i]);

                            Debug.Log("good road");
                        }
                    }

                }
            }

            trainsGood = trainOptions.ToArray();

            spawnedChunks.Add(p1);
        }


        if (Practice.Scenario == 7)
        {
            SlowLane();
        }

        if (Practice.Scenario == 8)
        {
            trainStalls();
        }


        if (Practice.Scenario == 9)
        {
            multiTrain();
        }

    }

    public void SlowLane()
    {

      
        int diffCar = Random.Range(2, 5);
        float diffspeed = Random.Range(2.8f, 5.2f);


        // for (int i = Random.Range(5, roadsGood.Length); i < 0; i--)
        for (int i = 1; i < 6; i++)   //Random.Range(6, roadsGood.Length); i++) //poss 6, length +1
        {

            int direction = Random.Range(0, 10);

            int cycle = Random.Range(2, 5);

            float speed = Random.Range(6f, 12f);



            int firstCar = (roadsGood.Length - i);  //last object in road means first lane

            Debug.Log(firstCar);

            CarSpawn carSpawn = roadsGood[firstCar].GetComponent<CarSpawn>();

            carSpawn.cycle = cycle;


            carSpawn.carSpeed = speed;


            if (i == diffCar)
            {
                carSpawn.carSpeed = diffspeed;
                carSpawn.cycle = 1;

                carSpawn.interval = 700;

            }

            // carSpawn.chosenCar = Random.Range(0, carSpawn.cars.Length);
            // carSpawn.thisCar = carSpawn.cars[carSpawn.chosenCar];  // cars[Random.Range(0, cars.Length)];
            carSpawn.thisCar = carSpawn.cars[direction];  // cars[Random.Range(0, cars.Length)];

          

            if (direction < 5) //in first half
            {
                carSpawn.dir = 1;
            }

            else
            {
                carSpawn.dir = 2;
            }



            float speedPercent = (speed / 8.5f); // * 100;


            float maxInterval = 1000;


            float percentInterval = speedPercent * maxInterval;


            //  interval = (int)(maxInterval - percentInterval);


            //fix low intervals

            float minInterval = 400f;  // smallest allowed gap

            if (i == diffCar)
            {
              
                minInterval = 800;

            }

            carSpawn.interval = (int)Mathf.Lerp(maxInterval, minInterval, speedPercent);

            // carSpawn.carSpeed = Random.Range(3f, 8.5f);
            //   carSpawn.dir = 2;
        }
    }

    public void trainStalls()
    {
        int direction = Random.Range(1, 3); //1 or 2

      //  int cycle = Random.Range(3, 5);

        float speed = Random.Range(6f, 12f);

        int count = 1;
       
        for (int i = 1; i < trainsGood.Length+1; i++) //4 trains  
        {

             direction = Random.Range(1, 3); //1 or 2

            int firstCar = (trainsGood.Length - i);  //last object in road means first lane

           // int firstCar = (i - 1);  //last object in road means first lane

            Debug.Log(firstCar);

            TrainSpawner trainSpawn = trainsGood[firstCar].GetComponent<TrainSpawner>();


           
            if (direction == 1) //in first half
            {
                trainSpawn.dir = 1;
            }

            else
            {
                trainSpawn.dir = 2;
            }


            //need count to be different
            count = 2000 - (i * 300); //500, 1000, 5000

            trainSpawn.count = count;


        }
    }

    public void multiTrain()
    {
        int direction = Random.Range(1, 3); //1 or 2

        //  int cycle = Random.Range(3, 5);

       // float speed = Random.Range(6f, 12f);

        int count = Random.Range(1, 1500);

        for (int i = 1; i < trainsGood.Length + 1; i++) //3 trains  
        {


            direction = Random.Range(1, 3); //1 or 2

            int firstCar = (trainsGood.Length - i);  //last object in road means first lane

        
            TrainSpawner trainSpawn = trainsGood[firstCar].GetComponent<TrainSpawner>();



            if (direction == 1) //in first half
            {
                trainSpawn.dir = 1;
            }

            else
            {
                trainSpawn.dir = 2;
            }


            //need count to be the same
         //   count = i * 500; //500, 1000, 5000

            trainSpawn.count = count;
        }
    }

    public void Cycles()
    {
        int randLane = 1;

        if (Practice.Scenario == 4)
        {
            randLane = Random.Range(11, 14);
        }

        if (Practice.Scenario == 5) //consecutive 4s
        {
            //randLane = Random.Range(11, 14);

            randLane = Random.Range(14, 17);
        }


        if (Practice.Scenario == 6)
        {
            randLane = Random.Range(21, 24);
        }

        GameObject p1 = Instantiate(laneChunks[randLane], spawnPoint.transform.position, Quaternion.identity);

        spawnPoint.transform.position += new Vector3(0, 0, 20);


        //add to spawned chunks

      //  spawnedChunks.Add(p1);
        //set cycles

        roads = FindObjectsOfType<CarSpawn>();

        List<CarSpawn> roadOptions = new List<CarSpawn>();

        Debug.Log("roads parent name:" + roads[0].transform.parent.name + ", lane chunks name: " + p1.gameObject.name);  //laneChunks[randLane].name);

        for (int i = 0; i < roads.Length; i++)
        {
            if (roads[i].transform.parent.name == p1.gameObject.name)  //laneChunks[randLane].name) //.Replace("(Clone)", "")
            {

                if (spawnedChunks.Count == 0)   //null) //first road, so add
                {
                    roadOptions.Add(roads[i]);
                }

                else //has some previous chunks in
                {
                   // if (roads[i].transform.parent != spawnedChunks[spawnedChunks.Count].gameObject)  //spawnedChunks[j]
                    if (!spawnedChunks.Contains(roads[i].transform.parent.gameObject))       //roads[i].transform.parent != spawnedChunks[spawnedChunks.Count].gameObject)  //spawnedChunks[j]
                    {
                          roadOptions.Add(roads[i]);

                        Debug.Log("good road");
                    }
                }


                    for (int j = 0; j < roads.Length; j++)   //spawnedChunks.Count; j++)
                    {


                        //  if (roads[i].transform.parent != spawnedChunks[spawnedChunks.Count])  //spawnedChunks[j]
                        {
                            //  roadOptions.Add(roads[i]);

                           // Debug.Log("good road");
                        }
                    }

              //  roadOptions.Add(roads[i]);

               // Debug.Log("good road");
            }
        }

        roadsGood = roadOptions.ToArray();

        spawnedChunks.Add(p1);


        if (Practice.Scenario == 4)
        {
            CarWall();
        }

        if (Practice.Scenario == 5)
        {
            Consec4s();
        }


        if (Practice.Scenario == 6)
        {
            ABs();
        }

    }

    public void CarWall()
    {
        int direction = Random.Range(0, 10);

        int cycle = Random.Range(3, 5);

        float speed = Random.Range(6f, 12f);

        int diffCycle = Random.Range(2, 5);

        // for (int i = Random.Range(5, roadsGood.Length); i < 0; i--)
        for (int i = 1; i < 6; i++)   //Random.Range(6, roadsGood.Length); i++) //poss 6, length +1
        {

            //  int firstCar = (roadsGood.Length - 1);  //last object in road means first lane
            int firstCar = (roadsGood.Length - i);  //last object in road means first lane

            Debug.Log(firstCar);

            CarSpawn carSpawn = roadsGood[firstCar].GetComponent<CarSpawn>();

            carSpawn.cycle = cycle;

            if (i == diffCycle)
            {
                carSpawn.cycle = cycle - 1;

            }

            // carSpawn.chosenCar = Random.Range(0, carSpawn.cars.Length);
            // carSpawn.thisCar = carSpawn.cars[carSpawn.chosenCar];  // cars[Random.Range(0, cars.Length)];
            carSpawn.thisCar = carSpawn.cars[direction];  // cars[Random.Range(0, cars.Length)];

            carSpawn.carSpeed = speed;


            if (direction < 5) //in first half
            {
                carSpawn.dir = 1;
            }

            else
            {
                carSpawn.dir = 2;
            }



            float speedPercent = (speed / 8.5f); // * 100;


            float maxInterval = 1000;


            float percentInterval = speedPercent * maxInterval;


            //  interval = (int)(maxInterval - percentInterval);


            //fix low intervals

            float minInterval = 400f;  // smallest allowed gap
            float maxInt = 1200f;    // largest allowed gap

            carSpawn.interval = (int)Mathf.Lerp(maxInterval, minInterval, speedPercent);

            // carSpawn.carSpeed = Random.Range(3f, 8.5f);
            //   carSpawn.dir = 2;
        }
    }

    public void Consec4s()
    {
        int direction = Random.Range(0, 10);

        int cycle = 4;

       // float speed = Random.Range(6f, 12f);

        //int diffCycle = Random.Range(2, 5);


        // for (int i = Random.Range(5, roadsGood.Length); i < 0; i--)
        for (int i = 1; i < 4; i++)   //Random.Range(6, roadsGood.Length); i++) //poss 6, length +1
        {


            if (i == 1 || i == 3)
            {
                 direction = Random.Range(0, 5);
            }

            if (i == 2)
            {
                direction = Random.Range(5, 10);
            }


            //  int firstCar = (roadsGood.Length - 1);  //last object in road means first lane
            int firstCar = (roadsGood.Length - i);  //last object in road means first lane

            Debug.Log(firstCar);

            CarSpawn carSpawn = roadsGood[firstCar].GetComponent<CarSpawn>();

            carSpawn.cycle = cycle;

           
            carSpawn.thisCar = carSpawn.cars[direction];


            float speed = Random.Range(6f, 12f);

            carSpawn.carSpeed = speed;


            if (direction < 5) //in first half
            {
                carSpawn.dir = 1;
            }

            else
            {
                carSpawn.dir = 2;
            }



            float speedPercent = (speed / 8.5f); // * 100;
            float maxInterval = 1000;
            float percentInterval = speedPercent * maxInterval;


            //fix low intervals

            float minInterval = 400f;  // smallest allowed gap
            float maxInt = 1200f;    // largest allowed gap

            carSpawn.interval = (int)Mathf.Lerp(maxInterval, minInterval, speedPercent);

        }
    }

    public void ABs()
    {

        //both need same speed + direction
        //but diff cycle

        //or same cycle but offset by 1


        int direction = Random.Range(0, 10);
        float speed = Random.Range(6f, 12f);


        int cycle = 3;

        // float speed = Random.Range(6f, 12f);

        //int diffCycle = Random.Range(2, 5);

        int order = Random.Range(1, 3); //if 1, first road smaller cycle - if 2, second road smaller cycle

        // for (int i = Random.Range(5, roadsGood.Length); i < 0; i--)
        for (int i = 1; i < 3; i++)   //Random.Range(6, roadsGood.Length); i++) //poss 6, length +1
        {
            /*
            if (order == 1)
            {
                if (i == 1)
                {
                    cycle = 2;
                }

                if (i == 2)
                {
                    cycle = 4;
                }
            }

            else if (order == 2)
            {

                if (i == 1)
                {
                    cycle = 4;
                }

                if (i == 2)
                {
                    cycle = 2;
                }
            }

            */

                //  int firstCar = (roadsGood.Length - 1);  //last object in road means first lane
                int firstCar = (roadsGood.Length - i);  //last object in road means first lane

            //Debug.Log(firstCar);

            CarSpawn carSpawn = roadsGood[firstCar].GetComponent<CarSpawn>();

            carSpawn.cycle = cycle;


            carSpawn.thisCar = carSpawn.cars[direction];


            

            carSpawn.carSpeed = speed;


            if (direction < 5) //in first half
            {
                carSpawn.dir = 1;
            }

            else
            {
                carSpawn.dir = 2;
            }



            float speedPercent = (speed / 8.5f); // * 100;
            float maxInterval = 1000;
            float percentInterval = speedPercent * maxInterval;


            //fix low intervals

            float minInterval = 400f;  // smallest allowed gap
          
            carSpawn.interval = (int)Mathf.Lerp(maxInterval, minInterval, speedPercent);


            if (order == 1)
            {
                if (i == 1)
                {
                    carSpawn.count = carSpawn.interval*2 - 1;

                    Debug.Log(carSpawn.count);
                }

                if (i == 2)
                {
                    //cycle = 4;

                    Debug.Log(carSpawn.count);
                }
            }

            else if (order == 2)
            {

                if (i == 1)
                {
                  //  cycle = 4;
                    carSpawn.count = carSpawn.interval*2 - 1;
                    Debug.Log(carSpawn.count);
                }

                if (i == 2)
                {
                    // cycle = 2;

                    Debug.Log(carSpawn.count);
                }
            }


        }
    }

    public void PoliceLanes()
    {

        int randLane = 1;

        if (Practice.Scenario == 1)
        {
             randLane = Random.Range(0, 4);
        }

        else if (Practice.Scenario == 2)
        {
             randLane = Random.Range(0, 6);
        }

        else if (Practice.Scenario == 3)
        {
            randLane = Random.Range(6, 10);
        }

        GameObject p1 = Instantiate(laneChunks[randLane], spawnPoint.transform.position, Quaternion.identity);

        spawnPoint.transform.position += new Vector3(0, 0, 20);

        //add to spawned chunks

      //  spawnedChunks.Add(p1);


        //set police lane

        roads = FindObjectsOfType<CarSpawn>();

        List<CarSpawn> roadOptions = new List<CarSpawn>();


        Debug.Log("roads parent name:" + roads[0].transform.parent.name + ", lane chunks name: " + p1.gameObject.name);  //laneChunks[randLane].name);
        for (int i = 0; i < roads.Length; i++)
        {

            if (spawnedChunks.Count == 0)   //null) //first road, so add
            {
                roadOptions.Add(roads[i]);
            }

            else //has some previous chunks in
            {
                // if (roads[i].transform.parent != spawnedChunks[spawnedChunks.Count].gameObject)  //spawnedChunks[j]
                if (!spawnedChunks.Contains(roads[i].transform.parent.gameObject))       //roads[i].transform.parent != spawnedChunks[spawnedChunks.Count].gameObject)  //spawnedChunks[j]
                {
                    roadOptions.Add(roads[i]);

                    Debug.Log("good road");
                }
            }
        }
            /*
            // if (roads[i].transform.parent.name == p1.gameObject.name)  //laneChunks[randLane].name) //.Replace("(Clone)", "")
            if (roads[i].transform.parent.name == p1.gameObject.name)   // && roads[i].transform.parent != spawnedChunks[i])  //laneChunks[randLane].name) //.Replace("(Clone)", "")
            {
                // roadsGood.Append(roads[i]);

                for (int j = 0; i < spawnedChunks.Count; i++)
                {
                    if (roads[i].transform.parent != spawnedChunks[j])
                    {
                        roadOptions.Add(roads[i]);
                    }
                }

            //    roadOptions.Add(roads[i]);


                //roadsGood = new CarSpawn[] { };

                Debug.Log("good road");
            }
        
            */
        

        roadsGood = roadOptions.ToArray();

        spawnedChunks.Add(p1);
        //choose lane to be the police lane

/*
        int randPolice = Random.Range(0, roadsGood.Length - 1);

        CarSpawn PoliceRoad = roadsGood[randPolice].GetComponent<CarSpawn>();

        PoliceRoad.PoliceLane = true;

        */
    }

    public void SelectionDropdown2()
    {
        if (dropdown.value == 0)
        {
            //enable police, disable others

            dropdowns[0].SetActive(true);

            dropdowns[1].SetActive(false);
            dropdowns[2].SetActive(false);
        }

        else if (dropdown.value == 1)
        {
            //cycles
            dropdowns[1].SetActive(true);

            dropdowns[0].SetActive(false);
            dropdowns[2].SetActive(false);
        }

        else if (dropdown.value == 2)
        {
            //priority

            dropdowns[2].SetActive(true);

            dropdowns[0].SetActive(false);
            dropdowns[1].SetActive(false);
           
        }
    }

    public void SelectionDropdowns()
    {
        // Guard against missing references
        if (dropdowns == null || dropdown == null || dropdowns.Length == 0)
            return;

        int selected = Mathf.Clamp(dropdown.value, 0, dropdowns.Length - 1);

        for (int i = 0; i < dropdowns.Length; i++)
        {
            var go = dropdowns[i];
            if (go != null)
                go.SetActive(i == selected);
        }
    }

    public void SelectionDropdown()
    {
        for (int i = 0; i < dropdowns.Length; i++)
        {

            for (int j = 0; j < dropdowns.Length; j++)
            {
                if (dropdown.value == j)
                {
                    dropdowns[j].SetActive(true);
                }

                else
                {
                    dropdowns[j].SetActive(false);
                }
            }
        }
    }




    public void StartGameButton()
    {
        //set scenario number

        if (dropdown.value == 0) //police
        {
           //TMP_Dropdown police = dropdowns[0].GetComponent<TMP_Dropdown>();
         //   policeDropdown = dropdowns[0].GetComponent<TMP_Dropdown>();

            Practice.Scenario = policeDropdown.value + 1;
        }

        if (dropdown.value == 1) //cycle
        {
         
            Practice.Scenario = cycleDropdown.value + 4;
        }


        if (dropdown.value == 2) //priority
        {
            
            Practice.Scenario = priorityDropdown.value + 7;
        }


        Debug.Log("Scenario: " + Practice.Scenario);


        for (int i = 0; i < spawnedChunks.Count; i++)
        {
            Destroy(spawnedChunks[i]);
        }

        //reset lanes - remove existing chunks, reset spawn

        spawnPoint.transform.position = new Vector3 (0, 0, 0);


        //reset player

        CrossyPlayer player = player1.GetComponent<CrossyPlayer>();

        player.Die();

        //SpawnLanes();

        LaneSpawns();

        menu.SetActive(false);

        pause.SetActive(false);

        Practice.isPaused = false;

        pauseText.SetText("||");


        Practice.ResetCount += 1;


        if (startScreen != null)
        {
            startScreen.SetActive(true);


           // newStartScreen.SetActive(false);
        }
    }


    public void PauseButton()
    {
        Practice.isPaused = !Practice.isPaused;

        if (Practice.isPaused)
        {
            pauseText.SetText("X");

            menu.SetActive(true);
        }

        else
        {
            pauseText.SetText("||");

            menu.SetActive(false);
        }
    }
}
