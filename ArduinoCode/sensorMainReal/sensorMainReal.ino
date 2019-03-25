#include "GSR_Class.h";
classGSR GSRC;

//Variable classifications
const long refreshR = 10;
unsigned char counter;  //antal hjerteslag.
unsigned long temp[refreshR + 1]; //array der skal have plads til counter
unsigned long sub;      //forskellen mellem sidste hjerte slag og det nuværende
bool startBool = true; //boolean der styrer
unsigned int HR;//the measurement result of heart rate
const int HRTimeOut = 2000;//you can change it follow your system's request.
//2000 meams 2 seconds. System return error
//if the duty overtrip 2 second.

void setup(){
  Serial.begin(9600);
  arrayInit();
  attachInterrupt(0, interrupt, RISING);
}

void loop(){
  GSRC.GSRrun();
}

/*Function: calculate the heart rate*/
void sum(){
  if (startBool) {
    HR = (60 * refreshR * 1000) / (temp[refreshR] - temp[0]); 
    Serial.print("HR=");
    Serial.println(HR);
    Serial.flush();
  }
  startBool = true; 
}
/*Function: Interrupt service routine.Get the sigal from the erefreshRternal interrupt*/
void interrupt() {
  temp[counter] = millis(); 
  switch (counter) { 
    case 0:
      sub = temp[counter] - temp[refreshR];
      break;
    default:
      sub = temp[counter] - temp[counter - 1];
      break;
  }
  if (sub > HRTimeOut) {
    startBool = false; //sign bit
    counter = 0;
    Serial.println("Heart rate measure error, test will restart!" );
    arrayInit();
  }
  if (counter == refreshR && startBool) {
    counter = 0;
    sum();
  }
  else if (counter != refreshR && startBool)
    counter++;
  else {
    counter = 0;
    startBool = true;
  }
}
void arrayInit(){
  for (unsigned char i = 0; i < refreshR; i ++)
  {
    temp[i] = 0;
  }
  temp[refreshR] = millis();
}
