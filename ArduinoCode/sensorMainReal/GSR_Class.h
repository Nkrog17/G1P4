class classGSR{
  public:
const int GSR=A2;
int GSRsensorValue;

void GSRrun(){

   GSRsensorValue=analogRead(GSR);
    
    Serial.print("GSRsensorValue: ");
    Serial.println(GSRsensorValue);
    delay(1000);
  }
};
