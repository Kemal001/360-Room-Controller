using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class TouchInfo : MonoBehaviour
{
    public OSC osc;

    private void Update()
    {
        TouchPosition();
    }

    private void TouchPosition()
    {
        if (Input.touchCount >= 1)
        {
            OscMessage message = new OscMessage();

            Touch touch = Input.GetTouch(0);

            message.address = "/camera_rotation_z";
            message.values.Add(touch.position.x / Screen.width);
            osc.Send(message);
        }
    }
}
