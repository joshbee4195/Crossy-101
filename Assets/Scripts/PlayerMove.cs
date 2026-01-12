using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class PlayerMove : MonoBehaviour
{
    public float moveDist;
    public float moveDistFor;

    public Vector3 startPos;

    public int moveCooldown;
    public int maxMoveCooldown;

    public int curDir;

    public int lane = 0;

    public TextMeshProUGUI endScore;
    public TextMeshProUGUI coin;
    public int coinCount;

    public bool onLog = false;
    public GameObject curLog;
    public int curLogLen;
    public int LogLoc;
    public bool logLocSet;

    public Camera cam;
    public Vector3 camPos;

    public GameObject[] characters;

    public int[] xObs;
    public int[] zObs;

    public int xLoc;
    public int zLoc;

    public float sinkAmount;
    public float mudAmount;

    public TextMeshProUGUI crText;
    public GameObject shop;
    public GameObject charChange;

    public Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        camPos = cam.transform.position;

        coin.SetText("0");

        xLoc = 0;
        zLoc = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))   // || Input.GetKeyDown(KeyCode.LeftArrow))// || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Gen.start = true;

            if (crText != null)
            {
                crText.SetText("");
            }

          //  shop.SetActive(false);
          //  charChange.SetActive(false);
        }

        Scene scene = SceneManager.GetActiveScene();
        Gen.lastScene = scene;    //(SceneManager.GetActiveScene().buildIndex);

        Gen.previousSceneName = SceneManager.GetActiveScene().name;

        if (Gen.start == false)
        {

            if (crText != null)
            {
                crText.SetText("Crossy Road");
            }

           // shop.SetActive(true);
           // charChange.SetActive(true);
        }
        //rotation

        if (curDir == 1)    //left
        {
            // transform.Rotate(new Vector3(0, 90, 0));
        }

        coin.SetText(Gen.coins.ToString());


        if (Gen.cha == 1)
        {
            characters[0].SetActive(true);
            characters[1].SetActive(false);
        }

        if (Gen.cha == 2)
        {
            characters[1].SetActive(true);
            characters[0].SetActive(false);
        }
        //player movement

        //left right forward and back
        moveCooldown -= 1;


        //need to add collision code for obstacles
        //before moving, need to check whether movement would collide with object
        //use grid system?


        //if x,z is not 6,6
        //move
        //else don't move

        //if level = 2 - for obstacles?

        if (moveCooldown <= 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("left was pressed");

                if (lane > -4)
                {
                    xLoc -= 2;

                    //if (xLoc == 6 && zLoc == 6) // tree square      //change to if any of the grid co-ords - eg if xLoc == xObs[0] and zLoc = zObs[0] OR xLoc = 2nd and zLoc = 2nd

                    if (xLoc == xObs[0] && zLoc == zObs[0] || xLoc == xObs[1] && zLoc == zObs[1]) // tree square      //change to FOR loop
                    {
                        xLoc += 2;
                    }

                    else        //can move, no obstacles in way
                    {

                        transform.position = transform.position + new Vector3(-moveDist, 0, 0);

                        transform.eulerAngles = new Vector3(0, -90, 0);
                        lane -= 1;
                        moveCooldown = maxMoveCooldown;
                       // onLog = false;
                    }
                   
                }
            }

            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("right was pressed");

                if (lane < 4)
                {
                    xLoc += 2;

                    // if (xLoc == 6 && zLoc == 6) // tree square
                    if (xLoc == xObs[0] && zLoc == zObs[0] || xLoc == xObs[1] && zLoc == zObs[1]) // tree square      //change to FOR loop
                    {
                        xLoc -= 2;
                    }

                    else
                    {
                        transform.position = transform.position + new Vector3(moveDist, 0, 0);
                        transform.eulerAngles = new Vector3(0, 90, 0);
                        lane += 1;
                        moveCooldown = maxMoveCooldown;
                       // onLog = false;
                    }
                   // xLoc += 2;
                }
            }

            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                zLoc += 2;
                // if (xLoc == 6 && zLoc == 6) // tree square
                if (xLoc == xObs[0] && zLoc == zObs[0] || xLoc == xObs[1] && zLoc == zObs[1]) // tree square      //change to FOR loop
                {
                    zLoc -= 2;
                }

                else
                {
                    Debug.Log("up was pressed");
                    transform.position = transform.position + new Vector3(0, 0, moveDistFor);

                    transform.eulerAngles = new Vector3(0, 0, 0);
                    Gen.pureScore += 1;

                    //gen.furthestScore += 1;
                    // gen.score += 1;
                    moveCooldown = maxMoveCooldown;
                //    onLog = false;
                    // zLoc += 2;
                }
            }

            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                zLoc -= 2;
                //if (xLoc == 6 && zLoc == 6) // tree square
                if (xLoc == xObs[0] && zLoc == zObs[0] || xLoc == xObs[1] && zLoc == zObs[1]) // tree square      //change to FOR loop
                {
                    zLoc += 2;
                }

                else
                {
                    Debug.Log("down was pressed");
                    transform.position = transform.position + new Vector3(0, 0, -moveDistFor);

                    transform.eulerAngles = new Vector3(0, 180, 0);
                    Gen.pureScore -= 1;
                    moveCooldown = maxMoveCooldown;
                  //  onLog = false;
                    // zLoc -= 2;
                }
            }

            if (transform.position.z < cam.transform.position.z) //player too far behind
            {
                Die();
            }
        }


        if (transform.position.y < -1)  //under water
        {
            Die();
        }

        if (transform.position.x > 8)
        {
            //transform.position = new Vector3(8, transform.position.y, transform.position.z);
            Die();
        }

        if (transform.position.x < -8)
        {
            //transform.position = new Vector3(-8, transform.position.y, transform.position.z);
            Die();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))   // || Input.GetKeyDown(KeyCode.LeftArrow))// || Input.GetKeyDown(KeyCode.RightArrow))
        {
            onLog = false;      //get off log - not locked on to log - unless going right
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))// || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow))// || Input.GetKeyDown(KeyCode.RightArrow))
        {
            onLog = false;      // going right
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (LogLoc == 1)
                {
                    LogLoc = 2;
                }

                else if (LogLoc == 2)
                {
                    LogLoc = 3;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (LogLoc == 3)
                {
                    LogLoc = 2;
                }

                else if (LogLoc == 2)
                {
                    LogLoc = 1;
                }
            }

            // transform.position = curLog.transform.position + new Vector3(2, 1.08f, 0);      //move with log     //middle of log
        }

     /*   if (Input.GetKeyDown(KeyCode.LeftArrow))// || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow))// || Input.GetKeyDown(KeyCode.RightArrow))
        {
            onLog = false;      // going right
            LogLoc = 1;
            // transform.position = curLog.transform.position + new Vector3(2, 1.08f, 0);      //move with log     //middle of log
        }

        */

        if (onLog == true)      //if player touching log
        {
            if (logLocSet == false)
            {
               // LogLoc = 1;
             //   logLocSet = true;
            }

            //one space log
          //  if (Input.GetKeyDown(KeyCode.UpArrow))
            {
              //  transform.position = transform.position + new Vector3(0, 0, 2);      //move with log     //middle of log
              //  onLog = false;
            }

            if (curLogLen == 1)
            {
                transform.position = curLog.transform.position + new Vector3(0, 1.08f, 0);      //move with log     //middle of log

                //jump left or right means off?
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    onLog = false;
                }
            }

            if (curLogLen == 2)
            {
                if (logLocSet == false)
                {
                //    LogLoc = 1;
                 //   logLocSet = true;
                }

                if (LogLoc == 1)
                {
                    transform.position = curLog.transform.position + new Vector3(-1, 1.08f, 0);      //move with log     //middle of log
                }
                if (LogLoc == 2 || LogLoc == 3)
                {
                    transform.position = curLog.transform.position + new Vector3(1, 1.08f, 0);      //move with log     //middle of log

                    LogLoc = 2;
                }

                if ((Input.GetKeyDown(KeyCode.RightArrow)))
                {
                    if (LogLoc == 1)
                    {
                       // transform.position = curLog.transform.position + new Vector3(1, 1.08f, 0);      //move with log     //middle of log
                       // LogLoc = 2;
                    }

                    else
                    {
                       // onLog = false;
                    }
                }

                if ((Input.GetKeyDown(KeyCode.LeftArrow)))
                {
                    if (LogLoc == 2)
                    {
                        //transform.position = curLog.transform.position + new Vector3(-1, 1.08f, 0);      //move with log     //middle of log
                       // LogLoc = 1;
                    }

                    else
                    {
                        //onLog = false;
                    }
                }

                //jump left or right means off?
            }

            if (curLogLen == 3)
            {
              //  transform.position = curLog.transform.position + new Vector3(-0, 1.08f, 0);      //move with log     //middle of log
              //  transform.position = curLog.transform.position + new Vector3(-2, 1.08f, 0);      //move with log     //middle of log

                if (LogLoc == 1)
                {
                    transform.position = curLog.transform.position + new Vector3(-2f, 1.08f, 0);      //move with log     //middle of log
                }
                if (LogLoc == 2)
                {
                    transform.position = curLog.transform.position + new Vector3(0, 1.08f, 0);      //move with log     //middle of log
                }

                if (LogLoc == 3)
                {
                    transform.position = curLog.transform.position + new Vector3(2f, 1.08f, 0);      //move with log     //middle of log
                }

                //jump left or right means off?
            }
            // transform.position = curLog.transform.position + new Vector3(0, 1.36f, 0);      //move with log     //middle of log


            //2 space log
            //transform.position = curLog.transform.position + new Vector3(-0.5f, 1.36f, 0);      //move with log     //middle of log


            //3 space log
            // transform.position = curLog.transform.position + new Vector3(-1f, 1.36f, 0);      //move with log     //middle of log

            //need to be able to jump off log
            //need to update lane count value

            //right side

            //xLoc = lane*2;  //works roughly but not exact


            if (transform.position.x > 7.8 && transform.position.x < 8.2)
            {
                lane = 4;
            }

            if (transform.position.x > 5.8 && transform.position.x < 6.2)
            {
                lane = 3;
            }

            if (transform.position.x > 3.8 && transform.position.x < 4.2)
            {
                lane = 2;
            }

            if (transform.position.x > 1.8 && transform.position.x < 2.2)
            {
                lane = 1;
            }

            //middle

            if (transform.position.x > -0.2 && transform.position.x < 0.2)
            {
                lane = 0;
            }

            //left side

            if (transform.position.x > -8.2 && transform.position.x < -7.8)
            {
                lane = -4;
            }

            if (transform.position.x > -6.2 && transform.position.x < -5.8)
            {
                lane = -3;
            }

            if (transform.position.x > -4.2 && transform.position.x < -3.8)
            {
                lane = -2;
            }

            if (transform.position.x > -2.2 && transform.position.x < -1.8)
            {
                lane = -1;
            }
        }

        if (onLog == false)
        {
            logLocSet = false;

            if (transform.position.x <= 1 && transform.position.x > -1)
            {
                //lane = 0;
                //transform.position.x = 0;

                transform.position = new Vector3(0, transform.position.y, transform.position.z);
                xLoc = 0;
            }

            if (transform.position.x <= 3 && transform.position.x > 1)
            {
                //lane = 1;
                //transform.position.x = 0;

                transform.position = new Vector3(2, transform.position.y, transform.position.z);
                xLoc = 2;
            }

            if (transform.position.x <= 5 && transform.position.x > 3)
            {
                //lane = 2;
                transform.position = new Vector3(4, transform.position.y, transform.position.z);

                xLoc = 4;
            }

            if (transform.position.x <= 7 && transform.position.x > 5)
            {
                //lane = 3;

                transform.position = new Vector3(6, transform.position.y, transform.position.z);

                xLoc = 6;
            }

            if (transform.position.x <= 9 && transform.position.x > 7)
            {
                //lane = 4;
                //transform.position.x = 0;

                transform.position = new Vector3(8, transform.position.y, transform.position.z);

                xLoc = 8;
            }

            if (transform.position.x <= -1 && transform.position.x > -3)
            {
                //lane = -1;
                //transform.position.x = 0;

                transform.position = new Vector3(-2, transform.position.y, transform.position.z);

                xLoc = -2;
            }

            if (transform.position.x <= -3 && transform.position.x > -5)
            {
                //lane = -2;
                transform.position = new Vector3(-4, transform.position.y, transform.position.z);

                xLoc = -4;
            }

            if (transform.position.x <= -5 && transform.position.x > -7)
            {
                //lane = -3;

                transform.position = new Vector3(-6, transform.position.y, transform.position.z);

                xLoc = -6;
            }

            if (transform.position.x <= -7 && transform.position.x > -9)
            {
                //lane = -4;

                transform.position = new Vector3(-8, transform.position.y, transform.position.z);

                xLoc = -8;
            }
        }
    }

    public void Die()
    {

        if (Gen.score > Gen.highScore)
        {
            Gen.highScore = Gen.score;  //set new high score

            //text below shows new top
            endScore.SetText("new top");
        }

        else
        {
            //text below shows current best
            endScore.SetText("top " + Gen.highScore);
        }

        lane = 0;


        //change to replay button

        transform.position = startPos;
        Gen.score = 0;
        Gen.pureScore = 0;

        cam.transform.position = camPos;

        xLoc = 0;
        zLoc = 0;

        onLog = false;
        LogLoc = 1;
        Gen.start = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "vehicle")
        {
            //die
            //change to death screen in future
            //transform.position = new Vector3(0, 2.43f, 0);
            //transform.position = startPos;

            Die();
        }

        if (other.gameObject.tag == "train")
        {
            Die();
        }

        if (other.gameObject.tag == "coin")
        {
            Gen.coins += 1;
            Destroy(other.gameObject);
        }


        if (other.gameObject.tag == "water")    //and no log?
        {
            //die

            //splash effect and sound

            //change to death screen in future
            // transform.position = new Vector3(0, 2.43f, 0);
            //transform.position = startPos;
            //

            if (onLog == false)
            {
               // Die();
            }
        }

        if (other.gameObject.tag == "log")    //and no log?
        {
            onLog = true;
            curLog = other.gameObject;

            if (other.gameObject.name == "LogMed(Clone)" || other.gameObject.name == "LogMed 1(Clone)")
            {
                curLogLen = 2;
            }

            if (other.gameObject.name == "LogBig(Clone)" || other.gameObject.name == "LogBig 1(Clone)")
            {
                curLogLen = 3;
            }

            if (other.gameObject.name == "LogSmall(Clone)" || other.gameObject.name == "LogSmall 1(Clone)")
            {
                curLogLen = 1;
            }
            //curLogLen = curLog.identifer;
        }

        if (other.gameObject.tag == "levelEnd")    //
        {
            Gen.start = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        //staying on log - eg moving along bigger log

        if (other.gameObject.tag == "log")    //and no log?
        {
            onLog = true;
            curLog = other.gameObject;
        }

        if (other.gameObject.tag == "water")    
        {
            if (onLog == false)
            {
                transform.position = transform.position += new Vector3(0, -sinkAmount, 0);
            }
        }

        if (other.gameObject.tag == "mud")
        {
            
            transform.position = transform.position += new Vector3(0, -mudAmount, 0);


            if (transform.position.y < -0.5)
            {
                Die();
            }

        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "log")    //and no log?
        {
            onLog = false;
            curLog = null;//other.gameObject;
        }

        if (other.gameObject.tag == "mud")
        {
            transform.position = new Vector3(transform.position.x, 1.2f, transform.position.z);
        }
    }
}
