using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class EncryptMethodAttribute : Attribute
{
    public string Name { get; private set; }

    public EncryptMethodAttribute(string name)
    {
        Name = name;
    }

}
