using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    public Transform target;
    public GameObject go;
    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(target.position);
        if (viewPos.x > 1F)
        {
            print("target is on the right side!");
            go.SetActive(true);
        }
        else
        {
            print("target is on the left side!");
            go.SetActive(false);
        }
    }
}
