using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearstage : MonoBehaviour
{
    public GameObject stage1;
    public GameObject player1;
    public GameObject player2;
    public GameObject gm1;
    public GameObject gm2;
    private timer timer;
    private Hahahaha clear;
    public string clearstage1;
    private void Awake()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (player1 != null && !string.IsNullOrEmpty(clearstage1) && other.gameObject==player1)
        {
            player1.tag = clearstage1;
            gm1.tag = clearstage1;
            Debug.Log("Tag changed to: " + player1.tag);
        }

        if (player2 != null && !string.IsNullOrEmpty(clearstage1) && other.gameObject == player2)
        {
            player2.tag = clearstage1;
            gm2.tag = clearstage1;
            Debug.Log("Tag changed to: " + player2.tag);
        }
    }
}
