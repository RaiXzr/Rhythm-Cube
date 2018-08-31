using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
    public Slider progress;

    public float EndPosition = -300;

    private float StartPosition = 0;

    void Start()
    {
        StartPosition = transform.position.x;
    }

    void Update()
    {
        float x = transform.position.x;
        float normalized = (x - StartPosition) / EndPosition;

        progress.value = normalized;
        Debug.Log(x + "/" + EndPosition + " " + normalized);
    }
}
