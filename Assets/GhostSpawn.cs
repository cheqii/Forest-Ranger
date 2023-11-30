using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawn : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject ghost;

    
    [SerializeField] private float SpawnRate = 30f;

    [SerializeField] private Nf_GameEvent SpawnGhostEvent;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ActivateDeactivateRoutine());
    }


    public void Spawn()
    {
        Ray ray = new Ray(spawnPoints[Random.Range(0, spawnPoints.Length)].position, Vector3.down);
        RaycastHit hit;

        // Draw the ray for debugging
        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);

        if (Physics.Raycast(ray, out hit))
        {
            // Check if the object hit is the ground (you can customize the tag or layer as needed)
            if (hit.collider.CompareTag("Ground"))
            {
                Instantiate(ghost, hit.point, Quaternion.identity);
                SpawnGhostEvent.Raise();
            }
            else
            {
               
            }
        }
    }

    public void DestroySpawner()
    {
        Destroy(this.gameObject);
    }
    
    IEnumerator ActivateDeactivateRoutine()
    {

        Spawn();
        
        
        yield return new WaitForSeconds(SpawnRate);
        // Restart the Coroutine to create a loop
        StartCoroutine(ActivateDeactivateRoutine());
    }

}
