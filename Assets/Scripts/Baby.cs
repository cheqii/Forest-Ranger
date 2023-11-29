using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;

public class Baby : MonoBehaviour, IInteractableObject
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
        if (isRescue) agent.SetDestination(player.transform.position);
    }

    public void Interactable()
    {
        Debug.Log("Rescue");
        isRescue = true;
    }
}
