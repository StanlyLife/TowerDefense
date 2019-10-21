using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadTransition : MonoBehaviour
{
	private Animator anim;

	public void PlayAnimation() {
		anim = GetComponent<Animator>();
		anim.SetTrigger("dead");
	}

}
