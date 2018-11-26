using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMotion : MonoBehaviour
{
    private Transform _target;
    private const float DELTA_POSITION = 4f;
    private const float DELTA_ROTATION = 2f;

    private const float TIME = 0.3f;

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

        float normalizedTime = 0.5f; //Time.deltaTime / TIME;
        normalizedTime = Mathf.Min(normalizedTime, 1);

        if (Vector3.SqrMagnitude(transform.position - _target.position) > DELTA_POSITION)
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

        if (Vector3.SqrMagnitude(currentRotation - targetRotation) > DELTA_ROTATION)
        {
            transform.eulerAngles = Vector3.Lerp(currentRotation, targetRotation, normalizedTime);
        }        
    }
}
