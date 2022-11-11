using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablingObjects : MonoBehaviour
{
    void Update()
    {
        void OnBecameVisible()
        {
            Debug.Log("Visible");
        }

        void OnBecameInvisible()
        {
            Debug.Log("Invisible");
        }
    }
}
