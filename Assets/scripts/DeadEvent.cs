using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DeadEvent : MonoBehaviour
{
    private Hahahaha clear;
    public GameObject Deadarea;
    public GameObject stage1;
    public float respawntime;
    public float respawntime1;
    public GameObject player1;
    public GameObject player2;
    public Deadanim deadanim;
    public timer timer;
    AudioManager audioManager;

    private void Awake()
    {

        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        clear = GetComponent<Hahahaha>();
        timer = GetComponent<timer>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player1return();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player1return2();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            player1return3();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            player2return();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            player2return2();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            player2return3();
        }
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

        if (other.gameObject.name == "player1" && player1.tag == "clearstage1")
        {
            Debug.Log("Enter2");
            StartCoroutine(deadanim.HandleDeadScreen(respawntime));
            Invoke(nameof(player1return2), respawntime);
            //player1.transform.position = new Vector3(5.356702f, 5.58f, 5.245076f);
            //  Invoke(nameof(CloseScreen), respawntime);
        }
        if (other.gameObject.name == "player1" && player1.tag == "clearstage2")
        {
            Debug.Log("Enter1");
            StartCoroutine(deadanim.HandleDeadScreen(respawntime));
            Invoke(nameof(player1return3), respawntime);
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
        if (other.gameObject.name == "player2" && player2.tag == "clearstage1")
        {
            Debug.Log("Enter1");
            StartCoroutine(deadanim.HandleDeadScreen1(respawntime));
            Invoke(nameof(player2return2), respawntime);
            //player1.transform.position = new Vector3(5.356702f, 5.58f, 5.245076f);
            //  Invoke(nameof(CloseScreen), respawntime);
        }
        if (other.gameObject.name == "player2" && player2.tag == "clearstage2")
        {
            Debug.Log("Enter1");
            StartCoroutine(deadanim.HandleDeadScreen1(respawntime));
            Invoke(nameof(player2return3), respawntime);
            //player1.transform.position = new Vector3(5.356702f, 5.58f, 5.245076f);
            //  Invoke(nameof(CloseScreen), respawntime);
        }
    }

    void player1return()
    {
        player1.transform.position = new Vector3(5.356702f, 5.58f, 5.245076f);
        
    }
    void player1return2()
    {
        player1.transform.position = new Vector3(143.14f, 6.08f, 30.41f);
    }
    void player1return3()
    {
        player1.transform.position = new Vector3(183.55f, 18.5f, 33.65f);
    }

    void player2return()
    {
        player2.transform.position = new Vector3(6.82f, 5.568f, 3.44f);
        
    }
    void player2return2()
    {
        player2.transform.position = new Vector3(143.14f, 6.08f, 30.41f);

    }
    void player2return3()
    {
        player2.transform.position = new Vector3(183.55f, 18.5f, 33.65f);

    }
}
