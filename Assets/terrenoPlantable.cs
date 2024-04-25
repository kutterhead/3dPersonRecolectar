using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrenoPlantable : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject manager;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("gameManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            manager.GetComponent<gameManager>().puedePlantar = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            manager.GetComponent<gameManager>().puedePlantar = false;
        }
    }
}
