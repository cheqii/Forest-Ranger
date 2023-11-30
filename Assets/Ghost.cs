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

    [SerializeField] private SkinnedMeshRenderer[] GhostModel;
    
    [Range(0.1f,3)]
    [SerializeField] private float blinkingRate;

    [SerializeField] private AudioSource FleeSfx;
    

    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<FPSMovement>().gameObject;
        ai.speed = speed;
        StartCoroutine(ActivateDeactivateRoutine());

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRunAway == false)
        {
            WalkToPlayer();
        }
        
        JumpScare();

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
        
        FleeSfx.Play(0);

        blinkingRate = 0.2f;


        Destroy(gameObject,3f);
    }
    
    
    IEnumerator ActivateDeactivateRoutine()
    {
        // Activate the Renderer

        foreach (var model in GhostModel)
        {
            model.enabled = true;
        }
        
        // Wait for 1 second
        yield return new WaitForSeconds(blinkingRate);
        
        
        foreach (var model in GhostModel)
        {
            // Deactivate the Renderer
            model.enabled = false;
        }

        // Wait for another 1 second
        yield return new WaitForSeconds(blinkingRate);

        // Restart the Coroutine to create a loop
        StartCoroutine(ActivateDeactivateRoutine());
    }
}
