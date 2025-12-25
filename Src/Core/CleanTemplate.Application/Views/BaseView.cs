using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanTemplate.Application.Views;

public class BaseView<TKey>
{

    public TKey Id { get; set; }

    [AllowNull]
    public string Name { get; set; }

    [AllowNull]
    public string Description { get; set; }
}
