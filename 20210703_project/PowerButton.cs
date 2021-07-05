namespace CSharpTutA.cs
{
    class PowerButton : ICommand
    {
        // You can refer to instances using
        // the interface
        IElectronicDevice device;
 
        // Now we get into the specifics of
        // what happens when the power button
        // is pressed.
        public PowerButton(IElectronicDevice device)
        {
            this.device = device;
        }
 
        public void Execute()
        {
            device.On();
        }
 
        // You can provide a way to undo
        // an action just like the power 
        // button does on a remote
        public void Undo()
        {
            device.Off();
        }
    }
}