#pragma once

#ifndef _NETCOREINITIALIZER_H_
#define _NETCOREINITIALIZER_H_

namespace SecondCLRProject
{
   // This is a hack to trigger the library to load its referenced assemblies into the Default
   // AssemblyLoadContext by first invoking a method from within the C# code.
   public ref class NetCoreInitializer
   {
   public:
      static void InitializeHack();
   };
}

#endif //_NETCOREINITIALIZER_H_