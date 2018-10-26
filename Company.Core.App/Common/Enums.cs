namespace Company.Core.App.Common
{
    public enum StateEnum
    {
        Unchanged,
        Created,
        Modified,
        Deleted
    }

    public enum InputOption
    {
        OK = 0,
        OKCancel = 1,
        YesNoCancel = 3,
        YesNo = 4
    }

    public enum InputResult
    {
        None = 0,
        OK = 1,
        Cancel = 2,
        Yes = 6,
        No = 7
    }
}
