using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
using TMPro;
using UnityEngine.SceneManagement;


public class E_EscenaFinal : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject Difuminado;
    public GameObject Jugador;
    public GameObject Agradecimiento;


    void OnTriggerEnter(){
        StartCoroutine(Final());
    }

    IEnumerator Final(){
        Jugador.GetComponent<FirstPersonController>().enabled = false;
        TextBox.GetComponent<TextMeshProUGUI>().text="Per fi puc sortir d'aquí!";
        TextBox.SetActive(true);
        yield return new WaitForSeconds(5);
        TextBox.GetComponent<TextMeshProUGUI>().text="";
        Difuminado.SetActive(true);
        yield return new WaitForSeconds(3);
        TextBox.GetComponent<TextMeshProUGUI>().text="Denki. Nala. Ja vaig de camí amb vosaltres!";
        yield return new WaitForSeconds(5);
        TextBox.GetComponent<TextMeshProUGUI>().text="";
        TextBox.SetActive(false);
        Agradecimiento.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(4);


    }
}
