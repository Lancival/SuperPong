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
        rb.position = new Vector2(leftSide ? -9 : 9, 0);
    }

    // Update is called once per frame
    void Update() {
        speed = gc.speed();
        float translation = Input.GetAxis(leftSide ? "LeftSide" : "RightSide");
        rb.velocity = new Vector2(0, translation * speed);
        if (rb.position[1] >= 4.15 && translation > 0)
            rb.velocity = Vector2.zero;
        if (rb.position[1] <= -4.15 && translation < 0)
            rb.velocity = Vector2.zero;
    }
}
