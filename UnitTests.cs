using Xunit;
public class MaximumPathSumTest
{

    string testString =
            "3\n" +
            "7 4\n" +
            "2 4 6\n" +
            "8 5 9 3";

    int[][] triangleArray = new int[][] {
            new int[]{3},
            new int[]{7, 4},
            new int[]{2, 4, 6},
            new int[]{8, 5, 9, 3}
        };

    [Fact]
    public void passingToTriangleArrayTest()
    {
        Assert.Equal(triangleArray, StringConverter.toTriangleArray(testString));
    }

    [Fact]
    public void passingGetMaximumPathSumTest()
    {
        Assert.Equal(23, Triangle.getMaximumPathSum(triangleArray));
    }
}