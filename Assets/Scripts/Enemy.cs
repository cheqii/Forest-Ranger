using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private GameObject target;
        [SerializeField] private List<Transform> warpPosition = new List<Transform>();
        

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            target = GameObject.FindGameObjectWithTag("Player");
        }
     
        
        void Update()
        {
            //agent.SetDestination(target.transform.position);
            Vector3 target = this.target.transform.position;
            seek(target);

            /*if (Input.GetKeyDown(KeyCode.Space))
            {
                RandomWarpEnemy();
            }*/
        }
     
        private void seek(Vector3 location)
        {
            agent.SetDestination(location);
        }
     
        private void Flee(Vector3 location)
        {
            agent.SetDestination(this.transform.position - location + this.transform.position);
        }
     
        private void Pursue()
        {
            Vector3 targetDir = target.transform.position - this.transform.position;
            float playerSpeed = target.GetComponent<NavMeshAgent>().velocity.magnitude;
            float lookAhead = targetDir.magnitude / (agent.speed + playerSpeed);
            seek(target.transform.position + target.transform.forward * lookAhead);
        }
     
        private void Evade()
        {
            Vector3 targetDir = target.transform.position - this.transform.position;
            float playerSpeed = target.GetComponent<NavMeshAgent>().velocity.magnitude;
            float lookAhead = targetDir.magnitude / (agent.speed + playerSpeed);
            Flee(target.transform.position + target.transform.forward * lookAhead);
        }

        public void RandomWarpEnemy()
        {
            int randomWrapIndexLocation = Random.Range(0, warpPosition.Count);

            Transform randomWarp = warpPosition[randomWrapIndexLocation];
            transform.position = randomWarp.position;
        }
}
