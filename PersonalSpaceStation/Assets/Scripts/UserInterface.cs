using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour {

    private float maxPower = 100;

    public Sprite emptyPowerBar;
    public Sprite fullPowerBar;
    public Sprite overloadedBar;

    public Text overloadText;
    public Text disabledText;
    public Text warningText;

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

        UpdatePowerUI();
    }

    void UpdatePowerUI()
    {
        // Engine room power
        float power = engine.stationHealth;
        power = Mathf.Clamp(power, 0, maxPower);

        StationHealth(enginePowerBars, power);

        // Atmo
        power = atmo.stationHealth;
        power = Mathf.Clamp(power, 0, maxPower);

        StationHealth(atmoPowerBars, power);

        // pump
        power = pump.stationHealth;
        power = Mathf.Clamp(power, 0, maxPower);

        StationHealth(pumpPowerBars, power);

        // Plant
        power = plant.stationHealth;
        power = Mathf.Clamp(power, 0, maxPower);

        StationHealth(plantPowerBars, power);
        
    }

    void StationHealth(Image[] stationBars, float power)
    {
        for (int i = 0; i < stationBars.Length; i++)
        {
            if (power / stationBars.Length >= i && power > 0)
            {
                if(i >= GameManager.instance.overloadThreshhold / 10)
                {
                    stationBars[i].sprite = overloadedBar;
                }
                else
                {
                    stationBars[i].sprite = fullPowerBar;
                }

            }
            else
            {
                stationBars[i].sprite = emptyPowerBar;
            }
        }
    }
}
