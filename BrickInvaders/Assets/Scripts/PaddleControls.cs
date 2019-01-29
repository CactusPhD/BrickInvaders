using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PaddleControls : MonoBehaviour {

    public int speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.right, Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = Vector3.Lerp(transform.position, transform.position - Vector3.right, Time.deltaTime * speed);
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1, 21), transform.position.y);

	}
}
