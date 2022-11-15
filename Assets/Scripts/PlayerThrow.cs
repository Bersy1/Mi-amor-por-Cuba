using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//IMPORTANT!!
//THIS SCRIPT WILL NOT WORK WITHOUT PLAYERGRAB SCRIPT
//IMPORTANT!!
public class PlayerThrow : MonoBehaviour
{
    [Header("Interacting stuff")]
    private bool _tryingToThrow;

    [Header("Rigidbodies")]
    private Rigidbody tempRB;

    [Header("Vectors")]
    private Vector3 tempVel;

    [Header("Gameobjects")]
    private GameObject _heldItemPos;
    private GameObject _heldObject;

    [Header("Raycast stuff")]
    private Camera _mainCamera;
    private RaycastHit _hit;
    private Renderer _renderer;

    [Header("Dependencies")]
    private PlayerGrab _playerGrabScript;


    private void Awake()
    {
        _playerGrabScript = gameObject.GetComponent<PlayerGrab>();
    }

    private void Update()
    {
        GetHoldingObject();
        Throwing();
    }
    public void Throwing()
    {
        if (Input.GetMouseButton(1))
        {
            _playerGrabScript._ray = _playerGrabScript._mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_playerGrabScript._ray, out _hit, 1000f) && _playerGrabScript._isHoldingItem == true)
            {
                //Get held item rigidbody
                tempRB = _heldObject.GetComponent<Rigidbody>();
                //Get held item velocity
                Vector3 tempVel = _heldObject.GetComponent<Rigidbody>().velocity;

                _tryingToThrow = true;

                if (_tryingToThrow == true)
                {
                    //Remove held item from child
                    gameObject.transform.Find("InteractBox").transform.parent = null;
                    //Remove held item constraints
                    tempRB.constraints = RigidbodyConstraints.None;

                    //Add force to held item
                    tempRB.AddForce((_playerGrabScript._ray.direction * 10), ForceMode.Impulse);
                }
                Invoke("FreezeThrownObject", 3f);

                _playerGrabScript._isHoldingItem = false;
                _tryingToThrow = false;
            }
        }
    }

    private void FreezeThrownObject()
    {
        //if velocity low enough...
        if (tempVel.magnitude == 0f)
        {
            //Add previously held item's constraints
            tempRB.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    //See if player is holding an object
    private void GetHoldingObject()
    {
        //if they're holding an object, save it in a variable.
        if (_playerGrabScript._isHoldingItem)
        {
            _heldObject = gameObject.transform.Find("InteractBox").gameObject;
        }
        //if they're not holding an object, clear the variable.
        else if (!_playerGrabScript._isHoldingItem)
        {
            _heldObject = null;
        }
    }

}
