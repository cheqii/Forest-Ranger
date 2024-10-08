using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarTrigger : MonoBehaviour
{
    private List<GameObject> WinObjects;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var v in WinObjects)
            {
                v.SetActive(true);
            }
            Invoke(nameof(RestartGame),5);
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
