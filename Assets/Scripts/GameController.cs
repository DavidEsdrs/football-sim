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

  public JSONDataManager dataManager;

  void Awake() {
    DontDestroyOnLoad(gameObject);

    var att = new PlayerAttributes();

    att.Attributes["Agility"] = 93;
    att.Attributes["Balance"] = 95;
    att.Attributes["Flexibility"] = 90;
    att.Attributes["BallControl"] = 99;
    att.Attributes["FirstTouch"] = 96;
    att.Attributes["Dribbling"] = 94;
    att.Attributes["Passing"] = 89;
    att.Attributes["LongPassing"] = 84;
    att.Attributes["Shooting"] = 90;
    att.Attributes["Vision"] = 89;
    att.Attributes["Composure"] = 88;
    att.Attributes["Decisions"] = 88;
    att.Attributes["Teamwork"] = 87;
    att.Attributes["Positioning"] = 85;

    Player messi = new(
      gameObject, 
      "Messi", 
      Position.Forward, 
      att
    );

    var success = dataManager.SaveJson(DataType.Player, messi);
    _logger.Log(success);

    // After we'll get the game info from a saving file
    calendarController = GetComponent<CalendarController>();
    
    MatchController = GetComponent<MatchController>();
    
    var sport = new Club("Sport", "Recife", 4);

    calendarController.Schedule(
      new DateTime(2023, 8, 22), 
      new Match(
        dateTime: new DateTime(2023, 8, 22),
        away: sport,
        home: new Club("São Paulo", "São Paulo", 5),
        _logger: this._logger
      )
    );

    calendarController.Schedule(
      new DateTime(2023, 8, 26),
      new Match(
        dateTime: new DateTime(2023, 8, 26),
        away: new Club("Flamengo", "Rio de Janeiro", 5),
        home: sport,
        _logger: this._logger
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
        home: sport,
        _logger: this._logger
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