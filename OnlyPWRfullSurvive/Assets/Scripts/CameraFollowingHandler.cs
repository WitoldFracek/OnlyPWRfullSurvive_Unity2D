using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowingHandler : MonoBehaviour
{
    [SerializeField]
    public Transform mainTarget;
    private Transform otherTarget;
    public Vector3 offset = new Vector3(0, 0, -10);
    
    private void FixedUpdate()
    {
        transform.position = mainTarget.position + offset;
        //if (otherTarget == null) {
        //    transform.position = mainTarget.position + offset;
        //}
        //else
        //{
        //    transform.position = (mainTarget.position + otherTarget.position) / 2 + offset;
        //}
        
    }

    public void SetupOtherTarget(Transform otherPlayer)
    {
        otherTarget = otherPlayer;
    }
}
