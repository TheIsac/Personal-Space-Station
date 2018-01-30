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
    private float baseMomentum = .5f;
    private float adjusterValue = .01f;

    public int completionValue = 5;

    public Interactable station;
    public bool isComplete = false;

	void Start () {

        startRotation = spak.rectTransform.rotation;

        currentMomentum = Random.Range(-baseMomentum, baseMomentum);
    }

    public void ResetStation()
    {
        isComplete = false;
        completionCounter = 0f;
        transform.rotation = startRotation;
    }

    void Update () {

        if (isComplete)
            return;

        CheckCompletionCriteria();
        MoveLever();
        HandlePlayerInput();
    }

    void HandlePlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentMomentum = baseMomentum;
            spak.rectTransform.Rotate(0f, 0f, currentMomentum);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentMomentum = -baseMomentum;
            spak.rectTransform.Rotate(0f, 0f, currentMomentum);
        }
    }

    void CheckCompletionCriteria()
    {
        if(completionCounter >= completionTime)
        {
            completionText.text = "Done";
            StartCoroutine(CompleteMiniGame());
        }

        if(spak.rectTransform.rotation.eulerAngles.z < 5f || spak.rectTransform.rotation.eulerAngles.z > 355f)
        {
            completionCounter += Time.deltaTime;
            completionText.text = completionCounter.ToString("#.0");
        }
    }

    IEnumerator CompleteMiniGame()
    {
        station.AddHealthToStation(completionValue);
        isComplete = true;

        yield return new WaitForSeconds(.5f);
        station.MiniGameComplete();
    }

    void MoveLever()
    {
        if(Mathf.Abs(currentMomentum) < 0.1f)
        {
            currentMomentum = Random.Range(-baseMomentum, baseMomentum);
        }
        else if(Mathf.Sign(currentMomentum) > 0)
        {
            currentMomentum += adjusterValue;
        }
        else
        {
            currentMomentum -= adjusterValue;
        }

        if(spak.rectTransform.rotation.eulerAngles.z < 90f || spak.rectTransform.rotation.eulerAngles.z > 270f)
            spak.rectTransform.Rotate(0f, 0f, currentMomentum);
    }
}
