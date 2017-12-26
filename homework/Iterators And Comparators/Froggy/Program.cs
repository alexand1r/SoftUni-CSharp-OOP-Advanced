using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] data = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Froggy frogy = new Froggy(data);

            string result = string.Join(", ", frogy);
            Console.WriteLine(result);
        }
    }

    public class Froggy : IEnumerable<int>
    {
        private List<int> data;

        public Froggy(int[] elements)
        {
            data = new List<int>(elements);
        }

        public Froggy()
        {
            data = new List<int>();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < data.Count; i += 2)
                yield return data[i];

            int lastIndex = 0;

            if (this.data.Count % 2 == 0)
                lastIndex = this.data.Count - 1;
            else
                lastIndex = this.data.Count - 2;

            for (int i = lastIndex; i >= 0; i -= 2)
                yield return data[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
