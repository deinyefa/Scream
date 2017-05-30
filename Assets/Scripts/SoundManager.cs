using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class SoundManager : MonoBehaviour {
    
	public static SoundManager instance = null;

    public AudioClip keySound;
    public AudioClip crawler;
    public AudioClip scarecrow;

	private PlaySound playSound;

	void Awake ()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

		if (SceneManager.GetActiveScene().name == "StartScene")
		{
			playSound = GetComponent<PlaySound> ();
			playSound.PlayLooping ();
		}
	}
}
