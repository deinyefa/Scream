using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PlayAmbientSounds : MonoBehaviour {

	private PlaySound playSound;

	void Awake ()
	{
		playSound = GetComponent<PlaySound> ();
	}

	void Start () 
	{
		playSound.PlayLooping ();
	}
}
