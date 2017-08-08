using System;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class AsyncHelper
    {
        public static T RunAsync<T>(Func<Task<T>> func)
        {
            try
            {
                return func().Result;
            }
            catch (AggregateException ex)
            {
                throw ex.Flatten().InnerException;
            }
        }


    }
}
