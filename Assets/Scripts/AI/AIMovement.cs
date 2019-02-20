using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public Animator ani;
    public NavMeshAgent navMesh;
    public Transform target;

    private void Update()
    {
        navMesh.SetDestination(new Vector3(target.position.x, target.position.y, target.position.z));
        ani.SetBool("walking", true);
    }
}
