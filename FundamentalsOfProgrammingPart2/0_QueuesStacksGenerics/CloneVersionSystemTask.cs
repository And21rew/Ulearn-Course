namespace UlearnCourse.FundamentalsOfProgrammingPart2.QueuesStacksGenerics
{
    public class CloneVersionSystem : ICloneVersionSystem
    {
        private readonly List<Clone> clones;
        private readonly Dictionary<string, Func<string[], string>> operations;

        public CloneVersionSystem()
        {
            clones = new() { new Clone() };

            operations = new Dictionary<string, Func<string[], string>>
            {
                ["learn"] = parts =>
                {
                    Learn(int.Parse(parts[1]), parts[2]);
                    return null;
                },

                ["rollback"] = parts =>
                {
                    Rollback(int.Parse(parts[1]));
                    return null;
                },

                ["relearn"] = parts =>
                {
                    Relearn(int.Parse(parts[1]));
                    return null;
                },

                ["clone"] = parts =>
                {
                    Clone(int.Parse(parts[1]));
                    return null;
                },

                ["check"] = parts =>
                    Check(int.Parse(parts[1]))
            };
        }

        public string Execute(string query)
        {
            var parts = query.Split();

            return operations[parts[0]](parts);
        }

        private void Learn(int ci, string pi)
        {
            clones[ci - 1].Learn(pi);
        }

        private void Rollback(int ci)
        {
            clones[ci - 1].Rollback();
        }

        private void Relearn(int ci)
        {
            clones[ci - 1].Relearn();
        }

        private void Clone(int ci)
        {
            clones.Add(new Clone(clones[ci - 1]));
        }

        private string Check(int ci)
        {
            return clones[ci - 1].Check();
        }
    }

    public class Stack<T>
    {
        private Command<T> last;
        private int size;

        public Stack() { }

        public Stack(Command<T> last, int size)
        {
            this.last = last;
            this.size = size;
        }

        public Command<T> Last => last;
        public int Count => size;

        public void Push(T command)
        {
            last = new Command<T>(command, last);
            size++;
        }

        public T Pop()
        {
            var command = last.Value;
            last = last.Previous;
            size--;

            return command;
        }

        public T Peek()
        {
            return last.Value;
        }

        public Stack<T> Clone()
        {
            return new Stack<T>(last, size);
        }

        public void Clear()
        {
            last = null;
            size = 0;
        }
    }

    public class Command<T>
    {
        public T Value;
        public Command<T> Previous;

        public Command(T value, Command<T> previous)
        {
            Value = value;
            Previous = previous;
        }
    }

    public class Clone
    {
        private Stack<string> programs;
        private Stack<string> history;

        public Clone()
        {
            programs = new Stack<string>();
            history = new Stack<string>();
        }

        public Clone(Clone clone)
        {
            programs = clone.programs.Clone();
            history = clone.history.Clone();
        }

        public void Learn(string program)
        {
            programs.Push(program);
            history.Clear();
        }

        public void Rollback()
        {
            var program = programs.Pop();
            history.Push(program);
        }

        public void Relearn()
        {
            var program = history.Pop();
            programs.Push(program);
        }

        public string Check()
        {
            if (programs.Count == 0)
                return "basic";

            return programs.Peek();
        }
    }
}