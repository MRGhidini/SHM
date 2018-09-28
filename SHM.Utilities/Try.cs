using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.Utilities
{
    public static class Try
    {
        public static void It(Action @try, Action<Exception> @catch = null)
        {
            try { @try?.Invoke(); } catch (Exception e) { @catch?.Invoke(e); }
        }

        public static async Task ItAsync(Func<Task> @try, Action<Exception> @catch = null)
        {
            try { await @try?.Invoke(); } catch (Exception e) { @catch?.Invoke(e); }
        }

        public static TResult It<TResult>(Func<TResult> @try, Func<Exception, TResult> @catch = null)
        {
            try { return @try != null ? @try() : default(TResult); } catch (Exception e) { return @catch != null ? @catch(e) : default(TResult); }
        }

        public static async Task<TResult> ItAsync<TResult>(Func<Task<TResult>> @try, Func<Exception, TResult> @catch = null)
        {
            try { return @try != null ? await @try() : default(TResult); } catch (Exception e) { return @catch != null ? @catch(e) : default(TResult); }
        }
    }
}
