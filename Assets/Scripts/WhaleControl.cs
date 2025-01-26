using System;
using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Vector3 = UnityEngine.Vector3;

public class WhaleControl : MonoBehaviour
{
    [SerializeField] private bool intro;
    [SerializeField] private bool gameplay;
    [SerializeField] private GameObject submarine;
    [SerializeField, Range(-100, 100)] private float x;
    [SerializeField, Range(-100, 100)] private float y;
    [SerializeField, Range(-100, 100)] private float z;
    [SerializeField] private GameObject textInput;

    private TextMeshPro tmp;

    private void Start()
    {
        if (intro) Intro();
        transform.position = new Vector3(x, y, z);
        // tmp = textInput.GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        transform.position = new Vector3(x, y, z);
        if (intro) Intro();
        if (gameplay) Gameplay();
    }

    private void Gameplay()
    {
        var fog = RenderSettings.fogDensity;
        // tmp.gameObject.SetActive(false);
        if (!(fog > 0.03f)) return;
        // transform.position = submarine.transform.position + new Vector3(40, 10, 0);
        submarine.transform.position = Vector3.zero;
        transform.position = new Vector3(40, 10, 0);
        // transform.rotation.Set(0, 180, 0, 0);
        // transform.eulerAngles = new Vector3(-20, 25, 180);
        transform.eulerAngles = new Vector3(-25, -5, 180);
        // tmp.gameObject.SetActive(true);
    }

    private void Intro()
    {
        transform.position = new Vector3(60, 25, 16);
        transform.rotation.Set(0, 40, 0, 0);
    }
}