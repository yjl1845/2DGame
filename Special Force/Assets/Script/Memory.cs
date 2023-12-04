using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour
{

    [SerializeField] int n;
    [SerializeField] int [] memoization;

    #region 동적 계획법
    // 특정 범위까지의 값을 구하기 위해서 그것과 다른 범위까지의 값을 이용하여, 효율적으로 값을 구하는 알고리즘.

    public int Fibonacci(int n, int[] array)
    {
        if(n<=0)
        {
            return 0;
        }

        else if(n==1 || n==2)
        {
            return 1;
        }

        if (array[n] != 0)
        {
            return array[n];
        }

        return array[n] = Fibonacci(n - 1, array) + Fibonacci(n - 2, array);
    }

    #endregion

    #region 메모이제이션
    // 프로그램이 동일한 계산을 반복해야 할 때, 이전에 계산한 값을 메모리에 저장함으로써
    // 동일한 계산을 반복 수행하는 작업을 제거하여, 프로그램의 실행 속도를 향상시키는 기술이다.

    #endregion

    void Start()
    {
        memoization = new int[n + 1];
        Debug.Log(Fibonacci(n, memoization));
    }
}
