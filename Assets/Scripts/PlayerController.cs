using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0;
    private int count = 0;
    private int hitCount = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI hitCountText;
    public GameObject winTextObject;
    public GameObject lostTextObject;
    public GameObject ball;
    public AudioClip eat;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        hitCount = 0;
        rb = GetComponent<Rigidbody>();
        SetCountText();
        SetHitCountText();
        winTextObject.SetActive(false);
        lostTextObject.SetActive(false);
    }

    // Update is called once per frame
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
        if(count == 8)
        {
            StopAllCoroutines();
            ball.SetActive(false);
            winTextObject.SetActive(true);
        }
    }

    void SetHitCountText()
    {
        hitCountText.text = "Hit: " + hitCount.ToString() + "/3";
        if(hitCount > 0)
        {
            hitCountText.color = Color.red;
        }
        if (hitCount == 3)
        {
            ball.SetActive(false);
            lostTextObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        if (rb.velocity.y > 0.0)
            rb.velocity = new Vector3(rb.velocity.x, 0.0f, rb.velocity.z); ;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
        else if(other.gameObject.CompareTag("DestroyerCylinder"))
        {
            hitCount += 1;
            SetHitCountText();
        }
        
    }
}
