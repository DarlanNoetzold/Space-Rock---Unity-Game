using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCameraScript : MonoBehaviour {

	public Button RestartBtn;
	public Text PointText;
	public int Points = 0;

	public void AddPoints() {
		this.Points += 100;
		this.PointText.text = Points.ToString ();
	}

	public void RestartGame() {
		SceneManager.LoadScene ("GameScene");
	}

	public void ShowRestartBtn() {
		this.RestartBtn.gameObject.SetActive (true);
	}
}
