
namespace Easter.Models.Workshops
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Dyes.Contracts;
    using Easter.Models.Eggs.Contracts;

    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {

            while (true)
            {
                if (bunny.Energy == 0 || bunny.Dyes.All(x => x.IsFinished()) || egg.IsDone())
                {
                    break;
                }

                var dye = bunny.Dyes.First(x => x.IsFinished() == false);
                bunny.Work();
                dye.Use();
                egg.GetColored();
            }

        }
    }
}
