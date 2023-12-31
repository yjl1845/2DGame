using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] Text timertext;
    [SerializeField] float time;
    [SerializeField] float currentTime;

    private int minute;
    private int second;

    private void Start()
    {
        currentTime = time;

        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            minute = (int)currentTime / 60;
            second = (int)currentTime % 60;

            timertext.text = minute.ToString("00") + ":" + second.ToString("00");

            yield return null;


            if (currentTime <= 0)
            {
                currentTime = 0;
                yield break;
            }
        }
    }
}
