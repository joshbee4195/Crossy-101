using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBreak : MonoBehaviour
{
    public int stepcount;
    public Material startMat;
    public Material snow1;
    public Material snow2;
    public Material snow3;

    public Renderer rend;

    public bool touching;

    public int thresh1;
    public int thresh2;
    public int thresh3;


    public GameObject player;

    public float fallAmount;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Gen.start == false)
        {
            stepcount = 0;
            rend.material = startMat;
        }

        if (touching == true)
        {
            stepcount++;
        }

        if (stepcount == thresh1)
        {
            //change mat
            rend.material = snow1;
        }

        if (stepcount == thresh2)
        {
            //change mat
            rend.material = snow2;
        }

        if (stepcount >= thresh3)
        {
            //change mat
            rend.material = snow3;

            //break/ fall away

            //player fall

            player.transform.position = player.transform.position -= new Vector3(0, fallAmount, 0);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            touching = true;
            player = other.gameObject;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            touching = false;
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            touching = true;
        }
    }
}
