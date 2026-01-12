using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSpawner : MonoBehaviour
{
    public GameObject train;
    public GameObject train2;
    public Transform spawnLeft;
    public Transform spawnRight;

    public int dir;

    public int timer;
    public int count;

    public Renderer light1;
    public Renderer light2;

    public Material r;
    public Material w;
    public Color red;

    public bool random = true;

    // Start is called before the first frame update
    void Start()
    {
        if (random)
        {
            dir = Random.Range(1, 3);   //1 is left to right, 2 is right to left

            count = Random.Range(1, 1500);  //random start point so trains aren't same cycle
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Practice.isPaused)
        {
            count += 1;

           //in game timings - 

            //light off to train on start of play area - 23 frames?
            //9 frames to cross

            //if (count == (timer * 0.7)) //proportion of 2000 - 0.7 is 1400
            if (count == (timer * 0.85)) //0.85 is 1700
            {
                light1.material = r;
                light2.material = r;
            }

            //if (count == (timer * 0.95)) //0.95 is 1900
            if (count == (timer * 0.95)) //0.96 is 1900
            {
                light1.material = w;
                light2.material = w;
            }

            if (count == timer)
            {
                //spawn car
                if (dir == 1)
                {
                   Instantiate(train, spawnLeft.transform.position + new Vector3(-10, -0.5f, 0), Quaternion.identity); //+ or - 10

                    //set spawned cars direction

                    //p1.dir = 1;
                }

                if (dir == 2)
                {
                    Instantiate(train2, spawnRight.transform.position + new Vector3(10, -0.5f, 0), Quaternion.identity); //+ or - 10 so not spawn partway on play area
                }

                count = 0;

                light1.material = w;
                light2.material = w;
            }
        }
    }
}
