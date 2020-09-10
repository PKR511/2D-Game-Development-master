using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteCheck : MonoBehaviour
{

	private AudioSource audioManager;

	void Awake() {
		audioManager = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == MyTags.PLAYER_TAG) {

			audioManager.Play ();
			StartCoroutine (Teleport(1f,target));
		}
	}

	IEnumerator Teleport(float timer,Collider2D target) {
		yield return new WaitForSeconds (1f);
		target.gameObject.SetActive (false);
	}
}
