using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform targetToLookAt;

    void Update()
    {
        transform.LookAt(targetToLookAt);
        WASD.ShiftWASDMovement(transform,1);
    }
}