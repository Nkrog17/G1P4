class classGSR{
  public:
const int GSR=A2;
int GSRsensorValue;

void GSRrun(){

   GSRsensorValue=analogRead(GSR);
    
    Serial.print("GSR=");
    Serial.print(GSRsensorValue);
    Serial.print(" ");
    Serial.println(millis());
    Serial.flush();
    delay(1000);
  }
};
