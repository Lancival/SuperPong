using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    private GameControllerScript gc;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameControllerScript>();
        rb = gameObject.GetComponent<Rigidbody2D>(); 
        rb.velocity = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        rb.velocity = rb.velocity.normalized * gc.speed();        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -11 || transform.position.x > 11)
        	Destroy(gameObject);

    }
}
