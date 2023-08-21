using UnityEngine;
using System.Collections.Generic;

public enum ContractType {
  Triangular,
  AcelerarColetivo,
  MarcacaoPressao,
  JogoCurtoRapido,
  CortaLuz,
  Tabelinha,
  BolaLonga
}

public abstract class Contract {
  ContractType Type;
  public Player Owner;
  List<Player> Players; // players that accepted the contract

  public int MaxPlayers;
  public int MinPlayers;
  public bool IsCompleted;
  public bool IsSuccess;

  public Contract(ContractType Type, Player Owner, int MaxPlayers, int MinPlayers = 2) {
    this.Type = Type;
    this.Owner = Owner;
    this.MaxPlayers = MaxPlayers;
    this.MinPlayers = MinPlayers;

    this.Players = new();
  }

  public virtual void Accept(Player player) {
    if (this.Players.Count < this.MaxPlayers) {
      this.Players.Add(player);
    }
  }

  public virtual void Done(bool isSuccess = false) {
    this.IsCompleted = true;
    this.IsSuccess = isSuccess;
  }

  public abstract bool CanActivate();

  public abstract void Execute();
}