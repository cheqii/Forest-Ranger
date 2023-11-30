using System;
using UnityEngine;

public class RushToPlayer : MonoBehaviour
{
    // Put this script to "MiniJumpScare_RushToPlayer" GameObject
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 30f;
    [SerializeField] private float destroyRange = 2f;

    private void OnEnable()
    {
        player = GameObject.FindWithTag("Player");
    }
    

    private void Update()
    {
        if (player != null)
        {
            MoveTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);

        if((player.transform.position - transform.position).magnitude < destroyRange)
        {
            Destroy(gameObject);
        }
    }
}