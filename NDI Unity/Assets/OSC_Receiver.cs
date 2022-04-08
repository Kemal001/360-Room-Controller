using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OSC_Receiver : MonoBehaviour
{
    public OSC osc;

    public TextMeshProUGUI objectNameText;

    private void Update()
    {
        osc.SetAddressHandler("/object_name", OnReceiveObjectName);
    }

    private void OnReceiveObjectName(OscMessage message)
    {
        string objectName = message.values[0].ToString();

        objectNameText.SetText(objectName);
    }
}
