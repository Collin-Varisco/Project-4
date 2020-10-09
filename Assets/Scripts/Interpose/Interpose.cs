using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpose : MonoBehaviour
{

    public Transform target1;
    public Transform target2;
    public float moveSpeed = 6.0f;
    private float minDistance = 0.2f;


    // Update is called once per frame
    void Update()
    {
	// Calls Interpose() every frame
	InterposeObject();
    }

    void InterposeObject()
    {

	// difference between vectors divided by two will give midpoint
	Vector3 mid = (target1.position - target2.position) - transform.position;

	Vector3 midPoint = mid - transform.position;

	// Check to see if interpose process is completed
	if(midPoint.magnitude > minDistance)
	{
		Vector3 moveVector = mid.normalized*moveSpeed*Time.deltaTime;

		// If condition is met, continue moving to the midpoint between targets
		transform.position += moveVector;

	}
    }
}
