using UnityEngine;
using System.Collections;

public class Translate : MonoBehaviour {
    public float moveSpeed = 15f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up*moveSpeed*Time.fixedDeltaTime,Camera.main.transform);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down*moveSpeed*Time.fixedDeltaTime,Camera.main.transform);
        }
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.0f, 4.0f), 0);
    }
}
