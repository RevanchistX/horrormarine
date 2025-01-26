using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform targetToLookAt;

    void Update()
    {
        transform.position = targetToLookAt.position - Vector3.forward * 50;
        transform.LookAt(targetToLookAt);
        WASD.ShiftWASDMovement(transform,1);
    }
}