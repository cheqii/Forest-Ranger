using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private GameObject questGroup;
    [SerializeField] private TextMeshProUGUI questInfoText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            questGroup.SetActive(true);
        }
        else
        {
            questGroup.SetActive(false);
        }
    }

    public void ChangeTextInfo(string info)
    {
        questInfoText.text = info;
    }
}
