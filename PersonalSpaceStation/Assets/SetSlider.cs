using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetSlider : MonoBehaviour {

    [SerializeField]
    private AudioMixer audioMixer;
    private Slider volumeSlider;

    [SerializeField]
    private string sliderName;
    private float volume;

	void Start ()
    {
        volumeSlider = GetComponent<Slider>();

        audioMixer.GetFloat(sliderName, out volume);

        volumeSlider.value = volume;
    }
}
