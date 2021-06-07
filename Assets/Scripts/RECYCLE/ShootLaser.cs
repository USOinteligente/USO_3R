using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootLaser : MonoBehaviour {

	[SerializeField] private Image Laser;

	public void shoot() {
		StopCoroutine("shootDelay");
		StartCoroutine("shootDelay");
	}

	private IEnumerator shootDelay() {
		Laser.gameObject.SetActive(true);
		yield return new WaitForSeconds(0.1f);
		Laser.gameObject.SetActive(false);
	}
}
