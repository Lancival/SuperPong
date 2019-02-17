using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndTextController : MonoBehaviour {

	[SerializeField] private Text GameEndText;

    // Start is called before the first frame update
    void Start() {
    	int lScore = ScoreScript.leftScore;
    	int rScore = ScoreScript.rightScore;
    	GameEndText.text = lScore.ToString() + " : " + rScore.ToString() + "\nPlayer " + (lScore > rScore ? "1" : "2") + " Won!";
    	ScoreScript.leftScore = 0;
    	ScoreScript.rightScore = 0;
    }

    // Update is called once per frame
    void Update() {}
}
