using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class SchedulingUI {
  private VisualElement document;
  private CalendarController calendarController;

  public SchedulingUI(VisualElement rootVisualElement, CalendarController calendarController) {
    document = rootVisualElement;
    this.calendarController = calendarController;
  }

  public void SetEvents(List<IEventListener> events) {
    List<string> names = events.Select(ev => ev.Title).ToList();
    document.Q<ListView>("schedule").itemsSource = names;
  }
}