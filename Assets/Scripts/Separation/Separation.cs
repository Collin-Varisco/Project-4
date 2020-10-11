using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separation : MonoBehaviour
{
    public Transform sphere1;
    public Transform sphere2;
    public float moveSpeed = 6.0f;
    private float minDistance = 10.0f;


    // Update is called once per frame
    void Update()
    {
	// Calls Separate() once per frame
	Separate();
    }

    void Separate(){
	Vector3 distance1 = sphere1.position - transform.position;
	Vector3 distance2 = sphere2.position - transform.position;

	if(distance1.magnitude < minDistance || distance2.magnitude < minDistance){
		// condition for middleSphere separation movement
		if(transform.position.x > sphere1.position.x && transform.position.x < sphere2.position.x){
			// initializes next point to move the ball to until it is at the minimum distance it should be
			Vector3 moveForward = new Vector3(0, 0, transform.position.x+1);
			Vector3 moveVector = moveForward.normalized*moveSpeed*Time.deltaTime;

			transform.position += moveVector;
		}


		// condition for leftSphere movement
		if(transform.position.x < sphere1.position.x && transform.position.x < sphere2.position.x){
				Vector3 leftMoveVector = distance1.normalized * moveSpeed * Time.deltaTime;
				transform.position -= leftMoveVector;
		}

		// Condition for rightSphere movement
		if(transform.position.x > sphere1.position.x && transform.position.x > sphere2.position.x){
			Vector3 rightMoveVector = distance2.normalized * moveSpeed * Time.deltaTime;
			transform.position -= rightMoveVector;

		}
	}


    }



}
