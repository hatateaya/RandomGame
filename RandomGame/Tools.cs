namespace RandomGame
{
    static class Tools
    {
        public static T RandomSelect<T>(params T[] objects)
        {
            return objects[Logic.save.random.Next(objects.Length)];
        }
        public static bool Lucky(double possibility)
        {
            return Logic.save.random.NextDouble() <= possibility;
        }
    }
}
