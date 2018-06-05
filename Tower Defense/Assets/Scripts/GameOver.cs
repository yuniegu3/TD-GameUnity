using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //reloads Scene


public class GameOver : MonoBehaviour {
    
    public string menuSceneName = "mainMenu";
    public Text roundsText;

	private void OnEnable()
	{
        roundsText.text = PlayerStats.Rounds.ToString();
	}

    public void Retry ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu ()
    {
        SceneManager.LoadScene("mainMenu");
    }

}
