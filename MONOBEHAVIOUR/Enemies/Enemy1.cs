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
		if (!gameSettings.isPaused) {
			anim.SetFloat("gamespeed", gameSettings.gameSpeed);
			move();
		} else {
			anim.SetFloat("gamespeed",0);
		}
	}
}
