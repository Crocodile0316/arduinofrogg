using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stairstageclear : MonoBehaviour
{
    public GameObject stage1;
    public GameObject player1;
    public GameObject player2;
    private timer timer;
    private Hahahaha clear;
    public string clearstage2;
    private void Awake()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (player1 != null && !string.IsNullOrEmpty(clearstage2))
        {
            player1.tag = clearstage2;
            Debug.Log("Tag changed to: " + player1.tag);
        }

        if (player2 != null && !string.IsNullOrEmpty(clearstage2))
        {
            player2.tag = clearstage2;
            Debug.Log("Tag changed to: " + player2.tag);
        }
    }
}
