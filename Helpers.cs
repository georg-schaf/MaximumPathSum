public class StringConverter
{

    public static int[][] toTriangleArray(string inputString)
    {
        var numList = extractNumbers(inputString);
        var triangle = mapToTriangle(numList);

        return triangle;
    }

    public static List<int> extractNumbers(string inputString)
    {
        var extractedNumbers = new List<int>();

        var numbers = "0123456789";
        var numStorage = "";

        for (int i = 0; i < inputString.Length; i++)
        {
            numStorage += inputString.ElementAt(i);

            if (!numbers.Contains(inputString.ElementAt(i)) || (i == inputString.Length - 1))
            {
                int extractedNumber;
                if (numStorage != null)
                {
                    extractedNumber = int.Parse(numStorage);
                    extractedNumbers.Add(extractedNumber);

                    numStorage = "";
                }
            }
        }

        return extractedNumbers;
    }

    public static int[][] mapToTriangle(List<int> numbers)
    {
        var rowCount = calcTriangleHeight(numbers.Count());

        var triangle = new int[rowCount][];

        var numIndex = 0;
        for (int i = 0; i < rowCount; i++)
        {
            triangle[i] = new int[i + 1];
            for (int j = 0; j <= i; j++)
            {
                triangle[i][j] = numbers[numIndex];
                numIndex++;
            }
        }

        return triangle;
    }

    public static int calcTriangleHeight(int numCount)
    {
        //Apply the Gauss Summation to calculate the number of rows in the pyramid
        var rowCount = Convert.ToInt32(-0.5f + Math.Sqrt(0.25 + 2 * numCount));

        return rowCount;
    }
}

public class Triangle
{

    public static int getMaximumPathSum(int[][] triangle)
    {
        var pathSum = triangle[0][0];

        var currentIndex = 0;
        for (int row = 1; row < triangle.Count(); row++)
        {
            var indexBaseL = getBaseIndex(currentIndex)[0];
            var indexBaseR = getBaseIndex(currentIndex)[1];

            currentIndex = getIndexOfLarger(triangle[row], indexBaseL, indexBaseR);
            pathSum += triangle[row][currentIndex];
        }

        return pathSum;
    }

    public static int[] getBaseIndex(int currentIndex)
    {
        int[] baseIndex = new int[] {
                currentIndex,
                currentIndex + 1
            };

        return baseIndex;
    }

    public static int getIndexOfLarger(int[] sequence, int index_1, int index_2)
    {
        if (sequence[index_1] < sequence[index_2])
            return index_2;

        return index_1;
    }
}