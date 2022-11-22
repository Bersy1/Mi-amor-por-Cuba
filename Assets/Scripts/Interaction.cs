using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public bool _isInteracting;
    private Camera _mainCamera;
    private Renderer _renderer;
    private Ray _ray;
    private RaycastHit _hit;
    private GameObject _heldItemPos;
    public bool _isHoldingItem;
    public bool _isPlacing;
    public GameObject _heldObject;
    public bool _tryingToThrow;

    private void Start()
    {
        _mainCamera = Camera.main;
        _renderer = GetComponent<Renderer>();
        _heldItemPos = gameObject.transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        Interacting();
        GetHoldingObject();
    }
    private void FixedUpdate()
    {
        ThrowingHeldItem();

    }
    public void Interacting()
    {
        if (Input.GetMouseButton(0))
        {
            _ray  = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(_ray, out _hit, 1000f))
            {
                if (_hit.transform.gameObject.tag == "Interactable" && _isHoldingItem == false)
                {
                    _isInteracting = true;
                }

                if(_hit.transform.gameObject.tag == "BoxPlace" &&_isHoldingItem == true)
                {
                    _isPlacing = true;
                }
            }
        }
        else
        {
            _isInteracting = false;
            _isPlacing = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Interactable" && _isInteracting == true)
        {
            other.gameObject.transform.parent = gameObject.transform;
            other.gameObject.transform.position = _heldItemPos.transform.position;

            _isHoldingItem = true;


            Debug.Log("I've been interacted with");
        }

        if(other.tag == "BoxPlace" && _isPlacing == true)
        {
            gameObject.transform.Find("InteractBox").transform.position = other.gameObject.transform.position;
            gameObject.transform.Find("InteractBox").transform.parent = null;
            _isHoldingItem = false;
        }
    }
    private void ThrowingHeldItem()
    {
        if (Input.GetMouseButton(1))
        {
            _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit, 1000f))
            {
                //Get held item rigidbody
                Rigidbody tempRB = _heldObject.GetComponent<Rigidbody>();   
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
                    tempRB.AddForce(_ray.direction, ForceMode.Impulse);
                }
                //if velocity low enough...
                if (tempVel.magnitude == 0f)
                {
                    //Add previously held item's constraints
                    tempRB.constraints = RigidbodyConstraints.FreezeAll;
                }

                _isHoldingItem = false;
                _tryingToThrow = false;
            }
        }
    }
    private void GetHoldingObject()
    {
        if (_isHoldingItem)
        {
            _heldObject = gameObject.transform.Find("InteractBox").gameObject;
        }else if(_isHoldingItem == false)
        {
            _heldObject = null;
        }
    }
}
