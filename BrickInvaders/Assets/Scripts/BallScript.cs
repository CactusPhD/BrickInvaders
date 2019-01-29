using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    public int forceStrength;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(-transform.up * forceStrength, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 direction;
        //rb.AddForce(Vector3.zero, ForceMode.VelocityChange);
        print("Collision Detected");
        if (collision.gameObject.CompareTag("Player"))
        {
            direction = (transform.position - collision.transform.position).normalized;

            print("Collision with Player");
        }
        else if (collision.gameObject.CompareTag("Brick"))
        {
            //this one's fucked
            direction = -rb.velocity.normalized;
            Destroy(collision.gameObject);
            print("Collision with Brick");
        }
        else
        {
            direction = transform.position - collision.rigidbody.ClosestPointOnBounds(transform.position);
            print("Collision with Object");
        }
        rb.AddForce(direction * forceStrength, ForceMode.Impulse);

    }
}
