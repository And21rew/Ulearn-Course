namespace UlearnCourse.FundamentalsOfProgrammingPart2.Delegates
{
    public class BrainfuckLoopCommands
    {
        public static void RegisterTo(IVirtualMachine vm)
        {
            var commands = vm.Instructions;
            var cycles = new Dictionary<int, int>();
            var brackets = new Stack<int>();

            for (int i = 0; i < commands.Length; i++)
            {
                var command = commands[i];

                if (command == '[')
                {
                    brackets.Push(i);
                }
                else if (command == ']')
                {
                    var openIndex = brackets.Pop();
                    cycles[openIndex] = i;
                    cycles[i] = openIndex;
                }
            }

            vm.RegisterCommand('[', b => Jump(b, b.Memory[b.MemoryPointer] == 0));
            vm.RegisterCommand(']', b => Jump(b, b.Memory[b.MemoryPointer] != 0));

            void Jump(IVirtualMachine vm, bool shouldJump)
            {
                if (shouldJump)
                    vm.InstructionPointer = cycles[vm.InstructionPointer];
            }
        }
    }
}