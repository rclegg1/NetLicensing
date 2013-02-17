What Is NetLicensing?
=====================

NetLicensing is a .NET library written in C# that helps you create a licensing solution for your application.

NetLicensing Can...
-------------------

* Verify product keys
* Create and verify product licenses

How Do Product Keys Work
-------------------------

Product keys can be loaded from anywhere, a file, your application's resources, etc., as long as they can be turned into a string or string array. A sample file with product keys might look like:

	111-222-333-444
	333-777-aaa-bbb
	555-uuu-iii-888

You can pass the product keys above to NetLicensing as a single string, or you could create an array and store each product key accordingly. Its up to you.

How Do Licenses Work
--------------------

NetLicensing licenses are encrypted files that contain two pieces of information.

* The MAC Address of the computer it was created on
* A product key

When a NetLicensing license is verified, the following is checked:

* The MAC Address in the file matches the MAC Address of the computer (so you can't copy the license)
* There is a valid product key

[Go To The Table Of Contents][1]

[1]: tableofcontents.md