using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : Monster
{
    protected override void Attack()
    {
        speed = 0;

        animator.SetBool("Attack", true);
    }

    protected override void Death()
    {
        Debug.Log("Death");
    }
}
