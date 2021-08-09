using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    float grabDistance = 5;
    float holdDistance = 0.4f;
    float dragSpeed = 200;

    Rigidbody heldRigidbody;

    Vector3 prevMousePosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Grab();
        else if (Input.GetMouseButton(0))
            Hold();
        else if (Input.GetMouseButtonUp(0))
            Drop();
        
        holdDistance += Input.mouseScrollDelta.y * 0.1f;
    }

    void Drop()
    {
        heldRigidbody = null;
    }

    void Grab()
    {
        var ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, grabDistance))
        {
            if (hit.collider.CompareTag("grabbable"))
            {
                holdDistance = hit.distance * 0.6f;
                heldRigidbody = hit.collider.gameObject.GetComponent<Rigidbody>();
                // onDragDelegate = DefaultDrag;
            }
        }
    }

    void Hold()
    {
        // onDragDelegate.Invoke();
        if (heldRigidbody != null)
            DefaultDrag();
    }

    //void DoNothing(){}

    void DefaultDrag()
    {
        var to = transform.position + transform.forward * holdDistance;
        var from = heldRigidbody.transform.position;

        heldRigidbody.velocity = (to - from) * dragSpeed * Time.deltaTime;
    }
}
