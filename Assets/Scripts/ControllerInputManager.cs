using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerInputManager : MonoBehaviour {


    private SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;

	public Scoreboard scoreBoard;
	public CollectableManager collectableManager;
	public SoundManager soundManager;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void Update()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);

        //Teleport();
    }

	void OnTriggerEnter(Collider other)
   	{
		//TODO: toggle scoreboard when controller hits a key
        if (other.gameObject.CompareTag("key"))
		{
			Debug.Log ("collider has hit" + name);
			//- ... play sound ...
			other.gameObject.GetComponent<AudioSource>().PlayOneShot(soundManager.keySound, 0.5f);
			//- display score ...
			for (int i = 0; i < collectableManager.collectables.Count; i++)
			{
				//- ... destroy other gameObject and remove index
				Destroy(other.gameObject);
				if (collectableManager.collectables[i] == null) 
					collectableManager.collectables.RemoveAt(i);
			}	

			switch (collectableManager.collectables.Count) {
			case 6: 
				scoreBoard.score.text = "5 keys are left";
				Debug.Log ("there are more than 2 collectables left in the scene");
				break;
			case 5: 
				scoreBoard.score.text = "4 keys are left";
				break;
			case 4: 
				scoreBoard.score.text = "3 keys are left";
				break;
			case 3:
				scoreBoard.score.text = "2 keys are left";
				break;
			case 2:
				scoreBoard.score.text = "1 key is left";
				break;
			case 1:
				scoreBoard.score.text = "No keys left to be taken.\nYou may leave";
				break;
			}
       	}
    }
}
