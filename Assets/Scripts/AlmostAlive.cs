using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmostAlive : MonoBehaviour {

    private AudioSource audioSource;

    public SoundManager soundManager;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        StartCoroutine(PlayCreatureSound(10f));
    }

    IEnumerator PlayCreatureSound (float waitTime)
    {
        if (this.gameObject.CompareTag("crawler"))
        {
            audioSource.PlayOneShot(soundManager.crawler, 0.7f);
        }
        else if (this.gameObject.CompareTag("scarecrow"))
        {
            audioSource.PlayOneShot(soundManager.scarecrow, 0.7f);
        }
        yield return new WaitForSeconds(waitTime);
    }

}
