using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDirection : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private Transform destination;

    [SerializeField] private LineRenderer line;

    [SerializeField] private Transform carPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            print("show line?");
            LeadPlayerToDestination();
        }
        
        line.SetPosition(0, playerPos.transform.position);
    }

    public void LeadPlayerToDestination()
    {
        line.gameObject.SetActive(true);
        //line.SetPosition(0, playerPos.transform.position);
        line.SetPosition(1, destination.transform.position);
        line.SetPosition(2, carPos.transform.position);
    }
}
