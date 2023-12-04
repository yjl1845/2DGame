using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour
{

    [SerializeField] int n;
    [SerializeField] int [] memoization;

    #region ���� ��ȹ��
    // Ư�� ���������� ���� ���ϱ� ���ؼ� �װͰ� �ٸ� ���������� ���� �̿��Ͽ�, ȿ�������� ���� ���ϴ� �˰�����.

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

    #region �޸������̼�
    // ���α׷��� ������ ����� �ݺ��ؾ� �� ��, ������ ����� ���� �޸𸮿� ���������ν�
    // ������ ����� �ݺ� �����ϴ� �۾��� �����Ͽ�, ���α׷��� ���� �ӵ��� ����Ű�� ����̴�.

    #endregion

    void Start()
    {
        memoization = new int[n + 1];
        Debug.Log(Fibonacci(n, memoization));
    }
}