using System;
using Xunit;

namespace TypewiseAlert.Test
{
  public class TypewiseAlertTest
  {
    [Fact]
    public void InfersBreachAsPerLimits()
    {
      Assert.True(TypewiseAlert.inferBreach(12, 20, 30) ==
        TypewiseAlert.BreachType.TOO_LOW);
      Assert.True(TypewiseAlert.inferBreach(-12, 20, 30) ==
        TypewiseAlert.BreachType.TOO_LOW);
      Assert.True(TypewiseAlert.inferBreach(20, 20, 30) ==
        TypewiseAlert.BreachType.NORMAL);
      Assert.True(TypewiseAlert.inferBreach(50, 20, 30) ==
        TypewiseAlert.BreachType.TOO_HIGH);
      Assert.True(TypewiseAlert.inferBreach(30, 20, 30) ==
        TypewiseAlert.BreachType.NORMAL);
      Assert.True(TypewiseAlert.inferBreach(50, 50, 50) ==
        TypewiseAlert.BreachType.NORMAL);
      Assert.True(TypewiseAlert.inferBreach(25, 20, 40) ==
        TypewiseAlert.BreachType.NORMAL);
      
      //Email Validation
      Assert.True(TypewiseAlert.sendToEmail(TypewiseAlert.BreachType.TOO_LOW)=="too low");
      Assert.True(TypewiseAlert.sendToEmail(TypewiseAlert.BreachType.TOO_HIGH)=="too high");
      Assert.True(TypewiseAlert.sendToEmail(TypewiseAlert.BreachType.NORMAL)=="normal");    
      
      //Alert Check
      Assert.True(TypewiseAlert.checkAndAlert(TypewiseAlert.AlertTarget.TO_CONTROLLER, new TypewiseAlert.BatteryCharacter(TypewiseAlert.CoolingType.PASSIVE_COOLING),58.5d);
      Assert.True(TypewiseAlert.checkAndAlert(TypewiseAlert.AlertTarget.TO_EMAIL, new TypewiseAlert.BatteryCharacter(TypewiseAlert.CoolingType.HI_ACTIVE_COOLING), 42);
        
    }
  }
}
