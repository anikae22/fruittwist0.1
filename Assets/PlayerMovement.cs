using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{   
    public UIController ui;

    public Camera mainCam;

    [Tooltip("Speed multiplier for Horizontal and Vertical movement.")]
    [Range(5f,50f)]           // adds a slider to drag
    public float speed = 10, jumpForce = 5, dashForce = 5;

    public float resetHeight = -5;

    public Vector3 dir;     // this is the direction we want to add force
    public Vector3 startPosition;      // assign this in Start()

    public bool isGrounded = true;

    public bool canJump = false;       // these don't need to be public

    // get a reference to a rigidbody.
    Rigidbody rb;

     [SerializeField]

     [Header("coinSound")]

    public AudioSource aud;
    public AudioClip coinClip;
    [Range(0f, 1f)]

    public float coinVolume = 0.5f;

     [Header("powerupSound")]

    public AudioSource aud2;
    public AudioClip powerupClip;
    [Range(0f, 1f)]

    public float powerupVolume = 0.5f;

    [Header("vegetableSound")]

    public AudioSource aud3;
    public AudioClip vegetableClip;
    [Range(0f, 1f)]

    public float vegetableVolume = 0.5f;





    void Start() {
        rb = this.GetComponent<Rigidbody>();
        if(ui == null) ui = GameObject.Find("Canvas").GetComponent<UIController>();
        startPosition = GameObject.Find("Start Here").transform.position;
        if(PlayerPrefs.GetInt("canJump") == 1)
        {
            canJump = true;
        }
        ResetPlayer();
        if(mainCam == null) mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
      
    }

    void FixedUpdate() {
        rb.AddForce(dir * speed);

        // if the player falls below the level, reset the player
        if(this.transform.position.y < resetHeight) {
            ResetPlayer();
        }
    }

    

    public void ResetPlayer() {
        this.transform.position = startPosition;        // move player
        rb.velocity = Vector3.zero;                     // set speed to zero
        rb.angularVelocity = Vector3.zero;              // set rotation speed to zero
        this.transform.rotation = Quaternion.identity;  // set rotation to 0,0,0.
    }

    public void Jump() {
        if(isGrounded && canJump) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void Dash()
    {
        if(canDash)
        {
            Debug.Log("I should be dashing.");
        // add dash cool down
        rb.velocity = Vector3.zero;
        rb.AddForce(dir* dashForce, ForceMode.Impulse);
        StartCoroutine(Wait());
        }
    }

    bool canDash = false;

    IEnumerator Wait(float waitTime = 1f)
    {
        canDash = false;       //if true, now it is NOT true
        yield return new WaitForSeconds(waitTime);
        canDash = true;       //if false, now it is NOT false
    }

    int coins = 0;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Floor")) {
            isGrounded = true;
        }

//        if(other.gameObject.CompareTag("Sand"))
  //      {
   //         isGrounded = true;
   //         rb.mass *= 2;       // double the mass of the player
  //      }


          if(other.gameObject.CompareTag("Coin")) {
               aud.PlayOneShot(coinClip);
            ui.UpdateScore();
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("Coinx5")) {
            aud.PlayOneShot(coinClip);
            ui.UpdateScore(5);
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("Coinx25")) {
             aud.PlayOneShot(coinClip);
            ui.UpdateScore(25);
            Destroy(other.gameObject);
        }

        else if(other.gameObject.CompareTag("JumpPowerup"))
        {
            aud2.PlayOneShot(powerupClip);
            canJump = true;
            PlayerPrefs.SetInt("canJump", 1);       // 1 is true, 0 is false
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("AltCam"))
        {
            mainCam.gameObject.SetActive(false);
            other.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if(other.gameObject.CompareTag("DashPowerUp"))
        {
            aud2.PlayOneShot(powerupClip);
            canDash = true;
            PlayerPrefs.SetInt("canDash", 1);
            Destroy(other.gameObject);
        }

        else if(other.gameObject.CompareTag("Vegetable"))
        {
            aud3.PlayOneShot(vegetableClip);
            ui.UpdateScore(-50);
            Destroy(other.gameObject);
        }
         if(other.gameObject.CompareTag("Sand"))
        {
            isGrounded = true;
            rb.mass *= 3;       // double the mass of the player
        }
    }

    void OnTriggerExit(Collider other) {

        if(other.gameObject.CompareTag("Sand"))
        {
            isGrounded = true;
            rb.mass /= 3;       // double the mass of the player
        }
        if(other.gameObject.CompareTag("Floor")) {
            isGrounded = false;
        } 
        else if(other.gameObject.CompareTag("AltCam"))
        {
            mainCam.gameObject.SetActive(true);
            other.transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    // // create a function to move.
    // public void MoveHorizontal(float force) {
    //     rb.AddForce(force * speed, 0, 0);
    // }

    // // create a function to move.
    // public void MoveVertical(float force) {
    //     rb.AddForce(0, 0, force * speed);
    // }
}