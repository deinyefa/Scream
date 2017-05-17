using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenOpener : MonoBehaviour {

    private Animator anim;

	void Awake () {
        anim = GetComponent<Animator>();
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("controller"))
        {
            anim.SetBool("hasHitOvenDoor", true);
        }
    }
}
