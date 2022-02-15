#include "UnmanagedThing.h"

#include <vcclr.h>

using namespace ManagedClassLib;

// Now this is definitely weird, but the "UnmanagedThing" class has both managed and unmanaged compilations.
void SecondCLRProject::UnmanagedThing::InitManager() const
{
   // The SecondCLRProject referenced assemblies were loaded using a separate AssemblyLoadContext from Default,
   // so this will actually create a whole new instance of the Manager object as it has no knowledge
   // of the one in the Default ALC.
   Manager::Instance->DoAThing();
}