using System;
using System.Collections.Generic;
using UnityEngine;

public class Match : IEventListener {
  public string Title { get; set; }

  public Club Home { get; set; }
  public Club Away { get; set; }
  public (int homeGoals, int awayGoals) Result { get; set; }
  public List<(Player player, int minute)> goalsRecord { get; }

  public bool IsStarted = false;
  public bool IsFinished = false;

  public DateTime DateTime { get; set; }
  public string Description { get; set; }
  public bool IsPriority { get; set; }
  public int Priority { get; set; }
  public bool IsCompleted { get; set; }

  private int minute = 0;
  private int addedTime = 0;

  private TimeSpan span;
  private TimeSpan spanInterval;

  public Match(DateTime dateTime, Club home, Club away) {
    DateTime = dateTime;
    Home = home;
    Away = away;
    Result = (0, 0);
    spanInterval = TimeSpan.FromSeconds(10);
    Title = $"{home} x {away} - {dateTime}";
    Description = this.ToString();
    IsPriority = true;
    Priority = 1;
  }

  public (int, int) HomeGoal(Player player) {
    if(IsStarted && !IsFinished) {
      var res = (Result.homeGoals + 1, Result.awayGoals);
      Result = res;
      goalsRecord.Add((player, minute));
      return Result;
    }
    throw new System.Exception("Can't change match that already finished!");
  }

  public (int, int) AwayGoal(Player player) {
    if(IsStarted && !IsFinished) {
      var res = (Result.homeGoals, Result.awayGoals + 1);
      Result = res;
      goalsRecord.Add((player, minute));
      return Result;
    }
    throw new System.Exception("Can't change match that already finished!");
  }

  public void StartMatch() {
    IsStarted = true;
    Tick();
  }

  public void FinishMatch() {
    IsFinished = true;
  }

  public void Tick() {
    // calc time and match finishing
    span += spanInterval;
    minute = Convert.ToInt32(span / TimeSpan.FromMinutes(1));
    if(minute >= 90 + addedTime) {
      FinishMatch();
    }
  }

  public void Execute() {
    GameController controller = GameObject.Find("GameController").GetComponent<GameController>();
    controller.MatchController.Match = this;
    controller.MatchController.StartMatch();
  }

  public void Prematch() {
    Debug.Log("Escolhendo a equipe...");
    Debug.Log("Falando com a equipe...");
    Debug.Log("Entrando em campo...");
    Debug.Log("Cumprimentando a equipe adversária...");
    Debug.Log("Indo para suas posições...");
    Debug.Log("Tudo pronto!!!");
  }

  public override string ToString() {
    return $"Match between {Home.Name} and {Away.Name}";
  }
}