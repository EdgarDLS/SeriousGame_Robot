using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void LateUpdate()
    {
        transform.LookAt(player.transform);
    }
}
