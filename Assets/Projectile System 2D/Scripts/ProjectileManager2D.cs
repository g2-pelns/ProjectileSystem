﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager2D : MonoBehaviour {

    [SerializeField]
    float fireRate = 0;
    [SerializeField]
    float damage = 10;
    [SerializeField]
    LayerMask whatToHit;
    [SerializeField]
    Transform bulletPrefab;

    private float rot;
    private float timeToFire = 0;
    private Transform firePoint;

    float getRot() { return rot; }

    // Use this for initialization
    void Awake () {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No firepoint");
        }
	}
	
	// Update is called once per frame
	void Update () {
        //setRotation();
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ShootMulti();
            }
        }
        else
        {
            if (Input.GetButton ("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                ShootOne();
            }
        }
	}

    void ShootOne()
    {
        setRotation();

        firePoint.rotation = Quaternion.Euler(0.0f, 0.0f, rot);
        SpawnBullet();
    }

    void ShootMulti()
    {
        setRotation();

        firePoint.rotation = Quaternion.Euler(0.0f, 0.0f, rot);
        SpawnBullet();

        firePoint.rotation = Quaternion.Euler(0.0f, 0.0f, rot + 4);
        SpawnBullet();

        firePoint.rotation = Quaternion.Euler(0.0f, 0.0f, rot - 4);
        SpawnBullet();
    }

    void SpawnBullet()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void setRotation ()
    {
        Vector3 Di = Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.position;
        Di.Normalize();
        rot = Mathf.Atan2(Di.y, Di.x) * Mathf.Rad2Deg; //Find the an
    }
}


















//Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
//Vector2 mousePosition2 = new Vector2(mousePosition.x - 0.2f, mousePosition.y - 0.2f);
//Vector2 mousePosition3 = new Vector2(mousePosition.x + 0.1f, mousePosition.y + 0.1f);
//Vector2 mousePosition4 = new Vector2(mousePosition.x - 0.1f, mousePosition.y - 0.1f);

//Vector2 firePointPos = new Vector2(firePoint.position.x, firePoint.position.y);
//RaycastHit2D hit = Physics2D.Raycast(firePointPos, mousePosition - firePointPos, 100, whatToHit);

//Debug.DrawLine(firePointPos, (mousePosition - firePointPos) * 100, Color.green);
//Debug.DrawLine(firePointPos, (mousePosition1 - firePointPos) * 100, Color.blue);
//Debug.DrawLine(firePointPos, (mousePosition2 - firePointPos) * 100, Color.yellow);
//Debug.DrawLine(firePointPos, (mousePosition3 - firePointPos) * 100, Color.white);
//Debug.DrawLine(firePointPos, (mousePosition4 - firePointPos) * 100, Color.cyan);

//if (hit.collider != null)
//{
//    Debug.DrawLine(firePointPos, hit.point, Color.red); 
//}