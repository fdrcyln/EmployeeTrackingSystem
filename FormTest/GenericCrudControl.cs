using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin.Controls;
using FontAwesome.Sharp;
using WinTimer = System.Windows.Forms.Timer;

namespace FormTest
{
    public class CrudColumn
    {
        public string Name { get; set; } = "";
        public string Header { get; set; } = "";
        public Type Type { get; set; } = typeof(string);
        public bool ReadOnly { get; set; } = true;
        public string? Format { get; set; }
        public int Width { get; set; } = 100;
    }

    public class CrudConfig
    {
        public string Title { get; set; } = "";
        public Func<IEnumerable<object>> GetItems { get; set; } = () => new List<object>();
        public Action<object> AddItem { get; set; } = _ => { };
        public Action<object> UpdateItem { get; set; } = _ => { };
        public Action<object> DeleteItem { get; set; } = _ => { };
        public List<CrudColumn> Columns { get; set; } = new();
        public List<CrudField> Fields { get; set; } = new();
        public Func<Dictionary<string, object?>, (bool success, string? message)>? Validator { get; set; }
        public List<Control> Filters { get; set; } = new();
    }

    public class GenericCrudControl : UserControl
    {
        private Panel _panelHeader;
        private MaterialTextBox _txtSearch;
        private IconPictureBox _iconSearch;
        private MaterialButton _btnRefresh;
        private MaterialButton _btnNew;
        private DataGridView _gridView;
        private StatusStrip _statusStrip;
        private ToolStripStatusLabel _lblCount;
        private ToolStripStatusLabel _lblTime;
        private Panel _panelFilters;

        private CrudConfig? _config;
        private BindingList<object> _bindingList = new();
        private WinTimer _searchTimer;

        public event Action<object>? ItemDoubleClicked;

        public GenericCrudControl()
        {
            InitializeComponent();
            _searchTimer = new WinTimer { Interval = 300 };
            _searchTimer.Tick += SearchTimer_Tick;
        }

        private void InitializeComponent()
        {
            Dock = DockStyle.Fill;
            BackColor = Color.White;

            CreateHeaderPanel();
            CreateFiltersPanel();
            CreateDataGrid();
            CreateStatusStrip();
        }

        private void CreateHeaderPanel()
        {
            _panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                Padding = new Padding(12, 10, 12, 10),
                BackColor = Color.FromArgb(250, 250, 250)
            };

            _iconSearch = new IconPictureBox
            {
                IconChar = IconChar.MagnifyingGlass,
                IconSize = 24,
                IconColor = Color.Gray,
                Dock = DockStyle.Left,
                Width = 40,
                BackColor = Color.Transparent
            };

            _txtSearch = new MaterialTextBox
            {
                Hint = "Ara...",
                Dock = DockStyle.Fill
            };
            _txtSearch.TextChanged += TxtSearch_TextChanged;

            var rightPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Right,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(5, 5, 0, 5)
            };

            _btnRefresh = new MaterialButton
            {
                Text = "Yenile",
                AutoSize = true,
                Margin = new Padding(5, 0, 5, 0)
            };
            _btnRefresh.Click += BtnRefresh_Click;

            _btnNew = new MaterialButton
            {
                Text = "Yeni",
                AutoSize = true,
                Margin = new Padding(0, 0, 5, 0)
            };
            _btnNew.Click += BtnNew_Click;

            rightPanel.Controls.Add(_btnRefresh);
            rightPanel.Controls.Add(_btnNew);

            _panelHeader.Controls.Add(_txtSearch);
            _panelHeader.Controls.Add(_iconSearch);
            _panelHeader.Controls.Add(rightPanel);

