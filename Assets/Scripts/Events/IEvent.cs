using System;
using System.Collections.Generic;

public interface IEventEmitter
{
  void Notify();
}

public interface IEventListener
{
  public string Title { get; set; }
  void Execute();
}