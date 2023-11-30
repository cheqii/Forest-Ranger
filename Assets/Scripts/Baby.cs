using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;

public class Baby : MonoBehaviour, IInteractableObject
{
    private Player player;
    
    private InteractObject _interactObject;
    private NavMeshAgent agent;

    [Header("Animator")]
    [SerializeField] private Animator animator;
    
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
        if (isRescue)
        {
            agent.SetDestination(player.transform.position);
            if (agent.stoppingDistance + 0.1f < _interactObject.TargetDistance)
            {
                // agent.speed = 3;
                // agent.acceleration = 1;
                animator.SetBool("isWalk", true);
                // animator.Play("Walk");
            }
            else
            {
                // agent.speed = 0;
                // agent.acceleration = 0;
                animator.SetBool("isWalk", false);
                // animator.Play("Idle");
            }
        }
    }

    public void Interactable()
    {
        Debug.Log("Rescue");
        isRescue = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        // animator.SetBool("isWalk", false);
        // animator.Play("Idle");
    }

    private void OnCollisionExit(Collision other)
    {
        // animator.SetBool("isWalk", true);
        // animator.Play("Walk");
    }
}
