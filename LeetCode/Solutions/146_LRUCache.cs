public class LRUCache
{
    private LinkedList<KeyValuePair<int, int>> CacheList;
    private Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> Cache;
    private int Capacity;

    public LRUCache(int capacity)
    {
        Cache = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>(capacity);
        CacheList = new LinkedList<KeyValuePair<int, int>>();
        Capacity = capacity;
    }

    public int Get(int key)
    {
        int value = -1;
        if (Cache.TryGetValue(key, out LinkedListNode<KeyValuePair<int, int>> node))
        {
            value = node.Value.Value;
            CacheList.Remove(node);
            CacheList.AddFirst(node);
        }
        return value;
    }

    public void Put(int key, int value)
    {
        LinkedListNode<KeyValuePair<int, int>> newNode = new LinkedListNode<KeyValuePair<int, int>>(new KeyValuePair<int, int>(key, value));
        if (Cache.ContainsKey(key))
        {
            LinkedListNode<KeyValuePair<int, int>> oldNode = Cache[key];
            Cache[key] = newNode;
            CacheList.Remove(oldNode);
            CacheList.AddFirst(newNode);
        }
        else if (Cache.Count >= Capacity)
        {
            LinkedListNode<KeyValuePair<int, int>> evictedNode = CacheList.Last;
            Cache.Remove(evictedNode.Value.Key);
            Cache.Add(key, newNode);
            CacheList.AddFirst(newNode);
            CacheList.Remove(evictedNode);
        }
        else
        {
            Cache.Add(key, newNode);
            CacheList.AddFirst(newNode);
        }
    }
}