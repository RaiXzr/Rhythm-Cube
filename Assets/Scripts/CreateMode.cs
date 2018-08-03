using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMode : MonoBehaviour {

    public KeyCode key;
    public bool createMode;
    public GameObject spawn;
    public GameObject level;
		
	void Update ()
    {
		if (createMode)
        {
            if (Input.GetKeyDown(key))
            {
                GameObject go = Instantiate(spawn, transform.position, Quaternion.identity) as GameObject;
                go.transform.SetParent(level.transform);
            }
        }
	}
}
