using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{

    public GameControl control;

    // Start is called before the first frame update
    void Start()
    {
        control = FindObjectOfType<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //set next to spawn

            Practice.SectionsSpawned += 1;

            Debug.Log("Player");

            //   GameControl p1 = GetComponent<GameControl>();

            // control.SpawnLanes();
            control.LaneSpawns();

            Destroy(gameObject);

            
        }
    }
}
