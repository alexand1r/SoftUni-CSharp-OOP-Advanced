using System.Collections.Generic;

public interface ILeutenantGeneral : IPrivate
{
    IList<IPrivate> PrivatesUnderCommand { get; }
}