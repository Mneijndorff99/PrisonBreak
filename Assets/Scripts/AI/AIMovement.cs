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
    public enum States { Walking, Searching, Chasing, Idle};
    public States state;
    Vector3 lastSeen;
    void Start()
    {
        navMesh.autoBraking = false;
        ani.SetBool("walking", true);
        SetState(States.Walking);
        StartCoroutine("WaitForNextWaypoint");
    }

    void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        
        //if (!navMesh.pathPending && navMesh.remainingDistance < 0.5f)
        //    SetState(States.Idle);
        bool canSee = CanSeeTarget();

        if (canSee && state == States.Walking)
        {
            SetState(States.Chasing);
        }

        if (!canSee)
        {
            if (state == States.Searching)
            {
                SetState(States.Walking);
            }
            if(state == States.Chasing)
            {
                SetState(States.Searching);
            }
        }

        switch (state)
        {
            case States.Walking:
                break;
            case States.Searching:
                if (navMesh.remainingDistance < .5f)
                    SetState(States.Walking);
                break;
            case States.Chasing:
                if (CanSeeTarget())
                {
                    navMesh.SetDestination(player.transform.position);
                }
                else
                {
                    SetState(States.Searching);
                }
                break;
        }
        //if (!navMesh.pathPending && navMesh.remainingDistance < 0.5f)
        //    StartCoroutine("WaitForNextWaypoint");
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
                navMesh.destination = wayPoints[Random.Range(0, wayPoints.Count)].transform.position;
                ani.SetBool("walking", true);
                aud.Stop();
                break;
            case States.Searching:
                navMesh.SetDestination(lastSeen);
                break;
            case States.Chasing:
                aud.Play();
                lastSeen = player.transform.position;
                break;
            case States.Idle:
                ani.SetBool("walking", false);
                break;
        }

        state = newState;
    }

    public bool CanSeeTarget()
    {
        RaycastHit hit;

        Vector3 direction = player.transform.position - transform.position;
        if (Physics.Raycast(transform.position, direction, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                //Debug.Log("I hitted the player");
                float angle = Vector3.Angle(transform.forward, direction);
                if (angle < fieldOfView / 2)
                {
                    //Debug.Log("the player is in my FOV");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            //Debug.Log("I See nothing");
            return false;
        }
    }

    //IEnumerator WaitForNextWaypoint()
    //{
    //    ani.SetBool("walking", false);
    //    yield return new WaitForSeconds(6);
    //    ani.SetBool("walking", true);
    //    GotoNextPoint();
    //}

    IEnumerator WaitForNextWaypoint()
    {
        while (true)
        {
            if (state == States.Walking)
            {
                Vector3 destination = wayPoints[Random.Range(0, wayPoints.Count)].transform.position;
                Debug.Log(destination);
                navMesh.SetDestination(destination);
                ani.SetBool("Walking", false);
                
            }

            yield return new WaitForSeconds(Random.Range(20, 30));
            SetState(States.Walking);
        }

    }
}

