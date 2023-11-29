using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Baby : MonoBehaviour
{
    private Player player;
    
    private InteractObject _interactObject;
    private NavMeshAgent agent;

    [SerializeField] private bool isRescue;

    private void Start()
    {
        player = FindObjectOfType<Player>().GetComponent<Player>();
        
        _interactObject = GetComponent<InteractObject>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        PlayerRescue();
    }

    void PlayerRescue()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _interactObject.CanInteract)
        {
            isRescue = true;
        }

        if (isRescue)
        {
            Debug.Log("Rescue");
            agent.SetDestination(player.transform.position);
        }
    }
}
