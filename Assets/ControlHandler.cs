using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class ControlHandler : MonoBehaviour {

	float invertPitch = -1;

	bool controlsAreEnabled = true;

	[Header("General")]
	[Tooltip("In m/s")] [SerializeField] float baseMovementSpeed = 16f;

	[Header("Body Rotation on Position")]
	[SerializeField] float pitchFactor = -5f;
	[SerializeField] float yawFactor = 5f;

	[Header("Body Rotation On Control")]
	[SerializeField] float controlPitchFactor = -20f;
	[SerializeField] float controlYawFactor = 20f;
	[SerializeField] float controlRollFactor = -40f;

	float xThrow;
	float yThrow;

	// Start is called before the first frame update
	void Start() {
    
  }

  // Update is called once per frame
  void Update() {
		runControls();
  }

	private void runControls() {
		if (controlsAreEnabled) {
			HandleTranslation();
			HandleRotation();
		}
	}


	private void HandleTranslation() {
		xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		yThrow = CrossPlatformInputManager.GetAxis("Vertical");

		float xOffset = xThrow * baseMovementSpeed * Time.deltaTime;
		float yOffset = yThrow * baseMovementSpeed * Time.deltaTime * invertPitch;

		float xPosition = Mathf.Clamp(transform.localPosition.x + xOffset, -7.5f, 7.5f);
		float yPosition = Mathf.Clamp(transform.localPosition.y + yOffset, -4f, 4f);

		transform.localPosition = new Vector3(xPosition, yPosition, transform.localPosition.z);
	}

	private void HandleRotation() {

		float pitch = transform.localPosition.y * pitchFactor + yThrow * controlPitchFactor * invertPitch; // x axis
		float yaw = transform.localPosition.x * yawFactor + xThrow * controlYawFactor; // y axis
		float roll = xThrow * controlRollFactor; // z axis

		transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
	}

	private void StopMovement() {
		controlsAreEnabled = false;
		print("controls disabled");
	}
}
