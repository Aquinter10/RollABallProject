using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public float speed = 5
    ;
    public TextMeshProUGUI countText; 

    public GameObject winTextObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb;

    private int count;
    private float movementX;
    private float movementY; 
    void Start()
    {
        winTextObject.SetActive(false);
        rb = GetComponent <Rigidbody>();
        count = 0;
        SetCountText(); 
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
       other.gameObject.SetActive(false);
       count = count + 1;
       SetCountText();
       }
    
   }
    void OnMove (InputValue movementValue)
   {
    Vector2 movementVector = movementValue.Get<Vector2>();
    movementX = movementVector.x; 
    movementY = movementVector.y; 

   }

      void SetCountText() 
   {
       countText.text =  "Count: " + count.ToString();

       if (count >= 6)
       {
           winTextObject.SetActive(true);
           Destroy(GameObject.FindGameObjectWithTag("Enemy"));
       }
   }
    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
{
   if (collision.gameObject.CompareTag("Enemy"))
   {
       // Destroy the current object
       Destroy(gameObject); 
       // Update the winText to display "You Lose!"
       winTextObject.gameObject.SetActive(true);
       winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
   }
}
    
}
