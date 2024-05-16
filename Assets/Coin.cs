using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject manager;
    public GameObject padre;
    public Rigidbody rb;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("gameManager");
        rb.useGravity = true;
        print("Función start moneda ejecutada");

    }

    private void Update()
    {

        //a modo de animación
        gameObject.transform.Rotate(0,100 * Time.deltaTime,0);

        //gameObject.transform.RotateAround(transform.position,transform.up, 10);
    }

    private void OnTriggerEnter(Collider other)
    {

        print("trigger activado con: " + other.gameObject.name);
        rb.useGravity = false;
        rb.velocity = Vector3.zero;

        if (other.gameObject.CompareTag("Player"))
        {
            print("Colisión detectada con player");
            sumaSaldo();
            Destroy(padre);

        }

        
    }

    public void sumaSaldo()
    {
        
        if (manager == null)//si perdió al manager por cambio de escena lo recaptura
        {
            manager = GameObject.FindGameObjectWithTag("gameManager");
        }
        manager.GetComponent<gameManager>().saldo += 10;
    }

}
