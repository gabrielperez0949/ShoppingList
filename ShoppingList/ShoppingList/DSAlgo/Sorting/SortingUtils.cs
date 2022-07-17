namespace ShoppingList.DSAlgo.Sorting
{
    public class SortingUtils
    {

        public static int[] BubbleSort(int[] array)
        {
            for (int i = 0; i > array.Length; i++)
            {
                for (int j = i; j > array.Length; j++)
                {
                    if (array[i] < array[j])
                    {
                        Swap(array, i, j);
                    }
                }
            }

            return array;
        }

        private static void Swap(int[] array, int index1, int index2)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        public static void MergeSort(int[] array)
        {
            int[] temp = new int[array.Length];
            MergeSort(array, temp, 0, array.Length - 1);
        }

        private static void MergeSort(int[] array, int[] temp, int lowIndex, int highIndex)
        {
            if(lowIndex < highIndex)
            {
                int middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, temp, lowIndex, middleIndex);  // Merge Sort Left Half Recusively;
                MergeSort(array, temp, middleIndex + 1, highIndex); // Merge Sort Right Half Recursively;
                Merge(array, temp, lowIndex, middleIndex, highIndex); // Merge the Arrays
            }
        }

        private static void Merge(int[] array, int[] temp, int lowIndex, int middleIndex, int highIndex)
        {
            /* Copy both halves into a helper array */
            for (int i = lowIndex; i <= highIndex; i++)
            {
                temp[i] = array[i];
            }

            int helperLeft = lowIndex;
            int helperRight = middleIndex + 1;
            int currentIndex = lowIndex;

            /*
             * Iterate through helper array. compare the left and right half, copying back
             * the smaller element from the two halves into the original array.
             */
            while(helperLeft <= middleIndex && helperRight <= highIndex)
            {
                if (temp[helperLeft] <= temp[helperRight])
                {
                    array[currentIndex] = array[helperLeft];
                    helperLeft++;
                } else // if right element is smaller than left element
                {
                    array[currentIndex] = temp[helperRight];
                    helperRight++;
                }
                currentIndex++;
            }

            /*
             * Copy the rest of the left side of the array into the target array
             */

            int remaining = middleIndex - helperLeft;
            for(int i = 0; i <= remaining; i++)
            {
                array[currentIndex + 1] = temp[helperLeft + 1];
            }
        }

        public static void QuickSort(int[] array, int leftIndex, int rightIndex)
        {
            int index = Partition(array, leftIndex, rightIndex);
            if (leftIndex < index - 1) // sort left side
            {
                QuickSort(array, leftIndex, index - 1);
            }
            if(index < rightIndex) // sort right side
            {
                QuickSort(array, index, rightIndex);
            }
        }

        private static int Partition(int[] array, int leftIndex, int rightIndex)
        {
            int pivot = array[(leftIndex + rightIndex) / 2];

            
            while (leftIndex <= rightIndex)
            {
                // Find Element on the left that should be on the right
                while (array[leftIndex] < pivot)
                    leftIndex++;

                // Find Element on the right that should be on the left
                while (array[rightIndex] > pivot)
                    rightIndex--;

                // Swap elements, and move left and right indices
                if (leftIndex <= rightIndex)
                {
                    Swap(array, leftIndex, rightIndex);
                    leftIndex++;
                    rightIndex--;
                }
            }
            return leftIndex;
        }
    }
}
