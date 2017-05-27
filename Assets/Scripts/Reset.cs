using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {

	public GameObject player;
	private Vector3 initialPlayerPosition;

	void Awake ()
	{
		initialPlayerPosition = player.transform.position;
	}

	void OnTriggerEnter (Collider other) {
		//- reset player position if player falls off the platform
		other.transform.position = initialPlayerPosition;
	}
}
