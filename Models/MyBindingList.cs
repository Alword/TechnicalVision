using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TechnicalVision.WindowsForms.Models
{
    // https://stackoverflow.com/questions/43331145/how-can-i-improve-performance-of-an-addrange-method-on-a-custom-bindinglist
    public class MyBindingList<I> : BindingList<I>
    {
        private readonly List<I> _baseList;

        public MyBindingList() : this(new List<I>())
        {

        }

        public MyBindingList(List<I> baseList) : base(baseList)
        {
            if(baseList == null)
                throw new ArgumentNullException();            
            _baseList = baseList;
        }

        public void AddRange(IEnumerable<I> vals)
        {
            ICollection<I> collection = vals as ICollection<I>;
            if (collection != null)
            {
                int requiredCapacity = Count + collection.Count;
                if (requiredCapacity > _baseList.Capacity)
                    _baseList.Capacity = requiredCapacity;
            }

            bool restore = RaiseListChangedEvents;
            try
            {
                RaiseListChangedEvents = false;
                foreach (I v in vals)
                    Add(v); // We cant call _baseList.Add, otherwise Events wont get hooked.
            }
            finally
            {
                RaiseListChangedEvents = restore;
                if (RaiseListChangedEvents)
                    ResetBindings();
            }
        }
    }
}
