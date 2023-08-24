using System;
using System.Collections.Generic;

[Serializable]
public class Stadium {
  public string name;
  public string city;
  public string country;
  public int capacity;
  public int ticketSold; // quantity of tickets sold
  public float ticketPrice; // price of each ticket
  public float ticketIncome; // total income from tickets
  public float maintenanceCost; // cost of maintenance
  public List<float> ticketIncomeHistory = new();

  public Stadium(string name, string city, string country, int capacity, float ticketPrice, float maintenanceCost) {
    this.name = name;
    this.city = city;
    this.country = country;
    this.capacity = capacity;
    this.ticketPrice = ticketPrice;
    this.maintenanceCost = maintenanceCost;
  }

  public void SellTickets(int quantity) {
    ticketSold += quantity;
    ticketIncome += quantity * ticketPrice;
    ticketIncomeHistory.Add(ticketIncome);
  }

  public void PayMaintenance() {
    ticketIncome -= maintenanceCost;
  }

  public void ImproveStadium(int quantity) {
    capacity += quantity;
    maintenanceCost += quantity * 1000; // 1k per seat
  }

  public override string ToString() {
    return $"{name} - {capacity}";
  }
}