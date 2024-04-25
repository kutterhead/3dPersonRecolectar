using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{

    public Scrollbar barraStamina;
    private float tiempoBarra;
    public float tiempoBarraMaximo = 4;





    // Start is called before the first frame update
    public GameObject vegetables;//estos vegetales los lleva en la mano
    public GameObject prefabSeed;//solo hay una semilla, su tipo define que planta sale

    public int[] numeroPlantas;



    public Transform plantPoint;
    public GameObject player;
    public GameObject panelInventario;
    public ThirdPersonOrbitCamBasic scriptCam;//para permitir o no la rotación de cámara
    public BasicBehaviour bh;//para bloquear o no el movimiento de player




    public Text textoMensajes;

    public bool puedePlantar = false;

    void Start()
    {
        panelInventario.SetActive(false);
        tiempoBarra = 0f;
        barraStamina.size = 1f;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            vegetables.SetActive(!vegetables.activeSelf);

        }

        if (Input.GetKeyDown(KeyCode.P))
        {

            
            panelInventario.SetActive(!panelInventario.activeSelf);
            scriptCam.enabled = !panelInventario.activeSelf;
            bh.enabled = !panelInventario.activeSelf;
        }


        //disminuye progresivamente la barra de estamina
        if (barraStamina.size > 0)
        {
            tiempoBarra += Time.deltaTime;
            barraStamina.size = (1 - tiempoBarra / tiempoBarraMaximo);
            print("tiempobarra: " + tiempoBarra);

        }
        

    }

    public void recargaStamina(float valor)
    {
        tiempoBarra = 0;
        barraStamina.size += valor;




    }



    //ordena poner una planta desde el canvas
    public void ponerUnaPlanta(int indicePlanta)
    {
        print("planta?");
        if (puedePlantar)//esta dentro del áre dee plantar
        {
            if (numeroPlantas[indicePlanta]>0)
            {


                numeroPlantas[indicePlanta]--;//resta una planta de ese tipo en la lista, sirve para todos los tipos de planta
                player.GetComponent<Animator>().SetTrigger("Plant");
                StartCoroutine(plantartemporizado(indicePlanta));

            }
            else
            {

                print("No quedan plantas de este tipo");
            }
            

        }



    }





    

    IEnumerator plantartemporizado(int indicePlanta)
    {

        yield return new WaitForSeconds(3);

        GameObject semillaGO = Instantiate(prefabSeed, plantPoint.position, plantPoint.rotation);
        semillaGO.GetComponent<semilla>().tipoSemilla = indicePlanta;



    }





}
