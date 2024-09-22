using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement; 
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0; 
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    AudioManager audioManager;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY; 

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove (InputValue movementValue)
   {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x; 
        movementY = movementVector.y; 
   }

   void SetCountText() 
   {
       countText.text =  "Pontos: " + count.ToString();

       if (count >= 14)
       {
           winTextObject.SetActive(true);
           GameObject.FindObjectOfType<TimerScript>().saveTime();
           SceneManager.LoadScene("EndGameWin");
       }
   }

    private void FixedUpdate() 
   {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed); 
   }

     void OnTriggerEnter(Collider other) 
   {
          if (other.gameObject.CompareTag("PickUp")) 
          {
               audioManager.PlayCollect();
               other.gameObject.SetActive(false);
               count = count + 1;

               SetCountText();
          }

          else if (other.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene("GameOver");
        }
   }
}
