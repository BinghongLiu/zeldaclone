using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrade : MonoBehaviour {
	[SerializeField] GameObject[] targets;

	public bool requireOre;
    public float requireAmount;
    int i;

	void OnTriggerEnter(Collider other) {
		if (requireOre && Managers.Inventory.equippedItem != "ore" && Managers.Inventory.GetItemCount("ore")<5) {
			return;
		} else {
            Managers.Inventory.AddItem("key");
            i = 0;
            while (i < 5) {
                Managers.Inventory.ConsumeItem("ore");
                i++;
            }
            Managers.Inventory.EquipItem(null);
        }
	}

	void OnTriggerExit(Collider other) {
		return;
	}
}
