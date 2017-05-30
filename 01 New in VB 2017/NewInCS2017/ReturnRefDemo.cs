using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewInCS2017
{
    public static class ReturnRefDemo
    {

        public static ref int Find(int number, int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == number)
                {
                    return ref numbers[i]; // return the storage location, not the value
                }
            }
            throw new IndexOutOfRangeException($"{nameof(number)} not found");
        }

        public static string TestSentence()
        {
            var aSentence = new Sentence("Adrian is going to marry Adriana, because Adrian loves Adriana.");
            var found = false;

            do
            {
                // In CSharp we can declare a local variable as ref - in VB we cannot.
                // This variable takes the result...
                ref string foundString = ref aSentence.FindNext("Adr", ref found);
                if (foundString == "Adrian")
                {
                    // but via the reference, so writing this variable does actually
                    foundString = "Klaus";
                }
            } while (found);

            return aSentence.ToString();
        }
    }

    public class Sentence
    {
        private string[] mySentence;
        private int myCurrentSearchPointer;

        public Sentence(string sentence)
        {
            mySentence = sentence.Split(' ');
            myCurrentSearchPointer = -1;
        }

        public ref string FindNext(string startWithString, ref bool found)
        {
            for (int count = myCurrentSearchPointer + 1; count < mySentence.Length; count++)
            {
                if (mySentence[count].StartsWith(startWithString))
                {
                    myCurrentSearchPointer = count;
                    found = true;
                    return ref mySentence[myCurrentSearchPointer];
                }
            }

            myCurrentSearchPointer = -1;
            found = false;
            return ref mySentence[0];
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            Array.ForEach(mySentence, (word) => sb.Append(word + " "));
            return sb.ToString();
        }
    }
}
