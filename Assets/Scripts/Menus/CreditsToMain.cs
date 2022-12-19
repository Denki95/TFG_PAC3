using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CreditsToMain : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(CreditosAMenu());
    }

    IEnumerator CreditosAMenu(){
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene(1);
    }

}
