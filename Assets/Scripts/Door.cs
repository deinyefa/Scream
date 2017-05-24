using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Door : MonoBehaviour {

	public void LoadNextLevel () {
		SteamVR_LoadLevel.Begin ("StartScene");
	}
}
