using System;
using System.Net.Sockets;
using System.Net;
using UnityEngine;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using Unity.VisualScripting;

public class ServerManager : MonoBehaviour
{
    public Action<string> response;
    public Action<string> action;
    private Socket socket;
    private readonly string ip = "127.0.0.1";
    private readonly int port = 9999;
    private bool isConnected = false;


    public void Start()
    {
    }

    public void ConnectToServer()
    {
        if (isConnected) return;
        try
        {
            IPEndPoint iPEndPoint = new(IPAddress.Parse(ip), port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(iPEndPoint);
            isConnected = socket.Blocking;
            UnityEngine.Debug.Log("서버 연결 성공");
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogFormat("서버 연결 실패! error cored : {0}", e);
        }
    }
    public void DisconnectServer()
    {
        if (!isConnected) return;

        isConnected = socket.Blocking;
        socket.Close();
        socket.Dispose();
    }
    private void Send(byte[] data)
    {
        try
        {
            Debug.Log("SendData");
            byte[] length = new byte[4];
            length = BitConverter.GetBytes(data.Length);
            Array.Reverse(length);
            if(this.socket == null)
            {
                print("소켓이없넹?");
            }
            socket.Send(length);
            socket.Send(data);
        }
        catch (Exception e) 
        { 
            Debug.LogFormat("Fail send message, {0}\n", e);
        }

    }
    public void SendData(int data)
    {
        byte[] databytes = new byte[sizeof(int)];
        try
        {
            databytes = BitConverter.GetBytes(data);
            Array.Reverse(databytes);
            Send(databytes);
        }
        catch { }
    }
    public void SendData(float[] floatarray)
    {
        byte[] bytearray = new byte[floatarray.Length * sizeof(float)];
        int typesize = sizeof(float);
        byte[] buffer = new byte[typesize];

        try
        {
            Buffer.BlockCopy(floatarray, 0, bytearray, 0, bytearray.Length);
            for (int i = 0; i < bytearray.Length; i += typesize) 
            {
                Buffer.BlockCopy(bytearray,i, buffer, 0, typesize);
                Array.Reverse(buffer);
                Buffer.BlockCopy(buffer, 0, bytearray, i, typesize);
            }
            Send(bytearray);
        }
        catch(Exception e) { print("fail sendata float array "+e); }

    }
    public void SendData(string data) 
    {
        byte[] bytes = Encoding.UTF8.GetBytes(data);
        Send(bytes);
    }
    public async Task<byte[]> Recv()
    {
        byte[] data = new byte[4];
        int length = 0;
        try
        {
            await Task.Run(() =>
            {
                socket.Receive(data, data.Length, SocketFlags.None);
                Array.Reverse(data);
                length = BitConverter.ToInt32(data, 0);
                print(length);
                data = new byte[length];
                socket.Receive(data, length, SocketFlags.None);
            });
            
            
        }
        catch (Exception e) 
        { 
            Debug.LogFormat("Fail receive message : {0}", e);
            return null;
        }
        return data;
    }
    public async void ReceiveMassagePacket()
    {
        int id = 0;
        while (id!=1)
        {
            byte[] data = await Recv();
            Array.Reverse(data);
            id = BitConverter.ToInt32(data, 0);
            print(id);
            if (id == 1)
            {
                data = await Recv();
                string responseMsg = Encoding.UTF8.GetString(data);
                print(responseMsg);
                data = await Recv();
                string actionMsg = Encoding.UTF8.GetString(data);
                print(actionMsg);
                response(responseMsg);
                action(actionMsg);
                break;
            }
        }
        print("hello");
        
    }
    public void SendVoicePacket(string npcName,List<float[]> wave)
    {
        int sampleCount = wave.Count;
        SendData(5);                                 // packetID
        SendData(npcName);
        SendData(sampleCount);                       // array size
        for (int i = 0; i < sampleCount; i++)        // array 
        {
            SendData(wave[i]);
        }
    }
    public void SendMessagePacket(string msg)
    {
        SendData(2);              // packet ID
        SendData(msg);            // message

    }

}

