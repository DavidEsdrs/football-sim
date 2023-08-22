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
    switch (type) {
      case "hardness":
        Hardness = trainingUI.hardnessSlider.value;
        break;
      case "colletive":
        Colletive = trainingUI.colletiveSlider.value;
        break;
      case "attack":
        Attack = trainingUI.attackSlider.value;
        break;
      case "defense":
        Defense = trainingUI.defenseSlider.value;
        break;
      case "shooting":
        Shooting = trainingUI.shootingSlider.value;
        break;
      case "passing":
        Passing = trainingUI.passingSlider.value;
        break;
      case "crossing":
        Crossing = trainingUI.crossingSlider.value;
        break;
      case "creativity":
        Creativity = trainingUI.creativitySlider.value;
        break;
      case "trackling":
        Trackling = trainingUI.tracklingSlider.value;
        break;
      default:
        Hardness = trainingUI.hardnessSlider.value;
        Colletive = trainingUI.colletiveSlider.value;
        Attack = trainingUI.attackSlider.value;
        Defense = trainingUI.defenseSlider.value;
        Shooting = trainingUI.shootingSlider.value;
        Passing = trainingUI.passingSlider.value;
        Crossing = trainingUI.crossingSlider.value;
        Creativity = trainingUI.creativitySlider.value;
        Trackling = trainingUI.tracklingSlider.value;
        break;
    }
  }

  public int GetTraining(string type) {
    return type switch
    {
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