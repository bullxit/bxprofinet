
Library to work with PROFINET devices.<br/>
Compatible with .net standard 2, so basically with all current .net and .net framework versions.

### Usage
```C#
bx.profinet.opentcp.S7Client plc = new opentcp.S7Client();
plc.SetConnectionType(1);
plc.ConnectTo(ip, 0, 1);

byte[] temp = new byte[50];

//read 1 byte from DB6.DBW2
plc.DBRead(6, 2, 1,temp);

//read 2 bytes from I100
plc.IRead(100,2,temp);

//read DINT from DB20.DBD5
plc.DBRead(20, 5, 4, temp); //read the 4 bytes we need
S7.GetDIntAt(temp, 0); //convert to int
