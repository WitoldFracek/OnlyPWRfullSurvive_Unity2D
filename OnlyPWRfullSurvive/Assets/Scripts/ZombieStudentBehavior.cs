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
    }
    void Update()
    {
        if(isPoint1Destination) {
            agent.SetDestination(point1.position);
            if((point1.transform.position - this.transform.position).sqrMagnitude < distance) {
                isPoint1Destination = false;
            }
        }
        else {
            agent.SetDestination(point2.position);
            if((point2.transform.position - this.transform.position).sqrMagnitude < distance) {
                isPoint1Destination = true;
            }
        }
    }
}
