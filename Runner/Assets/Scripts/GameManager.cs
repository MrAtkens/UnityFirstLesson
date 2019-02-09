using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


	[SerializeField]
 private Text scoreText;

 	[SerializeField]
 private Player player;

 private float score=0;

 private void Update() {
	score =  player.transform.position.z;
	scoreText.text ="Счёт: " + score.ToString("0");
 }

}
