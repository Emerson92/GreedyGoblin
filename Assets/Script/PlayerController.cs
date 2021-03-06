﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    public float speed = 10;

    public static int count;

    public Text countText;

    public Text winText;
    public Text lifeText;
    private Transform _transform;
    public Object explore;
    private int life = 0;
    private Animator _animation;
    public static bool isDeathing = false;
    private AudioSource[] _AudioS;
    public GameObject SpeedRing;
    public GameObject ProtectRing;
    private bool isVisible = false;
    private bool isAddSpeeding = false;
    private bool isAddProtecting = false;
    private float SpeedTime = 0;
    private float ProtectTime = 0;
    public GameObject restarButton;
    private Vector3 StartPositoin;

    public void Start()
    {
        //rb = GetComponent<Rigidbody>();
        _transform = this.GetComponent<Transform>();
        StartPositoin = _transform.position;
        count = 0;
<<<<<<< HEAD
        if (lifeText !=null) { 
        lifeText.text = "Life:" + life.ToString();
        }
=======
        lifeText.text = "Life:" + life.ToString();
>>>>>>> c8abdcf36ff1611ab7d8600a835c952cfdd9709c
        setCountext();
        _animation = this.GetComponent<Animator>();
        _AudioS = this.GetComponents<AudioSource>();
    }
    void Update() {
        if (isAddSpeeding) {
            if (SpeedTime > 5)
            {
                setSpeedingToShutDown();
                SpeedTime = 0;
                isAddSpeeding = false;
            }
            else {
                SpeedTime += Time.deltaTime;
            }
        }
        if (isAddProtecting) {
            if (ProtectTime > 5)
            {
                setProtectRingToShutDown();
                ProtectTime = 0;
                isAddProtecting = false;
            }
            else {
                ProtectTime += Time.deltaTime;
            }
        }
    }
    public void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(
            moveHorizontal * Time.deltaTime * speed,
            0.5f,
            moveVertical * Time.deltaTime * speed
            );
        _transform.position = new Vector3(
            Mathf.Clamp(_transform.position.x + movement.x, -9.3f, 9.4f),
            0.5f,
            Mathf.Clamp(_transform.position.z + movement.z, -9.36f, 9.06f)
            ); ;

        //rb.AddForce(movement * speed);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("goldchest"))
        {
            //Debug.Log("onTrigger");
            other.gameObject.SetActive(false);
            count += 1;
            setCountext();
            if (count % 5 == 0 && count !=0)
            {
                life += 1;
                lifeText.text = "Life:" + life.ToString();
                _AudioS[4].Play();
            }
            _AudioS[1].Play();
        }
        else if (other.gameObject.CompareTag("goldspeedchest"))
        {
            if (!isAddSpeeding)
            {
                SpeedRing.SetActive(true);
<<<<<<< HEAD
                MoveJoystick.Speed = 0.45f;
=======
                MoveJoystick.Speed = 0.15f;
>>>>>>> c8abdcf36ff1611ab7d8600a835c952cfdd9709c
                isAddSpeeding = true;
                //Invoke("setSpeedingToShutDown", 5);
            }
            else {
                SpeedTime = 0;
            }
            _AudioS[2].Play();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("golddragon"))
        {
            if (!isAddProtecting)
            {
                ProtectRing.SetActive(true);
                isVisible = true;
                isAddProtecting = true;
                _AudioS[3].Play();
                //Invoke("setProtectRingToShutDown", 5);
            }
            else {
                ProtectTime = 0;
            }
            _AudioS[1].Play();
            Destroy(other.gameObject);
        }
        else if (other.tag.Equals("glaive"))
        {
            if (!isDeathing)
            {
                if (!isVisible)
                {
                    if (life == 0)
                    {
                        Instantiate(explore, _transform.position, Quaternion.identity);
                        //Destroy(this.gameObject);s
<<<<<<< HEAD
                        _animation.SetBool("GobinRun",false);
=======
>>>>>>> c8abdcf36ff1611ab7d8600a835c952cfdd9709c
                        _animation.SetBool("Death", true);
                        winText.text = "YOU LOSE!";
                        isDeathing = true;
                        restarButton.SetActive(true);
                    }
                    else {
                        _AudioS[5].Play();
                        life -= 1;
                        lifeText.text = "Life:" + life.ToString();
                    }
                }
            }
        }

    }

    public void setCountext()
    {
<<<<<<< HEAD
        if (countText != null) { 
            countText.text = "Count :" + count.ToString();
            winText.text = "";
        }
=======
        countText.text = "Count :" + count.ToString();
        winText.text = "";
>>>>>>> c8abdcf36ff1611ab7d8600a835c952cfdd9709c
    }

    void setSpeedingToShutDown()
    {
        SpeedRing.SetActive(false);
<<<<<<< HEAD
        MoveJoystick.Speed = 0.3f;
=======
        MoveJoystick.Speed = 0.1f;
>>>>>>> c8abdcf36ff1611ab7d8600a835c952cfdd9709c
    }
    void setProtectRingToShutDown()
    {
        isVisible = false;
        ProtectRing.SetActive(false);

    }
    public void restartTheGame() {
        //Application.LoadLevel(0);
        //SceneManager.LoadScene(0);
        count = 0;
        life = 0;
        ProtectRing.SetActive(true);
        isVisible = true;
        isAddSpeeding = false;
        isAddProtecting = true;
        SpeedTime = 0;
        ProtectTime = 0;
        _transform.position = StartPositoin;
        PlayerController.isDeathing = false;
        _animation.SetBool("Death", false);
        restarButton.SetActive(false);
        setCountext();
        lifeText.text = "Life:" + life.ToString();
    }
}
