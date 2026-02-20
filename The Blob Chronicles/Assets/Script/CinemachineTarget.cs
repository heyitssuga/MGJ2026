using UnityEngine;
using Unity.Cinemachine;

public class CinemachineTarget : MonoBehaviour
{
    private CinemachineCamera _camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camera = GetComponent<CinemachineCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_camera.Target.TrackingTarget == null)
        {
            _camera.Target.TrackingTarget = GameObject.Find("Oopy Goopy").transform;
        }
    }
}
