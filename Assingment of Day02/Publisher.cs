using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_of_Day02
{
  public class Publisher
  {
    public String Name {get; set;}
    public String WebSite {get; set;}

    public override string ToString()
    {
      return Name;
    }
  }
}
