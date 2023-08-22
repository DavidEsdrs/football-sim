using System;
using System.Collections.Generic;

public interface IEventEmitter
{
  void Notify();
}

public interface IEventListener
{
  public DateTime DateTime { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public bool IsPriority { get; set; }
  public int Priority { get; set; }
  public bool IsCompleted { get; set; }
  void Execute();
}