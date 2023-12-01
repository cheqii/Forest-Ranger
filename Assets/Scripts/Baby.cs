using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;

public class Baby : MonoBehaviour
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
        agent.SetDestination(player.transform.position);
        if (agent.stoppingDistance + 0.1f < _interactObject.TargetDistance)
            animator.SetBool("isWalk", true);
        else
            animator.SetBool("isWalk", false);
    }

    public void DestroyKid()
    {
        Destroy(this.gameObject);
    }
}
