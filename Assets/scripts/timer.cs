using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class timer : MonoBehaviour
{
    public Text timerText;  // Reference to the UI Text component
    private float elapsedTime;  // Variable to store the elapsed time

    void Start()
    {
        elapsedTime = 0f;  // Initialize elapsed time
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;  // Increment elapsed time by the time passed since the last frame

        // Format the elapsed time to minutes and seconds
        int minutes = Mathf.FloorToInt(elapsedTime / 60F);
        int seconds = Mathf.FloorToInt(elapsedTime % 60F);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 1000F) % 1000F);

        // Update the Text component with the formatted time
        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