            Controls.Add(_panelHeader);
        }

        private void CreateFiltersPanel()
        {
            _panelFilters = new Panel
            {
                Dock = DockStyle.Top,
                Height = 50,
                Visible = false,
                BackColor = Color.FromArgb(245, 245, 245),
                Padding = new Padding(12, 5, 12, 5)
            };

            Controls.Add(_panelFilters);
        }

        private void CreateDataGrid()
        {
            _gridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToOrderColumns = false,
                MultiSelect = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoGenerateColumns = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
                GridColor = Color.FromArgb(230, 230, 230)
            };

            _gridView.RowTemplate.Height = 35;
            _gridView.ColumnHeadersHeight = 40;
            _gridView.EnableHeadersVisualStyles = false;
            _gridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(63, 81, 181);
            _gridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            _gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            _gridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(63, 81, 181);
            _gridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 234, 246);
            _gridView.DefaultCellStyle.SelectionForeColor = Color.Black;
            _gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            _gridView.DoubleClick += GridView_DoubleClick;
            _gridView.KeyDown += GridView_KeyDown;

            // Context menu for delete
            var contextMenu = new ContextMenuStrip();
            var deleteItem = new ToolStripMenuItem("Sil", null, DeleteItem_Click);
            contextMenu.Items.Add(deleteItem);
            _gridView.ContextMenuStrip = contextMenu;

            Controls.Add(_gridView);
        }

        private void CreateStatusStrip()
        {
            _statusStrip = new StatusStrip
            {
                BackColor = Color.FromArgb(240, 240, 240)
            };

            _lblCount = new ToolStripStatusLabel("0 kayýt")
            {
                Spring = true,
                TextAlign = ContentAlignment.MiddleLeft
            };

            _lblTime = new ToolStripStatusLabel(DateTime.Now.ToString("HH:mm:ss"))
            {
                TextAlign = ContentAlignment.MiddleRight
            };

            _statusStrip.Items.Add(_lblCount);
            _statusStrip.Items.Add(_lblTime);

            Controls.Add(_statusStrip);

            // Update time every second
            var timer = new WinTimer { Interval = 1000 };
            timer.Tick += (s, e) => _lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            timer.Start();
        }

        public void SetConfig(CrudConfig config)
        {
            _config = config;
            SetupColumns();
            SetupFilters();
            RefreshData();
        }

        private void SetupColumns()
        {
            if (_config == null) return;

            _gridView.Columns.Clear();

            foreach (var column in _config.Columns)
            {
                var gridColumn = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = column.Name,
                    HeaderText = column.Header,
                    Width = column.Width,
                    ReadOnly = column.ReadOnly
                };

                if (!string.IsNullOrEmpty(column.Format))
                {
                    gridColumn.DefaultCellStyle.Format = column.Format;
                }

                _gridView.Columns.Add(gridColumn);
            }
        }

        private void SetupFilters()
        {
            if (_config == null) return;

            _panelFilters.Controls.Clear();

            if (_config.Filters.Any())
            {
                _panelFilters.Visible = true;
                _panelFilters.Height = 50;

                var flowPanel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    FlowDirection = FlowDirection.LeftToRight,
                    WrapContents = false,
                    AutoScroll = true
                };

                foreach (var filter in _config.Filters)
                {
                    filter.Margin = new Padding(5, 10, 10, 5);
                    flowPanel.Controls.Add(filter);

                    // Wire events for automatic refresh
                    if (filter is ComboBox combo)
                        combo.SelectedIndexChanged += Filter_Changed;
                    else if (filter is MaterialSwitch materialSwitch)
                        materialSwitch.CheckedChanged += Filter_Changed;
                }

                _panelFilters.Controls.Add(flowPanel);
            }
            else
            {
                _panelFilters.Visible = false;
                _panelFilters.Height = 0;
            }
        }

        private void Filter_Changed(object? sender, EventArgs e)
        {
            RefreshData();
        }

        private void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            _searchTimer.Stop();
            _searchTimer.Start();
        }

        private void SearchTimer_Tick(object? sender, EventArgs e)
        {
            _searchTimer.Stop();
            RefreshData();
        }

        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            RefreshData();
        }

        private void BtnNew_Click(object? sender, EventArgs e)
        {
            ShowEditDialog(null);
        }

        private void GridView_DoubleClick(object? sender, EventArgs e)
        {
            if (_gridView.CurrentRow?.DataBoundItem is object item)
            {
                ItemDoubleClicked?.Invoke(item);
                ShowEditDialog(item);
            }
        }

        private void GridView_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && _gridView.CurrentRow?.DataBoundItem is object item)
            {
                DeleteItem(item);
            }
        }

        private void DeleteItem_Click(object? sender, EventArgs e)
        {
            if (_gridView.CurrentRow?.DataBoundItem is object item)
            {
                DeleteItem(item);
            }
        }

        private void DeleteItem(object item)
        {
            if (_config == null) return;

            var result = MessageBox.Show("Bu kaydý silmek istediðinizden emin misiniz?", 
                "Silme Onayý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _config.DeleteItem(item);
                    RefreshData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Silme hatasý: {ex.Message}", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ShowEditDialog(object? item)
        {
            if (_config == null) return;

            var title = item == null ? $"Yeni {_config.Title}" : $"{_config.Title} Düzenle";
            var dialog = new SmartEditDialog(title, _config.Fields, _config.Validator);

            if (item != null)
            {
                // Load existing values
                var values = new Dictionary<string, object?>();
                var itemType = item.GetType();
                foreach (var field in _config.Fields)
                {
                    var property = itemType.GetProperty(field.Name);
                    if (property != null)
                    {
                        values[field.Name] = property.GetValue(item);
                    }
                }
                dialog.LoadValues(values);
            }

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (item == null)
                    {
                        _config.AddItem(dialog.FieldValues);
                    }
                    else
                    {
                        // Update existing item
                        var itemType = item.GetType();
                        foreach (var kvp in dialog.FieldValues)
                        {
                            var property = itemType.GetProperty(kvp.Key);
                            if (property != null && property.CanWrite)
                            {
                                property.SetValue(item, kvp.Value);
                            }
                        }
                        _config.UpdateItem(item);
                    }

                    RefreshData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Kaydetme hatasý: {ex.Message}", "Hata", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            dialog.Dispose();
        }

        public void RefreshData()
        {
            if (_config == null) return;

            try
            {
                var allItems = _config.GetItems().ToList();
                var filteredItems = ApplyFilters(allItems).ToList();
                
                _bindingList.Clear();
                foreach (var item in filteredItems)
                {
                    _bindingList.Add(item);
                }

                _gridView.DataSource = _bindingList;
                _lblCount.Text = $"{filteredItems.Count} kayýt";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri yükleme hatasý: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private IEnumerable<object> ApplyFilters(IEnumerable<object> items)
        {
            // Apply search filter
            var searchText = _txtSearch.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                items = items.Where(item =>
                {
                    var itemType = item.GetType();
                    return itemType.GetProperties()
                        .Where(p => p.PropertyType == typeof(string))
                        .Any(p =>
                        {
                            var value = p.GetValue(item)?.ToString()?.ToLower();
                            return !string.IsNullOrEmpty(value) && value.Contains(searchText);
                        });
                });
            }

            return items;
        }

        public void ApplyTheme(bool isDark)
        {
            var bgColor = isDark ? Color.FromArgb(48, 48, 52) : Color.White;
            var headerBgColor = isDark ? Color.FromArgb(32, 32, 35) : Color.FromArgb(250, 250, 250);
            var gridHeaderBg = isDark ? Color.FromArgb(63, 63, 70) : Color.FromArgb(63, 81, 181);
            var gridBg = isDark ? Color.FromArgb(45, 45, 48) : Color.White;
            var gridAltBg = isDark ? Color.FromArgb(50, 50, 53) : Color.FromArgb(248, 248, 248);
            var statusBg = isDark ? Color.FromArgb(40, 40, 43) : Color.FromArgb(240, 240, 240);

            BackColor = bgColor;
            _panelHeader.BackColor = headerBgColor;
            _panelFilters.BackColor = headerBgColor;
            _gridView.BackgroundColor = gridBg;
            _gridView.ColumnHeadersDefaultCellStyle.BackColor = gridHeaderBg;
            _gridView.AlternatingRowsDefaultCellStyle.BackColor = gridAltBg;
            _statusStrip.BackColor = statusBg;

            if (isDark)
            {
                _gridView.DefaultCellStyle.BackColor = gridBg;
                _gridView.DefaultCellStyle.ForeColor = Color.White;
                _gridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(80, 80, 90);
                _gridView.DefaultCellStyle.SelectionForeColor = Color.White;
                _gridView.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
                _statusStrip.ForeColor = Color.White;
            }
            else
            {
                _gridView.DefaultCellStyle.BackColor = gridBg;
                _gridView.DefaultCellStyle.ForeColor = Color.Black;
                _gridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 234, 246);
                _gridView.DefaultCellStyle.SelectionForeColor = Color.Black;
                _gridView.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
                _statusStrip.ForeColor = Color.Black;
            }
        }
    }
}