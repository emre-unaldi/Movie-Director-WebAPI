using Core.Utilities.Results.Abstracts;

namespace Core.Utilities.Results.Concretes;

public class DataResult<T> : Result, IDataResult<T>
{
    private T _data;
    public DataResult(bool success, T data) : base(success) => this.Data = data;

    public DataResult(bool success, string Message, T data) : base(success, Message) => this.Data = data;

    public T Data { get => _data; set => _data = value; }
}
