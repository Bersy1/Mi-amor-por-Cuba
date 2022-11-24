using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGamePauseButton : MonoBehaviour
{
    public void Pausing()
    {
        Gamemanager._gameIsPaused = true;
    }
    public void UnPausing()
    {
        Gamemanager._gameIsPaused = false;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Gamemanager._gameIsPaused = false;
    }
}
