using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Application.LoadLevel("Scenes/level1");
    }
    public void QuitGame()
    {
        Application.LoadLevel("Scenes/startGame");
    }
}
