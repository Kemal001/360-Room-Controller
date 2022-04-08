using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SendObjectStats : MonoBehaviour
{
    public OSC osc;

    public float rotationSpeed;

    private void Update()
    {
        ObjectRotation();
    }

    private void ObjectRotation()
    {
        OscMessage message = new OscMessage();

        if(Input.touchCount >= 1 && (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Moved) && !EventSystem.current.IsPointerOverGameObject(0))
        {
            float xCoordinate = Input.GetTouch(0).position.x / Screen.width;
            float yCoordinate = Input.GetTouch(0).position.y / Screen.height;

            Debug.Log("x = " + xCoordinate + " / " + "y = " + yCoordinate);

            Vector2 touchPosition = Input.GetTouch(0).deltaPosition;
            transform.Rotate(0f, touchPosition.x * rotationSpeed, 0f);

            message.address = "/screen_coordinate_x";
            message.values.Add(xCoordinate);
            osc.Send(message);

            message.address = "/screen_coordinate_y";
            message.values.Add(yCoordinate);
            osc.Send(message);

            /*message.address = "/camera_rotation_z";
            message.values.Add(transform.localEulerAngles.y);
            osc.Send(message);*/
        }
    }
}
