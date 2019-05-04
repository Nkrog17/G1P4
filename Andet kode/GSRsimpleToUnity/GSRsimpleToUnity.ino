#include "GSR.h";
GSR g;
void setup() {

Serial.begin(9600);
}

void loop() {
g.GSRrun();
Serial.flush();
}
