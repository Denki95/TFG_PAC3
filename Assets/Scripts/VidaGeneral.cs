using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaGeneral : MonoBehaviour
{
    public static int VidaActual = 20;
    public int VidaInterna;

    void Update()
    {
        VidaInterna = VidaActual;

        if(VidaActual <= 0){
            SceneManager.LoadScene(3);
        }
    }
}
