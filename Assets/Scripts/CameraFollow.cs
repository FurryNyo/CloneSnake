using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    [Header("Target for camera")]
    [SerializeField] private Transform _targetForCamera;

    // Update is called once per frame
    void Update()
    {
        Vector3 transformPosition = transform.position;
        transformPosition.z = _targetForCamera.position.z - 2;
        transform.position = transformPosition;
    }
}
