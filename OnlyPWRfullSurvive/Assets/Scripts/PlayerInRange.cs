using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRange : MonoBehaviour
{
    private Transform player;
    protected float distance = 2f;
    private void Awake() {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if ((player.transform.position - this.transform.position).sqrMagnitude < distance) {
            whenInRange();
        }
        else {
            whenOutOfRange();
        }
    }

    protected virtual void whenInRange() {}
    protected virtual void whenOutOfRange() {}
}
