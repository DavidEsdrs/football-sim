using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour {
  [SerializeField]
  private Logger _logger;

  public UIDocument document;
  public VisualElement header;
  public VisualElement sidebar;

  public List<string> screens = new();

  [Header("Header")]
  private Button nextBtn;
  private TextElement date;

  [Header("Sidebar")]
  private Label club;

  [SerializeField]
  private TrainingController trainingController;

  [SerializeField]
  CalendarController calendarController;

  void Awake() {
    SetLayout();

    nextBtn = document.rootVisualElement.Q<Button>("next-date");
    nextBtn.RegisterCallback<ClickEvent>(NextDay);

    date = document.rootVisualElement.Q<TextElement>("date");

    club = document.rootVisualElement.Q<Label>("club");
  }

  // set screens
  void SetLayout() {
    document = GetComponent<UIDocument>();

    sidebar = document.rootVisualElement.Q<VisualElement>("sidebar");

    RegisterScreenCallback(sidebar, "scheduling", "SchedulingContainer");
    RegisterScreenCallback(sidebar, "training", "TrainingContainer");
  }

  /// <summary>
  /// Register callback in sidebar. I.e, register the callback in which will change screen
  /// </summary>
  /// <param name="visualElement">
  ///  name of the container that holds the navigation buttons (e.g. the sidebar)
  /// </param>
  /// <param name="navName">
  ///  name of the navigation button in the sidebar
  /// </param>
  /// <param name="screenContainerName">
  /// name of the container in which holds the screen (that can be navigated to)
  /// </param>
  void RegisterScreenCallback(VisualElement visualElement, string navName, string screenContainerName) {
    screens.Add(screenContainerName);
    visualElement.Q<Button>(navName).RegisterCallback<ClickEvent, string>(Goto, screenContainerName);
  }

  // Sidebar
  // Change current screen
  void Goto(ClickEvent ev, string screenName) {
    _logger.Log("Trying to change screen - " + screenName);
    foreach(var screen in screens) {
      if(screen == screenName) {
        document.rootVisualElement.Q<VisualElement>(screen).RemoveFromClassList("none");
      } else {
        document.rootVisualElement.Q<VisualElement>(screen).AddToClassList("none");
      }
    }
  }

  // Increment current date by one day
  private void NextDay(ClickEvent ev) {
    calendarController.NextDay();
  }

  // Set the current date in the UI
  public void SetDateString(string date) {
    this.date.text = date;
  }

  // Set the club in the UI
  public void SetClub(string name, Color color) {
    club.text = name;
    club.style.color = color;
  }

}
