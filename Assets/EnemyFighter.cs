using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighter : MonoBehaviour {

	[SerializeField] GameObject deathFX;
	[SerializeField] Transform parent;

	// Start is called before the first frame update
	void Start() {
		BoxCollider boxCollider = this.gameObject.AddComponent<BoxCollider>();
		boxCollider.isTrigger = false;
  }

  // Update is called once per frame
  void Update() {
  }

	private void OnParticleCollision(GameObject gameObject) {
		print("ahhhh I've been shot " + this.gameObject.name);

		//BoxCollider boxCollider = GetComponent<BoxCollider>();
		//Destroy(boxCollider);
		DestroyAsset();
	}

	private void DestroyAsset() {
		GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity); // create an instatiation of deathFX into the position of the dying enemy, apply no rotation
		fx.transform.parent = parent;
		Destroy(this.gameObject);
	}
}
