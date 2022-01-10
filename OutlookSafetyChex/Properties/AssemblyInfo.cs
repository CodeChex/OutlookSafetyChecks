using System;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("✓ Outlook Email Safety Checks")]
[assembly: AssemblyDescription("https://github.com/CodeChex/OutlookSafetyChex")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("@CodeChex")]
[assembly: AssemblyProduct("OutlookSafetyChex")]
[assembly: AssemblyCopyright("© Copyright 2018")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(true)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("784d73ec-37da-4cb7-a011-e4265664dd22")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.03.*")]
[assembly: AssemblyFileVersion("22.01.09")]

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]
[assembly: NeutralResourcesLanguage("en")]
