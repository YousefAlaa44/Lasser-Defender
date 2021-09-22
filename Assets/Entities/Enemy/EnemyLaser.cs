using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public float speed = 5.0f;
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = -transform.up * speed;
    }

   
}
