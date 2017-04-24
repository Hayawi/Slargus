using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockChooseScript : MonoBehaviour {

    public GameObject grassTopBlock;
    public GameObject rockTopBlock;
    public GameObject waterTopBlock;

    public GameObject grassBlock;
    public GameObject rockBlock;
    public GameObject waterBlock;
    public GameObject destroyBlock;

    public GameObject grassHUDBlock;
    public GameObject rockHUDBlock;
    public GameObject waterHUDBlock;
    public GameObject destroyBlockHUD;

    public GameObject blockToPlace;

    public GameObject worldBlocks;

    public AudioSource blockPlacing;

    bool placedBlock = false;

    // Update is called once per frame
    void Update () {
        Vector3 localMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); ;
        localMousePosition.z = 0;
        blockToPlace.transform.position = localMousePosition;

        if (blockToPlace.tag == "Placing" || blockToPlace.tag == "Destroying")
            placeBlock();

        if (blockToPlace.tag == "Choosing")
            chooseBlock(localMousePosition);
    }

    void placeBlock()
    {
        if (Input.GetMouseButton(0))
        { 
            Vector2 blockPosition = blockToPlace.transform.position;
            blockPosition = new Vector2((int)(blockPosition.x / 2.08f) * 2.08f + (int)((blockPosition.x % 2.08f) / 1.04f) * 2.08f, (int)(blockPosition.y / 2.08f) * 2.08f + (int)((blockPosition.y % 2.08f) / 1.04f) * 2.08f);

            RaycastHit2D[] collidersHit = new RaycastHit2D[1];
            blockToPlace.GetComponent<BoxCollider2D>().Raycast(new Vector2(0, 0), collidersHit);

            if (blockPosition != Vector2.zero && (!collidersHit[0] || collidersHit[0].transform.gameObject.tag != "UI"))
            {
                if (blockToPlace.tag == "Placing")
                {
                    changeBlockTag();
                    deletePreviousBlock();

                    GameObject placedBlock = Instantiate(blockToPlace);
                    placedBlock.transform.parent = worldBlocks.transform;
                    placedBlock.transform.position = blockPosition;
                    placedBlock.GetComponent<SpriteRenderer>().sortingOrder = 10;

                    blockToPlace.tag = "Placing";
                    blockToPlace.GetComponent<SpriteRenderer>().sortingOrder = 100;
                } else if (blockToPlace.tag == "Destroying")
                {
                    deletePreviousBlock();
                }
            }
            placedBlock = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(blockToPlace);
            blockToPlace = new GameObject();
            blockToPlace.tag = "Choosing";
            placedBlock = false;
        }

        if (Input.GetMouseButtonDown(1))
            cancelBlockPlacement();
    }

    void chooseBlock(Vector3 localMousePosition)
    {
        if (Input.GetMouseButtonUp(0) && grassHUDBlock.GetComponent<BoxCollider2D>().OverlapPoint(localMousePosition))
        {
            Destroy(blockToPlace);
            blockToPlace = Instantiate(grassBlock, blockToPlace.transform.position, blockToPlace.transform.rotation);
            blockToPlace.GetComponent<SpriteRenderer>().sortingOrder = 100;
            blockToPlace.tag = "Placing";
            blockPlacing.Play();
        }

        if (Input.GetMouseButtonUp(0) && waterHUDBlock.GetComponent<BoxCollider2D>().OverlapPoint(localMousePosition))
        {
            Destroy(blockToPlace);
            blockToPlace = Instantiate(waterBlock, blockToPlace.transform.position, blockToPlace.transform.rotation);
            blockToPlace.GetComponent<SpriteRenderer>().sortingOrder = 100;
            blockToPlace.tag = "Placing";
            blockPlacing.Play();
        }

        if (Input.GetMouseButtonUp(0) && rockHUDBlock.GetComponent<BoxCollider2D>().OverlapPoint(localMousePosition))
        {
            Destroy(blockToPlace);
            blockToPlace = Instantiate(rockBlock, blockToPlace.transform.position, blockToPlace.transform.rotation);
            blockToPlace.GetComponent<SpriteRenderer>().sortingOrder = 100;
            blockToPlace.tag = "Placing";
            blockPlacing.Play();
        }

        if (Input.GetMouseButtonUp(0) && destroyBlockHUD.GetComponent<BoxCollider2D>().OverlapPoint(localMousePosition))
        {
            Destroy(blockToPlace);
            blockToPlace = Instantiate(destroyBlock, blockToPlace.transform.position, blockToPlace.transform.rotation);
            blockToPlace.GetComponent<SpriteRenderer>().sortingOrder = 100;
            blockToPlace.tag = "Destroying";
            blockPlacing.Play();
        }
    }

    void cancelBlockPlacement()
    {
        if (Input.GetMouseButton(1))
        {
            Destroy(blockToPlace);
            blockToPlace = new GameObject();
            blockToPlace.tag = "Choosing";
        }
    }

    void deletePreviousBlock()
    {
        RaycastHit2D[] collidersHit = new RaycastHit2D[1];
        blockToPlace.GetComponent<BoxCollider2D>().Raycast(new Vector2(0, 0), collidersHit);
        if (collidersHit[0] && collidersHit[0].transform.gameObject.tag != "HomeBlock")
            Destroy(collidersHit[0].transform.gameObject);
    }

    void changeBlockTag()
    {
        if (blockToPlace.name == "GrassBlock(Clone)")
            blockToPlace.tag = "Dirt";
        else if (blockToPlace.name == "RockBlock(Clone)")
            blockToPlace.tag = "Rock";
        else if (blockToPlace.name == "WaterBlock(Clone)")
            blockToPlace.tag = "Water";
    }
}
