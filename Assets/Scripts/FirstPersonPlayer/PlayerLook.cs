using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    float sensitivity = 128;
    float pitch = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        var dist = sensitivity * Time.deltaTime;
        var mx = Input.GetAxis("Mouse X") * dist;
        var my = Input.GetAxis("Mouse Y") * dist;
        pitch = Mathf.Clamp(pitch - my, -90f, 90f);
        transform.localRotation = Quaternion.Euler(pitch, 0, 0);
        /* var pitch = Mathf.Clamp(transform.localRotation.x
            - Input.GetAxis("Mouse Y") * dist, -90, 90);
        transform.localRotation = Quaternion.Euler(pitch, 0, 0); */
        transform.parent.Rotate(Vector3.up * mx);
    }
}
