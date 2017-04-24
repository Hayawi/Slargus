using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailBehaviour : MonoBehaviour {

    int direction = 1;

    public GameObject dirtBlock;
    public GameObject waterBlock;

	// Update is called once per frame
	void Update () {
        RaycastHit2D[] colliderToWalkOn = new RaycastHit2D[1];
        gameObject.GetComponent<BoxCollider2D>().Raycast(new Vector2(direction, -0.5f), colliderToWalkOn, 2.08f);
        RaycastHit2D[] colliderToBumpInto = new RaycastHit2D[1];
        gameObject.GetComponent<BoxCollider2D>().Raycast(new Vector2(direction, 0), colliderToBumpInto, 1.04f);
        if (colliderToWalkOn[0] && (!colliderToBumpInto[0] || colliderToBumpInto[0].transform.gameObject.tag == "Snail" || colliderToBumpInto[0].transform.gameObject.tag == "Tree"))
            move();
        else
        {
            move(-1);
        }

        colliderToWalkOn = new RaycastHit2D[1];
        gameObject.GetComponent<BoxCollider2D>().Raycast(new Vector2(0, -1), colliderToWalkOn, 2.08f);
        if (!colliderToWalkOn[0])
        {
            Destroy(gameObject);
        }

        RaycastHit2D[] colliderUnderneath = new RaycastHit2D[1];
        gameObject.GetComponent<BoxCollider2D>().Raycast(new Vector2(0, -1f), colliderUnderneath, 2.08f);
        if (colliderUnderneath[0].transform.gameObject.tag == "Rock")
        {
            if (Random.Range(0, 2000) < 5)
            {
                GameObject rockGameObject = colliderUnderneath[0].transform.gameObject;
                GameObject dirtBlockCreated = Instantiate(dirtBlock, rockGameObject.transform.position, rockGameObject.transform.rotation, rockGameObject.transform.parent);
                dirtBlockCreated.tag = "Dirt";
                Destroy(rockGameObject);
            }
        }
        else if (colliderUnderneath[0].transform.gameObject.tag == "Dirt")
        {
            if (Random.Range(0, 2000) < 5)
            {
                GameObject dirtGameObject = colliderUnderneath[0].transform.gameObject;
                GameObject waterBlockCreated = Instantiate(waterBlock, dirtGameObject.transform.position, dirtGameObject.transform.rotation, dirtGameObject.transform.parent);
                waterBlockCreated.tag = "Water";
                Destroy(dirtGameObject);
            }
        }
    }

    private void move()
    {
        if (Random.Range(0, 500) > 50)
            return;

        if (Random.Range(0,10) == 0)
        {
            direction *= -1;
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX; ;
        }
        gameObject.transform.Translate(new Vector2(0.5f * direction, 0));
    }

    private void move(int directionChange)
    {
        if (Random.Range(0, 500) > 10)
            return;

        
        direction *= -1;
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX; ;
    }
}
