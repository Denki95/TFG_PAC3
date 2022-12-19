using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject MenuPausa;
    public GameObject Jugador;
    void Update()
    {
        if(Input.GetButtonDown("Pausa")){
            if(isPaused){
                Resume();
            } else{
                Pause();
            }
        }
    }
    void Resume(){
        Jugador.GetComponent<FirstPersonController>().enabled = true;
        MenuPausa.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
    }
    void Pause(){
        Jugador.GetComponent<FirstPersonController>().enabled = false;
        MenuPausa.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        isPaused = true;
    }

    public void Continuar(){
        Jugador.GetComponent<FirstPersonController>().enabled = true;
        MenuPausa.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
    }
    public void CargarMenu(){
        SceneManager.LoadScene(1);
    }
    public void SalirJuego(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
