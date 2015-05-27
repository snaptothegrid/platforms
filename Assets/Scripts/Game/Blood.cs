﻿using UnityEngine;
using System.Collections;

public class Blood : Ent {

	public void Init () {
		float sc = Random.Range(0.25f, 1f);
		transform.localScale = new Vector2(sc, sc);
		transform.position += Vector3.up * 0.5f;
		Vector2 vec = new Vector3(Random.Range(-1f, 1f), Random.Range(0, 5f)) * Random.Range(1f, 4f);
		StartCoroutine (Bleed(vec));
	}


	private IEnumerator Bleed (Vector2 vec) {
		float duration = Random.Range(0.25f, 0.75f);

		velocity.y = vec.y;
		Vector2 pos = new Vector2(transform.position.x + vec.x, transform.position.y);

		float startTime = Time.time;
		while (Time.time <= startTime + duration) {
			float targetVelocityX = (pos.x - transform.position.x) * 10f;
			velocity.x = Mathf.Lerp(targetVelocityX, 0, Time.deltaTime * 5f);
			ApplyGravity();
			controller.Move (velocity * Time.deltaTime, jumpingDown);

			yield return null;
		}

		Destroy(gameObject);
	}
}