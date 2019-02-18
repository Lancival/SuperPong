using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour {

	[SerializeField] private int m_speed = 1;
    [SerializeField] private GameObject Powerup;
	[SerializeField] private GameObject TimeDown;
	private int[] score;
    private int tickCounter = 0;
	public bool timeflag = true;

	// Start is called before the first frame update
	void Start() {
    	score = new int[2];
    	score[0] = 0; // Left Player Score
    	score[1] = 0; // Right Player Score
    }

    // Update is called once per frame
    void Update() {
        if (tickCounter++ >= 60) {
            GameObject obj = Instantiate(Powerup, new Vector3(Random.Range(-7f, 7f), Random.Range(-4.5f, 4.5f), 0), Quaternion.identity);
            tickCounter = 0;
			int randomGenerator = Random.Range(0, 6);
			if (randomGenerator == 4 && timeflag)
			{
				timeflag = false;
				GameObject slowTime = Instantiate(TimeDown, new Vector3(Random.Range(-7f, 7f), Random.Range(-4.5f, 4.5f), 0), Quaternion.identity);
				
			}
        }
		
        if (score[0] >= 20 || score[1] >= 20) {
        	ScoreScript.leftScore = score[0];
        	ScoreScript.rightScore = score[1];
        	SceneManager.LoadScene("Game End");
        }
    }

	// Accessors
	public int speed() { return m_speed; }
	public int leftScore() {return score[0];}
	public int rightScore() {return score[1];}

	// Mutators
    public void increaseLeftScore(int howMuch) {score[0] += howMuch;}
	public void increaseRightScore(int howMuch) {score[1] += howMuch;}
    public void increaseSpeed(int howMuch) {m_speed += howMuch;}
	public void flagTrue() { timeflag = true;}


}
