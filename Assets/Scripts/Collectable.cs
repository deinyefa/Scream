using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Collectable : MonoBehaviour {

    private AudioSource audioSource;

//    public Scoreboard scoreBoard;
//    public CollectableManager collectableManager;

    void Awake()
    {
		audioSource = GetComponent<AudioSource> ();
       // sound = GetComponent<SoundPlayOneshot>();
    }

    void OnCollisionEnter(Collision other)
    {
		Debug.Log(name + "has been collided with");
        //- when controller touches it...
//		if (other.gameObject.CompareTag("controller"))
//        {
//			Debug.Log ("collider has hit this key" + name);
//            //- ... play sound ...
//            sound.Play();
//            //- display score ...
//			for (int i = collectableManager.collectables.Count; i > 0 ; i--)
//            {
//                if (collectableManager.collectables.Count >= 2)
//                {
//                    scoreBoard.score.text = collectableManager.collectables.Count - 1 + " are left";
//					Debug.Log ("there are more than 2 collectables left in the scene");
//                }
//                else if (collectableManager.collectables.Count == 1)
//                {
//                    scoreBoard.score.text = collectableManager.collectables.Count - 1 + "is left";
//					Debug.Log ("1 collectable left in the scene");
//                }
//                else if (collectableManager.collectables.Count == 0)
//                {
//                    scoreBoard.score.text = "No keys are left, you are free to leave";
//					Debug.Log ("no collectable left in the scene");
//                }
//                //- ... remove the key at index i ...
//                collectableManager.collectables.RemoveAt(i);
//            }
//            //- ... disable gameObject
//            this.gameObject.SetActive(false);
//        }
    }
}
