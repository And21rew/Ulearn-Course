namespace UlearnCourse.Branches
{
    internal class RobotControl
    {
        public static bool ShouldFire2(bool enemyInFront, string enemyName, int robotHealth)
        {
            return enemyInFront && (enemyName != "boss" || robotHealth >= 50);
        }
    }
}