using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectExit : MonoBehaviour
{
    [SerializeField] string nameTag;
    [SerializeField] GameObject[] objectToSpawn;
    [SerializeField] GameObject[] objectToDestroy;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerExit(Collider other)
    {

        //Check NameTag
        if (other.gameObject.tag == nameTag)
        {

            // Destroy Objects
            for (int i = 0; i < objectToDestroy.Length; i++)
            {
                objectToDestroy[i].SetActive(false);
            }

            // Spawn Object
            for (int i = 0; i < objectToSpawn.Length; i++)
            {
                objectToSpawn[i].SetActive(true);
            }
        }
    }
}
