namespace RandomGame
{
    static class Tools
    {
        public static T RandomSelect<T>(List<T> objects,List<int> possibilities)
        {
            if (possibilities.Count != objects.Count)
            {
                throw new ArgumentException();
            }
            var sum = possibilities.Sum();
            var lucky = Logic.save.random.Next(sum);
            for(int i = 0,j=0; i < possibilities.Count; i++)
            {
                j += possibilities[i];
                if (j >= lucky)
                {
                    return objects[i];
                }
            }
            throw new Exception();
        }
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
