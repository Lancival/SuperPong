using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
	private GameControllerScript gc;
	private Rigidbody2D rb;
	[SerializeField] private GameObject Ball;
	[SerializeField] private GameObject Obstacle;


    // Start is called before the first frame update
    public void Start() {
    	gc = GameObject.Find("GameController").GetComponent<GameControllerScript>();
    	rb = gameObject.GetComponent<Rigidbody2D>(); // Get Rigidbody component from sprite
    	//rb.position = new Vector2(Random.Range(-7f, 7f), Random.Range(-4.5f, 4.5f));
    }

    // Update is called once per frame
   	void Update() {}

   	public void randomPowerup(){
   		int randomSeed = Random.Range(0, 5);

   		//incrementSpeed();
   		switch (randomSeed){
   			case 0: 
   			p_superSpeed();
   			break;

   			case 1: 
   			sizePaddles(.2f);
   			break;

   			case 2:
   			sizePaddles(-.2f);
   			break;

   			case 3:
   			addBall();
   			break;

   			case 4:
   			addObstacle();
   			break;



   		}

   		Destroy(gameObject);
   	}


    void incrementSpeed() {gc.increaseSpeed(1);}
    
    void p_superSpeed(){
   		gc.increaseSpeed(2);
    }

    void addSparkles(){

    }

    void sizePaddles(float amt){
    	GameObject[] arr = GameObject.FindGameObjectsWithTag("Paddle");
    	/*
    	if(arr[0].transform.localScale.y > 0.2){ //so if paddles won't disappear
    		arr[0].transform.localScale += new Vector3(0, amt, 0);
    		arr[1].transform.localScale += new Vector3(0, amt, 0);
    	}
    	*/
    	arr[0].transform.localScale *= (1+amt);
    	arr[1].transform.localScale *= (1+amt);


	//transform.localScale += new Vector3(0.1F, 0, 0);
    }

    void addBall(){
    	GameObject obj = Instantiate(Ball);
    }

    void addObstacle(){
    	GameObject obj = Instantiate(Obstacle);

    }




}
