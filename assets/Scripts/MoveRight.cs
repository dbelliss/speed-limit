using UnityEngine;
using System.Collections;

public class MoveRight : MonoBehaviour {
    public static float thrust=5;
    private Rigidbody2D rb;
	public Camera cam;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        StartCoroutine(addForce());
        if (thrust<=0)
        {
            thrust = 0;
        }	


		cam.orthographicSize = 5.0f + (rb.velocity.x / 10f);
		print (rb.velocity.x);

	}
    IEnumerator addForce()
    {
        rb.AddForce(transform.right * thrust);
        yield return new WaitForSeconds(2f);       
    }
}
