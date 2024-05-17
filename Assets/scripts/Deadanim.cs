using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Deadanim : MonoBehaviour
{
    public GameObject DeadScreen;
    public GameObject DeadScreen1;
    public VideoPlayer videoPlayer;
    public VideoPlayer videoPlayer1;

    void Start()
    {
        DeadScreen.SetActive(false);
        DeadScreen1.SetActive(false);

        if (DeadScreen != null)
        {
            videoPlayer = DeadScreen.GetComponent<VideoPlayer>();
            if (videoPlayer != null)
            {
                videoPlayer.Pause(); // Pause the video at the start
            }
            else
            {
                Debug.LogError("VideoPlayer component not found on DeadScreen!");
            }
        }

        if (DeadScreen1 != null)
        {
            videoPlayer1 = DeadScreen1.GetComponent<VideoPlayer>();
            if (videoPlayer1 != null)
            {
                videoPlayer1.Pause(); // Pause the video at the start
            }
            else
            {
                Debug.LogError("VideoPlayer component not found on DeadScreen1!");
            }
        }
    }

    public void TriggerDeadScreen()
    {
        DeadScreen.SetActive(true);
        if (videoPlayer != null)
        {
            videoPlayer.Play();
        }
    }

    public void TriggerDeadScreen1()
    {
        DeadScreen1.SetActive(true);
        if (videoPlayer1 != null)
        {
            videoPlayer1.Play();
        }
    }

    // Method to deactivate the dead screen and stop video
    public void CloseDeadScreen()
    {
        DeadScreen.SetActive(false);
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
        }
    }

    public void CloseDeadScreen1()
    {
        DeadScreen1.SetActive(false);
        if (videoPlayer1 != null)
        {
            videoPlayer1.Stop();
        }
    }

    public IEnumerator HandleDeadScreen(float respawnTime)
    {
        TriggerDeadScreen();
        yield return new WaitForSeconds(respawnTime);
        CloseDeadScreen();
    }

    public IEnumerator HandleDeadScreen1(float respawnTime1)
    {
        TriggerDeadScreen1();
        yield return new WaitForSeconds(respawnTime1);
        CloseDeadScreen1();
    }
}
