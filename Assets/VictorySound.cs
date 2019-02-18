using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictorySound : MonoBehaviour
{
	public AudioClip victorySound;
	public AudioSource audio;

	// Start is called before the first frame update
	void Start()
    {
		audio = GetComponent<AudioSource>();
		audio.PlayOneShot(victorySound);
	}

}
