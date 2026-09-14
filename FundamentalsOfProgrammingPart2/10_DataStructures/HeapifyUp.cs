namespace UlearnCourse.FundamentalsOfProgrammingPart2.DataStructures
{
    internal class HeapifyUp
    {
        public static void HeapifyUp(List<int> heap)
        {
            var itemIndex = heap.Count - 1;

            while (itemIndex > 1 && heap[itemIndex] < heap[itemIndex / 2])
            {
                var parentIndex = itemIndex / 2;
                var t = heap[itemIndex];
                heap[itemIndex] = heap[parentIndex];
                heap[parentIndex] = t;
                itemIndex = parentIndex;
            }
        }
    }
}