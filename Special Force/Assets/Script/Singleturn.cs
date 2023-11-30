using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleturn<T> : MonoBehaviour where T : MonoBehaviour
{

    public static T instance
    {
        get;
        set;
    }

    public void Awake()
    {
        if(instance == null)
        {
            instance = (T)FindObjectOfType(typeof(T));
        }

        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(instance.gameObject);
    }
}
