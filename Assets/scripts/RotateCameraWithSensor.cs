using UnityEngine;
using Cinemachine;

public class RotateCameraWithSensor : MonoBehaviour
{
    public Transform targetObject; // Object for the camera to rotate around
    public float angleRange = 135.0f; // Half-range of camera angles: default = 135.0f
    public float minSensorValue = 0; // Minimum value received from the sensor
    public float maxSensorValue = 1023; // Maximum value received from the sensor
    GameObject sv2;

    private CinemachineFreeLook freeLookCamera;

    void Start()
    {
        // Get reference to the Cinemachine FreeLook Camera
        freeLookCamera = GetComponent<CinemachineFreeLook>();
        sv2 = GameObject.Find("forceitem");
    }

    void Update()
    {
        // Get sensor value from Arduino (replace this with your actual sensor input)
        float sensorValue2 = sv2.GetComponent<forceeee>().sensorValue2; ;

        // Map the sensor value to the range of camera angles
        float mappedValue = Mathf.InverseLerp(minSensorValue, maxSensorValue, sensorValue2);
        float targetRotation = Mathf.Lerp(-angleRange, angleRange, mappedValue);

        // Set the X-axis rotation of the camera
        freeLookCamera.m_XAxis.Value = targetRotation;

        // Set the camera's Look At target to the specified object
        freeLookCamera.LookAt = targetObject;
    }
}
