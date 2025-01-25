using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    void Update()
    {
        var isCtrl = Input.GetKey(KeyCode.LeftControl);
        if (!isCtrl) return;
        var isW = Input.GetKey("W");
        var isA = Input.GetKey("A");
        var isS = Input.GetKey("S");
        var isD = Input.GetKey("D");
        var position = transform.position;
        if (isW)
        {
            position = Vector3.Lerp(position, new Vector3(position.x, position.y, position.z + 10), 10);
            transform.position = position;
        }

        if (isS && !isW)
        {
            position = Vector3.Lerp(position, new Vector3(position.x, position.y, position.z - 10), 10);
            transform.position = position;
        }

        if (isA)
        {
            position = Vector3.Lerp(position, new Vector3(position.x + 10, position.y, position.z), 10);
            transform.position = position;
        }

        if (isD && !isA)
        {
            position = Vector3.Lerp(position, new Vector3(position.x - 10, position.y, position.z), 10);
            transform.position = position;
        }

        var isSpace = Input.GetKey(KeyCode.Space);
        if (isSpace)
        {
            position = Vector3.Lerp(position, new Vector3(position.x, position.y - 10, position.z), 10);
            transform.position = position;
        }

        position = Vector3.Lerp(position, new Vector3(position.x, position.y + 10, position.z), 10);
        transform.position = position;
    }
}