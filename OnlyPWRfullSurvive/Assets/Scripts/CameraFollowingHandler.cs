using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowingHandler : MonoBehaviour
{
    private Transform mainTarget;
    private Transform otherTarget;
    public Vector3 offset = new Vector3(0, 0, -10);
    private void Awake() {
        mainTarget = GameObject.Find("Player").GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        if(otherTarget == null) {
            transform.position = mainTarget.position + offset;
        }
        else
        {
            transform.position = (mainTarget.position + otherTarget.position) / 2 + offset;
        }
        
    }

    public void SetupOtherTarget(Transform otherPlayer)
    {
        otherTarget = otherPlayer;
    }
}
