using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Monster
{
    public void Start()
    {
        base.Start();
        health = 100;
    }

    protected override void Attack()
    {
        attack = 20f;

        animator.SetBool("Attack", true);
    }

    protected override void Death()
    {
        animator.Play(typeof(Golem) + " " + "Die");
    }
}
