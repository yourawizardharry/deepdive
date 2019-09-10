using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour

{
	public static bool gameRunning = true;
	public Camera cam;
	public GameObject Player, BackgroundImageFirst,BackgroundImageSecond;
	public PlayerMovement PlayerInstanceMovementScript;

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
		Parallax ParallaxScript = (Parallax) Player.GetComponent(typeof(Parallax));
		ParallaxScript.Construct(BackgroundImageFirst, BackgroundImageSecond, cam);

		startGame();

	}

	public void stopGame() 
	{
		gameRunning = false;
		//PlayerMovement PlayerInstanceMovementScript = (PlayerMovement) Player.GetComponent(typeof(PlayerMovement));
		PlayerInstanceMovementScript.stopMovement();
	}

	public void startGame()
	{
		gameRunning = true;
		//PlayerMovement PlayerInstanceMovementScript = (PlayerMovement) Player.GetComponent(typeof(PlayerMovement));
		PlayerInstanceMovementScript.startMovement();
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