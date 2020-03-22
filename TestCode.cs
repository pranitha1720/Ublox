using System;

// Class Device definition
public class Device
{
public string DeviceAddress { get; }
public Device(String address)
{
DeviceAddress = address;
}
}

//### Helper class which has helper functions defined with its functionality

public class Helper
{
private void Bond(Device tester1, Device tester2)
{
}
private bool WriteAtCommand(Device tester, String atCommand)
{
}
private Device[] ListBondedDevices(Device tester)
{
}
	
}

//### code snippet defined in the PDF ###

public class BLETest
{
	
public void TestBondAndUnbond()
{
Bond(device1, device2);
WriteAtCommand(device1, “AT+UBTUB=” + device2.DeviceAddress + “\r”);
Device[] bondedDevices = ListBondedDevices(device1);
Assert.That(bondedDevices, Is.Empty);
}
	
//### Sanity check for the AT command arguments

public void ATcommandSanityTest()
{
	Helper helper = new Helper();
    Device device1 = new Device("BLE Address");
	
 string Address = "0x123FFD09AB77";  // ### Here passing the valid device address as string
 
  // ### Here providing the Atcommands in different argument combinations into a string array
  
 string[] at_command= {"AT+UBTUB="+ Address,"AT+UBTUB", "AT+UBTUB=0x343JFH09AB77", "AB+UTTCB=" + Address, "" };
 
      // ### Using Regular expression validating the syntax of the AT command with valid address
	  
 Regex rgx = new Regex(@"^\b(\w*AT\+\w*UBTUB)\b=\b0x[a-fA-F0-9]{0,12}\b$");  
 
 foreach (string cmd in at_command)
    {
         Console.WriteLine("{0} {1} a valid AT command.",
                           cmd,
                           rgx.IsMatch(cmd) ? "is" : "is not"); // ### Validating the AT command + Address
						   
		// Validate the command functionality
		bool commandsuccess = helper.WriteAtCommand(device1, cmd );
		if(commandsuccuess == TRUE) 
			Assert that ATcommand carriage return is OK;
		Else
			Assert that ATcommand carriage return is ERROR;
		
	}
}
		
//### Test scenario1 ###

public void Test1()
{
	Helper helper = new Helper();
    Device device1 = new Device("BLE Address");
	Device device2 = new Device("Paired device to Bluetooth address");
	
	Device[] bondedDevices = ListBondedDevices(device1.DeviceAddress); // ### Read for the devices bonded into a variable of type Device[] ###
	
	If(bondedDevices == Null)
	{
		helper.Bond(device1, device2);
		bool commandsuccess = helper.WriteAtCommand(device1, “AT+UBTUB=” + device2.DeviceAddress + “\r”);
		if(commandsuccuess == TRUE) 
		{
			Assert that ATcommand carriage return is OK;
			
			Device[] bondedDeviceunpaired = ListBondedDevices(device1.DeviceAddress);  //### verify that the device is unpaired ###
		    Assert.that(bondedDeviceunpaired, not(hasitem(device2)));
					
		}
		else
		{
			Assert that ATcommand carriage return is ERROR;
			
			Device[] bondedDevicepaired = ListBondedDevices(device1.DeviceAddress); //### verify that the device exists in the list
		    Assert.that(bondedDevicepaired, hasitem(device2));
		}
			
	}
	
	Else
	{
		Device[] devicebonded = ListBondedDevices(device1.DeviceAddress);
		foreach(var x in devicebonded)
		{
			bool commandsuccess = helper.WriteAtCommand(device1, “AT+UBTUB=” + x + “\r”);
			if(commandsuccuess == TRUE) 
			{
				Assert that ATcommand carriage return is OK;
			
				Device[] bondedDeviceunpaired = ListBondedDevices(device1.DeviceAddress); // ### verify that the device is unpaired
		    	Assert.that(bondedDeviceunpaired, not(hasitem(x)));
					
			}
			else
			{
				Assert that ATcommand carriage return is ERROR;
				
				Device[] bondedDevicepaired = ListBondedDevices(device1.DeviceAddress);  // ###verify that the device exists in the list
		    	Assert.that(bondedDevicepaired, hasitem(x));
			}
		
		}
	
	}
	
}

//Test Scenario2
public void test2()
{
    Helper helper = new Helper();
    Device device1 = new Device("BLE Address");
	Device device2 = new Device("Paired device to Bluetooth address");
	
	// ## Read for the devices bonded into a variable of type Device[]
	Device[] bondedDevices = ListBondedDevices(device1.DeviceAddress);
	
	If(bondedDevices == Null)
	{
		helper.Bond(device1, device2);
		bool commandsuccess = helper.WriteAtCommand(device1, “AT+UBTUB=0xFFFFFFFFFFFF" + “\r”);
		if(commandsuccuess == TRUE) 
		{
			Assert that ATcommand carriage return is OK;
			
			// ## verify that all bonded devices are unpaired 
			Device[] devicesdeleted = ListBondedDevices(device1.DeviceAddress);
			Assert.that(devicesdeleted, Is.Empty);
		}
		Else
		{
			Assert that ATcommand carriage return is ERROR;
			Device[] bondedDevicepaired = ListBondedDevices(device1.DeviceAddress); //### verify that the device exists in the list
		    Assert.that(bondedDevicepaired, Is.Not.Null);
		}
	}
	Else
	{
		// ## the Devices bonded are already read into this object "bondedDevices" before the condition is set 
		bool commandsuccess = helper.WriteAtCommand(device1, “AT+UBTUB=0xFFFFFFFFFFFF" + “\r”);
		if(commandsuccuess == TRUE) 
		{
			Assert that ATcommand carriage return is OK;
			Assert.that(bondedDevices, Is.Empty);   
		}
		Else
		{
			Assert that ATcommand carriage return is ERROR;
			Device[] bondedDevicepaired = ListBondedDevices(device1.DeviceAddress); //### verify that the device exists in the list
		    Assert.that(bondedDevicepaired, Is.Not.Null);
		}
		
			
	}
	
}