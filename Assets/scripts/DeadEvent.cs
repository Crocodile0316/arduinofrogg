using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DeadEvent : MonoBehaviour
{
   
    public GameObject Deadarea;
    public float respawntime;
    public float respawntime1;
    public GameObject player1;
    public GameObject player2;
    public Deadanim deadanim;

    AudioManager audioManager;

    private void Awake()
    {

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }


    void OnTriggerEnter(Collider other)
    {
        if (deadanim == null)
        {
            Debug.LogError("Deadanim reference is not set!");
            return;
        }

        if (other.gameObject.name == "player1")
        {
            Debug.Log("Enter1");
            StartCoroutine(deadanim.HandleDeadScreen(respawntime));
            Invoke(nameof(player1return), respawntime);
            //player1.transform.position = new Vector3(5.356702f, 5.58f, 5.245076f);
            //  Invoke(nameof(CloseScreen), respawntime);
        }

        if (other.gameObject.name == "player2")
        {
            Debug.Log("Enter2");
            StartCoroutine(deadanim.HandleDeadScreen1(respawntime1));
            Invoke(nameof(player2return), respawntime1);
            //  Invoke(nameof(CloseScreen), respawntime);
        }
    }

    void player1return()
    {
        player1.transform.position = new Vector3(5.356702f, 5.58f, 5.245076f);
        
    }

    void player2return()
    {
        player2.transform.position = new Vector3(6.82f, 5.568f, 3.44f);
        
    }
}
