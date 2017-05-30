using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PlayAmbientSounds : MonoBehaviour {

	public static DontDestroyVRTKManager instance = null;

	void Awake ()
	{
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
	}
}
