using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Monster
{
    protected override void Attack()
    {
        speed = 0;
        attack = 20f;
        health = 100;

        animator.SetBool("Attack", true);
    }

    protected override void Death()
    {
        Debug.Log("Death");
    }
}
