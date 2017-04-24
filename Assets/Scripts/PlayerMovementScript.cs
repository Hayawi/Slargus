using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {

        // Rotating the player around the mouse
        Vector3 playerMousePosition = Input.mousePosition;
        Vector3 playerCharacterPosition = gameObject.transform.position;

        Vector3 localPositionOfMouse = playerMousePosition - playerCharacterPosition;

        print(localPositionOfMouse);

        float playerRotation = Mathf.Rad2Deg * Mathf.Atan(playerMousePosition.y / playerMousePosition.x);

        gameObject.transform.rotation = Quaternion.AngleAxis(playerRotation, Vector3.forward);
        //gameObject.transform.FindChild("Main Camera").transform.rotation = Quaternion.AngleAxis(playerRotation * -1, Vector3.forward);

    }
}
