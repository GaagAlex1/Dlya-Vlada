using System;
using System.Linq;

namespace Lab4
{
    public partial class ArrayTasks
    {
        private static Random random = new Random();

        public static void FillArrayRandom()
        {
            for (int i = 0; i < _arr.Length; i++)
            {
                _arr[i] = random.Next(-10, 10);
            }
        }

        public static void FillArrayManual(string reference)
        {
            string[] input = reference.Split(' ');

            _len = input.Length;
            _arr = new int[_len];

            for (int i = 0; i < _len; ++i)
            {
                _arr[i] = Convert.ToInt32(input[i]);
            }
        }

        public static void DeleteHigherThanMid()
        {
            int sum = 0;
            foreach (int i in _arr) sum += i;
            double mid = sum / _len;
            int cnt = 0;
            for (int i = 0; i < _len; i++)
            {
                if (mid < _arr[i])
                {
                    cnt++;
                    for (int j = i; j < _len - 1; j++)
                    {
                        _arr[j] = _arr[j + 1];
                    }
                }
            }
            Resize(_arr.Length - cnt);
            _len = _arr.Length;
        }

        private static void Resize(int size)
        {
            int[] arrCopy = _arr;
            _arr = new int[size];
            for (int i = 0; i < _len && i < arrCopy.Length; i++) _arr[i] = arrCopy[i];
        }

        public static void AddNumbersFromKeyboard(string input)
        {
            Resize(_len + input.Count(space => space == ' ') + 1);
            string[] addedItems = input.Split(' ');
            for (int i = _len; i < _arr.Length; i++)
            {
                _arr[i] = Convert.ToInt32(addedItems[i - _len]);
            }
            _len = _arr.Length;
        }

        public static void SwapEvenOddItems()
        {
            for (int i = 1; i < _arr.Length; i += 2)
            {
                (_arr[i - 1], _arr[i]) = (_arr[i], _arr[i - 1]);
            }
        }

        public static int IndexOfFirstNegative(out int c)
        {
            c = 0;
            int elem = 0;
            for (int i = 0; i < _arr.Length; i++)
            {
                c++;
                if (_arr[i] < 0)
                {
                    if (elem == 0) elem = _arr[i];
                    else
                    {
                        if (_arr[i] == elem)
                        {
                            return i;
                        }    
                    }
                }
            }
            return -1;
        }

        public static int ExponentialSearch(int value, out int c)
        {
            c = 1;
            if (_arr[0] == value)
                return 0;

            int i = 1;
            while (i < _len && _arr[i] <= value)
                i *= 2;

            return BinarySearch(i / 2, Math.Min(i, _len - 1), value, ref c);
        }

        private static int BinarySearch(int left, int right, int value, ref int c)
        {
            if (right >= left)
            {
                c++;
                int mid = left + (right - left) / 2;

                if (_arr[mid] == value)
                {
                    return mid;
                }
                if (_arr[mid] > value)
                {
                    return BinarySearch(left, mid - 1, value, ref c);
                }

                return BinarySearch(mid + 1, right, value, ref c);
            }

            return -1;
        }

        public static void QuickSort(int left, int right)
        {
            int i = left;
            int j = right;
            int start = _arr[left];
            while (i <= j)
            {
                while (_arr[i] < start) i++;
                while (_arr[j] > start) j--;

                if (i <= j)
                {
                    (_arr[i], _arr[j]) = (_arr[j], _arr[i]);
                    i++;
                    j--;
                }
            }

            if (left < j) QuickSort(left, j);
            if (i < right) QuickSort(i, right);
        }

        private static void InsertSortArray()
        {
            for (int i = 0; i < _arr.Length; i++)
            {
                int item = _arr[i];
                for (int j = i - 1; j >= 0 && _arr[j]>item; j--)
                {
                    _arr[j + 1] = _arr[j];
                    _arr[j] = item;
                }
            }
        }
    }
}

