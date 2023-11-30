using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{

    [SerializeField] private Renderer _renderer;
    [SerializeField] private NavMeshAgent ai;
    [SerializeField] private GameObject player;
    
    [Range(0, 100)] public float speed = 0.5f;


    [SerializeField] private float jumpScareRange;

    [SerializeField] private bool isRunAway = false;
    public float RunawayDistance = 10f;
    [Range(0, 300)] public float runawaySpeed = 0.5f;

    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<FPSMovement>().gameObject;
        ai.speed = speed;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRunAway == false)
        {
            WalkToPlayer();
        }
        
        JumpScare();

        if (Input.GetMouseButtonDown(0))
        {
            RunAway();
        }
    }

    private void WalkToPlayer()
    {
        ai.SetDestination(player.transform.position);
    }

    private void JumpScare()
    {
        float distance =  Vector3.Distance (this.transform.position, player.transform.position);
        Debug.Log(distance);
        
        if (distance < jumpScareRange)
        {
            Debug.Log("jump scare");
            Destroy(this.gameObject);
        }
    }

    public void RunAway()
    {
        isRunAway = true;
        ai.speed = runawaySpeed;
        ai.acceleration = 50;
        
        
        if (Vector3.Distance(transform.position, player.transform.position) < RunawayDistance)
        {
            // Calculate a position opposite to the player.
            Vector3 fleeDirection = transform.position - player.transform.position;
            Vector3 fleePosition = transform.position + fleeDirection.normalized * RunawayDistance;

            // Set the destination for the NavMeshAgent to flee.
            ai.SetDestination(fleePosition);
        }


        Destroy(this.gameObject,3f);
    }
}
