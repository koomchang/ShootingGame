using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public float speed = 5;

	private void Update() {
		Vector3 dir = Vector3.down;
		transform.position += dir * (speed * Time.deltaTime);
	}

	private void OnCollisionEnter(Collision other) {
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
