using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainApplication
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();

         // Uncomment the following to see how the AssemblyLoadContext issue is "fixed" by
         // calling a dummy/hack method in the SecondCLRProject to trigger it to load referenced
         // assemblies into the Default ALC.
         //SecondCLRProject.NetCoreInitializer.InitializeHack();

         // Initialize the instance of our "manager" example.
         ManagedClassLib.Manager.Instance.DoAThing();

         // Now try to call into the CLR library, which will call into the SecondCLRProject library.
         CLRLibrary.ManagedThing thing = new CLRLibrary.ManagedThing();
      }
   }
}
