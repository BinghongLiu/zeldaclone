using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour {
	[SerializeField] string itemName;

	void OnTriggerEnter(Collider other) {
		if (itemName == "ore") {
			Managers.Inventory.AddItem(itemName);
		} else if (itemName == "health") {
			Managers.Player.ChangeHealth(25);
		}
		Destroy(this.gameObject);
	}
}
