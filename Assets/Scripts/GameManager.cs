using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    // Study related

    
    Dictionary<string,string> ParticipantLog = new Dictionary<string,string>(){
        { "participant_id", "" },
        { "condition", "" },
        { "score", "0" },
    };


    


    //-----
    public float levelDurationSec = 60;

    float playTime = 0;

    public TMP_Text timerText;
    public GameObject spawner;
    public GameObject infoPanel;

    public TMP_Text infoText;

    public GameObject surveyPanel;

    public Player player;
    public SendToGoogleForms googleForms;

    public bool isPlaying = false;
    // Start is called before the first frame update

    string InputDescKey(Player.InputMethod inputMethod) {
        string str = "";
		switch(inputMethod) {
        case Player.InputMethod.Keys:
            str = "the <b>arrow keys</b>.";
            break;
        case Player.InputMethod.Mouse:
            str = "the <b>mouse</b>. The player follows the direction of the mouse on the screen.";
            break;
		}
        return str;
    }

    void Start()
    {
        playTime = levelDurationSec;
        surveyPanel.SetActive(false);

        InitParticipant();
        infoText.text = $"Hello and welcome to the study. \n" +
            $"Your task is to play a catch game for {levelDurationSec} sec. \n" +
            $"The goal is to collect the fruits and coins while avoiding the bombs." +
			$"You control the player using {InputDescKey(player.inputMethod)} \n" +
            $"Please press start when you are ready.";
    }

    public void StartStudy() {
        infoPanel.SetActive(false);
        isPlaying = true;
    }


    void InitParticipant()
	{
        ParticipantLog["participant_id"] = Guid.NewGuid().ToString();

        player.inputMethod = (Player.InputMethod)UnityEngine.Random.Range(0,Enum.GetNames(typeof(Player.InputMethod)).Length);
        ParticipantLog["condition"] = player.inputMethod.ToString();

        player.score = 0;
        ParticipantLog["score"] = $"{player.score}";
    }


    public void SendLog()
	{
        googleForms.SendLog(ParticipantLog);

    }


    // Update is called once per frame
    void Update()
    {
		if(!isPlaying) {
            return;
		}

        ParticipantLog["score"] = $"{player.score}";

        if(playTime <= 0) {
            playTime = 0.0f;
            isPlaying = false;
            spawner.SetActive(false);
            surveyPanel.SetActive(true);
            googleForms.SendLog(ParticipantLog);

		} else {
            timerText.text = string.Format("{0:0.00}",playTime);
            playTime -= Time.deltaTime;
        }

        
    }


	public void Reset()
	{
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

	public void OpenSurvey()
	{
        //Application.OpenURL("https://forms.gle/UQfiwSBz9uVcXjix9");
        googleForms.OpenSurvey(ParticipantLog);

    }
}
