using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StudyConsent : MonoBehaviour
{
    public Toggle consentToggle;

    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startButton.interactable = consentToggle.isOn;
    }


    public void StartStudy() {
        SceneManager.LoadScene("MainScene");
    }

}
