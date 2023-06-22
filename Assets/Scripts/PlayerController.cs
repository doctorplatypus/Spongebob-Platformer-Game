using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 10;
    Rigidbody rb;
    float jumpForce = 8.0f;
    bool isjumping = false;
    public bool isDead = false;
    public int score;
    public GameObject winScreen;
    public Text CoinText;
    public AudioClip coinSound;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CoinText.text = "Coins: " + score;
        if (isDead == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if (Input.GetButtonDown("Jump") && isjumping == false)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isjumping = true;
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("BeachBall"))
        {
            Debug.Log("Good kick!");
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            isjumping = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            score += 1;
            Debug.Log("Score is " + score);
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameOver();
        }
        if (other.gameObject.CompareTag("Win"))
        {
            Win();
        }
    }
    void GameOver()
    {
        isDead = true;
        SceneManager.LoadScene("3D platformer");

    }

    void Win()
    {
        winScreen.SetActive(true);
        isDead = true;
        StartCoroutine("ResetScene");
    }

    IEnumerator ResetScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("3D platformer");
    }
}
