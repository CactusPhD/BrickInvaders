using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PaddleControls : MonoBehaviour {

    public int speed;
    public Text lifeText;
    private int lives;
    private bool gameOver;

    // Use this for initialization
    void Start () {
        lives = 3;
        lifeText.text = "Lives: " + lives;
        gameOver = false;
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

    public void win()
    {
        if (!gameOver)
        {
            lifeText.text = "You Win!";
            gameOver = !gameOver;
        }

    }

    void lose()
    {
        if (!gameOver)
        {
            lifeText.text = "You Lose :(";
            gameOver = !gameOver;
        }
    }

    public void hit()
    {
        lives--;
        if (!gameOver) {
            lifeText.text = "Lives: " + lives;
            if(lives <= 0){
                lose();
            }
        }
    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("Bullet"))
//        {
//            hit();
//            Destroy(collision.gameObject);
//        }
//    }
}
