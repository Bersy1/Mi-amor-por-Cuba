using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager _instance;
    public GameObject[] interactableStuff;
    public static bool _gameIsPaused;
    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        PausedGameBehaviour();
    }

    public void PausedGameBehaviour()
    {
        if (_gameIsPaused)
        {
            Time.timeScale = 0f;
        } else if (!_gameIsPaused)
        {
            Time.timeScale = 1f;
        }
    }

    public void InteractableGlow()
    {
        interactableStuff = GameObject.FindGameObjectsWithTag("Interactable");

        foreach (GameObject FindWithTags in interactableStuff)
        {
        }
    }
}