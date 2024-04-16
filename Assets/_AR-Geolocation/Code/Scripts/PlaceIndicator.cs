using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceIndicator : MonoBehaviour
{
    private ARRaycastManager raycatManager;
    private GameObject indicator;
    public GameObject uiCamera;
    public GameObject uiPlacement;
    public GameObject placeManager;
    private List<ARRaycastHit> hits = new List <ARRaycastHit> ();
    // Start is called before the first frame update
    void Start()
    {
        raycatManager = FindObjectOfType<ARRaycastManager> ();
        indicator = transform.GetChild(0).gameObject;
        indicator.SetActive(false);
        placeManager.SetActive(false);
        uiCamera.SetActive(true);
        uiPlacement.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        var ray = new Vector2(Screen.width / 2, Screen.height / 2);
        if (raycatManager.Raycast(ray, hits, TrackableType.Planes))
        {
            Pose hitPose = hits[0].pose;

            transform.position = hitPose.position;
            transform.rotation = hitPose.rotation;

            if (!indicator.activeInHierarchy)
            {
                indicator.SetActive(true);
                placeManager.SetActive(true);
                uiCamera.SetActive(false);
                uiPlacement.SetActive(true);
            }
        }
    }
}
