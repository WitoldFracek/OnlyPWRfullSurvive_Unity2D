using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerOver : MonoBehaviour
{
    private Transform player;
    private float xRange, yRange;
    private Transform leftPoint, rightPoint;
    private Transform upPoint, downPoint;
    private void Awake() {
        player = GameObject.Find("Player").GetComponent<Transform>();
        xRange = GetComponent<Renderer>().bounds.size.x / 2;
        yRange = GetComponent<Renderer>().bounds.size.y / 2;
    }

    void FixedUpdate()
    {
        var distance = (player.transform.position - this.transform.position);
        if (Math.Abs(distance.x) < xRange && Math.Abs(distance.y) < yRange) {
            whenInRange();
        }
        else {
            whenOutOfRange();
        }
    }

    protected virtual void whenInRange() {}
    protected virtual void whenOutOfRange() {}
}
