using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSong : MonoBehaviour
{
	public AudioClip titleSong;
	public AudioSource audio;

	// Start is called before the first frame update
	void Start()
	{
		audio = GetComponent<AudioSource>();
		audio.PlayOneShot(titleSong);
	}

}
