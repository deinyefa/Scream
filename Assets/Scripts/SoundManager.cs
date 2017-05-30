using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class SoundManager : MonoBehaviour {
    
    public AudioClip keySound;
    public AudioClip crawler;
    public AudioClip scarecrow;

	private PlaySound playSound;

	void Awake ()
	{
		DontDestroyOnLoad (this.gameObject);
		if (SceneManager.GetActiveScene().name == "StartScene")
		{
			playSound = GetComponent<PlaySound> ();
			playSound.PlayLooping ();
		}
	}
}
