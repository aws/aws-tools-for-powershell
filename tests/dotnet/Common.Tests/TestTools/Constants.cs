using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSSDK_DotNet35.UnitTests.TestTools
{
    public static class Constants
    {
        public static readonly DateTime DEFAULT_DATE = new DateTime(1997, 8, 12, 19, 54, 44, 0, DateTimeKind.Utc);
        public static readonly Byte[] DEFAULT_BLOB = UTF8Encoding.UTF8.GetBytes("Cyberdyne Systems");
        public static readonly string DEFAULT_BLOB_ENCODED = Convert.ToBase64String(DEFAULT_BLOB);
        public static readonly decimal DEFAULT_DECIMAL = 10.1111222412323m;
    }
}
