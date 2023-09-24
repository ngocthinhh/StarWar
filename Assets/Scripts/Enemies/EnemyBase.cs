using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public GameObject GetPlayer()
    {
        return player;
    }
}
