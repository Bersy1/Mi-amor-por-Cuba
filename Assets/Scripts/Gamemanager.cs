using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager _instance;
    public GameObject[] interactableStuff;
    public static bool _gameIsPaused;
    private Slider _progressSlider;
    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _progressSlider = FindObjectOfType<Slider>();
    }

    private void Update()
    {
        PausedGameBehaviour();
        NextLevelPlease();
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

    public void NextLevelPlease()
    {
        if(_progressSlider.value == 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}