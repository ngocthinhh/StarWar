using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private bool canFollowX = true;
    private bool canFollowY = true;

    public bool moveSlow = false;

    private void Update()
    {

        if (!moveSlow)
        {
            FollowXPlayer();
            FollowYPlayer();
        }
        else if (moveSlow)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, player.transform.position.y, -10), Time.deltaTime * 2f);
            
            if (Vector2.Distance(transform.position, player.transform.position) < 0.1f || transform.position.y >= 18f || transform.position.y <= -18)
            {
                moveSlow = false;
            }
        }
    }

    private void FollowXPlayer()
    {
        if (canFollowX)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, -10f);
        }
    }

    private void FollowYPlayer()
    {
        if (canFollowY)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, -10f);
        }
    }

    public void SetCanFollowX(bool enable)
    {
        canFollowX = enable;
    }

    public void SetCanFollowY(bool enable)
    {
        canFollowY = enable;
    }
}
