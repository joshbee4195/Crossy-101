using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{

    public int identifier;

    public int dir;

    public GameObject log1;
    public GameObject log2;
    public GameObject log3;

    public GameObject logR1;
    public GameObject logR2;
    public GameObject logR3;

    public int level;

    public int count;

    public Transform spawnLeft;
    public Transform spawnRight;

    public int countTarget;

    public int logSize;

    public GameObject[] logs;
    public GameObject[] logs2;

    // Start is called before the first frame update
    void Start()
    {
        spawnLeft = this.transform.Find("spawnLeft");
        spawnRight = this.transform.Find("spawnRight");
    }

    // Update is called once per frame
    void Update()
    {
        if (Gen.level == 3)
        {
            level = 3;
        }


        count++;

        //if (level == 3)
        {
            if (identifier == 1)
            {
                if (count == countTarget)
                {
                    //spawn car, left to right

                    logSize = Random.Range(0, 3);    //could be 0,1,2    //,3
                                                     //;//]logSize = Random.Range(1,4);    //could be 1,2,3

                    GameObject p1 = Instantiate(logs[logSize], spawnLeft.transform.position, Quaternion.identity);

                    count = 0;
                }
            }

            if (identifier == 2)
            {
                if (count == countTarget)
                {
                    //spawn car, left to right

                    logSize = Random.Range(0, 3);    //could be 0,1,2    //,3
                                                     //;//]logSize = Random.Range(1,4);    //could be 1,2,3

                    GameObject p1 = Instantiate(logs2[logSize], spawnRight.transform.position, Quaternion.identity);

                    count = 0;
                }
            }
        }
    }
}
