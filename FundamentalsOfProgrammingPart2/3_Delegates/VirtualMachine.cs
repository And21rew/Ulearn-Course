namespace UlearnCourse.FundamentalsOfProgrammingPart2.Delegates
{
    public class VirtualMachine : IVirtualMachine
    {
        public string Instructions { get; }
        public int InstructionPointer { get; set; }
        public byte[] Memory { get; }
        public int MemoryPointer { get; set; }

        private Dictionary<char, Action<IVirtualMachine>> commands = new();

        public VirtualMachine(string program, int memorySize)
        {
            Instructions = program;
            Memory = new byte[memorySize];
        }

        public void RegisterCommand(char symbol, Action<IVirtualMachine> execute)
        {
            if (!commands.ContainsKey(symbol))
                commands.Add(symbol, execute);
        }

        public void Run()
        {
            while (InstructionPointer >= 0 && InstructionPointer < Instructions.Length)
            {
                var instruction = Instructions[InstructionPointer];

                if (commands.TryGetValue(instruction, out var command))
                    command.Invoke(this);

                InstructionPointer++;
            }
        }
    }
}