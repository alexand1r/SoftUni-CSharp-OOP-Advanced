public interface ICheckable
{
    string ID { get; }

    void CheckId(string pattern);
}