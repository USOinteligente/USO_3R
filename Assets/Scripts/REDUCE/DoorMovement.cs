using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorMovement : MonoBehaviour {

	private Animator animator;

	// Start is called before the first frame update
	void Start() {
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update() {

	}

	public void makeTransition(int futurePos) {
		animator.SetInteger("FUTURE", futurePos);
	}

	

}





