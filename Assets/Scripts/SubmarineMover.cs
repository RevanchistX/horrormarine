using System;
using UnityEngine;

public class SubmarineMover : MonoBehaviour
{
    [SerializeField] private Rotator rotator;


    private void Update()
    {
        var speed = 0;
        var isSpace = Input.GetKey(KeyCode.Space);
        if (isSpace)
        {
            if (speed < 200)
            {
                speed += 10;
            } //kontrola na perkite
            //TODO add rigid body za boost
        }

        var isE = Input.GetKey(KeyCode.E);
        if (isE)
        {
            EngineSpeedControl(speed);
        } //should be value from space hold duration
    }

    void EngineSpeedControl(float speed)
    {
        rotator.StartEngine(speed); //just starts the animation, add variable for speed control
    }
}