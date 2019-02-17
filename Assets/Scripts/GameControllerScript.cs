using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

	[SerializeField] private int m_speed = 1;

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}

    public int speed() {
    	return m_speed;
    }
}
