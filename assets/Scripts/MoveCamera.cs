using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
	public Rigidbody2D rb;
    public GameObject car;
    private Vector3 offset;
    private Vector3 temp;
	// Use this for initialization
	void Start () {
        car = GameObject.Find("Car");
        offset = transform.position - car.transform.position;

	}
	
	// Update is called once per frame
	void LateUpdate () {
        temp = car.transform.position + offset;

		transform.position = new Vector3(temp.x +  (rb.velocity.x / 6f),0,-1);
	}
}
