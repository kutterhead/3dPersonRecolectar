using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant : MonoBehaviour
{
    private GameObject manager;


    //es para recargar la barra de vida, usar valores entre 0 y 1
    public float valorStamine;//este valor lo puede leer el player cuando recolecte este elemento
    
    
    public float tiempoMaximoCrecimiento = 3f;//tiempo de crecimiento
    public float offsetY = 0;


    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("gameManager");
        StartCoroutine(crecerPlanta());
    }

   

    IEnumerator crecerPlanta()//pone una planta transcurrido un tiempo
    {
        float tiempoActual = 0; 
        
        
        
        float ratioTiempo = 0;


        float posY = gameObject.transform.position.y;



        while (true)
        {
            tiempoActual += Time.deltaTime;
            ratioTiempo = tiempoActual / tiempoMaximoCrecimiento;//esta división sólo puede dar valores comprendidos entre 0 y 1
            

            gameObject.transform.localScale = new Vector3(1,1,1) * ratioTiempo;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, (posY - offsetY * ratioTiempo), gameObject.transform.position.z);


            if (tiempoActual >= tiempoMaximoCrecimiento)
            {

               

                break;//rompemos while pues ha pasado el tiempo

            }


                    yield return null;
        
        
        }
        




    }

    private void OnTriggerEnter(Collider other)
    {

       
        if (other.gameObject.CompareTag("Player"))
        {
            print("Colisión vegetal con Player");
            manager.GetComponent<gameManager>().recargaStamina2(valorStamine);
            Destroy(gameObject);
        }
    }

}
