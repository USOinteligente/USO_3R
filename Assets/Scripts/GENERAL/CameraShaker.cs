using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour {

	public static CameraShaker instance;
	private Transform tf;
	private Vector3 tfPos;
	private float shakeLength;
	private float shakeMagnitude;

	// Start is called before the first frame update
	void Start() {
		instance = this;
		tf = GetComponent<Transform>();
		// Set component values
		tfPos = tf.localPosition;
		ConstantShakeCamera();
	}

	// Call to adjust coroutine variables
	public void ShakeCamera(float magnitude = 0.7f, float length = 0.5f) {
		shakeMagnitude = magnitude;
		shakeLength = length;
		StartCoroutine("Shake");
	}

	public void ConstantShakeCamera(float magnitude = 0.7f, float length = 0.5f) {
		shakeMagnitude = magnitude;
		shakeLength = length;
		StartCoroutine("ConstantShake");
	}

	// Shake camera
	private IEnumerator Shake() {
		while (shakeLength > 0) {
		    shakeLength -= 0.1f;
		    tf.localPosition = tfPos + Random.insideUnitSphere * shakeMagnitude;
		    yield return null;
		}
		shakeLength = 0f;
		tf.localPosition = tfPos;
	}

	// Shake camera constantly
	private IEnumerator ConstantShake() {
		while (true) {
		    ShakeCamera(shakeMagnitude, shakeLength);
		    yield return new WaitForSeconds(shakeLength);
		}
	}
}











