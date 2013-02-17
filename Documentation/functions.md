NetLicensing Functions
======================

This file contains information about the different functions included in the NetLicensing library. They are organized by class.

Encryption
----------

	public string EncryptString(string ClearText, string key, string key2)
	
This function takes the string *ClearText* and based on *string key* and *string key2*, returns an encrypted string. *string key* and *string key2* may be any string you want, except for the following limitations:

* key must be 16 characters long
* key2 must be 32 characters long

You may want to use this function to encrypt product keys if you are storing them in a basic text file.

	public string DecryptString(string EncryptedText, string key1, string key2)

This function does the opposite of *EncryptString*. Just make sure to pass the same keys to *DecryptString* as you did to *EncryptString*.

License
-------

	public void createLicenseFile(string filename, string key, string key1, string key2)
	
This function creates a license based on the following information:

* *string filename* - the filename of the license file
* *string key* - the product key
* *string key1* - the first encryption key
* *string key2* - the second encryption  key
	
It is important to note that you must check for exceptions thrown by this function yourself.

Networking
----------

	public string GetMACAddress()

This function returns the MAC address of the computer it runs on as a string and without the colons or dashes.

Validation
----------

	public bool validateKey(string key, string keys)
	
This function returns *true* if it finds *string key* within *string keys*. It returns *false* if not.

	public bool validateKeyArray(string key, string[] keys)

This function does the same thing as *validateKey*, but it uses an array of product keys to check against instead of using one flat string.

	public bool validateLicense(string licenseFile, string key1, string key2, string keys)
	
This function returns *true if the license file *string licenseFile*:

* Contains the same MAC Address as the computer it is running on
* Contains a valid product key

You must pass *validateLicense* the smae *string key1* and *string key2* as you did when you created the license file. If any exception is thrown, the license is automatically invalid.

	public bool validateLicenseArray(string licensefile, string key1, string key2, string[] keys)
	
This function does the same thing as *validateLicense*, except is uses an array of product keys to check against instead of using one flat string.

[Go To The Table Of Contents][1]

[1]: tableofcontents.md