# Find Control (by Name) and Extend

As I understand it, the essence of your question is how to **find and use control** _using event without ASP_. In Winforms, the equivalent of `FindControlByName` is to use the `string` indexer of the `Controls` collection as shown below. However, I also notice that you're in a handler for a `MouseClick` occurring on `dgvSignals` which means that `sender` is already `dgvSignals`.

___

Nevertheless, if you want to find this or any other control by name, it's pretty easy:

```
public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        dgvSignals.MouseClick += DgvSignals_MouseClick;
    }

    private void DgvSignals_MouseClick(object? sender, MouseEventArgs e)
    {
        if(sender is DataGridView dgv)
        {
            Debug.Assert(
                dgv.Name == nameof(dgvSignals), 
                "Expecting sender name is dgvSignals");

            // Find control by name without ASP
            var findByName = Controls[nameof(dgvSignals)] as DataGridView;
            Debug.Assert(
                ReferenceEquals(findByName, dgv), 
                "Expecting these to be the same object");
        }
        else
        {
            Debug.Assert(
                false, 
                "Expecting DataGridView");
        }
    }
}
```

If the `DataGridView` isn't at the top level (e.g. it's inside a `TableLayoutPanel` or other `Control`) you will have to [IterateControlTree](https://stackoverflow.com/a/77416678/5438626) to find it.

___

There is a subtext to your question where you want to call this library from any program with a `DataGridView` regardless of name. Using [Extension Methods](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods) in your common library is one way.

```
/// <summary>
/// Custom functionality for any program with any DataGridView
/// </summary>
public static partial class DataGridViewExtensions
{
    public static void WhoAmI(this DataGridView anyDataGridView)
    {
        var controlName =
            string.IsNullOrWhiteSpace(anyDataGridView.Name) ?
                "Unnamed DataGridView" :
                anyDataGridView.Name;
        MessageBox.Show($"{nameof(WhoAmI)} called by {controlName}");
    }
}
```
[![demo of WhoAmI popup][1]][1]

**Call extension**

```
private void DgvSignals_MouseClick(object? sender, MouseEventArgs e)
{
    if(sender is DataGridView dgv)
    {
        // Call extension
        dgv.WhoAmI();
    }
    else
    {
        Debug.Assert(false, "Expecting DataGridView");
    }
}
```
  [1]: https://i.stack.imgur.com/rEyml.png