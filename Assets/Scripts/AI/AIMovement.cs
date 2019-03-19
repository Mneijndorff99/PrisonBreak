using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    public float fieldOfView = 110;
    public Animator ani;
    public GameObject player;
    public NavMeshAgent navMesh;
    public Transform target;
    public float distance;
    public List<GameObject> wayPoints;
    public AudioSource aud;
    bool canplay = true;
    bool seePlayer = false;
    public enum States { Walking, Searching, Chasing };
    public States state;
    Vector3 lastSeen;
    void Start()
    {
        navMesh.autoBraking = false;
        ani.SetBool("walking", true);
        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        navMesh.destination = wayPoints[Random.Range(0, wayPoints.Count)].transform.position;
        
        //Debug.Log(navMesh.destination);
    }

    void Update()
    {
        switch (state)
        {
            case States.Walking:
                break;
            case States.Searching:
                break;
            case States.Chasing:
                break;
        }
        if (!navMesh.pathPending && navMesh.remainingDistance < 0.5f)
            StartCoroutine("WaitForNextWaypoint");
        //distance =  Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position);

        //if (distance < 20)
        //{
        //    if(canplay)
        //        aud.Play();
        //    canplay = false;
        //    target = GameObject.FindGameObjectWithTag("Player").transform;
        //    navMesh.destination = new Vector3(target.position.x, target.position.y, target.position.z);
        //}
        //else
        //{
        //    aud.Stop();
        //    canplay = true;
        //}

    }

    public void SetState(States newState)
    {
        switch (newState)
        {
            case States.Walking:
                GotoNextPoint();
                //StartCoroutine("WaitForNextWaypoint");
                break;
            case States.Searching:
                break;
            case States.Chasing:
                target = player.transform;
                break;
        }

        state = newState;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == player)
        {
            Vector3 dir = collision.transform.position - transform.position;
            float angle = Vector3.Angle(dir, transform.forward);

            if (angle < fieldOfView * 0.5f)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position + transform.up, dir.normalized, out hit))
                {
                    if (hit.collider.gameObject == player)
                    {
                        SetState(States.Chasing);
                        Debug.Log("I see the player");
                    }
                    else
                    {
                        SetState(States.Walking);
                    }
                }
            }
        }
    }

    IEnumerator WaitForNextWaypoint()
    {
        ani.SetBool("walking", false);
        yield return new WaitForSeconds(6);
        ani.SetBool("walking", true);
        GotoNextPoint();
    }
}

