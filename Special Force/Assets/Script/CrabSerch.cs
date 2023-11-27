using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabSerch : MonoBehaviour
{
    [SerializeField] int N;
    [SerializeField] List<int> array;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Find(array, N);
        }
    }

    void Start()
    {
        Find(array, N);
    }

    void Find(List<int> array, int target)
    {
        int left = 0;
        int right = array.Count - 1;

        while(left<=right)
        {
            // 1. �迭�� ��� ����� �ε����� pivot�� �����Ѵ�.
            int pivot = (left + right) / 2;

            // 2. [pivot]�� ���� ã���� �ϴ� target���� ���ٸ� �˻� ����
            if (array[pivot] == target)
            {
                Debug.Log("pivot�� �� : " + array[pivot]);
                return;
            }
            else if (array[pivot] > target) // 3.[pivot]�� ���� ã�� ������ ũ�ٸ�, left ~ pivot���� Ž���Ѵ�.
            {
                right = pivot - 1;
            }
            else
            {
                left = pivot + 1;
            }

            Debug.Log("���� ã�� ���߽��ϴ�.");
        }
    }
}