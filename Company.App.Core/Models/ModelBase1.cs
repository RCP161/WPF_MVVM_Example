using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using Catel.Data;
using Catel.Reflection;
using Company.Project.Core.Common;

namespace Company.Project.Core.Models
{
    public abstract class ModelBase1 : ModelBase
    {
        // Model für alle Darstellungssachen
        public ModelBase1()
        {
            State = StateEnum.Unchanged;
        }

        // Brauche ich hier schon wegen dem State. Kann ja ber default unchanged sein
        [Browsable(false)]
        [XmlIgnore]
        [NotMapped]
        [IgnoreOnState]
        public StateEnum State
        {
            get { return GetValue<StateEnum>(StateProperty); }
            protected set { SetValue(StateProperty, value); }
        }
        public static readonly PropertyData StateProperty = RegisterProperty(nameof(State), typeof(StateEnum));

        [Browsable(false)]
        [XmlIgnore]
        [NotMapped]
        [IgnoreOnState]
        private new bool IsDirty { get; set; }

        [Browsable(false)]
        [XmlIgnore]
        [NotMapped]
        [IgnoreOnState]
        public new bool IsReadOnly
        {
            get { return base.IsReadOnly; }
            protected set { base.IsReadOnly = value; }
        }

        [NotMapped]
        [IgnoreOnState]
        public string DisplayText
        {
            get { return GetValue<string>(DisplayTextProperty); }
            private set { SetValue(DisplayTextProperty, value); }
        }
        public static readonly PropertyData DisplayTextProperty = RegisterProperty(nameof(DisplayText), typeof(string));

        #region Methods

        private string GetDisplyTextWithState()
        {
            string dpText = GetDisplayText();

            if(State.HasFlag(StateEnum.Modified) || State.HasFlag(StateEnum.Created))
                dpText += "*";

            return dpText;
        }

        protected virtual string GetDisplayText()
        {
            return ToString();
        }

        protected override void OnPropertyChanged(AdvancedPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if(e.PropertyName != nameof(DisplayText))
                DisplayText = GetDisplyTextWithState();
        }

        #endregion
    }
}