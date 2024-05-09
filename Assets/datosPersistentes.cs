using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class datosPersistentes : MonoBehaviour
{
    // Start is called before the first frame update

    public int saldo;
    public float Stamine;
    public Vector3 positionPlayer;



    private void Awake()
    {

        GameObject persistentes = GameObject.FindGameObjectWithTag("datosPersistentes");

        if (persistentes != null && persistentes != gameObject)
        {
            //se destruye pues hay otro archivo con datos persistentes heredado de la pantalla anterior
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }



        
    }
    void Start()
    {
        
    }

   
}
