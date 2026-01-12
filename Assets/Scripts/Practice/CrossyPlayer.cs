using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class CrossyPlayer : MonoBehaviour
{
    public float moveDist;
    public float moveDistFor;

    public Vector3 startPos;

    public int moveCooldown;
    public int maxMoveCooldown;

    public int curDir;

    public int lane = 0;

    public TextMeshProUGUI endScore;
  
   

  

    public Camera cam;
    public Vector3 camPos;

    public GameObject[] characters;

    public int[] xObs;
    public int[] zObs;

    public int xLoc;
    public int zLoc;



    public TextMeshProUGUI crText;
   

    public Scene scene;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        camPos = cam.transform.position;

      

        xLoc = 0;
        zLoc = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Practice.isPaused)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))   // || Input.GetKeyDown(KeyCode.LeftArrow))// || Input.GetKeyDown(KeyCode.RightArrow))
            {
                Gen.start = true;

                if (crText != null)
                {
                    crText.SetText("");
                }


            }

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                Gen.start = true;

                if (crText != null)
                {
                    crText.SetText("");
                }
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

            }
          
          
            //player movement
            //left right forward and back

            moveCooldown -= 1;



            if (moveCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
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

                            //  MovePlayer();

                            transform.eulerAngles = new Vector3(0, -90, 0);
                            lane -= 1;
                            moveCooldown = maxMoveCooldown;
                            // onLog = false;
                        }

                    }
                }

                else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
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

                else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
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

                else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
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
                       
                    }
                }
            }



            // if (onLog == false)
            {


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
    }


    public void MovePlayer()
    {

        int repeats = 2;

        for (int i = 0; i < repeats; i++)
        {
           // yield return new WaitForSeconds(0.01f);

            transform.position = transform.position + new Vector3(-moveDist / repeats, 0, 0);
        }
    }

    public IEnumerator MovingPlayer()
    {

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.01f);

            transform.position = transform.position + new Vector3(-moveDist/10, 0, 0);
        }


        // return;
    }


    public void Die()
    {

        if (Gen.score > Gen.highScore)
        {
            Gen.highScore = Gen.score;  //set new high score

            //text below shows new top
         //   endScore.SetText("new top");
        }

        else
        {
            //text below shows current best
         //   endScore.SetText("top " + Gen.highScore);
        }

        lane = 0;


        //change to replay button

       
        Gen.score = 0;
        Gen.pureScore = 0;
        
        xLoc = 0;
        zLoc = 0;

      //  onLog = false;
      //  LogLoc = 1;
        Gen.start = false;


        //not working properly

        cam.transform.position = camPos;
        transform.position = startPos;

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


        if (other.gameObject.tag == "police")
        {
           
            Die();
        }

        if (other.gameObject.tag == "train")
        {
            Die();
        }
    }
}
