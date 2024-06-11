using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class tutorialdead : MonoBehaviour
{
    public GameObject deadarea;
    public GameObject player1;
    public GameObject player2;
    public GameObject G1;
    public GameObject G2;
    public Deadanim deadanim;
    public float respawntime;

    private void OnTriggerEnter(Collider other)
    {
        if (deadanim == null)
        {
            Debug.LogError("Deadanim reference is not set!");
            return;
        }

        if (other.gameObject.name == "player1")
        {
            Debug.Log("tnter1");
            StartCoroutine(deadanim.HandleDeadScreen(respawntime));
            Invoke(nameof(player1return), respawntime);
        }
        if (other.gameObject.name == "player2")
        {
            Debug.Log("tnter2");
            StartCoroutine(deadanim.HandleDeadScreen(respawntime));
            Invoke(nameof(player2return), respawntime);
        }
    }
    
    public void player1return()
    {
        G1.transform.position = new Vector3(-160.09f, -2.5f, 219.22f);
    }

    public void player2return()
    {
        G2.transform.position = new Vector3(-160.0295f, -2.54f, 201.82f);
    }

}
