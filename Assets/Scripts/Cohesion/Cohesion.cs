using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Cohesion : MonoBehaviour
{
    public GameObject rigidSphere;
    public static int numPrefabs = 8;
    public GameObject[] spheres = new GameObject[numPrefabs];
    public float velocity = 6.0f;
    public float minDistance = 0.2f;
  


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numPrefabs; i++)
        {
                spheres[i] = Instantiate(rigidSphere, new Vector3(Random.Range(25,50), .5f, Random.Range(25, 50)), Quaternion.identity);
            spheres[i].GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(2, 8), Random.Range(2, 8), Random.Range(2, 8));
        }
    }


    // Update is called once per frame
    void Update()
    {
        SeekTarget();
    }

    void SeekTarget()
    {
        for(int i = 0; i < numPrefabs; i++)
        {
            Vector3 cohesionVector = cohesionMethod(spheres[i]);
            spheres[i].GetComponent<Rigidbody>().velocity = cohesionVector;
                Vector3 moveVector = cohesionVector.normalized * Time.deltaTime;
                spheres[i].transform.position += moveVector;
        }
    }

    Vector3 cohesionMethod(GameObject j)
    {
        Vector3 pv = new Vector3();
        for(int i = 0; i < numPrefabs; i++)
        {
            if (spheres[i] != j)
                pv = pv + spheres[i].transform.position;
        }
        pv = pv / (numPrefabs - 1);
        return (pv - j.transform.position) / 100;
    }
}
