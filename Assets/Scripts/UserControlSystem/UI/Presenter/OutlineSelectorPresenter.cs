using UnityEngine;
public class OutlineSelectorPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    private OutlineSelector[] _outlineSelectors;
    private ISelecatable _currentSelectable;
    private void Start()
    {
        _selectable.OnSelected += onSelected;
        onSelected(_selectable.CurrentValue);
    }
    private void onSelected(ISelecatable selectable)
    {
        if (_currentSelectable == selectable)
        {
            return;
        }
        _currentSelectable = selectable;
        setSelected(_outlineSelectors, false);
        _outlineSelectors = null;
        if (selectable != null)
        {
            _outlineSelectors = (selectable as
            Component).GetComponentsInParent<OutlineSelector>();
            setSelected(_outlineSelectors, true);
        }
        static void setSelected(OutlineSelector[] selectors, bool value)
        {
            if (selectors != null)
            {
                for (int i = 0; i < selectors.Length; i++)
                {
                    selectors[i].SetSelected(value);
                }
            }
        }
    }
}
