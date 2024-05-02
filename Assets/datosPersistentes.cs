using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class datosPersistentes : MonoBehaviour
{
    // Start is called before the first frame update

    public float Stamine;
    public Vector3 positionPlayer;



    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

   
}
