using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

	private GameControllerScript gc;
	private int speed;
	private Rigidbody2D rb;
	private Vector2 velocity;

    // Start is called before the first frame update
    void Start() {
        gc = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        rb = gameObject.GetComponent<Rigidbody2D>();
		ResetVelocity();
    }

	void ResetPosition()
	{
		rb.velocity = new Vector2(0, 0);
		transform.position = Vector2.zero;
		Invoke("ResetVelocity", 1);
	}

	void ResetVelocity()
	{
		speed = gc.speed();
		int rand = Random.Range(0, 4);
		switch (rand)
		{
			case 0:
				rb.velocity = new Vector2(1, 1);
				break;
			case 1:
				rb.velocity = new Vector2(-1, 1);
				break;
			case 2:
				rb.velocity = new Vector2(1, -1);
				break;
			case 3:
				rb.velocity = new Vector2(-1, -1);
				break;
		}
		rb.velocity = rb.velocity.normalized * speed;
		velocity = rb.velocity;
	}

    // Update is called once per frame
    void Update() {
        speed = gc.speed();
		rb.velocity = rb.velocity.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D collision) {
    	if (collision.gameObject.tag == "Paddle")
		{
			rb.velocity = new Vector2(-velocity[0], velocity[1]);
			velocity = rb.velocity;
		}
		else
		{
			rb.velocity = new Vector2(velocity[0], -velocity[1]);
			velocity = rb.velocity;
		}
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Powerup")
        {
            //rb.velocity = new Vector2(rb.velocity[0], rb.velocity[1]);
            //ContactPoint2D contact = collision.contacts[0];
            //Vector2 reflectedVelocity = Vector2.Reflect(rb.velocity, contact.normal);
            //rb.velocity = reflectedVelocity;
            
            //rb.velocity = velocity = new Vector2(0, 0);
            collision.gameObject.GetComponent<PowerupScript>().randomPowerup();
        }
		if (collision.gameObject.tag == "Border_Left")
		{
			gc.increaseRightScore(1);
			ResetPosition();
		}
		else if (collision.gameObject.tag == "Border_Right")
		{
			gc.increaseLeftScore(1);
			ResetPosition();
		}
	}
	

}

