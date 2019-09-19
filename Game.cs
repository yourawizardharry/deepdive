﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour

{
	public bool gameRunning = true;
	public Camera cam;
	public GameObject Player, BackgroundImageFirst,BackgroundImageSecond;
	public PlayerMovement PlayerInstanceMovementScript;
    public PlayerControls PlayerControlsScript;
    public GameObject collisionobj1, collisionobj2;
    public Parallax ParallaxScript;
    private Vector3 startPosPlayer, backgroundPos1, backgroundPos2;
    

	void Start() 
	{
		//Instantiate Camera & player
		cam = Instantiate(cam);
		Player = Instantiate(Player);
		Player.AddComponent<PlayerMovement>();
		PlayerInstanceMovementScript = (PlayerMovement) Player.GetComponent(typeof(PlayerMovement));
		PlayerInstanceMovementScript.addCamera(cam);

		//Instantiate backgounds
		BackgroundImageFirst = Instantiate(BackgroundImageFirst);
		BackgroundImageSecond = Instantiate(BackgroundImageSecond);

		//add parallax
		Player.AddComponent<Parallax>();
		ParallaxScript = (Parallax) Player.GetComponent(typeof(Parallax));
		ParallaxScript.Construct(BackgroundImageFirst, BackgroundImageSecond, cam);

        //add camera component to movement controls
        PlayerControlsScript = (PlayerControls)Player.GetComponent(typeof(PlayerControls));
        PlayerControlsScript.addCamera(cam);

        //get start positions
        startPosPlayer = Player.transform.position;
        backgroundPos1 = BackgroundImageFirst.transform.position;
        backgroundPos2 = BackgroundImageSecond.transform.position;

        //Start game
        startGame();

	}

    public void restartGame()
    {
        Player.transform.position = startPosPlayer;
        BackgroundImageFirst.transform.position = backgroundPos1;
        BackgroundImageSecond.transform.position = backgroundPos2;
        PlayerControlsScript.isRunning(true);
        PlayerInstanceMovementScript.isRunning(true);
        ParallaxScript.isRunning(true);
        startGame();
    }

	public void stopGame() 
	{
		gameRunning = false;
		PlayerInstanceMovementScript.stopMovement();
        PlayerControlsScript.isRunning(false);
        PlayerInstanceMovementScript.isRunning(false);
        ParallaxScript.isRunning(false);
    }

	public void startGame()
	{
		gameRunning = true;
		PlayerInstanceMovementScript.startMovement();
	}


    public bool isRunning()
    {
        return gameRunning;
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour

{
	public static bool gameRunning = true;
	public Camera cam;
	public GameObject Player, BackgroundImageFirst,BackgroundImageSecond;

	void Start() 
	{
		//Initiate Camera
		var CameraInstance = Instantiate(cam);
		//Add script for camera to follow player
		Player.AddComponent<PlayerMovement>();
		//Initiate Player
		var PlayerInstance = Instantiate(Player);
		//Get the players movement script
		PlayerMovement PlayerInstanceMovementScript = (PlayerMovement) PlayerInstance.GetComponent(typeof(PlayerMovement));
		//assign camera to movement script
		PlayerInstanceMovementScript.addCamera(CameraInstance);
	}

	public void stopGame() 
	{
		gameRunning = false;
	}

	public void startGame()
	{
		gameRunning = true;
	}

}
*/