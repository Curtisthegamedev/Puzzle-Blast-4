using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ButtonMethods : MonoBehaviour
{
    [SerializeField] GameObject MainMenu, HowToPlayMenu, BasicInfoMenu, BasicInfoNextButton,
        PowerUpInfoMenu, ControlsMenu, BasicInfoMenuTextOneA, BasicInfoMenuTextOneB,
        BasicInfoMenuTextTwoA, BasicInfoMenuTextTwoB, BasicInfoMenuTextTwoC,
        BasicInfoMenuTextTwoD, BasicInfoMenuTextTwoE, levelTwoInstructions, winText, nextLevelButton, 
        levelTwoInstructionsButton;

    public void CloseGame()
    {
        //closes app. 
        Application.Quit(); 
    }

    public void LevelTwoInstructionsButton()
    {
        levelTwoInstructions.SetActive(true);
        levelTwoInstructionsButton.SetActive(false); 
        winText.SetActive(false);
        nextLevelButton.SetActive(true); 
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("JetPack"); 
    }

    public void LoadLevelOne()
    {
        //loads scene "levelOne". 
        SceneManager.LoadScene("LevelOne"); 
    }

    public void HowToPlay()
    {
        MainMenu.SetActive(false);
        HowToPlayMenu.SetActive(true); 
    }

    public void BasicInfo()
    {
        HowToPlayMenu.SetActive(false);
        BasicInfoMenu.SetActive(true);
        BasicInfoNextButton.SetActive(true); 
        BasicInfoMenuTextOneA.SetActive(true);
        BasicInfoMenuTextOneB.SetActive(true);
        BasicInfoMenuTextTwoA.SetActive(false);
        BasicInfoMenuTextTwoB.SetActive(false);
        BasicInfoMenuTextTwoC.SetActive(false);
        BasicInfoMenuTextTwoD.SetActive(false);
        BasicInfoMenuTextTwoE.SetActive(false); 
    }

    public void BasicInfoTwo()
    {
        BasicInfoMenuTextOneA.SetActive(false);
        BasicInfoMenuTextOneB.SetActive(false);
        BasicInfoNextButton.SetActive(false); 
        BasicInfoMenuTextTwoA.SetActive(true);
        BasicInfoMenuTextTwoB.SetActive(true);
        BasicInfoMenuTextTwoC.SetActive(true);
        BasicInfoMenuTextTwoD.SetActive(true);
        BasicInfoMenuTextTwoE.SetActive(true);
    }

    public void BackToMainMenu()
    {
        MainMenu.SetActive(true); 
        HowToPlayMenu.SetActive(false);
        BasicInfoMenu.SetActive(false);
        PowerUpInfoMenu.SetActive(false);
        ControlsMenu.SetActive(false); 
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }

    public void PowerUpInfoMenuStart()
    {
        HowToPlayMenu.SetActive(false);
        PowerUpInfoMenu.SetActive(true); 
    }

    public void Controls()
    {
        HowToPlayMenu.SetActive(false);
        ControlsMenu.SetActive(true); 
    }
}
