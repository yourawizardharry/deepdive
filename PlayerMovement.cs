using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerMovementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerMovementSpeed = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vect = transform.position;
        vect.y -= playerMovementSpeed;
        transform.position = vect;
        //GameObject.FindWithTag("MainCamera").transform.position = new Vector3 (GameObject.FindWithTag("MainCamera").transform.position.x, transform.position.y, -10);
        Camera.main.transform.position = new Vector3(GameObject.FindWithTag("MainCamera").transform.position.x, transform.position.y, -10);
    }
}
