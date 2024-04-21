using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class forcetest : MonoBehaviour
{
    public float Value;
    Thread IOThread = new Thread(DataThread);
    private static SerialPort sp;
    public static string incomingMsg = "";
    private static string outgoingMsg = "";

    private static void DataThread()
    {
        sp = new SerialPort("COM6", 9600);
        sp.Open();

        while (true)
        {
            if (outgoingMsg != "")
            {
                sp.Write(outgoingMsg);
                outgoingMsg = "";
            }
            incomingMsg = sp.ReadExisting();
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
        if (incomingMsg != "")
        {
            Value=float.Parse(incomingMsg);
            Debug.Log(Value);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
            outgoingMsg = "0";
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            outgoingMsg = "1";
    }
}
