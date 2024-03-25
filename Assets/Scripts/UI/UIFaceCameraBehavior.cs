using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFaceCameraBehavior : MonoBehaviour
{
    private void Update()
    {
        Transform cam = Camera.main.transform;
        transform.LookAt(transform.position + cam.forward);
    }
}
