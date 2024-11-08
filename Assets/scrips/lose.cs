// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;

// public class Lose : MonoBehaviour
// {
//     public TextMeshProUGUI score;
//     void Start()
//     {
//         Hide();
//     }
//     public void Show()
//     {
//         gameObject.SetActive(true);
//         int scoreI = FindObjectOfType<Kill>().currentKilled * 10;
//         score.text = "You get: " + scoreI.ToString() + " Score";
//         Time.timeScale = 0;
//     }

//     public void Hide()
//     {
//         Time.timeScale = 1;
//         gameObject.SetActive(false);
//     }
// }
