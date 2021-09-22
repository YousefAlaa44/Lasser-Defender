using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviar : MonoBehaviour
{
    public GameObject EnemyLaser;
    public float Health = 150;
    public float ShotsPerSSeconds = .5f;


    public int scorevalue = 50;
    private ScoreKeeper scoreKeeper;

    public AudioClip LaserSound;
    public AudioClip DeathSound;

    void Start()
    {
        scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    void Update()
    {
        float Probability = Time.deltaTime * ShotsPerSSeconds;
        if (Random.value < Probability)
        {
            Fire();
        }
    }
    void Fire()
    {
        
        GameObject enemylaser = Instantiate(EnemyLaser, transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(LaserSound, transform.position);
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
                die();
            }
        }
    }

    void die()
    {
        AudioSource.PlayClipAtPoint(DeathSound, transform.position);
        Destroy(gameObject);
        scoreKeeper.Score(scorevalue);
    }
}

