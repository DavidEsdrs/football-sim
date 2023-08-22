using System;
using System.Collections.Generic;
using UnityEngine;

public class Training : IEventListener {
  public string Title { get; set; }

  public DateTime DateTime { get; set; }

  public Training() {
    Title = $"Treino coletivo - {DateTime}";
  }

  public Training(string title, DateTime dateTime) {
    Title = $"{title} - {dateTime}";
    DateTime = dateTime;
  }

  public void Execute() {
    Debug.Log("Treino coletivo ocorreu");
  }

  public override string ToString() {
    return $"Treino coletivo";
  }
}