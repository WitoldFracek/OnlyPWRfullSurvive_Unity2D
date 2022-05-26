using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsRangeBahavior : PlayerInRange
{
    override protected void whenInRange() {
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    override protected void whenOutOfRange() {
        gameObject.GetComponent<SpriteRenderer>().color = Color.black;
    }
}
