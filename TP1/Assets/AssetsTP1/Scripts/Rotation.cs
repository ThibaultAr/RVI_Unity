using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public float vitesse = 1.0f;

	// Use this for initialization
	void Start () {
        Debug.Log(this.name);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, Time.deltaTime * vitesse, 0);
	}
}
