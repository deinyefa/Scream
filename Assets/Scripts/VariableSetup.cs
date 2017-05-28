using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VariableSetup : MonoBehaviour {

	public GameObject leftController;
	public GameObject rightController;
	public GameObject cameraEye;

	private ControllerInputManager leftControllerInputManager;
	private ControllerInputManager rightControllerInputManager;
	private CollectableManager collectableManager;
	private SoundManager soundManager;
	private Light spotlight;


	public void SetupVariables ()
	{
		if (SceneManager.GetActiveScene().name == "Fear") 
		{
			//- find the controller manager script in each of the controllers...
			leftControllerInputManager = leftController.GetComponent<ControllerInputManager> ();
			rightControllerInputManager = rightController.GetComponent<ControllerInputManager> ();

			//- ...find and set the collectable manager component in each... 
			leftControllerInputManager.collectableManager = GameObject.FindObjectOfType<CollectableManager> ();
			rightControllerInputManager.collectableManager = GameObject.FindObjectOfType<CollectableManager> ();

			//- ...find and set the sound manager in each...
			leftControllerInputManager.soundManager = GameObject.FindObjectOfType<SoundManager> ();
			rightControllerInputManager.soundManager = GameObject.FindObjectOfType<SoundManager> ();

			//- find and enable the spotlight in the cameraHead gameObject
			spotlight = GetComponentInChildren<Light> ();
			spotlight.enabled = true;
		}
	}
}
