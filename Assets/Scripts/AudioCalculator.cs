using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCalculator : MonoBehaviour {
    public float BPM;
    float BPS;
    public float offset;
	
	void Start ()
    {
        BPS = BPM / 60;
	}
	
	void Update ()
    {
        transform.Translate(-BPS * Time.deltaTime * offset, 0, 0);
	}
}
