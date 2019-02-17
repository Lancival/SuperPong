using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

	private GameControllerScript gc;
	private int speed;
	private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
        gc = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        speed = gc.speed();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        speed = gc.speed();
        rb.velocity = rb.velocity.Normalize() * speed;
    }
}
