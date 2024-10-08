using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarTrigger : MonoBehaviour
{
    public List<GameObject> WinObjects;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var v in WinObjects)
            {
                v.SetActive(true);
                if (v.TryGetComponent<TextMeshProUGUI>(out var _text))
                {
                    _text.color = Color.yellow;
                    _text.text = "Mission Completed!";
                }
            }
            Invoke(nameof(RestartGame),5);
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
