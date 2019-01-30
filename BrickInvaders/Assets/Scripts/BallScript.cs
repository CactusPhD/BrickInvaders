using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BallScript : MonoBehaviour {

    public int speed;
    private Vector3 direction;
    public GameObject player;

	// Use this for initialization
	void Start () {
        direction = -transform.up;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = Vector3.Lerp(transform.position, transform.position + direction, Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Collision Detected");
        if (collision.gameObject.CompareTag("Player"))
        {
            direction = (transform.position - collision.transform.position).normalized;

            print("Collision with Player");
        }
        else if (collision.gameObject.CompareTag("Brick"))
        {
            direction = -transform.up;
            collision.gameObject.GetComponent<BrickController>().destroyBrick();
            print("Collision with Brick");
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            direction = new Vector3(Random.insideUnitCircle.x, 1, 0).normalized;
            player.GetComponent<PaddleControls>().hit();
        }
        else
        {
            direction = new Vector3(-direction.x, direction.y, 0);
            print("Collision with Object");
        }
    }
}
