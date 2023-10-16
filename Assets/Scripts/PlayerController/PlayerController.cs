using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject strengthBar;
    [SerializeField] private GameObject speedBar;
    [SerializeField] private GameObject timeBar;
    [SerializeField] private GameObject optionLose;

    [SerializeField] private GameObject buttonShootImage;
    [SerializeField] private Sprite buttonShoot;
    [SerializeField] private Sprite buttonBanShoot;

    [SerializeField] private AudioSource audioSource;

    public int round = 1;

    private void Awake()
    {
        // Info
        playerInfo = GetComponent<PlayerInfo>();

        // Input
        playerInput = GetComponent<PlayerInput>();

        // Other
        animator = GetComponentInChildren<Animator>();
        camera = Camera.main;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        // Info
        playerInfo.SetMaxHealth(health);
        playerInfo.SetStrength(strength);
        playerInfo.SetSpeed(speed);

        // Other
        bulletBag.GetComponent<BulletBagController>().SetPlayer(gameObject);
        healthBar.GetComponent<Slider>().maxValue = playerInfo.GetMaxHealth();

        LoadHealthBar();
        LoadStrengthBar();
        LoadSpeedBar();
        LoadTimeBar(0f);
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        if (playerInfo.GetCurrentHealth() <= 0f)
        {
            animator.Play("Boom");

            optionLose.SetActive(true);

            if (!isDie)
            {
                isDie = true;
                StartCoroutine(AfterDie());
            }
        }
        else
        {
            Movement();

            Rotate();

            HandleCamera();

            HandleTime();
        }
    }

    private bool isDie = false;
    IEnumerator AfterDie()
    {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
    }

    // GIOI HAN CAMERA KHONG RA KHOI VUNG bAN DO
    private void HandleCamera()
    {
        if (transform.position.x > -13 && transform.position.x < 13)
        {
            camera.gameObject.GetComponent<CameraController>().SetCanFollowX(true);
        }
        else
        {
            camera.gameObject.GetComponent<CameraController>().SetCanFollowX(false);
        }

        // ROUND 1
        if (round.Equals(1))
        {
            if (transform.position.y > -18 && transform.position.y < -15)
            {
                camera.gameObject.GetComponent<CameraController>().SetCanFollowY(true);
            }
            else
            {
                camera.gameObject.GetComponent<CameraController>().SetCanFollowY(false);
            }
        }
        // ROUND 2
        else if (round.Equals(2))
        {
            if (transform.position.y > -18 && transform.position.y < -2.5f)
            {
                camera.gameObject.GetComponent<CameraController>().SetCanFollowY(true);
            }
            else
            {
                camera.gameObject.GetComponent<CameraController>().SetCanFollowY(false);
            }
        }
        // ROUND 3
        else if (round >= 3)
        {
            if (transform.position.y > -18 && transform.position.y < 18)
            {
                camera.gameObject.GetComponent<CameraController>().SetCanFollowY(true);
            }
            else
            {
                camera.gameObject.GetComponent<CameraController>().SetCanFollowY(false);
            }
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

            if (playerInfo.GetCurrentHealth() <= 20f)
            {
                animator.Play("MoveDanger");
            }
            else
            {
                animator.Play("Move");
            }
        }
        else
        {
            if (playerInfo.GetCurrentHealth() <= 20f)
            {
                animator.Play("IdleDanger");
            }
            else
            {
                animator.Play("Idle");
            }
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
    private bool canShoot = true;
    public void Shoot()
    {
        if (canShoot)
        {
            audioSource.clip = AudioManager.Instance.lazerShoot;
            audioSource.Play();

            Instantiate(bullet, transform.position, transform.rotation, bulletBag.transform);
        }
    }

    // LOAD BAR UI
    public void LoadHealthBar()
    {
        healthBar.GetComponent<Slider>().value = playerInfo.GetCurrentHealth();
    }

    public void LoadStrengthBar()
    {
        strengthBar.GetComponent<Slider>().value = playerInfo.GetStrength();
    }

    public void LoadSpeedBar()
    {
        speedBar.GetComponent<Slider>().value = playerInfo.GetSpeed();
    }

    public void LoadTimeBar(float num)
    {
        timeBar.GetComponent<Slider>().value = num;
    }
    //

    // KIEM SOAT THOI GIAN TRUNG HIEU UNG
    public float numTime = 0f;
    public void HandleTime()
    {
        if (numTime > 0f)
        {
            numTime -= Time.deltaTime;

            LoadTimeBar(numTime);
        }
        else
        {
            // SAU KHI HET THOI GIAN THI RESET LAI BTH
            playerInfo.SetStrength(strength);
            playerInfo.SetSpeed(speed);

            LoadStrengthBar();
            LoadSpeedBar();

            buttonShootImage.GetComponent<Image>().sprite = buttonShoot;

            canShoot = true;
        }
    }
    //

    public void LostHealth(Collider2D collision)
    {
        playerInfo.DecreaseHealth(collision.gameObject.GetComponent<BulletEnemy>().GetStrength());
        LoadHealthBar();
    }

    public void AddHealth(float health)
    {
        playerInfo.IncreaseHealth(health);
        LoadHealthBar();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletGreen"))
        {
            LostHealth(collision);
        }
        else if (collision.CompareTag("BulletOrange"))
        {
            LostHealth(collision);

            // GIAM DAMAGE
            playerInfo.SetStrength(1f);
            LoadStrengthBar();
            numTime = 5f;
            //
        }
        else if (collision.CompareTag("BulletGolden"))
        {
            LostHealth(collision);

            // HU HONG SUNG
            canShoot = false;
            buttonShootImage.GetComponent<Image>().sprite = buttonBanShoot;
            numTime = 5f;
            //
        }
        else if (collision.CompareTag("BulletWhite"))
        {
            LostHealth(collision);

            // GIAM TOC DO
            playerInfo.SetSpeed(2f);
            LoadSpeedBar();
            numTime = 5f;
            //
        }
        else if (collision.CompareTag("BulletPurple"))
        {
            LostHealth(collision);

            // TAO THEM ENEMY

            //
        }

        if (collision.CompareTag("HealthSafe"))
        {
            // HOI MAU VA XOA BO HIEU UNG
            AddHealth(20f);
            numTime = 0f;
            LoadTimeBar(numTime);

            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyInfo>().DecreaseHealth(100f);
            playerInfo.DecreaseHealth(100f);
        }
    }
}
