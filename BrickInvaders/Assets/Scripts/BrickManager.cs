using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BrickManager : MonoBehaviour {

    public Vector3 target;
    public int wait;
    public int width;
    public int height;
    public GameObject brick;
    public GameObject player;
    public Text scoreText;
    private List<GameObject> bricks;
    public int score;

	// Use this for initialization
	void Start () {
        bricks = new List<GameObject>();
        target = Vector3.zero;
        scoreText.text = "Score: " + score.ToString();

        // funtion to lay out bricks
        for (int i = 0; i < width; i++)
        {
            for(int j = 0; j< width; j++)
            {
                GameObject tempBrick = GameObject.Instantiate(brick, new Vector3(i * 4, j * -4, 0), Quaternion.identity, transform);
                bricks.Add(tempBrick);
            }
        }

        StartCoroutine("MoveTarget");
        StartCoroutine("RotateBricks");
        StartCoroutine("Shoot");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void removeBrick(GameObject oldBrick)
    {
        bricks.Remove(oldBrick);
        score++;
        scoreText.text = "Score: " + score.ToString();
        if(score == height * width)
        {
            player.GetComponent<PaddleControls>().win();
        }
    }    

    // make coroutine to randomly trigger rotation
    IEnumerator RotateBricks()
    {
        int rSelect;
        while(bricks.Count > 0)
        {
            rSelect = Random.Range(0, bricks.Count);
            bricks[rSelect].GetComponent<BrickController>().rotate();
            yield return new WaitForSeconds(wait / 4.0f);
        }
    }


    // make coroutine to randomly trigger shooting
    IEnumerator Shoot()
    {
        int rSelect;
        while (bricks.Count > 0)
        {
            rSelect = Random.Range(0, bricks.Count);
            bricks[rSelect].GetComponent<BrickController>().shoot();
            yield return new WaitForSeconds(wait / 4.0f);
        }
    }

    // moves bricks in a zig-zag like fashion
    IEnumerator MoveTarget()
    {
        while (bricks.Count > 0)
        {
            yield return new WaitForSeconds(wait);
            target = target + 3 * Vector3.right;
            yield return new WaitForSeconds(wait);
            target = target + -3 * Vector3.up;
            yield return new WaitForSeconds(wait);
            target = target + -3 * Vector3.right;
            yield return new WaitForSeconds(wait);
            target = target + -3 * Vector3.up;
            yield return new WaitForSeconds(wait);
        }
    }     
}
