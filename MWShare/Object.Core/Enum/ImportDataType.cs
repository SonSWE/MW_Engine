using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object.Core.Enum
{
    /// <summary>
    /// Enum case định dạng dữ liệu để map sang object
    /// </summary>
    public enum ImportDataType : int
    {
        String = 1,
        Int = 2,
        Decimal = 3,
        Long = 4,
        DateTime = 5,
        DateTimeString = 6,
        Double = 7,

    }
}
