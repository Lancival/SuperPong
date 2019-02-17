using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

	[SerializeField] private int m_speed = 1;
    [SerializeField] private Object Powerup;
	private int[] score;
    private int tickCounter;

    // Start is called before the first frame update
    void Start() {
    	score = new int[2];
    	score[0] = 0; // Left Player Score
    	score[1] = 0; // Right Player Score
        tickCounter = 0;
    }

    // Update is called once per frame
    void Update() {
        tickCounter++;
        if (tickCounter >= 60){
            GameObject obj = Instantiate(Powerup) as GameObject;
            tickCounter = 0;
        }
    }

    // Accessors
    public int speed() {return m_speed;}
	public int leftScore() {return score[0];}
	public int rightScore() {return score[1];}

	// Mutators
    public void increaseLeftScore(int howMuch) {score[0] += howMuch;}
	public void increaseRightScore(int howMuch) {score[1] += howMuch;}
    public void increaseSpeed(int howMuch) {m_speed += howMuch;}


}
