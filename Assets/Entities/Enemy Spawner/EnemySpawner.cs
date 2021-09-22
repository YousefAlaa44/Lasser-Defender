using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float width = 10;
    public float height = 3;

    public float Speed = 5.0f;
    private float direction = 1;
    public float padding = 1;
    public float SpawendelaySeconds = 1f;

    private float BoundryRightEdge, BoundreyLeftEdge;
    void Start()
    {
        Camera camera = Camera.main;
        float distance = transform.position.z - camera.transform.position.z;
        BoundreyLeftEdge = camera.ViewportToWorldPoint(new Vector3(0, 0, distance)).x + padding;
        BoundryRightEdge = camera.ViewportToWorldPoint(new Vector3(1, 1, distance)).x - padding;
        SpawenUntilFull();
    }


    void OnDrawGizmos()
    {
        float xmin = transform.position.x - .5f * width;
        float xmax = transform.position.x + .5f * width;
        float ymin = transform.position.y - .5f * height;
        float ymax = transform.position.y + .5f * height;

        Gizmos.DrawLine(new Vector3(xmin, ymin, 0), new Vector3(xmax, ymin, 0));
        Gizmos.DrawLine(new Vector3(xmax, ymin, 0), new Vector3(xmax, ymax, 0));
        Gizmos.DrawLine(new Vector3(xmax, ymax, 0), new Vector3(xmin, ymax, 0));
        Gizmos.DrawLine(new Vector3(xmin, ymax, 0), new Vector3(xmin, ymin, 0));

    }

    void Update()
    {
        float FormationRightEdge = transform.position.x + .5f * width;
        float FormationLeftEdge = transform.position.x - .5f * width;
        if (FormationRightEdge > BoundryRightEdge)
        {
            direction = -1;
        }
        if (FormationLeftEdge < BoundreyLeftEdge)
        {
            direction = 1;
        }
        transform.position += new Vector3(direction * Speed * Time.deltaTime, 0, 0);

        if (AllMembersAreDeads())
        {
            Debug.Log("Enemy Destroyed");
            SpawenUntilFull();
        }
    }

    

    void SpawenUntilFull()
    {
        Transform FreePos = NextFreePosition();
        GameObject enemy = Instantiate(enemyPrefab, FreePos.position, Quaternion.identity) as GameObject;
        enemy.transform.parent = FreePos;
        if (FreePositionExist())
        {
            Invoke("SpawenUntilFull", SpawendelaySeconds);
        }
    }

    bool FreePositionExist()
    {
        foreach (Transform position in transform)
        {
            if (position.childCount <= 0)
            {
                return true;
            }
        }
        return false;
    }

    Transform NextFreePosition()
    {

        foreach (Transform position in transform)
        {
            if (position.childCount <= 0)
            {
                return position;
            }
        }
        return null;
    }


    bool AllMembersAreDeads()
    {
        foreach (Transform position in transform)
        {
            if (position.childCount > 0)
            {
                return false;
            }            
        }
        return true;

    }
}  
