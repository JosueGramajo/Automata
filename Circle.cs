using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MindFusion.Diagramming.Wpf.Samples.CS.Anchors
{
    public class Circle
    {
        String letter;
        String number;
        String equalSymbol;
        String plusSymbol;
        String fdc;

        public String Letter {
            get { return this.letter; }
            set { this.letter = value; }
        }
        public String Number
        {
            get { return this.number; }
            set { this.number = value; }
        }
        public String EqualSymbol
        {
            get { return this.equalSymbol; }
            set { this.equalSymbol = value; }
        }
        public String PlusSymbol
        {
            get { return this.plusSymbol; }
            set { this.plusSymbol = value; }
        }
        public String Fdc
        {
            get { return this.fdc; }
            set { this.fdc = value; }
        }
    }
}
