using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInputManager : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;

    [Header("Teleporting")]
    //- to teleport
    public bool isLeftController;
    public LineRenderer laser;
    private float yNudgeAmount = 0.0001f;
    public GameObject teleportAimerObject;
    public Vector3 teleportLocation;
    public GameObject player;
    public LayerMask layerMask;


    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void Update()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);

        Teleport();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("key"))
        {
            other.gameObject.SetActive(false);
        }
    }

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
    }
}
