using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagerScript : MonoBehaviour {

    public GameObject player = null;
    public Button play;
    public Button exit;
    public Text title;
    Vector2 startingPos = Vector2.zero;

    public AudioClip MainTheme;
    public AudioClip MenuTheme;

	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
        this.GetComponent<AudioSource>().clip = MenuTheme;
        this.GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (player == null)
            player = GameObject.Find("Player(Clone)");
	}

    public void Play()
    {
        player.GetComponent<PlayerScript>().SetHealth();
        player.transform.position = startingPos;
        Time.timeScale = 1;
        play.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
        title.gameObject.SetActive(false);
        this.GetComponent<AudioSource>().clip = MainTheme;
        this.GetComponent<AudioSource>().Play();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 0;
        play.gameObject.SetActive(true);
        exit.gameObject.SetActive(true);
        title.gameObject.SetActive(true);
        player.GetComponent<PlayerScript>().SetHealth();
        player.transform.position = startingPos;
        this.GetComponent<AudioSource>().clip = MenuTheme;
        this.GetComponent<AudioSource>().Play();
    }
}
