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

    /*[Header("Teleporting")]
    public bool isLeftController;
    public LineRenderer laser;
    private float yNudgeAmount = 0.0001f;
    public GameObject teleportAimerObject;
    public Vector3 teleportLocation;
    public GameObject player;
    public LayerMask layerMask;*/


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
        if (other.gameObject.CompareTag("key"))
		{
			Debug.Log ("collider has hit" + name);
			//- ... play sound ...
			other.gameObject.GetComponent<AudioSource>().PlayOneShot(soundManager.keySound, 0.5f);
			//- display score ...
			for (int i = collectableManager.collectables.Count; i > 0 ; i--)
			{
				if (collectableManager.collectables.Count >= 2)
				{
					scoreBoard.score.text = collectableManager.collectables.Count - 1 + " are left";
					//- ... remove the key at index i ...
					collectableManager.collectables.RemoveAt(i);
					Debug.Log ("there are more than 2 collectables left in the scene");
				}
				else if (collectableManager.collectables.Count == 1)
				{
					scoreBoard.score.text = collectableManager.collectables.Count - 1 + "is left";
					Debug.Log ("1 collectable left in the scene");
				}
				else if (collectableManager.collectables.Count == 0)
				{
					scoreBoard.score.text = "No keys are left, you are free to leave";
					Debug.Log ("no collectable left in the scene");
				}
			}
			//- ... disable gameObject
            other.gameObject.SetActive(false);
       	}
    }





























    /*
    void Teleport()
    {
        if (isLeftController)
        {
            if (device.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
            {
                laser.gameObject.SetActive(true);
                teleportAimerObject.SetActive(true);

                laser.SetPosition(0, gameObject.transform.position);
                RaycastHit hit;

                if (Physics.Raycast(transform.position, transform.forward, out hit, 15, layerMask))
                {
                    if (hit.collider.CompareTag("ground"))
                    {
                        teleportLocation = hit.point;
                        laser.SetPosition(1, teleportLocation);
                        teleportAimerObject.transform.position = new Vector3(teleportLocation.x,
                                                                            teleportLocation.y + yNudgeAmount, teleportLocation.z);
                    }
                }
                else
                {
                    //teleportLocation = new Vector3(transform.forward.x * 15 + transform.position.x, transform.forward.y * 15 +
                    //transform.position.y, transform.forward.z * 15 + transform.position.z);
                    RaycastHit groundRay;
                    if (Physics.Raycast(teleportLocation, -Vector3.up, out groundRay, 17, layerMask))
                    {
                        if (groundRay.collider.name == "ground")
                        {
                            teleportLocation = new Vector3(transform.forward.x * 15 + transform.position.x,
                                                            groundRay.point.y, transform.forward.z * 15 + transform.position.z);
                        }
                    }
                    laser.SetPosition(1, transform.forward * 15 + transform.position);
                    teleportAimerObject.transform.position = teleportLocation + new Vector3(0, yNudgeAmount, 0);
                }
            }

            if (device.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                laser.gameObject.SetActive(false);
                teleportAimerObject.SetActive(false);
                player.transform.position = teleportLocation;
            }
        }
    } */
}
