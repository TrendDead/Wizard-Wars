using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlBetween : MonoBehaviour
{
    [SerializeField] private float _threshold;
    [SerializeField] private Transform _playerPos;
    
    private Camera _cam;

    private void Awake()
    {
        _cam = Camera.main;
    }

    void Update()
    {
        Vector3 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPos = (_playerPos.position + mousePos) / 2f;

        targetPos.x = Mathf.Clamp(targetPos.x, -(_threshold + 3) + _playerPos.position.x , (_threshold + 3) + _playerPos.position.x);
        targetPos.y = Mathf.Clamp(targetPos.y, -_threshold + _playerPos.position.y, _threshold + _playerPos.position.y);

        transform.position = targetPos;
    }

}
