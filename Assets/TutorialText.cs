using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

[Serializable]
public class TextWithObject
{
    public string text;
    public GameObject gameObject;
}

public class TutorialText : MonoBehaviour
{
    public List<TextWithObject> allTextWithObjects = new List<TextWithObject>();
    public TextMeshPro Text;
    private int currentTextIndex = 0;


    private void NextTextDelay()
    {
        currentTextIndex++;

        if (currentTextIndex > allTextWithObjects.Count - 1)
        {
            Text.color = Color.white;
            Text.text = "Tutorial End";
            return;
            //end
        }
        else
        {
            Text.text = allTextWithObjects[currentTextIndex].text;
        }

        RefreshQuest();

        Text.color = Color.white;
    }

    public void NextText(int _delay)
    {
        Text.color = Color.green;
        Invoke(nameof(NextTextDelay), _delay);
    }

    
    
    private void RefreshQuest()
    {
        allTextWithObjects[currentTextIndex].gameObject.SetActive(true);
    }
}
