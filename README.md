NetLicensing
============

NetLicensing is a .NET product key validation library written in C#.

What Can It Do?
---------------

NetLicensing can:

* Validate product keys when given a list of product keys
* Create and validate software licenses (more on that below)

NetLicensing Software Licenses
------------------------------

Each license file contains two things:

* The MAC Address of the computer it was created on (so a license file can't be copied from computer to computer)
* A product key

The license file is encrypted using two keys of your choosing, except for the fact that:

* The first key must be 16 characters long
* The second key must be 32 characters long

The License Of The Library Itself
---------------------------------

NetLicensing is licensed under the LGPL v2.1. You can read this license by reading LICENSE.txt

Documentation
-------------

Inside the Documentation folder you will find markdown files that document NetLicensing.