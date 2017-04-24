using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviour : MonoBehaviour {

    public Sprite rockBlock;
    public Sprite rockBlockTop;

    public GameObject slargianHouse;
    GameObject spawnedSlargianHouse;

	// Update is called once per frame
	void FixedUpdate () {
        RaycastHit2D[] collidersHit = new RaycastHit2D[1];
        gameObject.GetComponent<BoxCollider2D>().Raycast(new Vector2(0, 1), collidersHit, 2.08f);
        if (collidersHit[0] && collidersHit[0].transform.gameObject.tag == "Snail")
            GetComponent<SpriteRenderer>().sprite = rockBlockTop;

        if (!collidersHit[0])
        {
            int slargusSpawnRate = 1;
            Collider2D[] collidersAroundRock = Physics2D.OverlapBoxAll(gameObject.transform.position, new Vector2(10.4f, 4.16f), 0);
            for (int i = 0; i < collidersAroundRock.Length; i++)
            {
                if (collidersAroundRock[i].gameObject.tag == "Tree")
                {
                    slargusSpawnRate += 2;
                }
            }

            if (Random.Range(0, 5000) <= slargusSpawnRate && gameObject.tag != "Placing")
            {
                spawnedSlargianHouse = Instantiate(slargianHouse, gameObject.transform);
                spawnedSlargianHouse.transform.position = gameObject.transform.position + new Vector3(0, 3.3f, 0);
            }
        }
    }
}