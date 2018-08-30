using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressScript : MonoBehaviour
{

    float StartPosition = 0;
    float EndPosition = 2000;

    Update()
    {
        float x = transform.position.x;
        float normalized = (x - StartPosition) / EndPosition;

        Debug.Log("Percentage Completed: " + (normalized * 100).ToString());
    }
}
