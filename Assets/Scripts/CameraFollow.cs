using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    public Transform lookAt;
    public bool bHasSmoothing;
    [Range(0f, 1f)] public float _TrackingSpeed;

    [SerializeField] Vector2 _Bounderies; //The lookat's player buffer zone between movements

    private Vector3 _TargetPostion;

    private void LateUpdate()
    {
        Vector3 _TargetDistance = Vector3.zero;

        Vector2 currenDistance = new Vector2(lookAt.position.x - transform.position.x, lookAt.position.y - transform.position.y);
       
        //X axis
        if (currenDistance.x > _Bounderies.x || currenDistance.x < -_Bounderies.x)
        {
            if (transform.position.x < lookAt.position.x)
            {
                _TargetDistance.x = currenDistance.x - _Bounderies.x;
            }
            else
            {
                _TargetDistance.x = currenDistance.x + _Bounderies.x;
            }
        }

        //Y axis
        if (currenDistance.y > _Bounderies.y || currenDistance.y < -_Bounderies.y)
        {
            if (transform.position.y < lookAt.position.y)
            {
                _TargetDistance.y = currenDistance.y - _Bounderies.y;
            }
            else
            {
                _TargetDistance.y = currenDistance.y + _Bounderies.y;
            }
        }

        //Movement logic
        if (bHasSmoothing) { 
        //Move The Camera(Smoothing)
        _TargetPostion = transform.position + _TargetDistance;//Store
        transform.position = Vector3.Lerp(transform.position, _TargetPostion, _TrackingSpeed);//Move
        }
        else
        {
            //Move the Camera(Snapping)
            transform.position = transform.position + _TargetDistance;
        }

    }

}


