using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Weapon
{
    [SerializeField] Transform character;
    [SerializeField] int offset;

    public void Update()
    {
        Attack();

    }

    public override void Attack()
    {
        //Time.time : 게임이 실행되면서 흘러가는 시간을 의미
        transform.localPosition = new Vector3(Mathf.Cos(Time.time * speed) * offset, Mathf.Sin(Time.time *speed) * offset, 0);
    }
}
