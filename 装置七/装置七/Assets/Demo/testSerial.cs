using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSerial : MonoBehaviour {

    MySerialPort myserial;
    byte[] buffers = new byte[1024];
	// Use this for initialization
	void Start () {
        myserial = new MySerialPort("COM24", 115200, Parity.Mark, StopBits.One);
        myserial.Open();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        if (GUILayout.Button("读"))
        {
            int readnum = myserial.Read(buffers);
            Debug.Log(readnum);
        }
        if(GUILayout.Button("写"))
        {
            myserial.Write(new byte[] { 1,2,3,4,5});
        }
    }

    private void OnDestroy()
    {
        myserial.Close();
    }
}
