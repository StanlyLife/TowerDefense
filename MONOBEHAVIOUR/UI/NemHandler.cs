using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NemHandler : MonoBehaviour
{
	public void playAnimation() {
		GetComponent<Animator>().ResetTrigger("ActivateToolTip");
		GetComponent<Animator>().SetTrigger("ActivateToolTip");
	}
}
