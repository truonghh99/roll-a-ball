using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Text countText;
    public Text winText;
	public float speed;
    public Button resetButton;

    private Rigidbody rb;
    private int count;
    private GameObject[] pickups;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pickups = GameObject.FindGameObjectsWithTag("Pick Up");

        count = 0;
        SetCountText();
        winText.text = "";
        resetButton.onClick.AddListener(resetGame);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.acceleration.x;
        float moveVertical = Input.acceleration.y;
 
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
 
        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up")) {
            other.gameObject.SetActive(false);
            ++count;
            SetCountText();
        }
    }

    void SetCountText() {
        countText.text = "Count: " + count.ToString();
        if (count >= 15) {
            winText.text = "You won!!!";
        }
    }

    void resetGame() {
        resetPickups();
        resetPosition();
        resetCount();
    }

    void resetCount() {
        count = 0;
        countText.text = "Count: 0";
        winText.text = "";
    }

    void resetPickups() {
        foreach (GameObject pickup in pickups) {
            pickup.SetActive(true);
        }
    }

    void resetPosition() {
        Vector3 original = new Vector3 (0.19f, 0.5f, -6.29f);
        transform.position = original;
    }
}
