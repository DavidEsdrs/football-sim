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

  public VisualElement content;

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

    VisualTreeAsset trainingUI = Resources.Load<VisualTreeAsset>("training/TrainingUI");
    VisualTreeAsset schedulingUI = Resources.Load<VisualTreeAsset>("scheduling/SchedulingUI");

    screens.Add("SchedulingContainer");
    screens.Add("TrainingContainer"); 

    nextBtn = document.rootVisualElement.Q<Button>("next-date");
    nextBtn.RegisterCallback<ClickEvent>(NextDay);

    date = document.rootVisualElement.Q<TextElement>("date");

    club = document.rootVisualElement.Q<Label>("club");
  }

  void SetLayout() {
    document = GetComponent<UIDocument>();

    content = document.rootVisualElement.Q<VisualElement>("content");
    sidebar = document.rootVisualElement.Q<VisualElement>("sidebar");

    sidebar.Q<Button>("scheduling").RegisterCallback<ClickEvent, string>(Goto, "SchedulingContainer");
    sidebar.Q<Button>("training").RegisterCallback<ClickEvent, string>(Goto, "TrainingContainer");
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

  private void NextDay(ClickEvent ev) {
    calendarController.NextDay();
  }

  public void SetDateString(string date) {
    this.date.text = date;
  }

  public void SetClub(string name, Color color) {
    club.text = name;
    club.style.color = color;
  }

  public void SetEvents(List<IEventListener> events) {
    _logger.Log("drawing events");
    List<string> names = events.Select(ev => ev.Title).ToList();
    document.rootVisualElement.Q<ListView>("schedule").itemsSource = names;
  }
}
