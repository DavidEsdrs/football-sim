using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class TrainingUI {
  private readonly VisualElement root;

  private TrainingController trainingController;

  public SliderInt hardnessSlider;
  public SliderInt creativitySlider;
  public SliderInt passingSlider;
  public SliderInt colletiveSlider;
  public SliderInt crossingSlider;
  public SliderInt defenseSlider;
  public SliderInt attackSlider;
  public SliderInt tracklingSlider;
  public SliderInt shootingSlider;
  

  public TrainingUI(VisualElement root, TrainingController trainingController) {
    this.root = root;
    this.trainingController = trainingController;
    RegisterCallbacks();
  }

  void RegisterCallbacks() {
    hardnessSlider = root.Q<SliderInt>("hardness");
    colletiveSlider = root.Q<SliderInt>("colletive");
    attackSlider = root.Q<SliderInt>("attack");
    defenseSlider = root.Q<SliderInt>("defense");
    shootingSlider = root.Q<SliderInt>("shooting");
    passingSlider = root.Q<SliderInt>("passing");
    crossingSlider = root.Q<SliderInt>("crossing");
    creativitySlider = root.Q<SliderInt>("creativity");
    tracklingSlider = root.Q<SliderInt>("trackling");

    hardnessSlider.RegisterCallback<ChangeEvent<int>, string>(OnChange, "hardness");
    colletiveSlider.RegisterCallback<ChangeEvent<int>, string>(OnChange, "colletive");
    attackSlider.RegisterCallback<ChangeEvent<int>, string>(OnChange, "attack");
    defenseSlider.RegisterCallback<ChangeEvent<int>, string>(OnChange, "defense");
    shootingSlider.RegisterCallback<ChangeEvent<int>, string>(OnChange, "shooting");
    passingSlider.RegisterCallback<ChangeEvent<int>, string>(OnChange, "passing");
    crossingSlider.RegisterCallback<ChangeEvent<int>, string>(OnChange, "crossing");
    creativitySlider.RegisterCallback<ChangeEvent<int>, string>(OnChange, "creativity");
    tracklingSlider.RegisterCallback<ChangeEvent<int>, string>(OnChange, "trackling");
  }

  private void OnChange(ChangeEvent<int> evt, string type) => trainingController.ResetTraining(type);
}