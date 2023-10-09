using Cinemachine;
using UnityEngine;

public class CameraZoomer : MonoBehaviour
{
    [SerializeField, Range(3, 10)] private float _startZoomSize = 5f;
    [SerializeField, Range(3, 9)] private float _minZoomSize;
    [SerializeField, Range(3, 10)] private float _maxZoomSize;
    [SerializeField] private float _zoomSensitivity = 5f;

    private CinemachineVirtualCamera _cinemachineCamera;

    private void OnValidate()
    {
        if (_minZoomSize >= _maxZoomSize)
            _maxZoomSize = _minZoomSize + 1;
    }

    private void Awake()
    {
        _cinemachineCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        if (mouseWheel != 0)
        {
            _startZoomSize -= mouseWheel * _zoomSensitivity;
            _startZoomSize = Mathf.Clamp(_startZoomSize, _minZoomSize, _maxZoomSize);
            _cinemachineCamera.m_Lens.OrthographicSize = _startZoomSize;
        }
    }
}
