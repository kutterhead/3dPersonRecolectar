using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using TMPro;

public class buttonMessage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //public TextMeshProUGUI infoText;
    public GameObject tienda;
    public string mensaje = "";
   // public int valorItem;

    public void Start()
    {
        tienda = GameObject.FindGameObjectWithTag("Tienda");
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        
        print("El ratón está sobre el botón");

        tienda.GetComponent<tiendaManager>().escribeTextoMensaje(mensaje);
        //tienda.GetComponent<tiendaManager>().SumarCarro(valorItem);


    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //infoText.text = "";
        tienda.GetComponent<tiendaManager>().borraTextoMensaje();
    }
}
