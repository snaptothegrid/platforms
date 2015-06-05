﻿using UnityEngine;
using System.Collections;


public class Coin : Loot {


	public override IEnumerator Pickup (Ent collector) {
		if (spawning) { yield break; }
		yield return StartCoroutine(base.Pickup(collector));

		Audio.play("Audio/sfx/coin", 0.2f, Random.Range(3f, 5.0f));
	}


}
