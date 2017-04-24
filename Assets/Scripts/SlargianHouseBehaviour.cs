using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlargianHouseBehaviour : MonoBehaviour {

    public GameObject slargian;

    List<GameObject> slargiansSpawned = new List<GameObject>();

	// Update is called once per frame
	void Update () {
		if (Random.Range(0, 5000) <= 1)
        {
            slargiansSpawned.Add(Instantiate(slargian, gameObject.transform.position + new Vector3(0, -1.49f, 0), gameObject.transform.rotation, gameObject.transform));
        }
	}
}
