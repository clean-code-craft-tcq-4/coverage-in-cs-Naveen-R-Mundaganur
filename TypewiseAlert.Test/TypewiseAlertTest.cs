using System;
using Xunit;

namespace TypewiseAlert.Test
{
  public class TypewiseAlertTest
  {
    [Fact]
    public void InfersBreachAsPerLimits()
    {
      Assert.True(BatteryTemperatureAlert.inferBreach(12, 20, 30) == BatteryTemperatureAlert.BreachType.TOO_LOW);
      Assert.True(BatteryTemperatureAlert.inferBreach(-12, 20, 30) == BatteryTemperatureAlert.BreachType.TOO_LOW);
      Assert.True(BatteryTemperatureAlert.inferBreach(20, 20, 30) == BatteryTemperatureAlert.BreachType.NORMAL);
      Assert.True(BatteryTemperatureAlert.inferBreach(50, 20, 30) == BatteryTemperatureAlert.BreachType.TOO_HIGH);
      Assert.True(BatteryTemperatureAlert.inferBreach(30, 20, 30) == BatteryTemperatureAlert.BreachType.NORMAL);
      Assert.True(BatteryTemperatureAlert.inferBreach(50, 50, 50) == BatteryTemperatureAlert.BreachType.NORMAL);
      Assert.True(BatteryTemperatureAlert.inferBreach(25, 20, 40) == BatteryTemperatureAlert.BreachType.NORMAL);      
    }
     //Email Validation
    [Fact]
    public void SendsEmailBasedonBreach()
    {
     
      Assert.True(BatteryTemperatureAlert.sendToEmail(BatteryTemperatureAlert.BreachType.TOO_LOW)=="too low");
      Assert.True(BatteryTemperatureAlert.sendToEmail(BatteryTemperatureAlert.BreachType.TOO_HIGH)=="too high");
      Assert.True(BatteryTemperatureAlert.sendToEmail(BatteryTemperatureAlert.BreachType.NORMAL)=="normal");  
    }
    
    //Controller Verification
      [Fact]
    public void ValidateController()
    {
      BatteryTemperatureAlert.sendToController(BatteryTemperatureAlert.BreachType.NORMAL);
      BatteryTemperatureAlert.sendToController(BatteryTemperatureAlert.BreachType.TOO_LOW);
      BatteryTemperatureAlert.sendToController(BatteryTemperatureAlert.BreachType.TOO_HIGH);
    }
    
    //Classify the Breach Type Verification
     [Fact]
    public void ValidateBreachType()
    {
      Assert.True(BatteryTemperatureAlert.classifyTemperatureBreach(BatteryTemperatureAlert.CoolingType.PASSIVE_COOLING, 22)==BatteryTemperatureAlert.BreachType.NORMAL);
      Assert.True(BatteryTemperatureAlert.classifyTemperatureBreach(BatteryTemperatureAlert.CoolingType.HI_ACTIVE_COOLING, 48)==BatteryTemperatureAlert.BreachType.TOO_HIGH);
      Assert.True(BatteryTemperatureAlert.classifyTemperatureBreach(BatteryTemperatureAlert.CoolingType.MED_ACTIVE_COOLING, -10)==BatteryTemperatureAlert.BreachType.TOO_LOW);                  
    }
    
    //Alert Check
    [Fact]
    public void CheckAndAlertTheBreach()
    {     
        BatteryTemperatureAlert.checkAndAlert(BatteryTemperatureAlert.AlertTarget.TO_CONTROLLER, new BatteryTemperatureAlert.BatteryCharacter(BatteryTemperatureAlert.CoolingType.PASSIVE_COOLING),58.5d);
        BatteryTemperatureAlert.checkAndAlert(BatteryTemperatureAlert.AlertTarget.TO_EMAIL, new BatteryTemperatureAlert.BatteryCharacter(BatteryTemperatureAlert.CoolingType.HI_ACTIVE_COOLING),42);
        BatteryTemperatureAlert.checkAndAlert(BatteryTemperatureAlert.AlertTarget.TO_EMAIL, new BatteryTemperatureAlert.BatteryCharacter(BatteryTemperatureAlert.CoolingType.MED_ACTIVE_COOLING),-500);      
    }
  }
}
