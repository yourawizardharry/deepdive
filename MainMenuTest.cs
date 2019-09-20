using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NUnit.Framework;

public class MainMenuTest : MonoBehaviour
{
    [Test]
    public void PlayGame_Test()
    {
        
    }

    [Test]
    public void QuitGame_Test()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
