﻿using UnityEngine;
using System.Collections;

public class Player : Ent {

	private InputManager inputManager;
	private Hud hud;

	private int hd_C = 0;
	

	public override void Awake () {
		inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
		hud = GameObject.Find("Hud").GetComponent<Hud>();
		base.Awake();
	}


	protected override void SetInput () {
		input = Vector2.zero;
		if (inputManager.left) { input.x = -1f; }
		if (inputManager.right) { input.x = 1f; }
		if (inputManager.up) { input.y = 1f; }
		if (inputManager.down) { input.y = -1f; }

		if (inputManager.A) {
			SetJump(inputManager.down, inputManager.up ? 1.25f : 1f);
		}

		if (inputManager.B) { SetActionB(); }

		if (Input.GetButtonUp("C")) { 
			hd_C = 0;

			Item item = (Item)interactiveObject;
			if (item) { 
				if (item.opening) {
					item.CancelOpening();
				} else {
					SetActionC();
				}
			} else {
				SetActionC();
			}
		}

		if (Input.GetButton("C")) { 
			hd_C += 1;
			if (hd_C == 10) {
				SetActionCHold();
			}
		}
	}


	protected override void PickCoin (Coin coin) {
		base.PickCoin(coin);
		hud.UpdateCoins(inv.coins);
	}
}
