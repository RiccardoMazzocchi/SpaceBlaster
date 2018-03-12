using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int health;
    public int score;

    UIManager uim;
    // Use this for initialization
    void Start () {
        uim = FindObjectOfType<UIManager>();
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
            uim.scoreText.text += score;
        }
    }
}
