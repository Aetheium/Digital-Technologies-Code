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
    // variables, pretty simple, the names are almost all self descriptive

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();    // finds the nav agent of the gameobject 
        StartCoroutine(ExampleCoroutine());             // starts the duplication CoRoutine
        path = new NavMeshPath();                       // sets the path for the navigation for an initial destination
    }
    
    void Update()
    {
        if (Input.GetKey("k"))          // Destroys all instancces if the k key is pressed
        {                               //
            Destroy(gameObject);        //
            Debug.Log("Killed all.");   //
        }                               //

        if (!inCoRoutine)                       // if not in a cartain coroutine, start the coroutine
            StartCoroutine(DoSomething());

        if (!inCoRoutine1)
            StartCoroutine(ExampleCoroutine()); // same as above
    }

    Vector3 getNewRandomPosition()
    {
        float x = Random.Range(-randRange, randRange); // picks a number to set the x axis of the path
        float z = Random.Range(-randRange, randRange); // same as above but on the z axis

        Vector3 pos = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z); // makes a vecotr3 variable that puts a mark a location plus or minus the rand numbers
        return pos; // return the new vector
    }
    
    IEnumerator DoSomething()
    {
        inCoRoutine = true;                                                                 // Sets a new path for itself and if its bad, it will give a debug output
        yield return new WaitForSeconds(timeForNewPath);                                    //
        GetNewPath();                                                                       //
        if (!navMeshAgent.CalculatePath(target, path)) Debug.Log("Found Invalid Path");     //
        inCoRoutine = false;                                                                //
    }

    void GetNewPath()
    {
        target = getNewRandomPosition();                // sets the coordinates as the target of the nav
        navMeshAgent.SetDestination(target);            // applies a navigation target from the selected 
    }

    IEnumerator ExampleCoroutine()
    {
        inCoRoutine1 = true;                                            // Duplicates the gameobject every 5 seconds
        yield return new WaitForSeconds(waitforseconds);
        Instantiate(self, transform.position, Quaternion.identity);
        ExampleCoroutine();
        inCoRoutine1 = false;
    }
}