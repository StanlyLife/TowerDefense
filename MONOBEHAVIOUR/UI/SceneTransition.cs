using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
	public bool isMap;


	private Animator anim;
	private bool transitionOn = false;
	private string nextSceneName;
	private void Start() {
		anim = GetComponent<Animator>();

		if (isMap) {
			StartAnim("Out");
		}
	}

	public void StartAnim(string state) {
		if (state == "In") {
			anim.ResetTrigger("In");
			anim.SetTrigger("In");
		}else if (state == "Out") {
			anim.ResetTrigger("Out");
			anim.SetTrigger("Out");
		} else {
			Debug.Log("No name for that transition");
		}
	}

	public void NextScene(string sceneName) {
		transitionOn = true;
		nextSceneName = sceneName;
	}
	private void FixedUpdate() {
		if (transitionOn) {
			StartCoroutine(Transition(nextSceneName));
		}
	}

	IEnumerator Transition(string sceneName) {
		StartAnim("In");
		yield return new WaitForSeconds(1.9f /*time between animations*/);
		transitionOn = false;
		StartAnim("Out");
		SceneManager.LoadScene(sceneName);
	}

}
