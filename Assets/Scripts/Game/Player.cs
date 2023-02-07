using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Button gameOverMenuSelected;
    public Menu gameOverMenu;
    public Menu pauseMenu;
    public Projectile projectilePrefab;
    public float moveSpeed = 4f;
    public float rotationSpeed = 1f;
    private float verticalInput;
    private float horizontalInput;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        HandleVerticalInput();
        HandleHorizontalInput();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            Destroy(gameObject);
            gameOverMenu.ShowMenu();
            Debug.Log(gameOverMenu.transform.GetChild(1));
            // gameOverMenu.transform.GetChild(1).gameObject.GetComponent<Button>().Select();
            gameOverMenuSelected.Select();
        }
    }

    private void GetInput()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Fire1"))
        {
            HandleFire();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.TogglePause();
        }
    }

    private void HandleVerticalInput()
    {
        rb2d.AddRelativeForce(new Vector2(0, -verticalInput) * moveSpeed);
    }

    private void HandleHorizontalInput()
    {
        rb2d.AddTorque(-horizontalInput * rotationSpeed);
    }

    private void HandleFire()
    {
        Vector2 position = transform.position + -transform.up;
        Projectile projectile = Instantiate(projectilePrefab, position, transform.rotation);
        projectile.SetForce(-transform.up);
    }
}
