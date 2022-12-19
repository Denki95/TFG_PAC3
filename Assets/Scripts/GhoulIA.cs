using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using StarterAssets;
using TMPro;

public class GhoulIA : MonoBehaviour
{
    public GameObject ObjetivoGhoul;
    NavMeshAgent AgenteGhoul;
    public GameObject EnemigoGhoul;
    public GameObject SpawnGhoul;
    public static bool Spawn;
    public static bool Persigue;
    public  bool Ataque = false;
    public  bool GhoulAtaca = false;
    public AudioSource Herida1;
    public AudioSource Herida2;
    public AudioSource Herida3;
    public int HeridaAzar;
    public GameObject Sangrado_Golpe;


    //public bool verSpawn;
    //public bool verPersigue;

    void Start()
    {
        AgenteGhoul = GetComponent<NavMeshAgent>();
    }

    void OnTriggerEnter(){
        if(Persigue == false){
            Spawn = true;
        }

        if(Persigue == true && Spawn == false){
            Ataque = true;
        }
    }
    void OnTriggerExit(){
       if(Persigue == true){
            Spawn = false;
        }
        Ataque = false;
        
    }

    void Update()
    {
        //verSpawn = Spawn;
        //verPersigue = Persigue;
        if(Persigue == false){
            SpawnGhoul.GetComponent<BoxCollider>().enabled = true;
            if(Spawn == true){
                AgenteGhoul.GetComponent<NavMeshAgent>().isStopped = true;
                EnemigoGhoul.GetComponent<Animator>().Play("Idle");

            }

            if(Spawn == false){
                SpawnGhoul.SetActive(true);
                AgenteGhoul.GetComponent<NavMeshAgent>().isStopped = false;
                EnemigoGhoul.GetComponent<Animator>().Play("Walk");
                AgenteGhoul.SetDestination(SpawnGhoul.transform.position);
                
            }

        } else{
            SpawnGhoul.SetActive(false);
            SpawnGhoul.GetComponent<BoxCollider>().enabled = false;

        }

        if(Persigue == true && Ataque == false){
            AgenteGhoul.GetComponent<NavMeshAgent>().isStopped = false;
            EnemigoGhoul.GetComponent<Animator>().Play("Walk");
            AgenteGhoul.SetDestination(ObjetivoGhoul.transform.position);
        }

        if(Persigue == true && Ataque == true && GhoulAtaca == false){
            AgenteGhoul.GetComponent<NavMeshAgent>().isStopped = true;
            EnemigoGhoul.GetComponent<Animator>().Play("Attack1");
            StartCoroutine(DañoGhoul());
        }
    }

    IEnumerator DañoGhoul(){
        GhoulAtaca = true;
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
        GhoulAtaca = false;
    }
}
