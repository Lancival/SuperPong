using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScript : MonoBehaviour
{
	private GameControllerScript gc;
	private Rigidbody2D rb;
	[SerializeField] private GameObject TimeDown;

	public float slowdownFactor = 0.5f;
	public float slowdownLength = 1.0f;
	private int tickerCounter = -1;
	public void Start()
	{
		gc = GameObject.Find("GameController").GetComponent<GameControllerScript>();
		rb = gameObject.GetComponent<Rigidbody2D>(); // Get Rigidbody component from sprite
													 //rb.position = new Vector2(Random.Range(-7f, 7f), Random.Range(-4.5f, 4.5f));
	}

	void Update()
	{ 
		if (tickerCounter >= 0)
		{
			tickerCounter++;
			if (tickerCounter > 120)
			{
				Time.timeScale = 1;
				Time.fixedDeltaTime = 1f / 50;
				tickerCounter = 0;
				gc.flagTrue();
				Destroy(gameObject);
			}
		
		}
	}
	public void DoSlowmotion()
	{
		Time.timeScale = slowdownFactor;
		Time.fixedDeltaTime = Time.timeScale * 0.02f;

		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		gameObject.GetComponent<CircleCollider2D>().enabled = false;
		tickerCounter = 0;

	}
	
	

	
}
