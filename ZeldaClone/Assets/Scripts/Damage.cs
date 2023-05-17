using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
	[SerializeField] GameObject target;

	void OnTriggerEnter(Collider other) {
        Managers.Player.ChangeHealth(-25);
	}

    void onTriggerExit(Collider other) {
        return;
    }
}
