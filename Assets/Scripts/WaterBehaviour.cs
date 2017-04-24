using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : MonoBehaviour {

    public Sprite waterBlock;
    public Sprite waterBlockTop;

    public GameObject snail;

    List<GameObject> snailsSpawned = new List<GameObject>();

    // Update is called once per frame
    void Update () {
        if (Random.Range(0, 5000) <= 1)
        {
            RaycastHit2D[] collidersAbove = new RaycastHit2D[1];
            gameObject.GetComponent<BoxCollider2D>().Raycast(new Vector2(0, 1), collidersAbove, 2.08f);
            if (!collidersAbove[0])
                snailsSpawned.Add(Instantiate(snail, gameObject.transform.position + new Vector3(0, 1.741f, 0), gameObject.transform.rotation, gameObject.transform));
        }

        RaycastHit2D[] collidersHit = new RaycastHit2D[1];
        gameObject.GetComponent<BoxCollider2D>().Raycast(new Vector2(0, 1), collidersHit, 2.08f);
        if (collidersHit[0])
            GetComponent<SpriteRenderer>().sprite = waterBlock;
        else
            GetComponent<SpriteRenderer>().sprite = waterBlockTop;

        RaycastHit2D[] colliderToHold = new RaycastHit2D[1];
        gameObject.GetComponent<BoxCollider2D>().Raycast(new Vector2(0, -1), colliderToHold, 1.04f);
        if (!colliderToHold[0] && gameObject.tag == "Water")
            Destroy(gameObject);
    }
}
