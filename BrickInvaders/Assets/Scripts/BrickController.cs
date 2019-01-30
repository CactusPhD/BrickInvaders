﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BrickController : MonoBehaviour {

    public int speed;
    private Vector3 startingPosition;
    public GameObject bullet;

	// Use this for initialization
	void Start () {
        startingPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, startingPosition + GetComponentInParent<BrickManager>().target, Time.deltaTime * speed);
	}

    // shoots a bullet towards the player
    public void shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
    
    // allows manager to rotate brick
    public void rotate()
    {
        StartCoroutine("Rotate");
    }

    public void destroyBrick()
    {
        gameObject.GetComponentInParent<BrickManager>().removeBrick(gameObject);
        Destroy(gameObject);
    }

    // rotates the brick 90 degrees
    IEnumerator Rotate()
    {
        float startTime = Time.time;
        Quaternion start = transform.rotation;
        Quaternion finish = start * Quaternion.AngleAxis(-90, Vector3.forward);
        float elapsedTime;
        do {
            elapsedTime = Time.time - startTime;
            transform.rotation = Quaternion.Lerp(start, finish, elapsedTime * speed);
            yield return new WaitForEndOfFrame();
        } while (elapsedTime <= 1);        
    }
}
