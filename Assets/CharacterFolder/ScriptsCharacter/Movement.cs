using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Movement 
{
    Camera _cam;
    Rigidbody _rb;
    float _speed = 4;
    Transform transform;
    float rotateSpeed = 1;

    public Movement (Rigidbody rb, float speed, Camera cam, Transform _transform)
    {
        _rb = rb;
        _speed = speed;
        _cam = cam;
        transform = _transform; 
    }

    public void move(float h, float v)
    {
        var dir = _cam.transform.forward * v + _cam.transform.right * h;
       
        dir.y = 0;
        

        _rb.velocity = dir.normalized * _speed;

        Vector3 _newRotate = Vector3.Lerp(transform.forward, dir, rotateSpeed * Time.fixedDeltaTime);

        transform.forward = _newRotate;
       
    }

    public void stop() 
    {
        
            _rb.velocity = Vector3.zero;
    }
}
