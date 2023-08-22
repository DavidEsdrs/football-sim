using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour, IUICaller {
  [SerializeField]
  private Logger _logger;

  public CalendarController calendarController;

  public MatchController MatchController;

  public Club playerClub;

  [SerializeField]
  private UIController uiController;

  void Awake() {
    DontDestroyOnLoad(gameObject);

    // After we'll get the game info from a saving file
    calendarController = GetComponent<CalendarController>();
    
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

    calendarController.Schedule(
      new DateTime(2023, 8, 26),
      new Match(
        dateTime: new DateTime(2023, 8, 26),
        away: new Club("Flamengo", "Rio de Janeiro", 5),
        home: sport
      )
    );

    calendarController.Schedule(
      new DateTime(2023, 8, 31),
      new Interview("Entrevista da manhã", new DateTime(2023, 8, 31, 12, 0, 0))
    );

    calendarController.Schedule(
      new DateTime(2023, 8, 31),
      new Interview("Entrevista antes do jogo", new DateTime(2023, 8, 31, 21, 0, 0))
    );

    calendarController.Schedule(
      new DateTime(2023, 8, 31),
      new Interview("Entrevista depois do jogo", new DateTime(2023, 8, 31, 23, 0, 0))
    );

    calendarController.Schedule(
      new DateTime(2023, 8, 31),
      new Match(
        dateTime: new DateTime(2023, 8, 31, 21, 30, 0),
        away: new Club("Grêmio", "Porto Alegre", 4),
        home: sport
      )
    );

    playerClub = sport;
  }

  void Start() {
    DrawUI();
  }

  public void DrawUI() {
    uiController.SetClub(playerClub.Name, Color.red);
  }
}