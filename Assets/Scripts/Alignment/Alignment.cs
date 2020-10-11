using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alignment : MonoBehaviour
{
	public float minV = 5.0f;
	public float maxV = 20.0f;
	public int numPrefabs = 3;
	public GameObject prefab;
	public GameObject target;

	public Vector3 center;
	public Vector3 velocity;

	public GameObject[] sphereGroup;


	void Start(){
		sphereGroup = new GameObject[numPrefabs];

		for(int i = 0; i < numPrefabs; i++){
			Vector3 position = new Vector3(
				Random.value * GetComponent<Collider>().bounds.size.x,
				Random.value * GetComponent<Collider>().bounds.size.y,
				Random.value * GetComponent<Collider>().bounds.size.z
			);

			GameObject sphere = Instantiate(prefab,transform.position, transform.rotation) as GameObject;
			sphere.transform.parent = transform;
			sphere.transform.localPosition = position;
			sphereGroup[i] = sphere;
		}

	}

}
