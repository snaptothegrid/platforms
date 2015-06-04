﻿using UnityEngine;
using System.Collections;


public class Coin : Loot {


	public override IEnumerator Pickup (Ent collector) {
		if (spawning) { yield break; }
		yield return StartCoroutine(base.Pickup(collector));

		Audio.play("Audio/sfx/coin", 0.2f, Random.Range(3f, 5.0f)); // chimes

		//collector.AddLootToInventory(this);

		/*for (int n = 0; n < collector.inv.items.Count; n++) {
			InvItem item = collector.inv.items[n];
			print(item.loot.name);
		}*/
		//collector.inv.coins += 1;
		
		//if (collector is Player) {
			//Player player = (Player)collector;
			//player.hud.UpdateCoins(player.inv.coins);
		//}
		//yield return null; //new WaitForSeconds(0.1f);
		Destroy(gameObject);
	}

	/*public IEnumerator Pickup (Ent collector) {
		if (spawning) { yield break; }

		gameObject.GetComponent<BoxCollider2D>().enabled = false;
		affectedByGravity = false;

		Vector3 pos = transform.position + Vector3.up * collector.sprite.localScale.y * 0.5f;
		
		while (Vector2.Distance(transform.position, pos) > 0.1f) { //(Time.time <= startTime + duration) {
			pos = collector.transform.position + Vector3.up * collector.sprite.localScale.y * 0.5f;
			transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 15f);
			transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * 2f);
			yield return null;
		}

		Audio.play("Audio/sfx/coin", 0.2f, Random.Range(3f, 5.0f)); // chimes
		collector.inv.coins += 1;
		
		if (collector is Player) {
			Player player = (Player)collector;
			player.hud.UpdateCoins(player.inv.coins);
		}

		Destroy(gameObject);
	}*/
}
