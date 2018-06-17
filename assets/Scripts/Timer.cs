using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Timer : MonoBehaviour {
    GameObject timer;
    Text timerText;
	// Use this for initialization
	void Start () {
        timer = GameObject.Find("TimeText");
        timerText = timer.GetComponent<Text>();
        timerText.text = "Time: " + Time.time.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        timerText.text = "Time: " + Time.time.ToString();
	}
}
