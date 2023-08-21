using System;

public interface EventEmitter<T, C> {
  void Emit(string eventName, T data);
  void On(C eventType, Action<T> callback);
  void Off(C eventType, Action<T> callback);
}