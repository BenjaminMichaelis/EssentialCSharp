﻿using Chapter10.Tests.CustomTestAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace AddisonWesley.Michaelis.EssentialCSharp.Chapter10.Listing10_23.Tests
{
    [TestClass]
    public class TypeTests
    {

        [TestMethodWithIgnoreIfSupport]
        [IgnoreIf(nameof(NotWindows))]
        public void MakingTypesAvailableExternallyPS1_ExitCodeIs0()
        {
            //EssentialCSharp\\src\\Chapter10.Tests\\bin\\Debug\\netcoreapp3.0
            string ps1Path = Path.GetFullPath("../../../../Chapter10/Listing10.23.RegisteringAFinalizerWithProcessExit.ps1", Environment.CurrentDirectory);
            string traceValue = "1";

            System.Diagnostics.Process powerShell = System.Diagnostics.Process.Start("powershell", $"-noprofile -command \"{ps1Path} {traceValue}\"");
            powerShell.WaitForExit();

            Assert.AreEqual(0, powerShell.ExitCode);
            System.Collections.IDictionary x = Environment.GetEnvironmentVariables();

            foreach (object? y in x.Values)
            {
                Console.WriteLine(y);
            }

            Console.WriteLine();
        }

        private static bool NotWindows()
        {
            return !RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        }

    }
}


