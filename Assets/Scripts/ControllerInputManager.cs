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

		//- Deactivate scoreboard is active
		if (scoreBoard.score.gameObject.activeInHierarchy == true)
			scoreBoard.score.gameObject.SetActive(false);
    }

    void Update()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
    }

	void OnTriggerEnter(Collider other)
   	{
        if (other.gameObject.CompareTag("key"))
		{
			//- ... play sound ...
			other.gameObject.GetComponent<AudioSource>().PlayOneShot(soundManager.keySound, 0.5f);

			for (int i = 0; i < collectableManager.collectables.Count; i++)
			{
				//- ... destroy other gameObject and remove index
				Destroy(other.gameObject);
				if (collectableManager.collectables[i] == null) 
					collectableManager.collectables.RemoveAt(i);
			}	

			//- activate score board
			scoreBoard.score.gameObject.SetActive(true);

			//- Toggle Score Canvas
			StartCoroutine (ScoreText (5f));
       	}

		if  (device.GetPress(SteamVR_Controller.ButtonMask.Trigger)) 
		{
			Door door = GameObject.FindObjectOfType<Door> ();

			if (other.gameObject.CompareTag ("door")) 
			{
				door.LoadStartScreen ();
			}
			else if (other.gameObject.CompareTag("sphere")) 
			{
				door.LoadGameScene ();
			}
		}
    }

	IEnumerator ScoreText (float waitTime)
	{
		switch (collectableManager.collectables.Count) 
		{
		case 6: 
			scoreBoard.score.text = "5 keys are left";
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
			scoreBoard.score.text = "No keys left to be taken.\nTouch the door to leave";
			break;
		}
		yield return new WaitForSeconds (waitTime);

		//- Deactivate scoreboard after 5 seconds
		if (scoreBoard.score.gameObject.activeInHierarchy == true)
			scoreBoard.score.gameObject.SetActive(false);
	}
}
