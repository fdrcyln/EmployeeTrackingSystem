using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace FormTest
{
    public enum CrudFieldType
    {
        Text,
        Combo,
        Date,
        Switch
    }

    public class CrudField
    {
        public string Name { get; set; } = "";
        public string Label { get; set; } = "";
        public CrudFieldType ControlType { get; set; } = CrudFieldType.Text;
        public bool IsRequired { get; set; }
        public Func<IEnumerable<object>>? DataSourceProvider { get; set; }
        public string? DisplayMember { get; set; }
        public string? ValueMember { get; set; }
        public object? Value { get; set; }
    }

    public class SmartEditDialog : MaterialForm
    {
        private readonly List<CrudField> _fields;
        private readonly Dictionary<string, Control> _controls = new();
        private readonly MaterialButton _btnSave;
        private readonly MaterialButton _btnCancel;
        private readonly Func<Dictionary<string, object?>, (bool success, string? message)>? _validator;

        public Dictionary<string, object?> FieldValues { get; private set; } = new();

        public SmartEditDialog(string title, List<CrudField> fields, Func<Dictionary<string, object?>, (bool success, string? message)>? validator = null)
        {
            _fields = fields;
            _validator = validator;

            Text = title;
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(500, Math.Max(400, 150 + fields.Count * 70));
            Sizable = false;
            MaximizeBox = false;
            MinimizeBox = false;

            MaterialSkinManager.Instance.AddFormToManage(this);

            CreateControls();

            _btnSave = new MaterialButton
            {
                Text = "Kaydet",
                Location = new Point(300, Height - 100),
                Size = new Size(80, 36),
                DialogResult = DialogResult.OK
            };

            _btnCancel = new MaterialButton
            {
                Text = "Ýptal",
                Location = new Point(390, Height - 100),
                Size = new Size(80, 36),
                DialogResult = DialogResult.Cancel
            };

            _btnSave.Click += BtnSave_Click;
            
            Controls.Add(_btnSave);
            Controls.Add(_btnCancel);
        }

        private void CreateControls()
        {
            int yPos = 80;
            const int spacing = 70;
            const int labelHeight = 20;
            const int controlHeight = 36;

            foreach (var field in _fields)
            {
                // Label
                var label = new MaterialLabel
                {
                    Text = field.Label + (field.IsRequired ? " *" : ""),
                    Location = new Point(20, yPos),
                    AutoSize = true
                };
                Controls.Add(label);

                // Control
                Control control = field.ControlType switch
                {
                    CrudFieldType.Text => new MaterialTextBox
                    {
                        Location = new Point(20, yPos + labelHeight),
                        Size = new Size(440, controlHeight),
                        Name = field.Name
                    },
                    CrudFieldType.Combo => new MaterialComboBox
                    {
                        Location = new Point(20, yPos + labelHeight),
                        Size = new Size(440, controlHeight),
                        Name = field.Name,
                        DropDownStyle = ComboBoxStyle.DropDownList
                    },
                    CrudFieldType.Date => new DateTimePicker
                    {
                        Location = new Point(20, yPos + labelHeight),
                        Size = new Size(440, controlHeight),
                        Name = field.Name,
                        Format = DateTimePickerFormat.Short
                    },
                    CrudFieldType.Switch => new MaterialSwitch
                    {
                        Location = new Point(20, yPos + labelHeight),
                        Size = new Size(440, controlHeight),
                        Name = field.Name,
                        Text = field.Label
                    },
                    _ => throw new NotSupportedException($"Field type {field.ControlType} is not supported")
                };

                // Set data source for combo
                if (control is MaterialComboBox combo && field.DataSourceProvider != null)
                {
                    var dataSource = field.DataSourceProvider().ToList();
                    combo.DataSource = dataSource;
                    if (!string.IsNullOrEmpty(field.DisplayMember))
                        combo.DisplayMember = field.DisplayMember;
                    if (!string.IsNullOrEmpty(field.ValueMember))
                        combo.ValueMember = field.ValueMember;
                }

                // Set initial value
                if (field.Value != null)
                {
                    switch (control)
                    {
                        case MaterialTextBox textBox:
                            textBox.Text = field.Value.ToString() ?? "";
                            break;
                        case MaterialComboBox comboBox:
                            if (!string.IsNullOrEmpty(field.ValueMember))
                                comboBox.SelectedValue = field.Value;
                            else
                                comboBox.SelectedItem = field.Value;
                            break;
                        case DateTimePicker dateTimePicker:
                            if (field.Value is DateTime dt)
                                dateTimePicker.Value = dt;
                            break;
                        case MaterialSwitch switchControl:
                            if (field.Value is bool b)
                                switchControl.Checked = b;
                            break;
                    }
                }

                _controls[field.Name] = control;
                Controls.Add(control);

                yPos += spacing;
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            try
            {
                // Collect values
                FieldValues.Clear();
                foreach (var field in _fields)
                {
                    if (!_controls.TryGetValue(field.Name, out var control))
                        continue;

                    object? value = control switch
                    {
                        MaterialTextBox textBox => textBox.Text,
                        MaterialComboBox comboBox => string.IsNullOrEmpty(field.ValueMember) 
                            ? comboBox.SelectedItem 
                            : comboBox.SelectedValue,
                        DateTimePicker dateTimePicker => dateTimePicker.Value,
                        MaterialSwitch switchControl => switchControl.Checked,
                        _ => null
                    };

                    FieldValues[field.Name] = value;
                }

                // Validate required fields
                var missingFields = new List<string>();
                foreach (var field in _fields.Where(f => f.IsRequired))
                {
                    if (!FieldValues.TryGetValue(field.Name, out var value) || 
                        value == null || 
                        (value is string str && string.IsNullOrWhiteSpace(str)))
                    {
                        missingFields.Add(field.Label);
                    }
                }

                if (missingFields.Any())
                {
                    MessageBox.Show($"Þu alanlar zorunludur:\n{string.Join("\n", missingFields)}", 
                        "Doðrulama Hatasý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                    return;
                }

                // Custom validation
                if (_validator != null)
                {
                    var (success, message) = _validator(FieldValues);
                    if (!success)
                    {
                        MessageBox.Show(message ?? "Doðrulama hatasý", "Doðrulama Hatasý", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DialogResult = DialogResult.None;
                        return;
                    }
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;
            }
        }

        public void LoadValues(Dictionary<string, object?> values)
        {
            foreach (var kvp in values)
            {
                if (_controls.TryGetValue(kvp.Key, out var control) && kvp.Value != null)
                {
                    switch (control)
                    {
                        case MaterialTextBox textBox:
                            textBox.Text = kvp.Value.ToString() ?? "";
                            break;
                        case MaterialComboBox comboBox:
                            var field = _fields.FirstOrDefault(f => f.Name == kvp.Key);
                            if (field != null && !string.IsNullOrEmpty(field.ValueMember))
                                comboBox.SelectedValue = kvp.Value;
                            else
                                comboBox.SelectedItem = kvp.Value;
                            break;
                        case DateTimePicker dateTimePicker:
                            if (kvp.Value is DateTime dt)
                                dateTimePicker.Value = dt;
                            break;
                        case MaterialSwitch switchControl:
                            if (kvp.Value is bool b)
                                switchControl.Checked = b;
                            break;
                    }
                }
            }
        }
    }
}