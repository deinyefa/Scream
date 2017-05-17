using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    public AudioSource audioSource;
    public SoundManager soundManager;

    void OnCollisionEnter(Collision other)
    {
        //- key sound is played and gameObject is deactivated when the controller touches it
        if (other.gameObject.CompareTag("controller"))
        {
            audioSource.PlayOneShot(soundManager.keySound, 0.3f);
            this.gameObject.SetActive(false);
        }
    }
}
