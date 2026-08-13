namespace UlearnCourse.FundamentalsOfProgrammingPart2.QueuesStacksGenerics
{
    public class ListModel<TItem>
    {
        public List<TItem> Items { get; }

        private readonly LimitedSizeStack<ICommand> commandHistory;

        public ListModel(int undoLimit) : this(new List<TItem>(), undoLimit)
        {
        }

        public ListModel(List<TItem> items, int undoLimit)
        {
            Items = items;
            commandHistory = new LimitedSizeStack<ICommand>(undoLimit);
        }

        public void AddItem(TItem item)
        {
            var add = new AddItemCommand<TItem>(Items, item, Items.Count);
            add.Execute();
            commandHistory.Push(add);
        }

        public void RemoveItem(int index)
        {
            var remove = new RemoveItemCommand<TItem>(Items, Items[index], index);
            remove.Execute();
            commandHistory.Push(remove);
        }

        public bool CanUndo()
        {
            return commandHistory.Count > 0;
        }

        public void Undo()
        {
            var undoCommand = commandHistory.Pop();
            undoCommand.Undo();
        }
    }

    public interface ICommand
    {
        public void Execute();

        public void Undo();
    }

    public class AddItemCommand<TItem> : ICommand
    {
        private readonly List<TItem> items;
        private readonly TItem item;
        private readonly int index;

        public AddItemCommand(List<TItem> items, TItem item, int index)
        {
            this.items = items;
            this.item = item;
            this.index = index;
        }

        public void Execute()
        {
            items.Insert(index, item);
        }

        public void Undo()
        {
            items.Remove(item);
        }
    }

    public class RemoveItemCommand<TItem> : ICommand
    {
        private readonly List<TItem> items;
        private readonly TItem item;
        private readonly int index;

        public RemoveItemCommand(List<TItem> items, TItem item, int index)
        {
            this.items = items;
            this.item = item;
            this.index = index;
        }

        public void Execute()
        {
            items.RemoveAt(index);
        }

        public void Undo()
        {
            items.Insert(index, item);
        }
    }
}