using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtBehaviour : MonoBehaviour {

    public int growthFactor = 300;

    public GameObject grass;
    public GameObject tree;

    public Sprite grassBlockTop;
    public Sprite grassBlock;

    List<GameObject> grassGrowth;
    List<GameObject> treeGrowth;

	// Use this for initialization
	void Start () {
        grassGrowth = new List<GameObject>();
        treeGrowth = new List<GameObject>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Collider2D[] collidersAroundDirt = Physics2D.OverlapBoxAll(gameObject.transform.position, new Vector2(2.08f, 2.08f), 0);
        growthFactor = 300;
        for (int i = 0; i < collidersAroundDirt.Length; i++)
        {
            if (collidersAroundDirt[i].gameObject.tag == "Water")
            {
                growthFactor = 200;
            }
        }

        if (Random.Range(1, growthFactor) == 1 && gameObject.tag == "Dirt")
        {
            int grassOrTree = Random.Range(0, 2);
            if (grassOrTree == 0 && grassGrowth.Count < (300f / growthFactor) * 20f)
            {
                grassGrowth.Add(Instantiate(grass, gameObject.transform.position + new Vector3((Random.Range(0, 200) - 100) / 100f, 1.04f, 0), gameObject.transform.rotation, gameObject.transform));
            }
            else if (grassOrTree == 1 && treeGrowth.Count <= (300f / growthFactor) * 3f)
            {
                RaycastHit2D[] collidersOnTop = new RaycastHit2D[1];
                if (treeGrowth.Count > 0)
                    treeGrowth[treeGrowth.Count - 1].GetComponent<BoxCollider2D>().Raycast(new Vector2(0, 1), collidersOnTop, 2.08f);
                else
                {
                    gameObject.GetComponent<BoxCollider2D>().Raycast(new Vector2(0, 1), collidersOnTop, 2.08f);
                }
                if (!collidersOnTop[0] || collidersOnTop[0].transform.gameObject.tag == "Snail")
                    treeGrowth.Add(Instantiate(tree, gameObject.transform.position + new Vector3(0, 2.08f + treeGrowth.Count * 2.08f, 0), gameObject.transform.rotation, gameObject.transform));
            }
        }

        RaycastHit2D[] collidersHit = new RaycastHit2D[1];
        gameObject.GetComponent<BoxCollider2D>().Raycast(new Vector2(0, 1), collidersHit, 2.08f);
        if (collidersHit[0] && collidersHit[0].transform.gameObject.tag == "Snail")
            GetComponent<SpriteRenderer>().sprite = grassBlockTop;
    }
}