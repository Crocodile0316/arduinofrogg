using UnityEngine;
using System.IO.Ports;

public class forceeee : MonoBehaviour
{
    SerialPort serialPort;
    string portName = "COM4"; // Change this to match your Arduino's port
    int baudRate = 9600; // Match with Arduino's baud rate

    public float sensorValue1; // Public float to store sensorValue1
    public float sensorValue2; // Public float to store sensorValue2

    void Start()
    {
        serialPort = new SerialPort(portName, baudRate);
        serialPort.Open();
    }

    void Update()
    {
        if (serialPort.IsOpen && serialPort.BytesToRead > 0)
        {
            string message = serialPort.ReadLine().Trim();
            string[] values = message.Split(':');
            if (values.Length >= 2)
            {
                if (float.TryParse(values[0], out sensorValue1))
                {
                    Debug.Log("Received sensorValue1: " + sensorValue1);
                }
                else
                {
                    Debug.LogWarning("Failed to parse sensorValue1: " + values[0]);
                }

                if (float.TryParse(values[1], out sensorValue2))
                {
                    Debug.Log("Received sensorValue2: " + sensorValue2);
                }
                else
                {
                    Debug.LogWarning("Failed to parse sensorValue2: " + values[1]);
                }
            }
        }
    }

    void OnDestroy()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
