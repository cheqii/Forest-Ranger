using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    private Player player;
    private float targetDistance;

    public float TargetDistance
    {
        get => targetDistance;
        set => targetDistance = value;
    }

    [SerializeField] private bool canInteract;

    public bool CanInteract
    {
        get => canInteract;
        set => canInteract = value;
    }
    
    [SerializeField] private bool isInArea;

    [Header("Distance To Get Interact With")] 
    [SerializeField] private float interactRange;

    public Material outlineMat;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        InteractionWithPlayer();
    }

    void InteractionWithPlayer()
    {
        if (player == null) return;
        FindTargetDistance();
        if (targetDistance <= interactRange)
        {
            isInArea = true;
            if (isInArea) outlineMat.SetInt("_isOn", 1);
            // Debug.Log($"Player can interact the {this.gameObject.name} !");
            
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && canInteract || Input.GetKeyDown(KeyCode.Space) && canInteract)
            {
                Debug.Log($"Player have interaction with {gameObject.name}");
                GetComponent<IInteractableObject>().Interactable();
            }
        }
        else
        {
            isInArea = false;
            if (!isInArea) outlineMat.SetInt("_isOn", 0);
        }
    }

    void FindTargetDistance()
    {
        targetDistance = Mathf.Sqrt(Mathf.Pow(this.transform.position.x - player.transform.position.x, 2) + 
                                    Mathf.Pow(this.transform.position.z - player.transform.position.z, 2));
        
        Debug.Log($"distance from player : {targetDistance}");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("InteractArea")) canInteract = true;
        else Debug.Log("Banaana");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("InteractArea")) canInteract = false;
    }
}
