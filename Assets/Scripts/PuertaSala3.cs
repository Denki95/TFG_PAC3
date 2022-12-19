using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuertaSala3 : MonoBehaviour
{
 //Clases Script
    public float Distancia;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject TextBox;
    public GameObject ExtraCross;
    public AudioSource Cerrado;
    public AudioSource Abierto;
    public GameObject Puerta;
    public AudioSource Golpe;

    void Update()
    {
        //Cogemos distancia del script player_casting para aplicarlo al arma
        Distancia = Player_Casting.DistanceFromTarget;

    }

    
    void OnMouseOver(){
        //Con la distancia establecida se muestran los mensajes de texto
        if(Distancia <= 3){
            ExtraCross.SetActive(true);
            ActionText.GetComponent<TextMeshProUGUI>().text ="Obrir";
            ActionDisplay.SetActive (true);
            ActionText.SetActive (true);
        }
        //Acciones activadas al apretar el boton
        if(Input.GetButtonDown("Action")){
            if (Distancia <= 3){
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                ExtraCross.SetActive(false);
                StartCoroutine(PuertaBloqueada());
            }
        }
    }
    //Al retirar raton de la puerta desaparecen los mensajes de texto
    void OnMouseExit(){
        ExtraCross.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    IEnumerator PuertaBloqueada(){
        if(Inventario.LlaveExtintor == false){
        Cerrado.Play();
        TextBox.SetActive(true);
        TextBox.GetComponent<TextMeshProUGUI>().text = "Està tancada...";
        yield return new WaitForSeconds(2);
        TextBox.SetActive(false);
        TextBox.GetComponent<TextMeshProUGUI>().text = "";
        this.GetComponent<BoxCollider>().enabled = true;
        }
        else{
            Puerta.GetComponent<Animation>().Play("PuertaSala3");
            Abierto.Play();
            yield return new WaitForSeconds(2.4f);
            Golpe.Play();
        }
    }
}
