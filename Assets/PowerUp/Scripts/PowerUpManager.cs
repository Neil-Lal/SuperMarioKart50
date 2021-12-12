using UnityEngine;
using System.Collections.Generic;

public class PowerUpManager : Singleton<PowerUpManager>
{
	private PowerUpManager() {}

	private Queue<CustomizablePowerUp> powerUps;
	private Queue<CustomizablePowerUp> powerUpsLogs;
	private ushort powerUpLogLimit = 3;
	public static PowerUpManager instance;
	
	public int Count {
		get {
			return powerUps.Count;
		}
	}
	
	void Awake() {
		this.powerUps = new Queue<CustomizablePowerUp>();
		this.powerUpsLogs = new Queue<CustomizablePowerUp>();
		
		// Destroy if another instance already exists
		// if (instance == null)
		// {
		// 	DestroyImmediate(this);
		// }
		// else
		// {
		// 	instance = this;

		// 	// Prevent destruction of manager through Play agains
		// 	DontDestroyOnLoad (this.gameObject);

		// }
	}	

	public void Add(CustomizablePowerUp powerUp)
	{
		this.powerUps.Enqueue(powerUp);
		this.powerUpsLogs.Enqueue(powerUp);
		while (this.powerUpsLogs.Count > this.powerUpLogLimit && this.powerUpsLogs.Dequeue()) ;
	}

	private string RGBToHex(Color color)
	{
		return string.Format("#{0}{1}{2}", 
                     ((int)(color.r * 255)).ToString("X2"), 
                     ((int)(color.g * 255)).ToString("X2"), 
                     ((int)(color.b * 255)).ToString("X2"));
	}
}

