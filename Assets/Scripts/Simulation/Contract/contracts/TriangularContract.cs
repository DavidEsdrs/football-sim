using UnityEngine;
using System.Collections.Generic;

public class TriangularContract : Contract {
  public TriangularContract(Player owner) : base(ContractType.Triangular, owner, 3, 3) {
  }
  public override void Execute() {}

  public override bool CanActivate() {
    return false;
  }
}