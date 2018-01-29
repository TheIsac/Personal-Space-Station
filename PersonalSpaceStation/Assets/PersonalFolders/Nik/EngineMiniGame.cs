using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineMiniGame : MonoBehaviour {

    public Image spak;
    public float completionTime = 3f;
    private Quaternion startRotation;
    private float currentMomentum;
    private float completionCounter = 0f;
    public Text completionText;

	void Start () {
        transform.rotation = Camera.main.transform.rotation;
        startRotation = spak.rectTransform.rotation;

        currentMomentum = Random.Range(-5f, 5f);
    }
	
	void Update () {

        CheckCompletionCriteria();
        MoveLever();

		if(Input.GetKeyDown(KeyCode.Q))
        {
            currentMomentum = 5f;
            spak.rectTransform.Rotate(0f, 0f, currentMomentum / 10);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentMomentum = -5f;
            spak.rectTransform.Rotate(0f, 0f, currentMomentum / 10);
        }


    }

    void CheckCompletionCriteria()
    {
        if(completionCounter >= completionTime)
        {
            completionText.text = "Done";
            return;
        }

        if(spak.rectTransform.rotation.eulerAngles.z < 5f || spak.rectTransform.rotation.eulerAngles.z > 355f)
        {
            completionCounter += Time.deltaTime;
            completionText.text = completionCounter.ToString("#.0");
        }
    }

    void MoveLever()
    {
        if(Mathf.Abs(currentMomentum) < 0.5f)
        {
            currentMomentum = Random.Range(-5f, 5f);
        }
        else if(Mathf.Sign(currentMomentum) > 0)
        {
            currentMomentum += .1f;
        }
        else
        {
            currentMomentum -= .1f;
        }

        if(spak.rectTransform.rotation.eulerAngles.z < 90f || spak.rectTransform.rotation.eulerAngles.z > 270f)
            spak.rectTransform.Rotate(0f, 0f, currentMomentum / 10);
    }
}
