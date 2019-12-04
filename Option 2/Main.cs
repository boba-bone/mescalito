namespace Option_2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using log4net;

    internal class Main
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        internal static async Task Work(string[] args)
        {
            await Task.FromResult(0);

            Logger.Info("Hello Владимир! CLR:4.0.30319.42000");
            Logger.Warn("Goodbye.");
            Logger.Error("我爱你。 愛してます。 사랑해요. 🌏");

            1.UpTo(8).ForEach(i => Logger.Debug("_".JoinArray("^".Times(i))));
        }
    }
}
