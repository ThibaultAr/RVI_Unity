using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [ExecuteInEditMode]
public class CameraDualPoint : MonoBehaviour {

    public GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target.transform);
	}
}
