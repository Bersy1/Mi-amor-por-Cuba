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
    public GameObject _lost;
    public GameObject _nextLevel1star;
    public GameObject _nextLevel2star;
    public GameObject _nextLevel3star;
    public GameObject _nextLevelPerfect;
    public int _currentScore;
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
        if(_progressSlider.value == 4)
        {
            Invoke("NextLevelPlease", 2f);
        }
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
            if (_currentScore == 4)
            {
                _nextLevelPerfect.SetActive(true);
            }
            if (_currentScore == 3)
            {
                _nextLevel3star.SetActive(true);
            }
            if (_currentScore == 2)
            {
                _nextLevel2star.SetActive(true);
            }
            if (_currentScore == 1)
            {
                _nextLevel1star.SetActive(true);
            }
            if (_currentScore <= 0)
            {
                _lost.SetActive(true);
            }
        }


    }

}