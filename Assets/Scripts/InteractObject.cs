using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    private Player player;
    private float targetDistance;

    [SerializeField] private bool canInteract;
    [SerializeField] private bool isInArea;

    [Header("Distance To Get Interact With")] 
    [SerializeField] private float interactRange;

    public Material outlineMat;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().GetComponent<Player>();
        // outlineMat = GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {
        // FindTargetDistance();
        InteractionWithPlayer();
    }

    void InteractionWithPlayer()
    {
        // if (player != null) return;
        FindTargetDistance();
        if (targetDistance <= interactRange)
        {
            isInArea = true;
            if (isInArea) outlineMat.SetInt("_isOn", 1);
            // Debug.Log($"Player can interact the {this.gameObject.name} !");
            
            if (Input.GetKeyDown(KeyCode.Space) && canInteract)
            {
                Debug.Log($"Player have interact with {gameObject.name} already");
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
        
        // Debug.Log($"distance from player : {targetDistance}");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "LeftHand") canInteract = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "LeftHand") canInteract = false;
    }
}
