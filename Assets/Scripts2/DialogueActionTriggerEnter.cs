using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueActionTriggerEnter : MonoBehaviour
{
    public DialogueData dialogueData;
    public TMP_Text dialogueText;
    public GameObject centerEyeAnchor;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = centerEyeAnchor.GetComponent<AudioSource>();
    }

    IEnumerator StartDialogue()
    {
        if (dialogueData != null)
        {
            dialogueText.gameObject.SetActive(true);
            AudioClip[] dialogAudio = dialogueData.audioClips;
            string[] sentences = dialogueData.dialogueText;

            for (int i = 0; i < sentences.Length; i++)
            {
                dialogueText.text = sentences[i];

                if (i < dialogAudio.Length && dialogAudio[i] != null)
                {
                    audioSource.clip = dialogAudio[i];
                    audioSource.Play();
                }

                yield return new WaitForSeconds(dialogueData.delayBetweenText);
            }
            //Destroy(dialogueText.gameObject);
            dialogueText.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("DialogueData is not assigned to DialogueAction.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Start dialogue text and sound
            StartCoroutine(StartDialogue());
        }
    }
}