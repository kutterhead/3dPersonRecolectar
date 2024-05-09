using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class tiendaManager : MonoBehaviour
{

    public GameObject persistentData;//script usado para pasar datos entre escenas

    // Start is called before the first frame update

    public TextMeshProUGUI infoText;
    public TextMeshProUGUI saldoText;
    public TextMeshProUGUI textoCarro;

    public GameObject panelConfirma;

    string tempCarro;//valor temporal del carro



    public int saldo;//cantidad total €
    //public int carro;//cantidad € del carro


    public int carroCompra;
    private void Awake()
    {
        persistentData = GameObject.FindGameObjectWithTag("datosPersistentes");
    }


    void Start()
    {
        


        panelConfirma.SetActive(false);


    carroCompra = 0;//el carro empieza valiendo cero

        //esta variable seria asignada al cargar la escena
        saldo = 100;



        saldoText.text = saldo.ToString() + " €";
        

    }


    public void SumarCarro(int valor)
    {
       


        //sólo es texto para visualizar


        if (carroCompra == 0)
        {
            tempCarro = valor.ToString();

        }
        else
        {
            tempCarro = tempCarro + " + " + valor;
        }

        carroCompra += valor;//se almacena el total en carroCompra


        textoCarro.text = tempCarro.ToString() + " = " + carroCompra + " €";

    }

    public void eliminarCarro()
    {
        carroCompra = 0;
        textoCarro.text = "";
        tempCarro = "";
    }

    public void muestraPanelConfirma()
    {
        panelConfirma.SetActive(true);

    }

    public void ocultaPanelConfirma()
    {
        panelConfirma.SetActive(false);

    }




    public void comprarCarro()
    {
        if (carroCompra <= saldo)
        {
            
            saldo -= carroCompra;
            saldoText.text = saldo.ToString() + " €";
            eliminarCarro();
            escribeDatosPersistentes();
            panelConfirma.SetActive(false);//desactiva panel de confirmación
            infoText.text = "Compra realizada con éxito";
        }
        else
        {
            infoText.text = "No se ha podido realizar la compra ,saldo insuficiente.";


        }


    }




    public void escribeTextoMensaje(string mensaje)
    {
        infoText.text = mensaje;


    }

    public void borraTextoMensaje()
    {
        infoText.text = "";

    }

    public void escribeDatosPersistentes()
    {

        persistentData.GetComponent<datosPersistentes>().saldo = saldo;

        //algunas variables no hará falta cambiarlas porque conserva el valor que traían.

        //persistentData.Stamine = 

    }
}
