using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 pos;

    private void Awake()
    {
        if (!target)
            target = FindObjectOfType<Hero>().transform;
    }
    private void Update()
    {
        pos = target.position;
        pos.z = -10f;
        transform.position =
            Vector3.Lerp(transform.position, pos, Time.deltaTime);
    }
}
