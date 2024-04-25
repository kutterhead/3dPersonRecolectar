using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class semilla : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] prefabPlant;//estos vegetales crecen de la semilla
    public int tipoSemilla = 0;

    void Start()
    {



        //debe iniciar en start pues la semilla acaba de aparecer
        StartCoroutine(plantartemporizado());//arranca la corrutina en el start que el cuando aparece



        //tipoSemilla = Random.Range(0,3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator plantartemporizado()//pone una planta transcurrido un tiempo
    {


        yield return new WaitForSeconds(3);
        plant();//se planta la semilla





    }
    void plant()
    {

        Destroy(gameObject);

        //por si acaso compruebo que está dentro del índice
        if (tipoSemilla< prefabPlant.Length)
        {
            Instantiate(prefabPlant[tipoSemilla], transform.position, transform.rotation);
        }
        

    }

}
