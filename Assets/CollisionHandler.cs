using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionHandler : MonoBehaviour {

	[SerializeField] float levelLoadDelay = 0.5f;
	[SerializeField] GameObject deathFX;

  // Start is called before the first frame update
  void Start() {
    
  }

  // Update is called once per frame
  void Update() {
    
  }

	private void OnTriggerEnter(Collider collider) {

		StartDeathSequence();
	}

	private void StartDeathSequence() {

		deathFX.SetActive(true);
		SendMessage("StopMovement");
		Invoke("ReloadGame", levelLoadDelay);
	}

	private void ReloadGame() {
		SceneManager.LoadScene(1);
	}
}
