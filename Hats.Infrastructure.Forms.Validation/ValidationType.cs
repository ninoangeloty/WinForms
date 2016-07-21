using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hats.Infrastructure.Forms.Validation
{
    public enum ValidationType
    {
        Required,
        StringLength,
        RegularExpression,
        Range,
        Numeric,
        CustomAction,
        Custom
    }
}
