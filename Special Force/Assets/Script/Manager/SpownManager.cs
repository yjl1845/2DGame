using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownManager : MonoBehaviour
{
    private readonly WaitForSeconds waitForSeconds = new WaitForSeconds(3);

    [SerializeField] int rand;
    [SerializeField] List<Monster> monsterList;
    [SerializeField] Factory factory;
    [SerializeField] Monster enemy;

    public void Start()
    {
        monsterList.Capacity = 10;

        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        while (true)
        {
            yield return Corutincash.waitForSeconds(5);

            rand = Random.Range(0, monsterList.Count);

            Monster unit = factory.CreateUnit(monsterList[rand]);
        }
    }
}
