using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowingHandler : MonoBehaviour
{
    private Transform target;
    public Vector3 offset = new Vector3(0, 0, -10);
    private void Awake() {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        transform.position = target.position + offset;
    }
}
