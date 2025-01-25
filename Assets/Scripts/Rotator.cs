using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Vector3 rotation;

    [SerializeField, Range(-10, 10)] private float rotationX;

    [SerializeField, Range(-10, 10)] private float rotationY;

    [SerializeField, Range(-10, 10)] private float rotationZ;

    void Update()
    {
        rotation = new Vector3(rotationX, rotationY, rotationZ);
        transform.Rotate(rotation);
    }
}