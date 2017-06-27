using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	 public float speed = 5.0F;
    public float rotateAngle = 1.0F;
	

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
			Vector3 currentVector = Camera.main.gameObject.transform.position;
			Vector3 vectorTr = new Vector3 (speed * Time.deltaTime, 0, 0);
			Vector3 vector = currentVector + vectorTr;
			if(checkBoundaries(vector))
				transform.Translate(vectorTr);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
			Vector3 currentVector = Camera.main.gameObject.transform.position;
			Vector3 vectorTr =new Vector3(-speed * Time.deltaTime, 0, 0);
			Vector3 vector = currentVector + vectorTr;

			if (checkBoundaries (vector)) {
				Debug.Log ("radi");
				transform.Translate (vectorTr);
			}
            //transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
			Vector3 currentVector = Camera.main.gameObject.transform.position;
			Vector3 vectorTr =new Vector3(0, -speed * Time.deltaTime, 0);
			Vector3 vector = currentVector + vectorTr;

			if(checkBoundaries(vector))
				transform.Translate(vectorTr);
            //transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
			Vector3 currentVector = Camera.main.gameObject.transform.position;
			Vector3 vectorTr =new Vector3(0, speed * Time.deltaTime, 0);
			Vector3 vector = currentVector + vectorTr;

			if(checkBoundaries(vector))
				transform.Translate(vectorTr);
            //transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
			Vector3 currentVector = Camera.main.gameObject.transform.position;
			Vector3 vectorTr = new Vector3(0,0, speed * Time.deltaTime);
			Vector3 vector = currentVector + vectorTr;

			if(checkBoundaries(vector))
				transform.Translate(vectorTr);
           // transform.Translate(new Vector3(0,0, speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
			Vector3 currentVector = Camera.main.gameObject.transform.position;
			Vector3 vectorTr =new Vector3(0, 0,-speed * Time.deltaTime);
			Vector3 vector = currentVector + vectorTr;

			if(checkBoundaries(vector))
				transform.Translate(vectorTr);
           // transform.Translate(new Vector3(0, 0,-speed * Time.deltaTime));
        }
    }

	public bool checkBoundaries(Vector3 vector) {
		Debug.Log (DataHandler.MaxX);
		Debug.Log (DataHandler.MinX);
		Debug.Log (vector.x);
		if (vector.x > DataHandler.MaxX || vector.x < DataHandler.MinX || vector.y > DataHandler.MaxY || vector.y < DataHandler.MinY 
			|| vector.z > DataHandler.MaxZ || vector.z < DataHandler.MinZ)
			return false;
		else
			return true;
	

	}
}
