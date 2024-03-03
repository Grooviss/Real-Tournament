using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    Health health;
    NavMeshAgent agent;
    public AudioClip rah;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        agent = GetComponent<NavMeshAgent>();
        if (!target) target = GameObject.FindWithTag("Player").transform;
        
    }
    


    // Update is called once per frame
    void Update()
    {
        agent.destination = target.position;
    }
}
