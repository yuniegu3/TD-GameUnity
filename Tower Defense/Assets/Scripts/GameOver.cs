using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //reloads Scene


public class GameOver : MonoBehaviour {
    
    public SceneFader sceneFader;
    public Text roundsText;

	private void OnEnable()
	{
        roundsText.text = PlayerStats.Rounds.ToString();
	}

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFader.FadeTo("mainMenu");
    }

}
