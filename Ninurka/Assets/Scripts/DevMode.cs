using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DevMode : MonoBehaviour {
    public int devMode = 0;
    NavMeshAgent agent;
    public float devLevelZero;
    public float devLevelOne = 10f;
    public float devLevelTwo = 50f;
    public float devLevelThree = 100f;
    public float devLevelFour = 1000f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            devMode = 0;
        }
            
        if (devMode == 0)
        {
            DefaultNavMesh();
        }

    if (Input.GetKeyDown(KeyCode.Tab))
        {
            agent.angularSpeed = 2880;
            agent.acceleration = 1000;
            if (devMode == 0)
            {
                devMode = 1;
                agent.speed = devLevelOne;
            }
            else if (devMode == 1)
            {
                devMode = 2;
                agent.speed = devLevelTwo;
            }
            else if (devMode == 2)
            {
                devMode = 3;
                agent.speed = devLevelThree;
            }
            else if (devMode == 3)
            {
                devMode = 4;
                agent.speed = devLevelFour;
            }
            else if (devMode == 4)
            {
                devMode = 0;
                agent.speed = devLevelZero;
            }
        }
        
    }

    public void DefaultNavMesh()
    {
        agent.angularSpeed = 120;
        agent.acceleration = 8;
    }

}
