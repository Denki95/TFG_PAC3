using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;
using TMPro;

public class C_Pistola : MonoBehaviour
{
    //Variables para la secuencia
    public GameObject Jugador;
    public GameObject TextBox;

    public GameObject Flecha;
    public GameObject Activador;

    void OnTriggerEnter()
    {
        //Desactivamos controles primera persona y comenzamos escena
        Jugador.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(EscenaPistola()); 
    }

    IEnumerator EscenaPistola(){

        //Iniciamos texto escena inicio en la textbox
        TextBox.GetComponent<TextMeshProUGUI>().text="Em fa la sensació que necessitaré allò.";
        TextBox.SetActive(true);

        yield return new WaitForSeconds (2.5f);
        
        //vaciamos textbox
        TextBox.GetComponent<TextMeshProUGUI>().text="";
        TextBox.SetActive(false);

        //activamos controles primera persona
        Jugador.GetComponent<FirstPersonController>().enabled = true;

        //activamos flecha
        Flecha.SetActive (true);

        //desactivamos activador para que no vuelva a salir mensaje
        Activador.SetActive(false);
    }
    
}
