using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCreation : MonoBehaviour {

    public GameObject original;
    public GameObject plane;
    float zPos;
    public Camera cam;

	// Use this for initialization
	void Start () {
        //cam = GetComponent<Camera>();
        zPos = original.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            float rayDistance;
            Ray ray = cam.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            Plane p = new Plane(plane.transform.right, plane.transform.position);
            p.Raycast(ray, out rayDistance);
            Instantiate(original, ray.GetPoint(rayDistance), Quaternion.identity, transform);
        }
	}
}
