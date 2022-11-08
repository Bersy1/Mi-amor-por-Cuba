using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    private static Gamemanager _instance;
    public GameObject[] interactableStuff;
    private void Awake()
    {
        _instance = this;
    }




    public void InteractableGlow()
    {
        interactableStuff = GameObject.FindGameObjectsWithTag("Interactable");

        foreach (GameObject FindWithTags in interactableStuff)
        {
        }
    }


}
