using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;

public class Graphics : MonoBehaviour {

	public GameObject sphere;
	public GameObject popup;
	SocketIOComponent socketIO;
	public GameObject serverRequest;
	GetNodeInforServerRequestScript getNodeInforServerRequestScript;
	// Use this for initialization
	void Start () {
		Draw ();
		socketIO = GameObject.Find ("SocketIO").GetComponent<SocketIOComponent> ();
		socketIO.On ("globalupdate", OnGlobalUpdateEvent);
	}
	void Update () {
		if (Input.GetMouseButtonUp(0)) {
			RaycastHit hit = new RaycastHit ();
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Physics.Raycast (ray, out hit);
			Vector3 clickPosition = hit.point;
			if (hit.collider!=null) {
				SphereScript ss = hit.collider.GetComponent<SphereScript> ();
				DataHandler.GraphicSceneSelectedNode=ss.textHolder.GetComponent<TextMesh> ().text;
				//ShowPopup ("See node info ?", 2, clickPosition);
				GameObject popupObject = Instantiate(popup) as GameObject;
				Vector3 v = new Vector3 (clickPosition.x, clickPosition.y + 1.0F, clickPosition.z);
				DataHandler.SelectedPopup = popupObject;
				popupObject.transform.position = v;
			}
			else
				Debug.Log ("You haven't clicked on node");

		}

	}
	IEnumerator ShowPopup (string message, float delay,Vector3 vector) {
		GameObject popupObject = Instantiate(popup) as GameObject;	
		Debug.Log("popup");
		//SphereCollider sc = new SphereCollider();
		//sc.enabled=true;
		//sc.gameObject.SetActive (true);
		Vector3 v = new Vector3 (vector.x, vector.y + 1.0F, vector.z - 0.5F);
		//sc.transform.position=v;
		popupObject.transform.position = v;
		yield return new WaitForSeconds(delay);


	}

	public void Draw() {
		
		Debug.Log ("draw");
		//GameObject mainNode = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		GameObject mainNode = Instantiate(sphere) as GameObject;
		SphereScript mainSphereScript = mainNode.GetComponent<SphereScript> ();
		mainSphereScript.textHolder.GetComponent<TextMesh> ().text = DataHandler.SelectedNrds.node.name;
		Vector3 v3Start = new Vector3 (0, 0, -4);
		Vector3 v3End;
		mainNode.transform.position = new Vector3 (0, 0, -4);
		//		mainNode.tag = DataHandler.SelectedNrds.node.name;
		// Camera.main.ScreenToWorldPoint( Vector3(Screen.width/2, Screen.height/2, Camera.main.nearClipPlane) );
		//mainNode.transform.localScale += new  Vector3 (1.0f, 1.0f, 1.0f);

		GameObject s;
		GameObject link;
		//Debug.Log(relationship.Length);
		int circleCount = DataHandler.SelectedNrds.relationships.Count;
		float r = mainNode.GetComponent<SphereCollider> ().radius;
		float largeCircleR = 4 * r;
		int circlesDone = 0;
		float offset = 0;
		int level = 0;

		while (circlesDone < circleCount) {
			float toDrawHere = Mathf.Round(largeCircleR * 3.1416F / (2 * r));
			if (toDrawHere > circleCount - circlesDone)
				toDrawHere = circleCount - circlesDone;

			for (int i = 0; i < toDrawHere; i++) {
				float circleX = largeCircleR * Mathf.Cos (offset + 2 * Mathf.PI * i / toDrawHere);
				float circleY = largeCircleR * Mathf.Sin (offset + 2 * Mathf.PI * i / toDrawHere);
				s = Instantiate(sphere) as GameObject;
				SphereScript nodeSphereScript = s.GetComponent<SphereScript> ();
				if(!DataHandler.SelectedNrds.relationships[circlesDone].end_name.Equals(DataHandler.SelectedNrds.node.name))
					nodeSphereScript.textHolder.GetComponent<TextMesh> ().text = DataHandler.SelectedNrds.relationships[circlesDone].end_name;
				else
					nodeSphereScript.textHolder.GetComponent<TextMesh> ().text = DataHandler.SelectedNrds.relationships[circlesDone].start_name;
				v3End = new Vector3 (circleX,circleY,4*level);
				s.transform.position = v3End;
				//Gizmos.color = Color.blue;
				//Gizmos.DrawLine(startVector, endVector);
				GameObject line = new GameObject ();
				line.AddComponent<LineRenderer> ();
				LineRenderer lineRenderer = line.GetComponent<LineRenderer> ();
				lineRenderer.SetPosition (0, v3Start);
				lineRenderer.SetPosition (1, v3End);
				lineRenderer.SetWidth (0.1f, 0.1f);

				circlesDone++;

			}
			level++;
			largeCircleR += 5 * r;

			offset += Mathf.Asin ((3F * r) / largeCircleR);
		}
		DataHandler.MinX = -largeCircleR;
		DataHandler.MaxX = largeCircleR;
		DataHandler.MaxY = largeCircleR;
		DataHandler.MinY = -largeCircleR;
		DataHandler.MaxZ = 5 * level;
		DataHandler.MinZ = -5 * level;
	}

	public void clearScene() {
		Debug.Log ("clear scene");

		GameObject[] objects = GameObject.FindObjectsOfType<GameObject> ();
		foreach (GameObject o in objects) {
			Debug.Log (o.transform.name);
			if(o.transform.name.Equals("Sphere(Clone)") || o.transform.name.Equals("New Game Object"))
			Destroy (o);
		}
	}

	public void OnGlobalUpdateEvent(SocketIOEvent e) {
		GetNodeInforServerRequestScript getNodeInforServerRequestScript = serverRequest.GetComponent<GetNodeInforServerRequestScript> ();
		getNodeInforServerRequestScript.nodeInformationRequest (DataHandler.SelectedNrds.node._id, onNodeClickCallback);
	}


	public void onNodeClickCallback(NodeRelationshipDataSet nrds)
	{
		// za ovo napravi u DataHandler script jedan Node(singleton moze) koji ce da cuva selektovani Node i
		// i sve info za njega

		DataHandler.SelectedNrds=nrds;
		clearScene ();
		Draw ();
	}
}
