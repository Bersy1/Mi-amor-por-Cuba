using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedUIBehaviour : MonoBehaviour
{
    private GameObject _pausedMenu;
    private void Awake()
    {
        _pausedMenu = gameObject.transform.Find("--PausedMenu--").gameObject;
    }
    private void Update()
    {
        PausedUI();
    }
    public void PausedUI()
    {
        if(Gamemanager._gameIsPaused)
        {
            _pausedMenu.SetActive(true);
        }else if (!Gamemanager._gameIsPaused)
        {
            _pausedMenu.SetActive(false);
        }
    }
}
