using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    private Button btn;
    public OSC osc;

    public string color;

    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SendColor);
    }

    private void SendColor()
    {
        OscMessage message = new OscMessage();

        message.address = "/color";
        message.values.Add(color);
        osc.Send(message);
    }
}
