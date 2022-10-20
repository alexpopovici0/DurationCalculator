using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurationCalculator
{
    public class GradeDurationModel
    {
        public int[] _duration;
        public List<bool> _levels;

        public GradeDurationModel()
        {
            _duration = new int[] {0,0,0};
            _levels=new List<bool>();
        }
    }
}
