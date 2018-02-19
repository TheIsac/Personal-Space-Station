using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour {

    private float maxPower = 100;

    public Sprite emptyPowerBar;
    public Sprite fullPowerBar;

    public Image[] enginePowerBars;
    public Image[] atmoPowerBars;
    public Image[] pumpPowerBars;
    public Image[] plantPowerBars;

    public Interactable engine;
    public Interactable plant;
    public Interactable atmo;
    public Interactable pump;

    void Start () {

    }
	
	void Update () {

        // Engine room power
        float power = engine.stationHealth;
        power = Mathf.Clamp(power, 0, maxPower);

        for (int i = 0; i < enginePowerBars.Length; i++)
        {
            if(power / enginePowerBars.Length >= i)
            {
                enginePowerBars[i].sprite = fullPowerBar;
            }
            else
            {
                enginePowerBars[i].sprite = emptyPowerBar;
            }
        }

        // Atmo
        power = atmo.stationHealth;
        power = Mathf.Clamp(power, 0, maxPower);

        for (int i = 0; i < atmoPowerBars.Length; i++)
        {
            if (power / atmoPowerBars.Length >= i)
            {
                atmoPowerBars[i].sprite = fullPowerBar;
            }
            else
            {
                atmoPowerBars[i].sprite = emptyPowerBar;
            }
        }

        // plant
        power = plant.stationHealth;
        power = Mathf.Clamp(power, 0, maxPower);

        for (int i = 0; i < plantPowerBars.Length; i++)
        {
            if (power / plantPowerBars.Length >= i)
            {
                plantPowerBars[i].sprite = fullPowerBar;
            }
            else
            {
                plantPowerBars[i].sprite = emptyPowerBar;
            }
        }

        // pump
        power = pump.stationHealth;
        power = Mathf.Clamp(power, 0, maxPower);

        for (int i = 0; i < pumpPowerBars.Length; i++)
        {
            if (power / pumpPowerBars.Length >= i)
            {
                pumpPowerBars[i].sprite = fullPowerBar;
            }
            else
            {
                pumpPowerBars[i].sprite = emptyPowerBar;
            }
        }
    }
}
