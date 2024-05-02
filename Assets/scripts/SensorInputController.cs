using UnityEngine;

public class SensorInputController : MonoBehaviour
{
    void Update()
    {
        // Get the value of sensorValue2 from Input Manager
        float sensorValue2Input = Input.GetAxis("SensorValue2");

        // Use sensorValue2Input in your game logic
        Debug.Log("SensorValue2 Input: " + sensorValue2Input);
    }
}
