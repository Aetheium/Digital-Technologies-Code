using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveRandomly : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    NavMeshPath path;
    public float timeForNewPath;
    public float randRange;
    bool inCoRoutine = false;
    bool inCoRoutine1 = false;
    Vector3 target;
    public GameObject self;
    public float waitforseconds;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(ExampleCoroutine());
        path = new NavMeshPath();
    }
    
    void Update()
    {
        if (Input.GetKey("k"))
        {
            Destroy(gameObject);
            Debug.Log("Killed all.");
        }

        if (!inCoRoutine)
            StartCoroutine(DoSomething());

        if (!inCoRoutine1)
            StartCoroutine(ExampleCoroutine());
    }

    Vector3 getNewRandomPosition()
    {
        float x = Random.Range(-randRange, randRange);
        float z = Random.Range(-randRange, randRange);

        Vector3 pos = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        return pos;
    }
    
    IEnumerator DoSomething()
    {
        inCoRoutine = true;
        yield return new WaitForSeconds(timeForNewPath);
        GetNewPath();
        if (!navMeshAgent.CalculatePath(target, path)) Debug.Log("Found Invalid Path");
        inCoRoutine = false;
    }

    void GetNewPath()
    {
        target = getNewRandomPosition();
        navMeshAgent.SetDestination(target);
    }

    IEnumerator ExampleCoroutine()
    {
        inCoRoutine1 = true;
        yield return new WaitForSeconds(waitforseconds);
        Instantiate(self, transform.position, Quaternion.identity);
        ExampleCoroutine();
        inCoRoutine1 = false;
    }
}