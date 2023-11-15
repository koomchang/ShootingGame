using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public float speed = 5;
	private GameObject player;
	Vector3 dir;
	public GameObject explosionFactory;

	private void Start() {
		int randValue = UnityEngine.Random.Range(0, 10);
		if (randValue < 3) {
			GameObject target = GameObject.Find("Player");
			dir = target.transform.position - transform.position;
			dir.Normalize();
		}
		else {
			dir = Vector3.down;
		}
	}

	private void Update() {
		transform.position += dir * (speed * Time.deltaTime);
	}

	private void OnCollisionEnter(Collision other) {
		GameObject smObject = GameObject.Find("ScoreManager");
		ScoreManager sm = smObject.GetComponent<ScoreManager>();
		sm.SetScore(sm.GetScore()+1);
		
		GameObject explosion = Instantiate(explosionFactory);
		explosion.transform.position = transform.position;
		
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
