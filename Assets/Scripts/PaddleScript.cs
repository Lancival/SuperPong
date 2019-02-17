using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {

	public bool leftSide;

	private Rigidbody2D rb;
	private int speed = 3;
    // Start is called before the first frame update
    void Start() {
    	rb = GameObject.getComponent<Rigidbody2D>(); // Get Rigidbody component from sprite
        if (leftSide)
        	rb.position.x = 0; // If on the left side, set x-position to 0
        else
        	rb.position.x = 10; // If on the right side, set x-position to something
        rb.position.y = 0; // Paddles always start at the midline
    }

    // Update is called once per frame
    void Update() {
        if (leftSide) {
        	float translation = Input.GetAxis("LeftSide");
        }
        else {
        	float translation = Input.GetAxis("RightSide");
        	// Right side
        }
    }
}
