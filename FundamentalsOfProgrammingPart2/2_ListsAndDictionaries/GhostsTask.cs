namespace UlearnCourse.FundamentalsOfProgrammingPart2.ListsAndDictionaries
{
    public class GhostsTask : IMagic, IFactory<Vector>, IFactory<Segment>, IFactory<Cat>, IFactory<Robot>, IFactory<Document>
    {
        private byte[] bytes = { 1, 2, 3 };

        private Vector vector;
        private Segment segment;
        private Cat cat;
        private Robot robot;
        private Document document;

        public void DoMagic()
        {
            vector?.Add(new Vector(1, 1));
            segment?.Start.Add(new Vector(1, 1));
            cat?.Rename(" ");
            Robot.BatteryCapacity++;
            bytes[0] = 0;
        }

        Vector IFactory<Vector>.Create()
        {
            vector ??= new Vector(0, 0);
            return vector;
        }

        Segment IFactory<Segment>.Create()
        {
            segment ??= new Segment(new Vector(0, 0), new Vector(1, 1));
            return segment;
        }

        Cat IFactory<Cat>.Create()
        {
            cat ??= new Cat("", "", DateTime.Now);
            return cat;
        }

        Robot IFactory<Robot>.Create()
        {
            robot ??= new Robot("");
            return robot;
        }

        Document IFactory<Document>.Create()
        {
            document ??= new Document("", System.Text.Encoding.ASCII, bytes);
            return document;
        }
    }
}