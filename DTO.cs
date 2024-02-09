
class DTO
{
    Dictionary<string, string> points = new Dictionary<string, string>();
    public DTO()
    {
        points = new Dictionary<string, string>();
    }
    public DTO(string parse)
    {
        points = new Dictionary<string, string>();
        if (parse.StartsWith("#"))
            parse = parse.Remove(0, 1);
        string[] d = parse.Split(new string[] { "\n#" }, StringSplitOptions.None);
        for (int i = 0; i < d.Length; i++)
        {
            string[] p = d[i].Split(new string[] { ":" }, 2, StringSplitOptions.None);
            if (p.Length > 1)
                points.Add(p[0], p[1]);
        }
    }
    public void Add(string key, string value)
    {
        if(points.ContainsKey(key))
            points[key] = value;
        else
            points.Add(key, value);
    }
    public void Add(string[] o)
    {
        for (int i = 0; i < o.Length; i+=2)
        {
            Add(o[i], o[i + 1]);
        }
    }
    public string Get(string key)
    {
        if(points.ContainsKey(key))
            return points[key];
        return null;
    }
    public bool Contains(string key)
    {
        return points.ContainsKey(key);
    }
    public override string ToString()
    {
        string r = "";
        foreach (var item in points)
        {
            r += "\n#" + item.Key + ":" + item.Value;
        }
        if (r == "")
            return "";
        return r.Remove(0, 1);
    }
}