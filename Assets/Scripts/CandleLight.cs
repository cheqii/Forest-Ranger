using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLight : MonoBehaviour
{
    [SerializeField] private GameObject candleLight;
    [SerializeField] private bool alwaysOn = false;
    [SerializeField] private float raycastDistance = 10f;
    [SerializeField] private LayerMask detectionLayer;

    public Enemy enemy;
    private bool lightOn = false;

    // Start is called before the first frame update
    void Start()
    {
        if (alwaysOn)
        {
            candleLight.SetActive(true);
            lightOn = true;
        }
        else
        {
            candleLight.SetActive(false);
            lightOn = false;
        }

        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            enemy.GetComponent<Enemy>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            LitCandle(true);
            //candleLight.SetActive(true);
        }

        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            LitCandle(false);
            //candleLight.SetActive(false);
        }*/

        if (lightOn)
        {
            Ray ray = new Ray(transform.position, transform.up);

            if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance, detectionLayer))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    enemy.RandomWarpEnemy();
                }
            }
            Debug.DrawRay(ray.origin, ray.direction * raycastDistance);
        }
    }

    public void LitCandle(bool lit)
    {
        if (!alwaysOn)
        {
            if (lit)
            {
                candleLight.SetActive(true);
                lightOn = true;
            }
            else
            {
                candleLight.SetActive(false);
                lightOn = false;
            }
        }
    }
}
