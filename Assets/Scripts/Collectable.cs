using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    void OnCollisionEnter(Collision other)
    {
        //- is deactivated when the controller touches it
        if (other.gameObject.CompareTag("controller"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
