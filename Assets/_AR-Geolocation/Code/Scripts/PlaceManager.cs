using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceManager : MonoBehaviour
{
    private PlaceIndicator placeIndicator;
    private GameObject placedObjectPrefab;
    public GameObject objectToPlace;
    public GameObject[] spawn;
    public GameObject[] destroy;

    void Start()
    {
        placeIndicator = FindObjectOfType<PlaceIndicator>();
    }

    void Update()
    {
        // Check for touch or mouse click
        if (Input.GetMouseButtonDown(0)) // 0 indicates left mouse button on PC, touch on mobile devices
        {
            Debug.Log("Touched");
            PlaceObject();
        }
    }

    void PlaceObject()
    {
        // Ensure objectToPlace is not null and placeIndicator exists
        if (objectToPlace != null && placeIndicator != null)
        {
            // Destroy previously placed object if exists
            if (placedObjectPrefab != null)
            {
                Destroy(placedObjectPrefab);
            }

            // Instantiate new object at the position of placeIndicator
            placedObjectPrefab = Instantiate(objectToPlace, placeIndicator.transform.position, Quaternion.identity);
            for (int i = 0; i < spawn.Length; i++)
            {
                spawn[i].SetActive(true);
            }
            for (int i = 0; i < destroy.Length; i++)
            {
                destroy[i].SetActive(false);
            }
        }
    }
}
