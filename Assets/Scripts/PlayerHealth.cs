using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    Vector3 startPosition;
    public int health;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int amount)
    {
        health = health - amount;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        Invoke("Respawn", 1f);
    }
    void Respawn()
    {
        transform.position = startPosition;
        gameObject.SetActive(true);

    }
}
