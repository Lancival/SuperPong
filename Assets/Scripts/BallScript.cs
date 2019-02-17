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
		Reset();
    }
	
	void Reset()
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
	

}
