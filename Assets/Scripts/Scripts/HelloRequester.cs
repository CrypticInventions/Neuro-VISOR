﻿using AsyncIO;
using NetMQ;
using NetMQ.Sockets;
using UnityEngine;
using System.Collections;
using System.Net;
using C2M2.NeuronalDynamics.Interaction;
/// <summary>
///     Example of requester who only sends Hello. Very nice guy.
///     You can copy this class and modify Run() to suits your needs.
///     To use this class, you just instantiate, call Start() when you want to start and Stop() when you want to stop.
/// </summary>
public class HelloRequester : RunAbleThread
{
    /// <summary>
    ///     Request Hello message to server and receive message back. Do it 10 times.
    ///     Stop requesting when Running=false.
    /// </summary>
    /// 
    protected override void Run()
    {




        ForceDotNet.Force(); // this line is needed to prevent unity freeze after one use, not sure why yet
        using (RequestSocket client = new RequestSocket())
        {
            client.Connect("tcp://localhost:5555");
            //Need to allow for request to be sent multiple times


            Debug.Log("Sending request");
            client.SendFrame("data");
            // ReceiveFrameString() blocks the thread until you receive the string, but TryReceiveFrameString()
            // do not block the thread, you can try commenting one and see what the other does, try to reason why
            // unity freezes when you use ReceiveFrameString() and play and stop the scene without running the server
            //                string message = client.ReceiveFrameString();
            //                Debug.Log("Received: " + message);
            string message = null;
            bool gotMessage = false;
            while (Running)
            {
                gotMessage = client.TryReceiveFrameString(out message); // this returns true if it's successful
                if (gotMessage) break;
            }

            if (gotMessage)
            {
                Debug.Log("Received " + message);
                //Must generate a new preview panal after message has been send back to client

               
                   
            }


                    NetMQConfig.Cleanup(); // this line is needed to prevent unity freeze after one use, not sure why yet
           
                   
              
        }

    }
}
    
    
