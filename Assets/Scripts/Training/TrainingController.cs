using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using System.Linq;
using System;

public class TrainingController : MonoBehaviour {
  [SerializeField]
  private Logger _logger;

  [Header("Attributes")]
  
  [SerializeField]
  private int Hardness;
  
  [SerializeField]
  private int Colletive;
  
  [SerializeField]
  private int Attack;

  [SerializeField]
  private int Defense;

  [SerializeField]
  private int Midfield;

  [SerializeField]
  private int Shooting;

  [SerializeField]
  private int Passing;

  [SerializeField]
  private int Crossing;

  [SerializeField]
  private int Creativity;

  [SerializeField]
  private int Trackling;

  TrainingUI trainingUI;

  void Start() {
    var uiController = GameObject.Find("UIControllers").GetComponent<UIController>();
    trainingUI = new(uiController.document.rootVisualElement, this);
    ResetTraining("default");
  }

  public void ResetTraining(string type) {
    Hardness = trainingUI.GetValueFromSlider("hardness");
    Colletive = trainingUI.GetValueFromSlider("colletive");
    Attack = trainingUI.GetValueFromSlider("attack");
    Defense = trainingUI.GetValueFromSlider("defense");
    Shooting = trainingUI.GetValueFromSlider("shooting");
    Passing = trainingUI.GetValueFromSlider("passing");
    Crossing = trainingUI.GetValueFromSlider("crossing");
    Creativity = trainingUI.GetValueFromSlider("creativity");
    Trackling = trainingUI.GetValueFromSlider("trackling");
  }

  public int GetTraining(string type) {
    return type switch {
        "hardness" => Hardness,
        "colletive" => Colletive,
        "attack" => Attack,
        "defense" => Defense,
        "shooting" => Shooting,
        "passing" => Passing,
        "crossing" => Crossing,
        "creativity" => Creativity,
        "trackling" => Trackling,
        _ => 0,
    };
  }
}