using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    NavMeshAgent myNav;

    public Transform[] points;
    int destPoint = 0;

    bool turningBack;

    // Use this for initialization
    void Start () {
        myNav = GetComponent<NavMeshAgent>();

        GotoNextPoint();

        
    }
	
	// Update is called once per frame
	void Update () {
        if (!myNav.pathPending && myNav.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }

	}

    void GotoNextPoint()
    {
        

        myNav.destination = points[destPoint].position;

        if (destPoint == points.Length - 1)
        {
            turningBack = true;
        }
        if (destPoint == 0)
        {
            turningBack = false;
        }

        if (turningBack)
        {
            destPoint--;
        }
        else
        {
            destPoint++;
            
        }
        Debug.Log(destPoint);
        Debug.Log(turningBack);
    }
}
