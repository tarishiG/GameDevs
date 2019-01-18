using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private int count;
    public Text countText;
    public Text winText;

    public float speed;

    private Rigidbody rb;

    private Vector2 touchStart,touchEnd;


    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count=0;
        SetCountText();
        winText.text="";
    }

//     void Update() 
//     {
//    // Swipe start
//    if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began) 
//    {
//      touchStart = Input.GetTouch(0).position;
//    }
//    // Swipe end
//    if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended) 
//    {
//      touchEnd = Input.GetTouch(0).position;
//      float cameraFacing = Camera.main.transform.eulerAngles.y;
//      Vector2 swipeVector = touchEnd - touchStart;
//      Vector3 inputVector = new Vector3(swipeVector.x, 0.0f, swipeVector.y);
//      Vector3 movement = Quaternion.Euler(0.0f, cameraFacing, 0.0f) * Vector3.Normalize(inputVector);
//      rb.velocity = movement;
//    }   
//  }

 private void FixedUpdate ()
    {
        float moveHorizontal = Input.acceleration.x;
        float moveVertical = Input.acceleration.y;

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed * 2);
    }


    void OnTriggerEnter(Collider other) 
    {
         if (other.gameObject.CompareTag("PickUp"))
         {
              other.gameObject.SetActive(false);
              count=count+1;
              SetCountText();
              
         }
    }
    void SetCountText(){
        countText.text ="Count: "+ count.ToString();
        if(count>=12)
        {
            winText.text="You Win!!";
        }

    }
}

