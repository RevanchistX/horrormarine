using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Vector3 rotation;

    [SerializeField, Range(-10, 10)] private float rotationX;

    [SerializeField, Range(-10, 10)] private float rotationY;

    [SerializeField, Range(-10, 10)] private float rotationZ;

    private bool shouldWork;

    void Update()
    {
        if (!shouldWork) return;
        rotation = new Vector3(rotationX, rotationY, rotationZ);
        transform.Rotate(rotation);
    }

    public void StartEngine(float speed)
    {
        shouldWork = true;
        rotationX = speed;
    }

    public void StopEngine()
    {
        shouldWork = false;
        rotationX = 0;
    }
}