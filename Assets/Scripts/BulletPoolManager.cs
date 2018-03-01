using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour {

    Vector3 poolBulletPos = new Vector3(1000f, 1000f, 1000f);

    public Bullet BulletPrefab;
    public int maxBullets;

    public List<Bullet> bullets = new List<Bullet>();

	// Use this for initialization
	void Start () {
        for (int i = 0; i < maxBullets; i++)
        {
            Bullet bulletToAdd = Instantiate(BulletPrefab);
            bulletToAdd.OnShoot += OnBulletShoot;
            bulletToAdd.OnDestroy += OnBulletDestroy;
            OnBulletDestroy(bulletToAdd);
            bullets.Add(bulletToAdd);
        }
	}

    private void OnDisable()
    {
        foreach (Bullet bullet in bullets)
        {
            bullet.OnShoot -= OnBulletShoot;
            bullet.OnDestroy -= OnBulletDestroy;
        }

    }

    private void OnBulletShoot(Bullet bullet)
    {

    }

    private void OnBulletDestroy(Bullet bullet)
    {
        bullet.transform.position = poolBulletPos;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public Bullet GetBullet()
    {
        foreach (Bullet bullet in bullets)
        {
            if (bullet.currentBulletState == Bullet.BulletState.inPool)
            {
                return bullet;
            }
        }
        Debug.Log("Pool depleted");
        return null;
    }


}
