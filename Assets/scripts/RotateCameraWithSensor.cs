using UnityEngine;
using Cinemachine;

public class RotateCameraWithSensor : MonoBehaviour
{
    public float angleRange = 135.0f; // Half-range of camera angles: default = 135.0f
    public float minSensorValue = 0; // Minimum value received from the sensor
    public float maxSensorValue = 1023; // Maximum value received from the sensor
    public SensorType sensorToUse; // Variable to choose which sensor value to use

    public GameObject targetObject; // Target game object to rotate
    private CinemachineFreeLook freeLookCamera;

    public enum SensorType
    {
        SensorValue1,
        SensorValue2,
        SensorValue3,
        SensorValue4
    }

    void Start()
    {
        // Get reference to the Cinemachine FreeLook Camera
        freeLookCamera = GetComponent<CinemachineFreeLook>();
    }

    void Update()
    {
        float sensorValue = 0;

        // Choose the sensor value based on the selected option
        switch (sensorToUse)
        {
            case SensorType.SensorValue1:
                sensorValue = GetSensorValue("sensorValue1");
                break;
            case SensorType.SensorValue2:
                sensorValue = GetSensorValue("sensorValue2");
                break;
            case SensorType.SensorValue3:
                sensorValue = GetSensorValue("sensorValue3");
                break;
            case SensorType.SensorValue4:
                sensorValue = GetSensorValue("sensorValue4");
                break;
        }

        // Map the sensor value to the range of camera angles
        float mappedValue = Mathf.InverseLerp(minSensorValue, maxSensorValue, sensorValue);
        float targetRotation = Mathf.Lerp(-angleRange, angleRange, mappedValue);

        // Set the X-axis rotation of the camera
        freeLookCamera.m_XAxis.Value = targetRotation;

        if (targetObject != null)
        {
            Vector3 targetRotationEuler = targetObject.transform.eulerAngles;
            targetRotationEuler.y = targetRotation;
            targetObject.transform.eulerAngles = targetRotationEuler;
        }
    }

    float GetSensorValue(string sensorName)
    {
        GameObject sensorValueObj = GameObject.Find("forceitem");
        if (sensorValueObj != null)
        {
            forceeee forceScript = sensorValueObj.GetComponent<forceeee>();
            if (forceScript != null)
            {
                switch (sensorName)
                {
                    case "sensorValue1":
                        return forceScript.sensorValue1;
                    case "sensorValue2":
                        return forceScript.sensorValue2;
                    case "sensorValue3":
                        return forceScript.sensorValue3;
                    case "sensorValue4":
                        return forceScript.sensorValue4;
                }
            }
        }
        return 0; // Return default value if sensor value not found
    }
}