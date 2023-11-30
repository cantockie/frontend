using CursachFront.Core.Models;
using Newtonsoft.Json;
using System.IO;

public class MemoryService
{
    private static string memoryFile = "memory.json";

    public void Serialized(Memory memory)
    {
        string json = JsonConvert.SerializeObject(memory);
        File.WriteAllText(memoryFile, json);
    }

    public Memory Deserialize()
    {
        if (File.Exists(memoryFile))
        {
            string json = File.ReadAllText(memoryFile);
            return JsonConvert.DeserializeObject<Memory>(json);
        }

        return null;
    }

    public void ClearMemoryFile()
    {
        if (File.Exists(memoryFile))
        {
            File.Delete(memoryFile);
        }
    }
}
