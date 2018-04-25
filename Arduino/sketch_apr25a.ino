#include <Ethernet2.h>
#include <SPI.h>
#include <Arduino.h>
#include <SoftwareSerial.h>


int Bluetooth1 = 2;   //RX sau TX
int Bluetooth2 = 4;
SoftwareSerial bluetooth(Bluetooth1,Bluetooth2);   //RX, TX



void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  bluetooth.begin(9600);


  pinMode(Bluetooth1, INPUT);
  pinMode(Bluetooth2, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:

  if(bluetooth.available())
  {
    String a = bluetooth.readString();
    Serial.print(a);
    //delay(100);

   
  }
  //Serial.print("2");
  //Serial.print("\n");
  //Serial.print("AT+BIND?");
 // delay(300);
}
