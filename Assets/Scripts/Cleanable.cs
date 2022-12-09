using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanable : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButton("Interact") && other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
