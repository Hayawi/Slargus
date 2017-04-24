using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlargianBehaviour : MonoBehaviour {

    int direction = 1;

    public GameObject rockBlock;
    public GameObject dirtBlock;
    public GameObject goatHead;

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D[] colliderToWalkOn = new RaycastHit2D[1];
        gameObject.GetComponent<BoxCollider2D>().Raycast(new Vector2(direction, -0.5f), colliderToWalkOn, 2.08f);
        RaycastHit2D[] colliderToBumpInto = new RaycastHit2D[1];
        gameObject.GetComponent<BoxCollider2D>().Raycast(new Vector2(direction, 0), colliderToBumpInto, 1.04f);
        if (colliderToWalkOn[0] && (!colliderToBumpInto[0] || colliderToBumpInto[0].transform.gameObject.tag == "Snail" || colliderToBumpInto[0].transform.gameObject.tag == "Tree"))
        {
            move();
        }
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
        if (colliderUnderneath[0].transform.gameObject.tag == "Dirt")
        {
            if (Random.Range(0, 2000) < 5)
            {
                GameObject dirtGameObject = colliderUnderneath[0].transform.gameObject;
                GameObject rockBlockCreated = Instantiate(rockBlock, dirtGameObject.transform.position, dirtGameObject.transform.rotation, dirtGameObject.transform.parent);
                rockBlockCreated.tag = "Rock";
                Destroy(dirtGameObject);
            }
        }
        else if (colliderUnderneath[0].transform.gameObject.tag == "Water")
        {
            if (Random.Range(0, 2000) < 5)
            {
                GameObject WaterGameObject = colliderUnderneath[0].transform.gameObject;
                GameObject dirtBlockCreated = Instantiate(dirtBlock, WaterGameObject.transform.position, WaterGameObject.transform.rotation, WaterGameObject.transform.parent);
                dirtBlockCreated.tag = "Dirt";
                Destroy(WaterGameObject);
            }
        }

        RaycastHit2D[] goatSpace = new RaycastHit2D[1];
        gameObject.GetComponent<BoxCollider2D>().Raycast(new Vector2(0, 0), goatSpace, 2.08f);
        if (!goatSpace[0] && Random.Range(0, 10000) == 1)
        {
            Instantiate(goatHead, gameObject.transform.position + new Vector3(0, 1.13f, 0), gameObject.transform.rotation, gameObject.transform.parent.parent.parent);
        }

    }

    private void move()
    {
        if (Random.Range(0, 500) > 50)
            return;

        if (Random.Range(0, 10) == 0)
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
