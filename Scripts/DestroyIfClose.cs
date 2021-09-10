using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfClose : MonoBehaviour
{
    public GameObject thePlayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float range = Vector3.Distance(thePlayer.transform.position, transform.position);

        if (range < 20)
        {
            Destroy(gameObject);
        }
    }
}
