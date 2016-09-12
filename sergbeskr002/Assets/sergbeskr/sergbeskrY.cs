using UnityEngine;
using System.Collections.Generic;

public class sergbeskrY : MonoBehaviour {

	public float playerSpeed = 5.0f;
	private float currentSpeed = 0.0f;
	private Vector3 lastMovement = new Vector3();
	private float rotatespeed = 3.0f;

	void Start(){

	}

	void Update(){
		float xxx = rotatespeed * Input.GetAxis("Mouse X");
		float yyy = rotatespeed * Input.GetAxis("Mouse Y");

		if(Input.GetAxis("Mouse X")<0){
			RotateBody(xxx, yyy);
		}
		if(Input.GetAxis("Mouse X")>0){
			RotateBody(xxx, yyy);
		}
		if(Input.GetAxis("Mouse Y")<0){
			RotateBody(xxx, yyy);
		}
		if(Input.GetAxis("Mouse Y")>0){
			RotateBody(xxx, yyy);
		}
	}
	
	void RotateBody(float xxx, float yyy){
		this.transform.Rotate (-yyy, 0.0f, 0.0f);
	}
}
