using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEvent : MonoBehaviour
{
   
    public GameObject Deadarea;
    public float respawntime;
    public GameObject player1;
    public GameObject player2;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "player1")
        {
            Debug.Log("Enter1");
            
            player1.transform.position = new Vector3(5.356702f, 5.58f, 5.245076f);
          //  Invoke(nameof(CloseScreen), respawntime);
        }

        if (other.gameObject.name == "player2")
        {
            Debug.Log("Enter2");

            player2.transform.position = new Vector3(6.82f, 5.568f, 3.44f);
            //  Invoke(nameof(CloseScreen), respawntime);
        }
    }

}
