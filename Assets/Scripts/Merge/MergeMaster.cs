using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class MergeMaster : MonoBehaviour
{

    public TextMeshProUGUI xp;

    public int count;
    public int target;

    public GameObject character;

    public GameObject[] spaces;

    public static bool[] spaceOcc;

    public TextMeshProUGUI SelectedItem;

    public GameObject cam;
    public float camSpeed;

    public GameObject[] layer2s;
    public Vector3[] blockLoc2s;


    public GameObject[] blocksOfLand;
    public TextMeshProUGUI highestChar;
    public Image topChar;
    public TextMeshProUGUI level;
    public Slider lvlProgress;

    //
    //
    //

    public GameObject[] cards;
    public Transform spawner;

    // Start is called before the first frame update
    void Start()
    {
        //spaces 1 and 2 occupied at start

        //spaceOcc[0] = true;
        //spaceOcc[1] = true;

        // Merge.Layer2Land = [false;

        //for loop
        for (int i = 0; i < 12; i++)
        {
            // Code to be repeated.
            if (Merge.Layer2Land[i] == true)
            {
                Merge.Layer2Occ += 1;
            }
        }
       // Merge.Layer2Occ = Merge.Layer2Land.Length;

        Merge.Layer2BLocks = layer2s;   //set layer 2 blocks as those game objects
        Merge.blockPos = blockLoc2s;   //set layer 2 blocks as those game objects

        highestChar.SetText("Highest: chicken");

        Merge.highestChar = 1;
    }

    // Update is called once per frame
    void Update()
    {
        xp.SetText(Merge.xp.ToString());

        level.SetText(Merge.LVL.ToString());

      //  Debug.Log("merge layer:  " + Merge.Layer2Occ.ToString());
        //Debug.Log("merge blocks:  " + Merge.Layer2BLocks[0]);


        //if 

        //if not null
        //SelectedItem.SetText(Merge.obj1.tag);

        //cam movement

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //if in range
            cam.transform.position = cam.transform.position + new Vector3(-camSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //if in range
            cam.transform.position = cam.transform.position + new Vector3(camSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //if in range
            cam.transform.position = cam.transform.position + new Vector3(0, 0, camSpeed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //if in range
            cam.transform.position = cam.transform.position + new Vector3(0, 0, -camSpeed);
        }


        //spawning

        count++;

        if (count >= target)    //spawning on conveyor
        {
            Instantiate(character, transform.position, Quaternion.identity);    //rotate
            count = 0;
        }


        //levels

        if (Merge.xp < 10)
        {
            //lvl1
        }

        else if (Merge.xp >= 10 && Merge.xp < 25)
        {
            Merge.LVL = 2;
            //enable blocks for level2

            blocksOfLand[0].SetActive(true);
            blocksOfLand[1].SetActive(true);
            blocksOfLand[2].SetActive(true);
            blocksOfLand[3].SetActive(true);
        }

        else if (Merge.xp >= 25 && Merge.xp < 50)
        {
            Merge.LVL = 3;

            //enable blocks for level3
        }

        else if (Merge.xp >= 50 &&  Merge.xp < 100)
        {
            Merge.LVL = 4;

            //enable blocks for level4
        }

        else if (Merge.xp >= 100 && Merge.xp < 200)
        {
            Merge.LVL = 5;

            //enable blocks for level4
        }


        if (Merge.highestChar == 1)
        {
            highestChar.SetText("highest: chicken");

            //display image
        }

        else if (Merge.highestChar == 2)
        {
            highestChar.SetText("highest: cow");    //example
        }

        else if (Merge.highestChar == 3)
        {
            highestChar.SetText("highest: dragon");    //example
        }

        else if (Merge.highestChar == 4)
        {
            highestChar.SetText("highest: mallard");    //example
        }


        else if (Merge.highestChar == 5)
        {
            highestChar.SetText("highest: sheep");    //example
        }

        else if (Merge.highestChar == 6)
        {
            highestChar.SetText("highest: pig");    //example
        }




    }

    public void Area1But()
    {
        cam.transform.position = new Vector3(1.42f, 5.49f, -5.4f);
    }

    public void Area2But()
    {
        cam.transform.position = new Vector3(21.42f, 5.49f, -5.4f);
    }

    public void SpawnNewButton()
    {
        //when pressed, spawn level 1 (Debut) in random currently empty space

        Instantiate(cards[0], this.transform);


    }
}
