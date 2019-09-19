using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //removes the game object after 6 seconds 
        Destroy(gameObject, 6.0f); 
        
    }
}
