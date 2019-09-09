using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SerialManager : MonoBehaviour {

    /// <summary>
    /// 串口通讯
    /// </summary>
    private MySerialPort myserial;

    /// <summary>
    /// 串口名称
    /// </summary>
    public InputField comName;

    /// <summary>
    /// 波特率
    /// </summary>
    public InputField comRate;

    /// <summary>
    /// 显示的结果
    /// </summary>
    public List<Image> images;

    /// <summary>
    /// 读取数据的地址
    /// </summary>
    byte[] buffers = new byte[32];

    /// <summary>
    /// 打开串口
    /// </summary>
    public AnimationController AC;//配置控制器
    public void SerialStart()
    {
        if(myserial != null)
        {
            Debug.LogError("请先关闭串口");
            return;
        }

        if(!this.comName.text.Trim().StartsWith("Com"))
        {
            Debug.LogError("请设置串口名称");
            return;
        }

        if (this.comRate.text.Trim() == "")
        {
            Debug.LogError("请设置串口波特率");
            return;
        }

        int rateValue = 0;
        Int32.TryParse(this.comRate.text.Trim(),out rateValue);
        if(rateValue == 0)
        {
            Debug.LogError("串口波特率设置错误");
            return;
        }

        myserial = new MySerialPort(this.comName.text.Trim(), rateValue, Parity.None, StopBits.None);
        myserial.Open();

        Debug.LogError("串口启动成功");

        InvokeRepeating("ReadMessage", 0.5f, 0.5f);
    }

    void ReadMessage()
    {
        if(myserial == null)
        {
            return;
        }
        Debug.LogError("查询按钮状态:");
        myserial.Write(HexStringToBytes("FCAA"));
        buffers = new byte[32];
        int readnum = myserial.Read(buffers);
        if(readnum > 0)
        {
            string str = byteToHexStr(buffers, readnum);
            Debug.LogError(string.Format("串口读取成功: 长度:{0}, 内容:{1}", readnum, str));
            for(int i = 0; i< this.images.Count; i++)
            {
                this.images[i].color = Color.white;
            }
            switch (str)
            {
                case "FD01":
                    this.images[0].color = Color.red;AC.bgePlay();
                    break;
                case "FD02":
                    this.images[1].color = Color.red;AC.bgePlay1();
                    break;
                case "FD03":
                    this.images[2].color = Color.red;AC.bgePlay2();
                    break;
                case "FD04":
                    this.images[3].color = Color.red;AC.bgePlay3();
                    break;
                case "FD05":
                    this.images[4].color = Color.red;AC.bgePlay4();
                    break;
                case "FD06":
                    this.images[5].color = Color.red;
                    break;
            }
        }
    }

    /// <summary>
    /// Byte 转 16进制字符串
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string byteToHexStr(byte[] bytes, int length)
    {
        string returnStr = "";
        if (bytes != null)
        {
            for (int i = 0; i < length; i++)
            {
                returnStr += bytes[i].ToString("X2");
            }
        }
        return returnStr;
    }

    /// <summary>
    /// 16进制 转换为Byte数组
    /// </summary>
    /// <param name="hs"></param>
    /// <returns></returns>
    public static byte[] HexStringToBytes(string hexString)
    {
        if ((hexString.Length % 2) != 0)
        {
            hexString += " ";
        }

        byte[] returnBytes = new byte[hexString.Length / 2];
        for (int i = 0; i < returnBytes.Length; i++)
        {
            returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
        }
            
        return returnBytes;
    }

    public void SendLed1()
    {
        Debug.LogError("点亮LED1:");
        if (myserial == null)
        {
            return;
        }
        myserial.Write(HexStringToBytes("FC51"));
    }

    public void SendLed2()
    {
        Debug.LogError("点亮LED2:");
        if (myserial == null)
        {
            return;
        }
        myserial.Write(HexStringToBytes("FC52"));
    }

    public void SendLed3()
    {
        Debug.LogError("点亮LED3:");
        if (myserial == null)
        {
            return;
        }
        myserial.Write(HexStringToBytes("FC53"));
    }

    /// <summary>
    /// 关闭串口
    /// </summary>
    public void SerialStop()
    {
        CancelInvoke("ReadMessage");

        if (myserial == null)
        {
            return;
        }

        myserial.Close();
        myserial = null;

        Debug.LogError("串口关闭成功");
    }

    /// <summary>
    /// 销毁数据
    /// </summary>
    private void OnDestroy()
    {
        SerialStop();
    }

    // Use this for initialization
    void Start () {
        this.comName.text = "Com";
        this.comRate.text = "115200";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
