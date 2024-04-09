using System;

namespace UI.Binding
{
    public interface IView
    {
        Type ModelType { get; }
    }

    public interface IView<T> : IView where T : IModel
    {
        void Bind(T model);
    }
}