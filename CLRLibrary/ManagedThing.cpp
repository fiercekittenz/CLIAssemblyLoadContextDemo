#include "ManagedThing.h"
#include "..\SecondCLRProject\UnmanagedThing.h"

CLRLibrary::ManagedThing::ManagedThing()
{
   // This is a managed c++ class, but since we're being weird, we also have an unmanaged/native c++ class
   // in this same assembly, making it a mixed assembly. The managed code will call into native code,
   // which then uses the ManagedClassLib.Manager.
   SecondCLRProject::UnmanagedThing thing;
}

CLRLibrary::ManagedThing::~ManagedThing()
{
}