using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class turningtest : MonoBehaviour
{
    public float Value2;
    Thread IOThread = new Thread(DataThread);
    private static SerialPort sp;
    public static string incomingMsg2 = "";
    private static string outgoingMsg2 = "";

    private static void DataThread()
    {
        sp = new SerialPort("COM5", 9600);
        sp.Open();

        while (true)
        {
            if (outgoingMsg2 != "")
            {
                sp.Write(outgoingMsg2);
                outgoingMsg2 = "";
            }
            incomingMsg2 = sp.ReadExisting();
            Thread.Sleep(200);
        }
    }

    private void OnDestroy()
    {
        IOThread.Abort();
        sp.Close();
    }
    // Start is called before the first frame update
    void Start()
    {
        IOThread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (incomingMsg2 != "")
        {
            Value2 = float.Parse(incomingMsg2);
            Debug.Log(Value2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
            outgoingMsg2 = "0";
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            outgoingMsg2 = "1";
    }
}
