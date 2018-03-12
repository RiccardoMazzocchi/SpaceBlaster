using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    [Header("Input Settings")]
    public KeyCode shootingInput = KeyCode.Space;
    public Transform ShootStartPos, ShootStartPos2;
    BulletPoolManager bpm;

    public float shootingForce;
    public int health;

    float timer;



    // Use this for initialization
	void Start () {
        bpm = FindObjectOfType<BulletPoolManager>();

	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
		if (Input.GetKey(shootingInput))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        if (timer >= 0.075f)
        {

            Bullet bulletToShoot = bpm.GetBullet();
            bulletToShoot.transform.position = ShootStartPos.position;
            bulletToShoot.Shoot(transform.forward, shootingForce);
            bulletToShoot.GetComponentInChildren<MeshRenderer>().material.color = Color.yellow;
            //bulletToShoot.tag = "PlayerBullet";
            Bullet bulletToShoot2 = bpm.GetBullet();
            bulletToShoot2.transform.position = ShootStartPos2.position;
            bulletToShoot2.Shoot(transform.forward, shootingForce);
            bulletToShoot2.GetComponentInChildren<MeshRenderer>().material.color = Color.yellow;
            //bulletToShoot2.tag = "PlayerBullet";

            timer = 0f;
        }
    }



}
