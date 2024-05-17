using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Deadanim : MonoBehaviour
{
    public GameObject DeadScreen;
    public VideoPlayer videoPlayer;
    void Start()
    {
        DeadScreen.SetActive(false);


        videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer != null)
        {
            videoPlayer.Pause(); // Pause the video at the start
        }
        else
        {
            Debug.LogError("VideoPlayer component not found!");
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

    // Method to deactivate the dead screen and stop video
    public void CloseDeadScreen()
    {
        DeadScreen.SetActive(false);
        if (videoPlayer != null)
        {
            videoPlayer.Stop();
        }
    }

    public IEnumerator HandleDeadScreen(float respawnTime)
    {
        TriggerDeadScreen();
        yield return new WaitForSeconds(respawnTime);
        CloseDeadScreen();
    }

}
