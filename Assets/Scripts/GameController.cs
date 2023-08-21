using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour, IUICaller {
  [SerializeField]
  private Logger _logger;

  public CalendarController calendarController;

  public MatchController MatchController;

  public Club playerClub;

  private CalendarUI calendarUI;

  void Awake() {
    DontDestroyOnLoad(gameObject);

    calendarUI = calendarUI = GameObject.Find("Context").GetComponent<CalendarUI>();;

    // After we'll get the game info from a saving file
    calendarController = GameObject
      .FindGameObjectWithTag("CalendarController")
      .GetComponent<CalendarController>();
    
    MatchController = GetComponent<MatchController>();
    
    var sport = new Club("Sport", "Recife", 4);

    calendarController.Schedule(
      new DateTime(2023, 8, 22), 
      new Match(
        dateTime: new DateTime(2023, 8, 22),
        away: sport,
        home: new Club("São Paulo", "São Paulo", 5)
      )
    );

    playerClub = sport;
  }

  void Start() {
    DrawUI();
  }

  public void DrawUI() {
    calendarUI.SetClub(playerClub.Name, Color.red);
  }
}