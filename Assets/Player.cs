using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class Player : MonoBehaviour {

	[Tooltip("In m/s")] [SerializeField] float baseMovementSpeed = 16f;

	[SerializeField] float pitchFactor = -5f;
	[SerializeField] float yawFactor = 5f;

	[SerializeField] float controlPitchFactor = -10f;
	[SerializeField] float controlYawFactor = 10f;
	[SerializeField] float controlRollFactor = -30f;

	float xThrow;
	float yThrow;

	float invertPitch = -1;

	// Start is called before the first frame update
	void Start() {
    
  }

  // Update is called once per frame
  void Update() {
		runControls();
  }


	private void runControls() {
		handleTranslation();
		handleRotation();
	}

	private void handleTranslation() {
		xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		yThrow = CrossPlatformInputManager.GetAxis("Vertical");

		float xOffset = xThrow * baseMovementSpeed * Time.deltaTime;
		float yOffset = yThrow * baseMovementSpeed * Time.deltaTime * invertPitch;

		float xPosition = Mathf.Clamp(transform.localPosition.x + xOffset, -7.5f, 7.5f);
		float yPosition = Mathf.Clamp(transform.localPosition.y + yOffset, -4f, 4f);

		transform.localPosition = new Vector3(xPosition, yPosition, transform.localPosition.z);
	}

	private void handleRotation() {

		float pitch = transform.localPosition.y * pitchFactor + yThrow * controlPitchFactor * invertPitch; // x axis
		float yaw = transform.localPosition.x * yawFactor + xThrow * controlYawFactor; // y axis
		float roll = xThrow * controlRollFactor; // z axis

		transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
	}
}
