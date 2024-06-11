using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialclear : MonoBehaviour
{
    public GameObject stage0;
    public GameObject player1;
    public GameObject player2;
    public GameObject gm1;
    public GameObject gm2;
    private timer timer;
    private Hahahaha clear;
    public string clearstage0;
    public bool py1=false;
    public bool py2=false;
    private void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (player1 != null && !string.IsNullOrEmpty(clearstage0) && other.gameObject == player1)
        {
            player1.tag = clearstage0;
            py1 = true;
            Debug.Log("Tag changed to: " + player1.tag);
            Changetag();
        }

        if (player2 != null && !string.IsNullOrEmpty(clearstage0) && other.gameObject == player2)
        {
            player2.tag = clearstage0;
            py2 = true;
            Debug.Log("Tag changed to: " + player2.tag);
            Changetag();
        }
    }

    void Changetag()
    {
        if(py1==true&&py2==true)
        {
            gm1.transform.position = new Vector3(5.356702f, 5.58f, 5.245076f);
            gm2.transform.position = new Vector3(6.82f, 5.568f, 3.44f);
            py1 = false;
            py2 = false;
        }
    }
}
