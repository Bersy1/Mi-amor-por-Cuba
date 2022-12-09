using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerGrab : MonoBehaviour
{
    [Header("Interacting stuff")]
    private bool _isGrabbing;
    [HideInInspector] public bool _isHoldingItem;
    private bool _isPlacing;

    [Header("Where held item goes")]
    private GameObject _heldItemPos;

    [Header("Raycast stuff")]
    public Ray _ray;
    public Camera _mainCamera;
    private RaycastHit _hit;
    private Renderer _renderer;

    [Header("Progress slider stuff")]
    private Slider _progressSlider;
    private bool _hasAdded;


    private void Start()
    {
        //Raycast stuff
        _mainCamera = Camera.main;
        _renderer = GetComponent<Renderer>();
        _heldItemPos = gameObject.transform.GetChild(0).gameObject;


        _progressSlider = FindObjectOfType<Slider>();
    }

    private void Update()
    {
        //Calling Grab method
        Grabbing();
    }

    public void Grabbing()
    {
        //Input check
        if (Input.GetMouseButton(0))
        {
            //Cast ray
            _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            //If ray hits
            if (Physics.Raycast(_ray, out _hit, 1000f))
            {

                //if it hits an object with "boxplace" tag and player is holding an item, place the item.
                if (_hit.transform.gameObject.tag == "BoxPlace" && _isHoldingItem == true)
                {
                    _isPlacing = true;
                }

                //if it hits an object with "interactable" tag and player is holding an item, grab the item.
                if ((_hit.transform.gameObject.tag == "InteractableGood" || _hit.transform.gameObject.tag == "InteractableBad") && _isHoldingItem == false)
                {
                    _isGrabbing = true;
                }
            }
        }
        //if no input, player isn't placing nor grabbing
        else
        {
            _isGrabbing = false;
            _isPlacing = false;
        }
    }

    //Check if palyer is close enough to an object
    private void OnTriggerStay(Collider other)
    {
        //If player is close to a gameobject with "iteractable" tag and is grabbing, then grab the item and player is holding
        if ((other.tag == "InteractableGood" || other.tag == "InteractableBad") && _isGrabbing == true)
        {
            other.gameObject.transform.parent = gameObject.transform;
            other.gameObject.transform.position = _heldItemPos.transform.position;

            _isHoldingItem = true;
            _hasAdded = false;


            Debug.Log("I've been interacted with");
        }

        //If player is close to gameobject with "boxplace" tag and is placing, then place the object and player is no longer holding item
        if (other.tag == "BoxPlace" && _isPlacing == true)
        {
            try
            {
                gameObject.transform.Find("InteractBox").transform.position = other.gameObject.transform.position;
                gameObject.transform.Find("InteractBox").transform.parent = null;
            }
            catch (Exception)
            {

            }
            if(_hasAdded == false)
            {
                _progressSlider.value++;
                _hasAdded = true;

            }
            _isHoldingItem = false;
        }
    }
}