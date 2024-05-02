using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class accesoTienda : MonoBehaviour
{
    // Start is called before the first frame update
  
      private GameObject manager;



    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("gameManager");
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            


            print("Cargar escena tienda.");
            manager.GetComponent<gameManager>().cargaTienda();
        }
    }

}
