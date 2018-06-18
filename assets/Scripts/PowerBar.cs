using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PowerBar : MoveRight {
    public UnityEngine.UI.Slider powerSlider;
    GameObject car;
    GameObject camera;

    bool IsMaxPower;
    private Animator animator;
    public GameObject pointText;
    private Text points;
    private int score;

    AudioSource[] sounds;
    const int collisionSound = 0;
    const int speedBoostSound = 1;
    // Use this for initialization
    void Start() {
        powerSlider.value = 0;
        camera = GameObject.Find("Main Camera");

        score = 0;
        IsMaxPower = false;
        animator = GetComponent<Animator>();
        points = pointText.GetComponent<Text>();
        sounds = GetComponents<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (powerSlider.value == 10)
        {
            IsMaxPower = true;
        }
        if (IsMaxPower)
        {
            animator.SetTrigger("MaxPower");

        }
        points.text = "Score: " + score.ToString();
    }
    void FixedUpdate()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(!IsMaxPower)
        {
            if (other.gameObject.CompareTag("Finish"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if (other.gameObject.tag == "obstacle")
            {
                powerSlider.value -= 2;
                MoveRight.thrust -= 2;
                Debug.Log(MoveRight.thrust);
                sounds [collisionSound].Play ();
            }
            if (other.gameObject.tag == "boost")
            {
                powerSlider.value += 2;
                MoveRight.thrust += 2;
                sounds [speedBoostSound].Play ();
            }
        }
        if(IsMaxPower)
        {
            if (other.gameObject.CompareTag("Finish"))
            {
                if (SceneManager.GetActiveScene().buildIndex == 2) {
                    SceneManager.LoadScene(0); // Back to main menu
                }
                else {
                    SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
                }
            }
            if (other.gameObject.CompareTag("obstacle"))
            {
                Destroy(other.gameObject);
                sounds [collisionSound].Play ();
                score++;
            }
           
        }
    }
}
