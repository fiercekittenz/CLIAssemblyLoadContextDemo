#pragma once

#ifndef _UNMANAGEDTHING_H_
#define _UNMANAGEDTHING_H_

namespace SecondCLRProject
{
   class UnmanagedThing
   {
   public:
      __declspec(dllexport) UnmanagedThing();
      __declspec(dllexport) ~UnmanagedThing();

   protected:
      void InitManager() const;
   };
}

#endif //_UNMANAGEDTHING_H_