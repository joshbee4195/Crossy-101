using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChange : MonoBehaviour
{

    public GameObject[] characters;
    public GameObject[] charactersAll;  //every available character


    public GameObject cam;

    public int count = 1;   //which character on
    public int countOnSelect; //which character was selected

    public GameObject left;
    public GameObject right;

    public TextMeshProUGUI select;
    public Button selected;
    public Image selecteds;
    // Start is called before the first frame update
    void Start()
    {
        characters = new GameObject[5]; //total characters
    }

    // Update is called once per frame
    void Update()
    {
        if (Chars.whale == true)
        {
            //add whale to character list
            characters[0] = charactersAll[0];
        }



        //for loop

        //for i in characters
        //if not null
        //spawn /set active Char



       /* String[] numbers = new String[5];
        numbers[0] = "hello1";
        numbers[1] = "hello2";
        numbers[2] = "hello3";
        numbers[3] = "hello4";
        numbers[4] = "hello5";

        */

        if (count == 1)
        {
            //disable button
            left.SetActive(false);
        }

        else
        {
            left.SetActive(true);
        }

        if (count == charactersAll.Length)
        {
            //disable button
            right.SetActive(false);
        }

        else
        {
            right.SetActive(true);
        }
    }


    public void LeftArrow()
    {

        if (count > 1)
        {
            cam.transform.position += new Vector3(-10, 0, 0);
            count--;
        }

        select.SetText("select");
        //countOnSelect = count;

        selecteds.color = Color.white;
        selected.enabled = true;
    }

    public void RightArrow()
    {
        if (count < charactersAll.Length)
        {
            cam.transform.position += new Vector3(10, 0, 0);
            count++;
        }

        select.SetText("select");
        //countOnSelect = count;

        selecteds.color = Color.white;
        selected.enabled = true;
    }

    public void CharacterSelect()
    {
        Gen.cha = count;
        select.SetText("Selected");
        countOnSelect = count;

        selecteds.color = Color.gray;
        selected.enabled = false;
    }
}
