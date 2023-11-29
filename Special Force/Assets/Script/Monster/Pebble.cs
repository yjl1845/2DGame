using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pebble : Monster
{
    protected override void Attack()
    {
        speed = 0;
        attack = 3f;
        health = 20;

        animator.SetBool("Attack", true);
    }

    protected override void Death()
    {
        Debug.Log("Death");
    }
}
