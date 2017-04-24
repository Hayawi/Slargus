using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    Vector3 localMousePosition;
    Vector3 newMousePosition;

    // Use this for initialization
    void Start () {
        localMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        newMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update () {
        if (!Input.GetMouseButton(2))
            localMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); ;
        if (Input.GetMouseButton(2))
        {
            newMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.Translate(-(newMousePosition - localMousePosition)/ 100);
        }
	}
}
