using System;
using UnityEngine;
using UnityEngine.Serialization;

public class SubmarineMover : MonoBehaviour
{
    [SerializeField] private Rotator rotator;
    [SerializeField] private float speedBoostModifier = 0.09f;
    [SerializeField] private bool isEngineActive;
    [SerializeField] private BubbleSpawner bubbleSpawner;
    private float speed;
    private float originalSpeed;
    private AtmosphereControl atmosphereControl;

    private void Start()
    {
        atmosphereControl = GetComponent<AtmosphereControl>();
    }

    private void Update()
    {
        HandleEngineActivation();
        if (isEngineActive)
        {
            WASD.ADMovement(transform, 1);
            WASD.WSMovement(transform, 1);
            if (speed < 5) speed += 0.008f;
            rotator.StartEngine();
            rotator.AdjustSpeed(speed);
            bubbleSpawner.SetVisible();
            HandleBoost();
            HandleRotation();
        }
        else
        {
            rotator.StopEngine();
            if (speed > 1) speed -= 0.04f;
            else bubbleSpawner.SetHidden();
        }

        // HandleGravity();
        bubbleSpawner.UpdateBubbleScale(speed * 0.05f);
    }

    private void HandleGravity()
    {
        var position = transform.position;
        var value = 0.1f;
        transform.position =
            Vector3.Lerp(position, new Vector3(position.x - value, position.y - value, position.z), 10);
    }

    private void HandleRotation()
    {
        if (speed > 1)
        {
            var isR = Input.GetKey(KeyCode.D);
            bubbleSpawner.UpdateTrailRotation(new Vector3(isR ? -speed : speed, 0, 0));
        }

        WASD.RotationMovement(transform, 30, KeyCode.Q, KeyCode.E);
    }


    private void HandleEngineActivation()
    {
        var isE = Input.GetKeyUp(KeyCode.T);
        if (isE)
        {
            isEngineActive = !isEngineActive;
        }
    }

    private void HandleBoost()
    {
        var isSpace = Input.GetKey(KeyCode.Space);
        if (isSpace)
        {
            if (speed < 20)
                speed += speedBoostModifier;
            WASD.ADMovement(transform, 1.5f);
        }
        else
        {
            if (speed >= 5)
                speed -= speedBoostModifier;
        }
        
        
    }

    private void OnMouseDown()
    {
        atmosphereControl.ModifyDensity(0);
    }

    private void OnTriggerEnter(Collider collision)
    {
        print(collision.gameObject);
        if (!collision.gameObject.name.Contains("Bubble to consume")) return;
        atmosphereControl.ModifyDensity(0);
        Destroy(collision.gameObject);
    }
}