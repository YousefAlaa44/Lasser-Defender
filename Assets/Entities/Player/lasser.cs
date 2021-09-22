using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasser : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }

    
}
