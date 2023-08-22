using System;
using System.Collections.Generic;
using UnityEngine;

public class Interview : IEventListener {
  public string Title { get; set; }

  public DateTime DateTime { get; set; }
    public string Description { get; set; }
    public bool IsPriority { get; set; }
    public int Priority { get; set; }
    public bool IsCompleted { get; set; }

    public Interview() {
    Title = $"Entrevista coletiva - {DateTime}";
  }

  public Interview(string title, DateTime dateTime) {
    Title = $"{title} - {dateTime}";
    DateTime = dateTime;
    Description = this.ToString();
    IsPriority = false;
  }

  public void Execute() {
    Debug.Log("Entrevista coletiva ocorreu");
  }

  public override string ToString() {
    return $"Entrevista coletiva";
  }
}