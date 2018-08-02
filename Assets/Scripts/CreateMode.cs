using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMode : MonoBehaviour {

    public KeyCode key;
    public bool createMode;
    public GameObject spawn;
		
	void Update ()
    {
		if (createMode)
        {
            if (Input.GetKeyDown(key))
                Instantiate(spawn, transform.position, Quaternion.identity);
        }
	}
}
