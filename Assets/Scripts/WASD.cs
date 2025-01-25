using UnityEngine;

public class WASD
{
    public static void ShiftWASDMovement(Transform transform, float value)
    {
        var isShift = Input.GetKey(KeyCode.LeftShift);
        if (!isShift) return;
        WASDMovement(transform, 10);
        EQMovement(transform, 10);
    }

    public static void WASDMovement(Transform transform, float value)
    {
        WSMovement(transform, value);
        ADMovement(transform, value);
    }

    public static void ADMovement(Transform transform, float value)
    {
        var isA = Input.GetKey(KeyCode.A);
        var isD = Input.GetKey(KeyCode.D);
        var position = transform.position;
        if (isA)
        {
            position = Vector3.Lerp(position, new Vector3(position.x - value, position.y, position.z), 10);
            transform.position = position;
        }

        if (isD && !isA)
        {
            position = Vector3.Lerp(position, new Vector3(position.x + value, position.y, position.z), 10);
            transform.position = position;
        }
    }

    public static void WSMovement(Transform transform, float value)
    {
        var isW = Input.GetKey(KeyCode.W);
        var isS = Input.GetKey(KeyCode.S);

        var position = transform.position;
        if (isW)
        {
            position = Vector3.Lerp(position, new Vector3(position.x, position.y + value, position.z), 10);
            transform.position = position;
        }

        if (isS && !isW)
        {
            position = Vector3.Lerp(position, new Vector3(position.x, position.y - value, position.z), 10);
            transform.position = position;
        }
    }

    public static void EQMovement(Transform transform, float value)
    {
        var isQ = Input.GetKey(KeyCode.Q);
        var isE = Input.GetKey(KeyCode.E);
        var position = transform.position;
        if (isQ)
        {
            position = Vector3.Lerp(position, new Vector3(position.x, position.y, position.z + value), 10);
            transform.position = position;
        }

        if (isE && !isQ)
        {
            position = Vector3.Lerp(position, new Vector3(position.x, position.y, position.z - value), 10);
            transform.position = position;
        }
    }

    public static void RotationMovement(Transform transform, float value, KeyCode keycode1, KeyCode keyCode2)
    {
        var isR = Input.GetKey(keycode1);
        var isQ = Input.GetKey(keyCode2);
        var position = transform.position;

        transform.eulerAngles = Vector3.zero;

        if (isR)
        {
            transform.RotateAround(position, transform.right, value);
        }

        if (isQ)
        {
            transform.RotateAround(position, transform.right, -value);
        }
    }
}