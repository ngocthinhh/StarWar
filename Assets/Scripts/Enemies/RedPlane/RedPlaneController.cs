using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlaneController : MonoBehaviour
{
    private enum State
    {
        Non,
        Follow,
        KeepDistance
    }

    private EnemyInfo enemyInfo;

    // Info
    [SerializeField] private float health;
    [SerializeField] private float strength;
    [SerializeField] private float speed;

    // Other
    private Animator animator;


    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletBag;

    private void Awake()
    {
        // Info
        enemyInfo = GetComponent<EnemyInfo>();

        // Other
        animator = GetComponentInChildren<Animator>();

        player = transform.parent.gameObject.GetComponent<EnemyBase>().GetPlayer();
    }

    private void Start()
    {
        // Info
        enemyInfo.SetMaxHealth(health);
        enemyInfo.SetStrength(strength);
        enemyInfo.SetSpeed(speed);
    }

    private void Update()
    {
        if (enemyInfo.GetCurrentHealth() <= 0f)
        {
            animator.Play("Boom");

            Destroy(gameObject, 1f);
        }
        else
        {
            // SHOOT PLAYER AFTER DELAY TIME
            Shoot();

            // KEEP DIRECTION WITH PLAYER
            Vector3 diff = transform.position - player.transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90f);

            if (Vector3.Distance(transform.position, player.transform.position) > 2f)
            {
                // FOLLOW PLAYER IF DONT ENOUGH DISTANCE
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyInfo.GetSpeed() * Time.deltaTime);

            }
            else
            {
                // KEEP DISTANCE

            }

        }
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletPlayer"))
        {
            float lostHealth = collision.transform.parent.gameObject.GetComponent<BulletBagController>().GetPlayer().GetComponent<PlayerInfo>().GetStrength();
            enemyInfo.DecreaseHealth(lostHealth);
        }
    }

    private void Shoot()
    {
        if (!isDelayShoot)
        {
            isDelayShoot = true;

            StartCoroutine(DelayShoot());
        }
    }

    private bool isDelayShoot = false;
    IEnumerator DelayShoot()
    {
        float timeDelay = Random.Range(2f, 5f);
        yield return new WaitForSeconds(timeDelay);

        // AFTER DELAY TIME, IF ALIVE -> SHOOT PLAYER
        if (enemyInfo.GetCurrentHealth() > 0f)
        {
            Instantiate(bullet, transform.position, transform.rotation, bulletBag.transform);
        }
        //

        isDelayShoot = false;
    }
}
