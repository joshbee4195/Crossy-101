using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{

    public GameObject car;
    public GameObject car2;
    public Transform spawnLeft;
    public Transform spawnRight;

    public int dir;

    public int type;
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        dir = Random.Range(1, 3);   //1 is left to right, 2 is right to left
    }

    // Update is called once per frame
    void Update()
    {
        count += 1;

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
    }
}
