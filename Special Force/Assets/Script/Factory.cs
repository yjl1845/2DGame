using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    private Monster unit;

    [SerializeField] Transform[] spawnPosition;

    public Monster CreateUnit(Monster unitType)
    {
        // ���� ������Ʈ�� ������Ų��.
        unit = Instantiate(unitType);
        
        // ���� ������Ʈ�� ��ġ�� �����Ѵ�.
        unit.transform.position = spawnPosition[Random.Range(0, spawnPosition.Length)].position;

        // ���� ������Ʈ�� ��ȯ�Ѵ�.
        return unit;
    }
}