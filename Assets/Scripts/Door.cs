using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Door : MonoBehaviour {

	public CollectableManager collectableManager;

	public void LoadStartScreen () 
	{
		if (collectableManager.AreCollectablesInactive()) 
		{
			SteamVR_LoadLevel.Begin ("StartScene");
		}
	}
}
