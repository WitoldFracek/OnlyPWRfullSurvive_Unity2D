using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieStudentBehavior : MonoBehaviour
{
    //[SerializeField] Transform point1;
    //[SerializeField] Transform point2;
    [SerializeField] List<Transform> destinations;
    private Transform currentDestination;
    protected float distance = 2f;
    private bool isPoint1Destination;
    private NavMeshAgent agent;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody;
    private Animator animator;
    private System.Random rnd = new System.Random();
    private int lastIndex = -1;
    void Start()
    {
        currentDestination = GetRandomDestination();
        isPoint1Destination = true;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.SetDestination(currentDestination.position);

        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if((currentDestination.transform.position - transform.position).sqrMagnitude < distance)
        {
            currentDestination = GetRandomDestination();
            agent.SetDestination(currentDestination.position);
        }
        //if(isPoint1Destination) {
        //    if((point1.transform.position - this.transform.position).sqrMagnitude < distance) {
        //        isPoint1Destination = false;
        //        agent.SetDestination(point2.position);
        //    }
        //}
        //else {
        //    if((point2.transform.position - this.transform.position).sqrMagnitude < distance) {
        //        isPoint1Destination = true;
        //        agent.SetDestination(point1.position);
        //    }
        //}

        Vector2 velocity = agent.velocity;
        animator.SetFloat("Zombie speed", velocity.sqrMagnitude);
        if(velocity.sqrMagnitude * Mathf.Sign(velocity.x) > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(velocity.sqrMagnitude * Mathf.Sign(velocity.x) < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private Transform GetRandomDestination()
    {
        int index = 0;
        if(lastIndex < 0)
        {
            index = rnd.Next(0, destinations.Count);
        } else
        {
            index = rnd.Next(0, destinations.Count - 1);
            if(index >= lastIndex)
            {
                index += 1;
            }
        }
        lastIndex = index;
        return destinations[index];
    }
}
