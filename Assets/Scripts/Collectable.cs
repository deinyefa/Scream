using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class Collectable : MonoBehaviour {

    private AudioSource audioSource;
    private SoundPlayOneshot sound;

    public Scoreboard scoreBoard;
    public CollectableManager collectableManager;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        sound = GetComponent<SoundPlayOneshot>();
    }

    void OnCollisionEnter(Collision other)
    {
        //- when controller touches it...
        if (other.gameObject.CompareTag("controller"))
        {
            //- ... play sound ...
            sound.Play();
            //- display score ...
            for (int i = 0; i > collectableManager.collectables.Count; i++)
            {
                if (collectableManager.collectables.Count >= 2)
                {
                    scoreBoard.score.text = collectableManager.collectables.Count - 1 + " are left";
                }
                else if (collectableManager.collectables.Count == 1)
                {
                    scoreBoard.score.text = collectableManager.collectables.Count - 1 + "is left";
                }
                else if (collectableManager.collectables.Count == 0)
                {
                    scoreBoard.score.text = "No keys are left, you are free to leave";
                }
                //- ... remove the key at index i ...
                collectableManager.collectables.RemoveAt(i);
            }
            //- ... disable gameObject
            this.gameObject.SetActive(false);
        }
    }
}
