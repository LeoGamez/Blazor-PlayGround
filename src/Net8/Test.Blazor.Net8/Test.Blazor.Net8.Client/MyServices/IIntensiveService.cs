
namespace Test.Blazor.Net8.Client.MyServices;
public interface IIntensiveService
{
    Task HeavyListAsync(int max, Action<int> numberCallback);
    Task<int> HeavyMethod(int parameter);
}