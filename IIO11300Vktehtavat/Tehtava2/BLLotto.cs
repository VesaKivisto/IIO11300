using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava2
{
    class Lotto
    {
        #region Muuttujat (variables)
        Random random = new Random();
        private int[] numbers;
        #endregion
        #region Metodit (methods)
        public int[] DrawLotto()
        {
            // Normiloton arvonta
            numbers = new int[7];

            for (int i = 0; i < 7; i++)
            {
                int nextNumber;

                do
                {
                    nextNumber = random.Next(1, 40);
                } while (numbers.Contains(nextNumber));

                numbers[i] = nextNumber;
            }

            Array.Sort(numbers);
            return numbers;
        }
        public int[] DrawVikingLotto()
        {
            // Viking Loton arvonta
            numbers = new int[6];

            for (int i = 0; i < 6; i++)
            {
                int nextNumber;

                do
                {
                    nextNumber = random.Next(1, 49);
                } while (numbers.Contains(nextNumber));

                numbers[i] = nextNumber;
            }

            Array.Sort(numbers);
            return numbers;
        }
        public int[] DrawEurojackpotMain()
        {
            // Eurojackpotin arvonta
            numbers = new int[5];

            for (int i = 0; i < 5; i++)
            {
                int nextNumber;

                do
                {
                    nextNumber = random.Next(1, 51);
                } while (numbers.Contains(nextNumber));

                numbers[i] = nextNumber;
            }

            Array.Sort(numbers);
            return numbers;
        }

        public int[] DrawEurojackpotStar()
        {
            // Eurojackpotin arvonta
            numbers = new int[2];

            for (int i = 0; i < 2; i++)
            {
                int nextNumber;

                do
                {
                    nextNumber = random.Next(1, 9);
                } while (numbers.Contains(nextNumber));

                numbers[i] = nextNumber;
            }

            Array.Sort(numbers);
            return numbers;
        }
        #endregion
    }
}
