using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
	private GameControllerScript gc;
	private int speed;
	private Rigidbody2D rb;
	private Vector2 velocity;

    // Start is called before the first frame update
    public void Start()
    {
    	gc = GameObject.Find("GameController").GetComponent<GameControllerScript>();
    	speed = gc.speed();
    	rb = gameObject.GetComponent<Rigidbody2D>(); // Get Rigidbody component from sprite
		
    	speed = 1;
    	velocity = new Vector2(1f, 1f);
    	
    	rb.position = new Vector2(Random.Range(-7f, 7f), Random.Range(-4.5f, 4.5f));
      gameObject.GetComponent<SpriteRenderer>().enabled = true;

    }

    // Update is called once per frame
   	void Update() {
      speed = gc.speed();
		  rb.velocity = rb.velocity.normalized * speed;
    }

    void incrementSpeed() {gc.increaseSpeed(1);}
    
    void p_superSpeed(){
   		gc.increaseSpeed(3);
    }

   	public void randomPowerup(){
   		incrementSpeed();
   		p_superSpeed();
   		Destroy(gameObject);
   	}


}
