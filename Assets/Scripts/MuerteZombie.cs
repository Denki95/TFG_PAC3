using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteZombie : MonoBehaviour
{
    public int VidaEnemigo = 20;
    public GameObject Enemigo;
    public int StatusCheck;
    public AudioSource musicaAtaque;
    public AudioSource Ambiente1;
    public AudioSource Ambiente2;
    public AudioSource Ambiente3;
    public AudioSource Gruñido1;
    public AudioSource Gruñido2;
    public AudioSource Gruñido3;
    public int AzarGruñido;
    public AudioSource SonidoMuerte;
    public int AmbienteAzar;


    void DañoZombie(int CantidadDaño){
        VidaEnemigo -= CantidadDaño;
    }

    void Update()
    {
        if(VidaEnemigo <= 0 && StatusCheck == 0){
            this.GetComponent<ZombieIA>().enabled = false;
            this.GetComponent<CapsuleCollider>().enabled = false;
            Destroy(this.GetComponent<Rigidbody>());
            StatusCheck = 2;
            AzarGruñido = ZombieIA.GruñidoAzar;
            if(AzarGruñido == 1){
                Gruñido1.Stop();
            }else if(AzarGruñido == 2){
                Gruñido2.Stop();
            }else if(AzarGruñido == 3){
                Gruñido3.Stop();
            }
            SonidoMuerte.Play();
            Enemigo.GetComponent<Animator>().Play("Z_FallingForward");
            musicaAtaque.Stop();

            AmbienteAzar = BandaSonora.BSAzar;
            if(AmbienteAzar == 1){
                Ambiente1.Play();
            } else if(AmbienteAzar == 2){
                Ambiente2.Play();
            } else if(AmbienteAzar == 3){
                Ambiente3.Play();
            }
        }
    }    
    
}
