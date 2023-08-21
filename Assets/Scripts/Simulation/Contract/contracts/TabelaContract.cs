using UnityEngine;

public class TabelaContract : Contract {

  public TabelaContract(Player owner) : base(ContractType.Tabelinha, owner, 2) {}

  public override void Execute() {}

  public override bool CanActivate() {
    return false;
  }
}