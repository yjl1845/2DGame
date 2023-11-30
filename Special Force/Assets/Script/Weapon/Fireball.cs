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
        //Time.time : ������ ����Ǹ鼭 �귯���� �ð��� �ǹ�
        transform.localPosition = new Vector3(Mathf.Cos(Time.time * speed) * offset, Mathf.Sin(Time.time *speed) * offset, 0);
    }
}