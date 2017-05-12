﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInputManager : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void Update()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("key"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
