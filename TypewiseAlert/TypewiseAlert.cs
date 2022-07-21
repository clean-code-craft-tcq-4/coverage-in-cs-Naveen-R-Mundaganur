using System;

namespace TypewiseAlert
{
  public class TypewiseAlert
  {
    public enum BreachType 
    {
      NORMAL,
      TOO_LOW,
      TOO_HIGH
    };
    public static BreachType inferBreach(double value, double lowerLimit, double upperLimit) 
    {
      if(value < lowerLimit) 
      {
        return BreachType.TOO_LOW;
      }
      if(value > upperLimit) 
      {
        return BreachType.TOO_HIGH;
      }
      return BreachType.NORMAL;
    }
    public enum CoolingType 
    {
      PASSIVE_COOLING,
      HI_ACTIVE_COOLING,
      MED_ACTIVE_COOLING
    };
    public static BreachType classifyTemperatureBreach(CoolingType coolingType, double temperatureInC) 
    {
      int lowerLimit = 0;
      int upperLimit = 35;
      switch(coolingType) 
      {
        //case CoolingType.PASSIVE_COOLING:
        //  lowerLimit = 0;
        //  upperLimit = 35;
        //  break;
        case CoolingType.HI_ACTIVE_COOLING:
          //lowerLimit = 0;
          upperLimit = 45;
          break;
        case CoolingType.MED_ACTIVE_COOLING:
          //lowerLimit = 0;
          upperLimit = 40;
          break;
      }
      return inferBreach(temperatureInC, lowerLimit, upperLimit);
    }
    public enum AlertTarget
    {
      TO_CONTROLLER,
      TO_EMAIL
    };
    public struct BatteryCharacter 
    {
      public CoolingType coolingType;
      public string brand;
      
      //Constructor 
       public BatteryCharacter(CoolingType colling_info)
       {
           coolingType = colling_info;
           brand = "BMS";
       }
    }
    public static void checkAndAlert(AlertTarget alertTarget, BatteryCharacter batteryChar, double temperatureInC) 
    {

      BreachType breachType = classifyTemperatureBreach(batteryChar.coolingType, temperatureInC);

      switch(alertTarget) 
      {
        case AlertTarget.TO_CONTROLLER:
          sendToController(breachType);
          break;
        case AlertTarget.TO_EMAIL:
          sendToEmail(breachType);
          break;
      }
    }
    //Send Message to Controller
    public static void sendToController(BreachType breachType) 
    {
      const ushort header = 0xfeed;
      Console.WriteLine($"{header} : {breachType}\n");
    }
    
    //Send Email to Client
    public static string sendToEmail(BreachType breachType) 
    {
      string recepient = "a.b@c.com";
      string message = $"Hi, the temperature is ";
      string alerttype = "normal";

      if(breachType==BreachType.TOO_LOW)
      {
          alerttype = "too low";          
      }
      else if(breachType==BreachType.TOO_HIGH)
      {
          alerttype = "too high";
      }      
      SendMessage(recepient, message, alerttype);
      return alerttype;
    }
    
    //Send the Message in a Formated text
     public static void SendMessage(string sender, string message_info, string alert_info)
     {
         Console.WriteLine($"To: {sender}\n {message_info}{alert_info}");            
     } 
 }
}
