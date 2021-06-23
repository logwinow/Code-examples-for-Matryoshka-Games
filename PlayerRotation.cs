using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField]
    private Transform _playerCameraTransform;
    [SerializeField]
    private float _maxXRot = 90f;
    [SerializeField]
    private float _minXRot = -90f;
    [SerializeField]
    private float _sensitive = 1f;

    private Vector3 _curRot;

    public Vector3 Angle => _curRot;

    private void Start()
    {
        _curRot = transform.localEulerAngles;
    }

    private void Update()
    {
        float rotX = -Input.GetAxis("Mouse Y") * _sensitive; 
        float rotY = Input.GetAxis("Mouse X") * _sensitive; 

        _curRot.x = Mathf.Clamp(_curRot.x + rotX, _minXRot, _maxXRot);
        _curRot.y = Mathf.Repeat(_curRot.y + rotY, 360f);

        transform.rotation = Quaternion.Euler(0, _curRot.y, 0);
        _playerCameraTransform.localRotation = Quaternion.Euler(_curRot.x, 0, 0);
    }
}
