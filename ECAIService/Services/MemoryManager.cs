namespace ECAIService.Services;

public class MemoryManager
{
    private const bool mayCollectMemory = true;

    public void MayCollectMemory(Action collect)
    {
        if (mayCollectMemory) collect();
    }

    public void SetDefault<T>(ref T obj)
    {
        obj = default!;
    }

    public void SetDefault<T, T1>(ref T obj, ref T1 obj1)
    {
        obj = default!;
        obj1 = default!;
    }
}
