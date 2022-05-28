using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieStudentBehavior : MonoBehaviour
{
    [SerializeField] Transform point1;
    [SerializeField] Transform point2;
    protected float distance = 2f;
    private bool isPoint1Destination;
    private NavMeshAgent agent;
    void Start()
    {
        isPoint1Destination = true;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.SetDestination(point1.position);
    }
    void Update()
    {
        if(isPoint1Destination) {
            if((point1.transform.position - this.transform.position).sqrMagnitude < distance) {
                isPoint1Destination = false;
                agent.SetDestination(point2.position);
            }
        }
        else {
            if((point2.transform.position - this.transform.position).sqrMagnitude < distance) {
                isPoint1Destination = true;
                agent.SetDestination(point1.position);
            }
        }
    }
}
