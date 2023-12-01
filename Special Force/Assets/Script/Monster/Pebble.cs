using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pebble : Monster
{
    public void Start()
    {
        base.Start();
        health = 20;
    }

    protected override void Attack()
    {
        attack = 3f;

        animator.SetBool("Attack", true);
    }

    protected override void Death()
    {

        animator.Play(typeof(Pebble) + " " + "Die");
    }
}
