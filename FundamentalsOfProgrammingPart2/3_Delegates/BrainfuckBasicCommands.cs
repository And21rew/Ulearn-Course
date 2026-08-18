namespace UlearnCourse.FundamentalsOfProgrammingPart2.Delegates
{
    public class BrainfuckBasicCommands
    {
        public static void RegisterTo(IVirtualMachine vm, Func<int> read, Action<char> write)
        {
            var symbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            vm.RegisterCommand('.', b => { write((char)vm.Memory[vm.MemoryPointer]); });
            vm.RegisterCommand('+', b => { vm.Memory[vm.MemoryPointer] = (byte)((vm.Memory[vm.MemoryPointer] + 1) % 256); });
            vm.RegisterCommand('-', b => { vm.Memory[vm.MemoryPointer] = (byte)((vm.Memory[vm.MemoryPointer] + 255) % 256); });
            vm.RegisterCommand(',', b =>
            {
                int value = read();
                if (value != -1)
                    vm.Memory[vm.MemoryPointer] = (byte)value;
            });
            vm.RegisterCommand('>', b => { vm.MemoryPointer = (vm.MemoryPointer + 1) % vm.Memory.Length; });
            vm.RegisterCommand('<', b => { vm.MemoryPointer = (vm.MemoryPointer - 1 + vm.Memory.Length) % vm.Memory.Length; });
            foreach (var s in symbols)
                vm.RegisterCommand(s, b => { vm.Memory[vm.MemoryPointer] = (byte)s; });
        }
    }
}