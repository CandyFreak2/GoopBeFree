using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoopPoints : MonoBehaviour {
    private int points;

    void Start() {
        points = PlayerPrefs.GetInt("Points");
    }

    void Update() {
        points = PlayerPrefs.GetInt("Points");
    }

    public void AddPoints(int pointToAdd) {
        points += pointToAdd;
        UpdatePoints();
        Debug.Log("Added Points");
    }

    public void RemovePoints(int pointToRemove) {
        if (points == 0) return;
        points -= pointToRemove;
        UpdatePoints();
        Debug.Log("Took Points");
    }

    public void UpdatePoints() {
        PlayerPrefs.SetInt("Points", points);
        PlayerPrefs.Save();
    }
}
