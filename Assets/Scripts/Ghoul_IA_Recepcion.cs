using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul_IA_Recepcion : MonoBehaviour
{
    public GameObject Jugador;
    public GameObject Enemigo;
    public float velocidadEnemigo = 5;
    public bool activadorAtaque = false;
    public bool zombieAtaca = false;
    public AudioSource Herida1;
    public AudioSource Herida2;
    public AudioSource Herida3;
    public int HeridaAzar;
    public GameObject Sangrado_Golpe;


    void Update()
    {
        transform.LookAt(Jugador.transform);
        if(activadorAtaque == false && zombieAtaca == false){
            velocidadEnemigo = 5;
            Enemigo.GetComponent<Animator>().Play("Run");
            transform.position = Vector3.MoveTowards(transform.position, Jugador.transform.position, velocidadEnemigo * Time.deltaTime);
        }

        if(activadorAtaque == true && zombieAtaca == false){
            velocidadEnemigo = 0;
            Enemigo.GetComponent<Animator>().Play("Attack2");
            StartCoroutine(InflingeDaño());
        }
    }

    void OnTriggerEnter(){
        activadorAtaque = true;
    }

    void OnTriggerExit(){
        activadorAtaque = false;
    }

    IEnumerator InflingeDaño(){
        zombieAtaca = true;
        HeridaAzar = Random.Range(1, 4);

        if(HeridaAzar == 1){
            Herida1.Play();
        }else if(HeridaAzar == 2){
            Herida2.Play();
        } else if(HeridaAzar == 3){
            Herida3.Play();
        }

        Sangrado_Golpe.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Sangrado_Golpe.SetActive(false);

        yield return new WaitForSeconds(1.1f);
        VidaGeneral.VidaActual -= 5;

        yield return new WaitForSeconds(0.2f);
        zombieAtaca = false;
    }
}
