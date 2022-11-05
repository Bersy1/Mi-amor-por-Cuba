using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public bool isInteracting;


    private void Update()
    {
        Interacting();
    }
    public void Interacting()
    {
        if (Input.GetButton("Interact"))
        {
            isInteracting = true;
        }
        else
        {
            isInteracting = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Interactable" && isInteracting == true)
        {
            Debug.Log("I've been interacted with!");
        }
    }
}
