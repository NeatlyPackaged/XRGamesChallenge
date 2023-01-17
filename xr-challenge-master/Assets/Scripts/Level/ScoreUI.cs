using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreUI;

    [Header("References")]
    [SerializeField]
    public Pickup _Pickups;
    [SerializeField]
    public PickupDetection _StarCollector;

    // The Score will update to display the players current score
    void Start()
    {
        _scoreUI = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        _scoreUI.text = "Score: " + _StarCollector.collectedStars.ToString() + " Stars " + _StarCollector.scoreCollected.ToString();
    }
}
