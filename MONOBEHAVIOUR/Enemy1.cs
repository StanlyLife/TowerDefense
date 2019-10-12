using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : EnemyMove
{
	Animator anim;
	protected override void Start() {
		base.Start();
		anim = GetComponent<Animator>();
	}

    void Update()
    {
		anim.SetFloat("gamespeed", gameSettings.gameSpeed);
		if (!gameSettings.isPaused) {
			move();
		}
	}
}
