using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestAPI : MonoBehaviour
{

    static RestAPI _instance;

    public static RestAPI Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }
    public void Get(string url, Action<string> action)
    {
        StartCoroutine(IEGet(url, action));
    }

    IEnumerator IEGet(string url, Action<string> action)
    {
        WWW www = new WWW(url);
        yield return www;

        if (www.error == null)
        {
            action?.Invoke(www.text);
        }
        else
        {
            Debug.Log("ERROR: " + www.error);
        }
    }
}
