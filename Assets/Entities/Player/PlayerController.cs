using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject laser;
    public float Speed = 15f;
    private float xmin;
    private float xmax;
    public float padding = 1;
    public float ProjectleSpeedRate = .2f;
    public float Health = 150;

    public AudioClip LaserSound;
    void Start()
    {
        
        Camera camera = Camera.main;
        float distance = transform.position.z - camera.transform.position.z;
        xmin = camera.ViewportToWorldPoint(new Vector3(0, 0, distance)).x + padding;
        xmax = camera.ViewportToWorldPoint(new Vector3(1, 1, distance)).x - padding;

    }

    void Fire()
    {
        Vector3 Offset = new Vector3(0, 1, 0);
        GameObject lasser = Instantiate(laser, transform.position + Offset, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(LaserSound, transform.position);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.00001f, ProjectleSpeedRate);           
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x - Speed * Time.deltaTime,xmin,xmax),
                transform.position.y,
                transform.position.z
                );
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x + Speed * Time.deltaTime, xmin, xmax),
                transform.position.y,
                transform.position.z
                );
        }              
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile mesile = collider.gameObject.GetComponent<Projectile>();
        if (mesile)
        {
            Health -= mesile.Getdamage();
            mesile.Hit();
            if (Health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        LevelManager man = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        man.LoadLevel("win");
        Destroy(gameObject);

    }
}
