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
    private bool _isHoldingItem;
    private bool _isPlacing;

    private void Start()
    {
        _mainCamera = Camera.main;
        _renderer = GetComponent<Renderer>();
        _heldItemPos = gameObject.transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        Interacting();
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
        }
    }
}
