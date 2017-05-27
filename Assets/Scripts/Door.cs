using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Door : MonoBehaviour {

	public void LoadStartScreen () {
		SteamVR_LoadLevel.Begin ("StartScene");
	}
}
