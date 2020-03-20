using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameLoader : MonoBehaviour {
  // Start is called before the first frame update
  void Start() {
		Invoke("LoadGame", 3f);
	}

	private void LoadGame() {
		SceneManager.LoadScene(1);
	}
}
