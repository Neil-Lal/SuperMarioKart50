using System.Diagnostics;
using UnityEngine;
using System.Collections;
using KartGame.KartSystems;

public class TakeablePowerUp : MonoBehaviour {
	CustomizablePowerUp customPowerUp;
	public GameObject playerObj = null;
	public PowerUpManager powerManager;
    public ArcadeKart.StatPowerup boostStats = new ArcadeKart.StatPowerup
    {
		modifiers = new ArcadeKart.Stats {
			TopSpeed = 40f,
			Acceleration = 12f
		},
        MaxTime = 0.5f
    };

	void Start() {
		customPowerUp = (CustomizablePowerUp)transform.parent.gameObject.GetComponent<CustomizablePowerUp>();
		//this.audio.clip = customPowerUp.pickUpSound;

		if (playerObj == null)
			playerObj = GameObject.FindGameObjectWithTag("Player");

		if (powerManager == null)
		{
			powerManager = GameObject.Find("Powerups").GetComponent<PowerUpManager>();
		}
	}

	void OnTriggerEnter (Collider collider) {
		if(collider.tag == "Player") {

			// Fix bug with this not instantiating on "Play again"
			if (!customPowerUp)
				customPowerUp = (CustomizablePowerUp)transform.parent.gameObject.GetComponent<CustomizablePowerUp>();

			powerManager.Add(customPowerUp);
			if(customPowerUp.pickUpSound != null){
				AudioSource.PlayClipAtPoint(customPowerUp.pickUpSound, transform.position);

				// Increase top speed temporarily
				var kart = playerObj.GetComponent<Rigidbody>().GetComponent<ArcadeKart>();
				kart.AddPowerup(this.boostStats);

				transform.parent.parent.gameObject.SetActive(false); 


			}
		}
	}
}
