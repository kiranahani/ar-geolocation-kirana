using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaptoDestroy : MonoBehaviour
{
    public GameObject[] destroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Debug.Log("Touched");
            PlaceObject();
        }
    }
    void PlaceObject()
    {
        for (int i = 0; i < destroy.Length; i++)
        {
            destroy[i].SetActive(false);
        }
    }
}
