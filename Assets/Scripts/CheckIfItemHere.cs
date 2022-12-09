using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfItemHere : MonoBehaviour
{
    public PlayerGrab _playerGrab;
    public Gamemanager _gm;
    private bool _hasAdded = false;




    private void Start()
    {
        _playerGrab = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGrab>();
        _gm = GameObject.FindGameObjectWithTag("Gamemanager").GetComponent<Gamemanager>();
    }
    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "InteractableGood" && _playerGrab._isHoldingItem == false && _hasAdded == false)
        {
            int temp;
            temp = _gm._currentScore;
            if(temp == _gm._currentScore)
            {
                _gm._currentScore++;
                _hasAdded = true;
            }
        }
        if(other.tag == "InteractableBad" && _playerGrab._isHoldingItem == false && _hasAdded == false)
        {
            int temp;
            temp = _gm._currentScore;
            if (temp == _gm._currentScore)
            {
                _gm._currentScore--;
                _hasAdded = true;
            }
        }
    }
}
