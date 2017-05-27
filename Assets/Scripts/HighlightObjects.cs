using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using Valve.VR;

public class HighlightObjects : MonoBehaviour {

	public static Renderer myRenderer;
	public static bool hasBeenTouched = false;

	private Color initialColor;

	void Awake () 
	{
		myRenderer = GetComponent<Renderer> ();
	}
	
	void Start ()
	{
		initialColor = new Color32 (173, 24, 14, 225);
	}

	void Update ()
	{
		if (!hasBeenTouched)
			myRenderer.material.color = Color.Lerp (initialColor, Color.black, Mathf.PingPong (Time.time, 1));
	}

	public void LoadGameScene () {
		SteamVR_LoadLevel.Begin ("Fear");
	}
}
