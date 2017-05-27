using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;
using VRTK.Highlighters;

public class ControllerHighlightScript : MonoBehaviour {

	private SteamVR_TrackedObject trackedObj;
	public SteamVR_Controller.Device device;

	private bool hasPressedTrigger = false;

	public VRTK_ControllerHighlighter controllerHighlighter;
	public VRTK_OutlineObjectCopyHighlighter objectOutlineScript;
	public Color highlightColor;
	public bool isLeftController;

	private HighlightObjects highlightObject;

	void Awake () 
	{	
		trackedObj = GetComponent<SteamVR_TrackedObject>();
		controllerHighlighter = GameObject.FindObjectOfType<VRTK_ControllerHighlighter> ();
		highlightObject = GameObject.FindObjectOfType<HighlightObjects> ();
	}

	void Update () 
	{
		device = SteamVR_Controller.Input((int)trackedObj.index);
		HighLightTrigger ();
	}

	void HighLightTouchPad () 
	{
		if (!device.GetPressDown (SteamVR_Controller.ButtonMask.Touchpad))
		{
			//- set the highlight color of the touchpad
			controllerHighlighter.highlightTouchpad = highlightColor;

			//- alpha value of the color runs from 0 to 1
			controllerHighlighter.highlightTouchpad = Color.Lerp (Color.red, Color.clear, Mathf.PingPong(Time.time, 1));
		}
		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Touchpad))
		{
			//- set the highlight color of the touchpad
			controllerHighlighter.highlightTouchpad = Color.clear;
		}
	}

	void HighLightTrigger () 
	{
		if (isLeftController) {
			if (!device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger) && !hasPressedTrigger)
			{
				//- set the highlight color of the trigger
				controllerHighlighter.highlightTrigger = highlightColor;

				//- set the highlight color of the body and alpha value of
				//- trigger from 0 to 1
				controllerHighlighter.highlightBody = Color.clear;
				controllerHighlighter.highlightTrigger = Color.Lerp (Color.red, Color.clear, Mathf.PingPong(Time.time, 1));
			}
			else if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) 
			{
				//- when player presses the trigger, colors go back to normal
				hasPressedTrigger = true;
				controllerHighlighter.highlightTrigger = Color.clear;
				controllerHighlighter.highlightBody = Color.clear;
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag("interactable"))
		{
			//- stop sphere pulsing and set its color to green
			HighlightObjects.hasBeenTouched = true;
			other.gameObject.GetComponent<Renderer> ().material.color = Color.green;
		}
	}

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.CompareTag("interactable"))
		{
			//- when player presses pulsating touchpad, level changes
			HighLightTouchPad ();
			if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
			{
				highlightObject.LoadGameScene ();
			}
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.CompareTag ("interactable")) 
		{
			//- sets sphere back to initial color
			Renderer otherColor = other.GetComponent<Renderer> ();
			Color initialColor = new Color32 (173, 24, 14, 225);

			otherColor.material.color = initialColor;
		}
	}
}
