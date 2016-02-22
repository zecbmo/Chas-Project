using UnityEngine;
using System.Collections;

public class moveAfterSpawn : baseDreamClass
{

	// Use this for initialization
	void Start ()
    {
        this.GetComponent<Rigidbody2D>().velocity = (this.transform.up * this.Speed);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
