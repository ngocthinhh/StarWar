using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private bool canFollowX = true;
    private bool canFollowY = true;

    private void Update()
    {
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);

        FollowXPlayer();
        FollowYPlayer();
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
