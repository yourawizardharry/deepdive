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
        //will call spawn 4 seconds when started then re call it every 3 seonds 
        InvokeRepeating("spawn", 4, 3); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawn()
    {
        //getting the size of the array to randomly select an object 
        int index = Random.Range(0, rocks.Length); 
        //randomly decides along the x axis where the object will appear 
        float location = Random.Range(0, 12);
        //its between like 5 and -6 so have to adjust value
        location = location -5;
        //gettting the camera location so i know where to spawn the objects 
        float y = GameObject.FindGameObjectWithTag("MainCamera").transform.position.y - 10;
        //initatest the objects 
        Instantiate(rocks[index], new Vector3(location, y, 0), new Quaternion(0, 0, 0, 1));

    }
}
