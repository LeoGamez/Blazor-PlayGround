
namespace Test.Blazor.Net8.Client.MyServices;
public class IntensiveService : IIntensiveService
{
    public Task<int> HeavyMethod(int parameter)
    {
        return Task.Run(() =>
        {
            int ndx = 0;

            for (ndx = 0; ndx < 100000000; ++ndx)
            {
                ndx += 1;
            }

            return ndx;

        });
    }

    public async Task HeavyListAsync(int max, Action<int> numberCallback)
    {
        for (int i = 0; i < max; i++)
        {
            numberCallback(i);
        }
    }
}

