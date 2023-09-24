using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInfo playerInfo;
    private PlayerInput playerInput;

    // Info
    [SerializeField] private float health;
    [SerializeField] private float strength;
    [SerializeField] private float speed;

    // Other
    private Animator animator;
    private Camera camera;

    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletBag;

    [SerializeField] private GameObject circle;
    [SerializeField] private GameObject pivot;

    private void Awake()
    {
        // Info
        playerInfo = GetComponent<PlayerInfo>();

        // Input
        playerInput = GetComponent<PlayerInput>();

        // Other
        animator = GetComponentInChildren<Animator>();
        camera = Camera.main;
    }

    private void Start()
    {
        // Info
        playerInfo.SetMaxHealth(health);
        playerInfo.SetStrength(strength);
        playerInfo.SetSpeed(speed);

        // Other
        bulletBag.GetComponent<BulletBagController>().SetPlayer(gameObject);
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        if (playerInfo.GetCurrentHealth() <= 0f)
        {
            animator.Play("Boom");
        }
        else
        {
            Movement();

            Rotate();

            HandleCamera();
        }
    }



    // GIOI HAN CAMERA KHONG RA KHOI VUNG bAN DO
    private void HandleCamera()
    {
        if (transform.position.x > -12 && transform.position.x < 12)
        {
            camera.gameObject.GetComponent<CameraController>().SetCanFollowX(true);
        }
        else
        {
            camera.gameObject.GetComponent<CameraController>().SetCanFollowX(false);
        }

        if (transform.position.y > -18 && transform.position.y < 18)
        {
            camera.gameObject.GetComponent<CameraController>().SetCanFollowY(true);
        }
        else
        {
            camera.gameObject.GetComponent<CameraController>().SetCanFollowY(false);
        }
    }

    // DI CHUYEN
    private void Movement()
    {
        if (playerInput.horizontalInput > 0.2f || playerInput.horizontalInput < -0.2f
            || playerInput.verticalInput > 0.2f || playerInput.verticalInput < -0.2f)
        {
            float speedMax = 0f;
            float speedHori = Mathf.Abs(playerInput.horizontalInput);
            float speedVerti = Mathf.Abs(playerInput.verticalInput);

            if (speedHori >= speedVerti)
            {
                speedMax = speedHori;
            }
            else
            {
                speedMax = speedVerti;
            }

            transform.Translate(Vector2.up * speedMax * playerInfo.GetSpeed() * Time.deltaTime);
            animator.Play("Move");
        }
        else
        {
            animator.Play("Idle");
        }

    }

    // XOAY TAU
    private void Rotate()
    {
        //if (playerInput.horizontalInput > 0.2f)
        //{
        //    transform.Rotate(Vector3.forward * -playerInput.horizontalInput * 180f * Time.deltaTime);
        //}
        //else if (playerInput.horizontalInput < -0.2f)
        //{
        //    transform.Rotate(Vector3.forward * -playerInput.horizontalInput * 180f * Time.deltaTime);
        //}

        if (playerInput.horizontalInput > 0.2f || playerInput.horizontalInput < -0.2f 
            || playerInput.verticalInput > 0.2f || playerInput.verticalInput < -0.2f)
        {
            Vector3 diff = circle.transform.position - pivot.transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90f);
        }
    }

    // BAN 
    public void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation, bulletBag.transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletEnemy"))
        {
            playerInfo.DecreaseHealth(50f);
        }
    }
}
