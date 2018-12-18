using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    [SerializeField] private float floatingSpeed = 2.5f;
    [SerializeField] private float amplitude = 0.02f;

    void LateUpdate()
    {
        transform.position = transform.position + new Vector3(0.0f, (Mathf.Sin(Time.time * floatingSpeed) * amplitude), 0.0f);
    }
}