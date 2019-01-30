using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletScript : MonoBehaviour {

    public int speed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, transform.position + -1 * Vector3.up, Time.deltaTime * speed);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PaddleControls>().hit();
        }
        if (!collision.gameObject.CompareTag("Brick")) {
            Destroy(gameObject);
        }
    }
}
