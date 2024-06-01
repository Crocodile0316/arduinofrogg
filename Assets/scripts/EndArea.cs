using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndArea : MonoBehaviour
{
    public GameObject Endarea;

    public GameObject EndScreen;
    public GameObject EndScreen1;
    public GameObject restartbt;

    public GameObject player1;
    public GameObject player2;

    void Start()
    {
        Time.timeScale = 1f;
        EndScreen.SetActive(false);
        EndScreen1.SetActive(false);
        restartbt.SetActive(false);
    }


        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "player1")
            {
            PauseGame();
            EndScreen.SetActive(true);
            restartbt.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }

            if (other.gameObject.name == "player2")
            {
            PauseGame();
            EndScreen1.SetActive(true);
            restartbt.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        }
    public void PauseGame()
    {

        Time.timeScale = 0f;
        
    }

}
