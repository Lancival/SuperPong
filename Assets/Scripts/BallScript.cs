using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

	private GameControllerScript gc;
	private Rigidbody2D rb;
	private Vector2 velocity;
	private SpriteRenderer sr;
    private TrailRenderer tr;
    public AudioClip pongSound;
    public AudioClip pingSound;
    public AudioClip pointSound;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start() {
        gc = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        tr = gameObject.GetComponentInChildren<TrailRenderer>();
        audio = GetComponent<AudioSource>();
		ResetVelocity();
    }

	void ResetPosition() {
		rb.velocity = new Vector2(0, 0);
		transform.position = Vector2.zero;
		Invoke("ResetVelocity", 1);
        tr.Clear();
	}

	void ResetVelocity() {
		rb.velocity = new Vector2((Random.Range(0.0f, 1.0f) < 0.5 ? 1 : -1) * Random.Range(0.3f, 1.0f), Random.Range(-1.0f, 1.0f));
		rb.velocity = rb.velocity.normalized * gc.speed();
		velocity = rb.velocity;
		sr.color = new Color(1.0f, Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
	}

    // Update is called once per frame
    void Update() {rb.velocity = rb.velocity.normalized * gc.speed();}

    void OnCollisionEnter2D(Collision2D collision) {
    	if (collision.gameObject.tag == "Paddle")
			rb.velocity = new Vector2(-velocity[0], velocity[1]);
		else
			rb.velocity = new Vector2(velocity[0], -velocity[1]);
		velocity = rb.velocity;
        audio.Play(0);
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Powerup") {
            collision.gameObject.GetComponent<PowerupScript>().randomPowerup();
            audio.PlayOneShot(pongSound);

            return;
        }
		if (collision.gameObject.tag == "TimeDown")
		{
			collision.gameObject.GetComponent<TimeScript>().DoSlowmotion();
            audio.PlayOneShot(pongSound);
			return;
		}
		if (collision.gameObject.tag == "Border_Left"){
			gc.increaseRightScore(1);
            audio.PlayOneShot(pointSound);
        }
		else if (collision.gameObject.tag == "Border_Right"){
			gc.increaseLeftScore(1);
            audio.PlayOneShot(pointSound);
        }
		ResetPosition();
	}
	

}
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

    private GameControllerScript gc;
    private Rigidbody2D rb;
    private Vector2 velocity;
    private SpriteRenderer sr;
    public AudioClip pongSound;
    public AudioClip pingSound;
    public AudioClip pointSound;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start() {
        gc = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();

        audio = GetComponent<AudioSource>();

        ResetVelocity();
    }

    void ResetPosition() {
        rb.velocity = new Vector2(0, 0);
        transform.position = Vector2.zero;
        Invoke("ResetVelocity", 1);
    }

    void ResetVelocity() {
        rb.velocity = new Vector2((Random.Range(0.0f, 1.0f) < 0.5 ? 1 : -1) * Random.Range(0.3f, 1.0f), Random.Range(-1.0f, 1.0f));
        rb.velocity = rb.velocity.normalized * gc.speed();
        velocity = rb.velocity;
        sr.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
    }

    // Update is called once per frame
    void Update() {rb.velocity = rb.velocity.normalized * gc.speed();}

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Paddle")
            rb.velocity = new Vector2(-velocity[0], velocity[1]);
        else
            rb.velocity = new Vector2(velocity[0], -velocity[1]);
        velocity = rb.velocity;

        
        audio.Play(0);

    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Powerup") {
            collision.gameObject.GetComponent<PowerupScript>().randomPowerup();
            audio.PlayOneShot(pongSound);
            return;
        }
        if (collision.gameObject.tag == "Border_Left"){
            gc.increaseRightScore(1);
            audio.PlayOneShot(pointSound);
        }

        else if (collision.gameObject.tag == "Border_Right"){
            gc.increaseLeftScore(1);
            audio.PlayOneShot(pointSound);
        }
        ResetPosition();

  
    }
    

}

*/
