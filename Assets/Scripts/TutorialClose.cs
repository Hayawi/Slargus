using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialClose : MonoBehaviour {

	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            Destroy(gameObject);
        }	
	}
}
