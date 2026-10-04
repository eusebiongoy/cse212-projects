public class Node
{
public int Data { get; set; }
public Node? Right { get; private set; }
public Node? Left { get; private set; }

public Node(int data)
{
    this.Data = data;
}

public void Insert(int value)
{
    // Only insert unique values
    if (value == Data)
    {
        return;
    }

    if (value < Data)
    {
        // Insert to the left
        if (Left is null)
            Left = new Node(value);
        else
            Left.Insert(value);
    }
    else
    {
        // Insert to the right
        if (Right is null)
            Right = new Node(value);
        else
            Right.Insert(value);
    }
}

public bool Contains(int value)
{
    if (value == Data)
    {
        return true;
    }

    if (value < Data)
    {
        if (Left is null)
            return false;

        return Left.Contains(value);
    }

    if (Right is null)
        return false;

    return Right.Contains(value);
}

public int GetHeight()
{
    int leftHeight = Left is null ? 0 : Left.GetHeight();
    int rightHeight = Right is null ? 0 : Right.GetHeight();

    return 1 + Math.Max(leftHeight, rightHeight);
}


}