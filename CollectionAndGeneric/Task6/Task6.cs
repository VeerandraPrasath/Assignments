using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionAndGeneric.Task6
{
    public class Task6
    {
        private UnderstandIEnumerable _understandIEnumerable;
        private UnderstandingReadOnlyCollection _understandReadOnlyCollection;

        Task6() { 
            _understandIEnumerable=new UnderstandIEnumerable();
            _understandReadOnlyCollection=new UnderstandingReadOnlyCollection();
        }

        public void Run()
        {
            _understandIEnumerable.Run();
            _understandReadOnlyCollection.Run();
        }

    }
}
