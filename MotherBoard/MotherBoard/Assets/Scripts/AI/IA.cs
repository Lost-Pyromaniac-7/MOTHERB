using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject destination1;
    public GameObject destination2;
    
    private GameObject player;
    [Header("---------- Follow Player --------")]
    public bool followPlayer;
    private float distanceToPlayer;
    public float distanceToFollowPlayer = 100;

    void Start()
    {
        navMeshAgent.destination = destination1.transform.position;
        player = FindAnyObjectByType<FirstPersonController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {      

        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distanceToPlayer <= distanceToFollowPlayer && followPlayer){
            FollowPlayer();
        }else{
            float distance = Vector3.Distance(transform.position, destination1.transform.position);

            if(distance<2){
                navMeshAgent.destination = destination2.transform.position;
            }
        }
        
    }

    public void FollowPlayer(){
        navMeshAgent.destination = player.transform.position;
    }

}
