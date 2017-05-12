using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    public GameObject[] collectables;

    public bool AreCollectablesInactive ()
    {
        foreach (GameObject collectable in collectables)
        {
            if (collectable.gameObject.activeSelf == true)
            {
                return false;
            }
        }
        return true;
    }
}
