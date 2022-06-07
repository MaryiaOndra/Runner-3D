using System.Collections.Generic;
using Cinemachine;
using Platform;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> _virtualCameras;
    [SerializeField] private List<SafePoint> _safePoints;
    
    private int _currentPriority = 1;
    private int _activeCameraIndex = 0;
    private CinemachineVirtualCamera _activeCamera;
    
    private void Start()
    {
        InitCamerasOrder();
        
        _safePoints.ForEach(point => point.OnTrigger += SwitchCamera);
    }

    private void InitCamerasOrder()
    {
        for (int i = 0; i < _virtualCameras.Count; i++)
        {
            _virtualCameras[i].Priority = _currentPriority;
        }

        _currentPriority++;
        _virtualCameras[_activeCameraIndex].Priority = _currentPriority;
    }

    private void SwitchCamera()
    {
        _activeCameraIndex++;
        _currentPriority++;
        Debug.Log($"_activeCameraIndex:{_activeCameraIndex}________currentPriority:{_currentPriority}");
        _virtualCameras[_activeCameraIndex].Priority = _currentPriority;
    }
}
