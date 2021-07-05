using System;
 
namespace CSharpTutA.cs
{
    // Because we implemented the 
    // ElectronicDevice interface any
    // other device we create will know
    // exactly how to interface with it.
    class Television : IElectronicDevice
    {
        public int Volume { get; set; }
 
        public void Off()
        {
            Console.WriteLine("The TV is Off");
        }
 
        public void On()
        {
            Console.WriteLine("The TV is On");
        }
 
        public void VolumeDown()
        {
            if (Volume != 0) Volume--;
            Console.WriteLine($"The TV Volume is at {Volume}");
        }
 
        public void VolumeUp()
        {
            if (Volume != 100) Volume++;
            Console.WriteLine($"The TV Volume is at {Volume}");
        }
    }
}
 
// ---------- ICommand.cs ----------
 
namespace CSharpTutA.cs
{
    interface ICommand
    {
        // We can model what happens when
        // a button is pressed for example
        // a power button. By breaking
        // everything down we can add
        // an infinite amount of flexibility
        void Execute();
        void Undo();
    }
}