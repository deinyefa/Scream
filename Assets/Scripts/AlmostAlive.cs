﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmostAlive : MonoBehaviour {

    private AudioSource audioSource;
	private VariableSetup variableSetup;

    public SoundManager soundManager;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
		variableSetup = GameObject.FindObjectOfType<VariableSetup> ();
		variableSetup.SetupVariables ();
    }

    void Start()
    {
        StartCoroutine(PlayCreatureSound(10f));
    }

    IEnumerator PlayCreatureSound (float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
        if (this.gameObject.CompareTag("crawler"))
        {
            audioSource.PlayOneShot(soundManager.crawler, 0.6f);
        }
        else if (this.gameObject.CompareTag("scarecrow"))
        {
            audioSource.PlayOneShot(soundManager.scarecrow, 0.7f);
        }
    }

}
