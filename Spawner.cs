using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //setting up array of game objects 
    public GameObject[] rocks;
    // Start is called before the first frame update
    void Start()
    {
        //will call spawn 2 seconds when started then re call it every 2 seonds 
        InvokeRepeating("spawn", 2, 2); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawn()
    {
        if (GameObject.Find("Game_Manager").GetComponent<Game>().isRunning())
        {
            //getting the size of the array to randomly select an object 

            int percentage = Random.Range(0, 100);
            int index = 0;
            if (percentage < 40)
                index = 0;
            else if (percentage < 80)
                index = 1;
            else if (percentage < 85)
                index = 2;
            else if (percentage < 90)
                index = 3;
            else if (percentage < 95)
                index = 4;
			else if (percentage < 100)
                index = 5;
            //randomly decides along the x axis where the object will appear 
            float location = Random.Range(0, 12);
            //its between like 5 and -6 so have to adjust value
            location = location - 5;
            //gettting the camera location so i know where to spawn the objects 
            float y = GameObject.FindGameObjectWithTag("MainCamera").transform.position.y - 10;
            //initatest the objects 
            Instantiate(rocks[index], new Vector3(location, y, 0), new Quaternion(0, 0, 0, 1));
        }

    }
}
