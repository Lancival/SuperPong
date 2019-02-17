using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {

	public bool leftSide;

	private Rigidbody2D rb;
    private GameControllerScript gc;
	private int speed;
    // Start is called before the first frame update
    void Start() {
        gc = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        speed = gc.speed();
    	rb = gameObject.GetComponent<Rigidbody2D>(); // Get Rigidbody component from sprite
        if (leftSide)
        	rb.position = new Vector2(0, 0); // If on the left side, set x-position to 0
        else
        	rb.position = new Vector2(0, 10); // If on the right side, set x-position to something
    }

    // Update is called once per frame
    void Update() {
        speed = gc.speed();
        if (leftSide) {
        	float translation = Input.GetAxis("LeftSide");
            rb.velocity = new Vector2(0, translation * speed);
        }
        else {
        	float translation = Input.GetAxis("RightSide");
            rb.velocity = new Vector2(0, translation * speed);
        }
    }
}
