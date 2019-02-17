using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextControllerScript : MonoBehaviour {

	[SerializeField] private Text leftScoreText;
	[SerializeField] private Text rightScoreText;
	private GameControllerScript gc;

    // Start is called before the first frame update
    void Start() {
        gc = GameObject.Find("GameController").GetComponent<GameControllerScript>();
    }

    // Update is called once per frame
    void Update() {
        leftScoreText.text = gc.leftScore().ToString();
        rightScoreText.text = gc.rightScore().ToString();
    }
}
