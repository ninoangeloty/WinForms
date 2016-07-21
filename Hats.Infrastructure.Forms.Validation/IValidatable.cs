using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hats.Infrastructure.Forms.Validation
{
    public interface IValidatable
    {
        IEnumerable<ValidationResult> Validate();
    }
}
