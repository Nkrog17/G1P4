class GSR{
  public:
const int GSR=A2;
int GSRsensorValue;

void GSRrun(){

   GSRsensorValue=analogRead(GSR);

    Serial.print("GSRsensorValue= " + GSRsensorValue);
    
  }
};
