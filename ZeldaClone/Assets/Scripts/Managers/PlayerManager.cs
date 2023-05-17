using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour, IGameManager {
	public ManagerStatus status {get; private set;}

	public int health {get; private set;}
	public int maxHealth {get; private set;}
	public TextMeshProUGUI textMeshPro;

	public void Startup() {
		Debug.Log("Player manager starting...");

		// these values could be initialized with saved data
		health = 50;
		maxHealth = 100;

		textMeshPro.text = ($"Health: {health}/{maxHealth}");

		// any long-running startup tasks go here, and set status to 'Initializing' until those tasks are complete
		status = ManagerStatus.Started;
	}

	public void ChangeHealth(int value) {
		health += value;
		if (health > maxHealth) {
			health = maxHealth;
		} else if (health < 0) {
			health = 0;
		}
		textMeshPro.text = ($"Health: {health}/{maxHealth}");

		Debug.Log($"Health: {health}/{maxHealth}");
	}
}
