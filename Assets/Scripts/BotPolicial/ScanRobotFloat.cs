using UnityEngine;

public class ScanRobotFloat : MonoBehaviour
{
    [SerializeField] private float floatingSpeed = 2.5f;
    [SerializeField] private float amplitude = 0.02f;
    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
    }

    void LateUpdate()
    {
        transform.position = _startPosition  + new Vector3(0.0f, (Mathf.Sin(Time.time * floatingSpeed) * amplitude), 0.0f);
    }
}