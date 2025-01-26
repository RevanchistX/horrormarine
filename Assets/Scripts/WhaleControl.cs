using System;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;
using Vector3 = UnityEngine.Vector3;

public class WhaleControl : MonoBehaviour
{
    [SerializeField] private bool intro;
    [SerializeField] private bool gameplay;
    [SerializeField] private bool endgame;
    [SerializeField] private GameObject submarine;
    [SerializeField, Range(-100, 100)] private float x;
    [SerializeField, Range(-100, 100)] private float y;
    [SerializeField, Range(-100, 100)] private float z;
    [SerializeField] private GameObject textInput;

    private TextMeshPro tmp;
    private bool shouldFade = false;

    private void Start()
    {
        intro = true;
        gameplay = false;
        endgame = false;
        // transform.position = new Vector3(x, y, z);
        // tmp = textInput.GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        // // transform.position = new Vector3(x, y, z);
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            intro = true;
            gameplay = false;
            endgame = false;
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            intro = false;
            gameplay = true;
            endgame = false;
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            intro = false;
            gameplay = false;
            endgame = true;
        }

        if (intro) Intro();
        if (gameplay) Gameplay();
        if (endgame) Endgame();
    }

    private void Gameplay()
    {
        var distance = RenderSettings.fogDensity * 1000;
        transform.position = submarine.transform.position + new Vector3(50 - distance, 30 - distance, 0);
        transform.eulerAngles = new Vector3(0, 90, 180);
    }

    private void Endgame()
    {
        var fog = RenderSettings.fogDensity;
        if (!(fog > 0.03f)) return;
        submarine.transform.position = Vector3.zero;
        transform.position = new Vector3(-5, 10, 0);
        transform.eulerAngles = new Vector3(-25, -5, 180);
    }

    private void Intro()
    {
        transform.position = new Vector3(60, 25, 16);
        transform.eulerAngles = new Vector3(0, 40, 0);
    }

    private void FadeWhale()
    {
        transform.position += new Vector3(0, 0, 0.001f);
    }
}