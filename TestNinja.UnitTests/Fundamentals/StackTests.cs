namespace TestNinja.UnitTests.Fundamentals;

public class StackTests
{
    [Test]
    public void Count_EmptyStack_ReturnZero()
    {
        // arrange
        var stack = new TestNinja.Fundamentals.Stack<string>();

        // act & assert
        Assert.That(stack.Count, Is.Zero);
    }


    [Test]
    public void Push_WhenCalled_CountPlusOne()
    {
        // arrange
        var stack = new TestNinja.Fundamentals.Stack<string>();

        // act
        stack.Push("test");

        // assert
        Assert.That(stack.Count, Is.EqualTo(1));
    }

    [Test]
    public void Push_GivenNull_ThrowsArgumentNullException()
    {
        // arrange
        var stack = new TestNinja.Fundamentals.Stack<string>();

        // act & assert
        Assert.That(() =>
            stack.Push(null),
            Throws.ArgumentNullException
        );
    }

    [Test]
    public void Pop_WhenStackIsNotEmpty_ReturnLastItemFromStack()
    {
        // arrange
        var stack = new TestNinja.Fundamentals.Stack<string>();
        var secondItem = "second";
        stack.Push("first");
        stack.Push(secondItem);

        // act
        var actual = stack.Pop();

        // assert
        Assert.That(actual, Is.EqualTo(secondItem));
    }

    [Test]
    public void Pop_WhenStackIsNotEmpty_RemoveLastItemFromStack()
    {
        // arrange
        var stack = new TestNinja.Fundamentals.Stack<string>();
        var secondItem = "second";
        stack.Push("first");
        stack.Push(secondItem);

        // act
        var actual = stack.Pop();

        // assert
        Assert.That(stack.Count, Is.EqualTo(1));
    }

    [Test]
    public void Pop_WhenStackIsEmpty_ThrowsInvalidOperationException()
    {
        // arrange
        var stack = new TestNinja.Fundamentals.Stack<string>();

        // act & assert
        Assert.That(() =>
            stack.Pop(),
            Throws.InvalidOperationException
        );
    }

    [Test]
    public void Peek_WhenStackIsNotEmpty_ReturnLastItemFromStack()
    {
        // arrange
        var stack = new TestNinja.Fundamentals.Stack<string>();
        var secondItem = "second";
        stack.Push("first");
        stack.Push(secondItem);

        // act
        var actual = stack.Peek();

        // assert
        Assert.That(actual, Is.EqualTo(secondItem));
    }

    [Test]
    public void Peek_WhenStackIsNotEmpty_NotRemoveLastItemFromStack()
    {
        // arrange
        var stack = new TestNinja.Fundamentals.Stack<string>();
        var secondItem = "second";
        stack.Push("first");
        stack.Push(secondItem);

        // act
        var actual = stack.Peek();

        // assert
        Assert.That(stack.Count, Is.EqualTo(2));
    }

    [Test]
    public void Peek_WhenStackIsEmpty_ThrowsInvalidOperationException()
    {
        // arrange
        var stack = new TestNinja.Fundamentals.Stack<string>();

        // act & assert
        Assert.That(() =>
            stack.Peek(),
            Throws.InvalidOperationException
        );
    }
}