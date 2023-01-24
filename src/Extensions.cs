// Some extension methods.
static class Extensions
{
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Shared.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    // Peek an element. If the element is out of bounds, returns null. A negative index is from the back with -1 being the back most.
    public static T Peek<T>(this IList<T> list, int index = -1)
    {
        if (index < 0) index += list.Count;
        if (index < 0 || index >= list.Count) return default(T);
        else return list[index];
    }

    // Return the last element of a list. If it doesn't exist, return null.
    public static T PopBack<T>(this IList<T> list)
    {
        if (list.Count == 0) return default(T);
        else
        {
            T ret = list.Last();
            list.Remove(ret);
            return ret;
        }
    }

    // Return elements from the back of the list. The first element returned was the last one.
    public static List<T> Pop<T>(this IList<T> list, int count = 1)
    {
        if (count < 1) throw new ArgumentOutOfRangeException();
        List<T> ret = new List<T>();
        for (int i = 0; i < count; i++)
        {
            ret.Add(list.PopBack());
        }
        return ret;
    }

 }