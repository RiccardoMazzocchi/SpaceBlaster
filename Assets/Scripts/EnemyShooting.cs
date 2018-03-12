using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyShooting : MonoBehaviour {

    float timer;
    public float timeBetweenShots;
    public Transform shootStartPos;
    public float shootingForce;


    BulletPoolManager bpm;


	// Use this for initialization
	void Start () {
        bpm = FindObjectOfType<BulletPoolManager>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= timeBetweenShots)
        {
            Bullet bulletToShoot = bpm.GetBullet();

            bulletToShoot.transform.position = shootStartPos.position;
            bulletToShoot.Shoot(-transform.forward, shootingForce);
            bulletToShoot.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
            //bulletToShoot.tag = "EnemyBullet";

            timer = 0f;
        }
	}
}
