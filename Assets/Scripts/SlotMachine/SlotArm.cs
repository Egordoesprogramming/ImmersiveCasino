using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotArm : MonoBehaviour
{
    HingeJoint joint;
    
    void Start()
    {
        joint = GetComponent<HingeJoint>();
    }
    
    public bool IsActive()
    {
        //Debug.Log("transform.localRotation.x " + transform.localRotation.x);
        return joint.angle < (joint.limits.min * 0.6);
    }

    public void DebugLog()
    {
        Debug.Log("activeAngle: " + (joint.limits.min * 0.8f));
        Debug.Log("transform.rotation.eulerAngles.x: " + transform.rotation.eulerAngles.x);
        Debug.Log("transform.localEulerAngles.x: " + transform.localEulerAngles.x);
        
    }
}
