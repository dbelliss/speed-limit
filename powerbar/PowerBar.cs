using UnityEngine;
using System.Collections;

public class PowerBar : MonoBehaviour {
    public UnityEngine.UI.Slider powerSlider;

	// Use this for initialization
	void Start () {
        powerSlider.value = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "obstacle")
            powerSlider.value -= 1;
        if (other.gameObject.tag == "boost")
            powerSlider.value += 1;
    }
}
