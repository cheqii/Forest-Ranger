using UnityEngine;

[CreateAssetMenu]
public class DialogueData : ScriptableObject
{
    public AudioClip[] audioClips;
    [TextArea(3, 10)]
    public string[] dialogueText;
    public float delayBetweenText = 5f;
}