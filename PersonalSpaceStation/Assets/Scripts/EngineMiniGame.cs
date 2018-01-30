using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineMiniGame : MonoBehaviour, IResetUser, IResetStation
{

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

    private string stationUser = "";

	void Start () {

        startRotation = spak.rectTransform.rotation;

        currentMomentum = Random.Range(-baseMomentum, baseMomentum);
    }

    public void ResetStation(string player)
    {
        stationUser = player;
        isComplete = false;
        completionCounter = 0f;
        transform.rotation = startRotation;
    }

    public void ResetUser()
    {
        stationUser = "";
    }

    void Update () {

        if (isComplete || stationUser == "")
            return;

        CheckCompletionCriteria();
        MoveLever();
        HandlePlayerInput();
    }

    void HandlePlayerInput()
    {

        if (stationUser == "")
            return;

        float horizontalAxis = 0;

        if (Mathf.Abs(Input.GetAxis("Horizontal" + stationUser)) > .7f)
            horizontalAxis = Input.GetAxis("Horizontal" + stationUser);

        if (horizontalAxis < -.5f)
        {
            currentMomentum = baseMomentum;
            spak.rectTransform.Rotate(0f, 0f, currentMomentum);
        }
        if (horizontalAxis > .5f)
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
        stationUser = "";

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
