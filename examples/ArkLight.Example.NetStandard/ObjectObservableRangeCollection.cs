using System;

using ArkLight.Collection;

namespace ArkLight.Example
{
    public class ObjectObservableRangeCollection : ObservableRangeCollection<object>
    {
        public ObjectObservableRangeCollection()
        {
            this.Add(new object());
            this.Add(default);
            this.Add(default);
        }
    }
}
