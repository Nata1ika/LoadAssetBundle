using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMotion : MonoBehaviour
{
    private Transform _target;

    public void Init(Transform target)
    {
        _target = target;
    }
	
	private void LateUpdate()
    {
        if (_target == null)
        {
            return;
        }

        float normalizedTime = SmoothConstants.speed; 
        normalizedTime = Mathf.Min(normalizedTime, 1);

        if (Vector3.Magnitude(transform.position - _target.position) > SmoothConstants.deadZone)
        {
            transform.position = Vector3.Lerp(transform.position, _target.position, normalizedTime);
        }


        var currentRotation = transform.eulerAngles;
        var targetRotation = _target.eulerAngles;

        //x
        if (Mathf.Abs(currentRotation.x - targetRotation.x + 360) < Mathf.Abs(currentRotation.x - targetRotation.x))
        {
            currentRotation.x += 360;
        }
        else if (Mathf.Abs(currentRotation.x - targetRotation.x - 360) < Mathf.Abs(currentRotation.x - targetRotation.x))
        {
            currentRotation.x -= 360;
        }
        //y
        if (Mathf.Abs(currentRotation.y - targetRotation.y + 360) < Mathf.Abs(currentRotation.y - targetRotation.y))
        {
            currentRotation.y += 360;
        }
        else if (Mathf.Abs(currentRotation.y - targetRotation.y - 360) < Mathf.Abs(currentRotation.y - targetRotation.y))
        {
            currentRotation.y -= 360;
        }
        //z
        if (Mathf.Abs(currentRotation.z - targetRotation.z + 360) < Mathf.Abs(currentRotation.z - targetRotation.z))
        {
            currentRotation.z += 360;
        }
        else if (Mathf.Abs(currentRotation.z - targetRotation.z - 360) < Mathf.Abs(currentRotation.z - targetRotation.z))
        {
            currentRotation.z -= 360;
        }

        if (Vector3.Magnitude(currentRotation - targetRotation) > SmoothConstants.deadZoneRotation)
        {
            transform.eulerAngles = Vector3.Lerp(currentRotation, targetRotation, normalizedTime);
        }        
    }
}
