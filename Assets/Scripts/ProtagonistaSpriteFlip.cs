using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagonistaSpriteFlip : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.eulerAngles = new Vector3(0, -180, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
