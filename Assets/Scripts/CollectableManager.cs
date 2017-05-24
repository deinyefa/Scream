using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour {

    public List<GameObject> collectables;

    public bool AreCollectablesInactive()
    {
        foreach (GameObject collectable in collectables)
        {
            if (collectable.gameObject != null)
            {
                return false;
            }
        }
        return true;
    }
}
