namespace Behlog.Web.Models.Common;

public class ComboBoxViewModel
{
    public ComboBoxViewModel()
    {
        _items = new List<ComboBoxItemViewModel>();
    }

    private List<ComboBoxItemViewModel> _items;
    public IEnumerable<ComboBoxItemViewModel> Items => _items;

    public void Add(ComboBoxItemViewModel item)
    {
        if (item is null) throw new ArgumentNullException(nameof(item));
        
        _items.Add(item);
    }
}

public class ComboBoxItemViewModel
{
    public ComboBoxItemViewModel()
    {
    }

    public ComboBoxItemViewModel(string key, string value)
    {
        Key = key;
        Value = value;
    }
    
    public string Key { get; set; }
    public string Value { get; set; }
}