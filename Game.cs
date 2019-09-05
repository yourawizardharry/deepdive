using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour

{
	public static bool gameRunning = true;

	public static void stopGame() 
	{
		gameRunning = false;
	}

	public static void startGame()
	{
		gameRunning = true;
	}

}
