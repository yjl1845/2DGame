using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownManager : MonoBehaviour
{
    [SerializeField] Transform[] spawnposition;

    private readonly WaitForSeconds waitForSeconds = new WaitForSeconds(3);

    [SerializeField] Monster enemy;

    public void Start()
    {
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        yield return waitForSeconds;

        Instantiate(enemy, spawnposition[Random.Range(0, spawnposition.Length)]);
    }
}
