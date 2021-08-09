using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    float radians = 0;
    
    private void OnMouseDown()
    {
        radians = GetAngle() - Mathf.Atan2(
            transform.right.y, transform.right.x);
    }

    private void OnMouseDrag()
    {
        radians = GetAngle() - radians;
        transform.rotation = Quaternion.AngleAxis(
            radians * Mathf.Rad2Deg, Vector3.right);
    }

    float GetAngle()
    {
        var pos = Camera.main.WorldToScreenPoint(
            transform.position);
        pos = Input.mousePosition - pos;
        
        return Mathf.Atan2(pos.y, pos.x);
    }
}
