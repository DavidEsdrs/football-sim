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
  void Execute();
}