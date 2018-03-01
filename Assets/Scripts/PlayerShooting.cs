using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    [Header("Input Settings")]
    public KeyCode shootingInput = KeyCode.Space;
    public Transform ShootStartPos;
    BulletPoolManager bpm;

    public float shootingForce;

    // Use this for initialization
	void Start () {
        bpm = FindObjectOfType<BulletPoolManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(shootingInput))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        Bullet bulletToShoot = bpm.GetBullet();
        bulletToShoot.transform.position = ShootStartPos.position;
        bulletToShoot.Shoot(transform.forward, shootingForce);
    }
}
