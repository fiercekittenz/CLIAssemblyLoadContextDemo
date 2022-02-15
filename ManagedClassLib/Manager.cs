using Microsoft.Data.SqlClient;
using System;
using System.Diagnostics;

namespace ManagedClassLib
{
   public sealed partial class Manager
   {
      // Treat this as a singleton class. This should only instantiate once for the entirety of the application;
      // however, if invoked from native code via native code, it will load the ManagedClassLib assembly into an
      // "IsolatedComponentLoadContext" which has its own static memory and no knowledge or access to the Default
      // AssemblyLoadContext of the executing assembly.
      public static Manager Instance
      {
         get
         {
            if (sManagerInstance == null)
            {
               lock (sSingletonLock)
               {
                  if (sManagerInstance == null)
                  {
                     sManagerInstance = new Manager();
                     sManagerInstance.Initialize();
                  }
               }
            }

            return sManagerInstance;
         }
      }

      public void DoAThing()
      {
         System.Diagnostics.Debug.WriteLine("I'm doing stuff, ma!");
      }

      static Manager()
      {
      }

      private Manager()
      {
      }

      // Simulate the daisy-chain of events when we instantiate our manager that eventually lands on some sql calls
      // and crashes when invoked from Managed C++.
      private void Initialize()
      {
         // Make calls to a sql database using Microsoft.Data.SqlClient.
         SqlConnection connection;

         try
         {
            string connectionString = $@"Data Source=(local)\SQLEXPRESS;Integrated Security=SSPI;Encrypt=False;Connection Timeout=600";

            // Typically, this is the line where we would see the "Platform not supported" exception.
            // If you make the C++/CLI projects' character sets equal "Not Set" instead of "Use Unicode Character Set" then it works fine.
            connection = new SqlConnection(connectionString);

            connection.Open();
         }
         catch (Exception ex)
         {
            System.Diagnostics.Debug.WriteLine(ex.ToString());
         }
      }

      private static Manager sManagerInstance = null;
      private static object sSingletonLock = new Object();
   }
}
