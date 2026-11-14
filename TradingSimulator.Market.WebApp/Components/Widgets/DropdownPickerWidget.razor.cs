using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace TradingSimulator.Market.WebApp.Components.Widgets;

public partial class DropdownPickerWidget<T> : ComponentBase
{
    #region Public

    [Parameter] public T[] Entries { get; set; } = [];
    
    [Parameter] public string Label { get; set; } = string.Empty;

    [Parameter] public RenderFragment<T>? DropdownPickerEntryTemplate { get; set; }

    [Parameter] public EventCallback<T> OnSelectionChanged { get; set; }

    [Parameter] public string Placeholder { get; set; } = "Select an option";

    #endregion Public

    #region Private

    private bool _isOpen;
    private T? _selected;

    private void ToggleDropdown() => _isOpen = true;

    private void CloseDropdown() => _isOpen = false;

    private async Task SelectEntry(T entry)
    {
        _isOpen = false;
        
        _selected = entry;
        if (_selected is not null)
        {
            await OnSelectionChanged.InvokeAsync(entry);
        }
    }

    #endregion Private
}
