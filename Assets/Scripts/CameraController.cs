using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform targetToLookAt;
    [SerializeField, Range(-100.0f, 100.0f)] private float offset;

    void Update()
    {
        transform.position = targetToLookAt.position - Vector3.forward * offset;
        transform.LookAt(targetToLookAt);
        // WASD.ShiftWASDMovement(transform,1);
    }
}