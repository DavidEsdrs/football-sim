using UnityEngine;
using System;
using System.Collections.Generic;

public class CalendarController : MonoBehaviour, IEventEmitter, IUICaller {
  [SerializeField]
  private Logger _logger;

  public DateTime currentDate;
  public Dictionary<DateTime, List<IEventListener>> schedule = new();

  public int day;
  public int month;
  public int year;

  private CalendarUI calendarUI;

  void Start() {
    calendarUI = GameObject
      .Find("Context")
      .GetComponent<CalendarUI>();
    var now = DateTime.Now;
    currentDate = new DateTime(now.Year, now.Month, now.Day);
    day = currentDate.Day;
    month = currentDate.Month;
    year = currentDate.Year;
    DrawUI();
  }

  public void DrawUI() {
    calendarUI.SetDateString(currentDate.ToString("dddd, dd MMMM yyyy"));
    calendarUI.SetEvents(GetSchedule(currentDate));
  }

  // Schedule an event (ev) at the current date
  public void Schedule(DateTime date, IEventListener ev) {
    if(!schedule.ContainsKey(date)) {
      schedule.Add(date, new());
    }
    schedule[date].Add(ev);
    _logger.Log("Scheduled: " + ev + " at " + date);
  }

  // Add 1 day in the current date
  public void NextDay() {
    currentDate += TimeSpan.FromDays(1);
    day = currentDate.Day;
    month = currentDate.Month;
    year = currentDate.Year;
    Notify();
    DrawUI();
  }

  // Execute every event scheduled at the current date
  public void Notify() {
    var eventsToday = GetSchedule(currentDate);
    foreach(var ev in eventsToday) {
      ev.Execute();
    }
  }

  // Return all the events schedule in a given date
  private List<IEventListener> GetSchedule(DateTime date) {
    if(schedule.ContainsKey(date)) {
      _logger.Log($"Event scheduled at {date}");
      return schedule[date];
    }
    _logger.Log($"Nothing scheduled at {date}");
    return new();
  }
}