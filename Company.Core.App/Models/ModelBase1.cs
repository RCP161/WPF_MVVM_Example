using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Catel.Data;
using Catel.Reflection;
using Company.Core.App.Common;

namespace Company.Core.App.Models
{
    public abstract class ModelBase1 : ModelBase
    {
        // Model für alle Darstellungssachen
        
        // Brauche ich hier schon wegen dem State. Kann ja ber default unchanged sein
        [NotMapped]
        [IgnoreOnStateAttribute]
        public Enums.StateEnum State
        {
            get { return GetValue<Enums.StateEnum>(StateProperty); }
            protected set { SetValue(StateProperty, value); }
        }
        public static readonly PropertyData StateProperty = RegisterProperty(nameof(State), typeof(Enums.StateEnum));


        [NotMapped]
        [IgnoreOnStateAttribute]
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

            if(State.HasFlag(Enums.StateEnum.Modified) || State.HasFlag(Enums.StateEnum.Created))
                dpText += "*";

            return dpText;
        }

        /// <summary>
        /// Kann Überschrieben werden, wenn nicht ToString() verwendet werden soll
        /// </summary>
        protected virtual string GetDisplayText()
        {
            return ToString();
        }

        private void SetDisplayText()
        {
            DisplayText = GetDisplyTextWithState();
        }

        internal void AfterLoad()
        {
            IsDirty = false;
            State = Enums.StateEnum.Unchanged;
        }

        protected override void OnPropertyChanged(AdvancedPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if(e.PropertyName != nameof(DisplayText))
                SetDisplayText();
        }

        protected override bool ShouldPropertyChangeUpdateIsDirty(string propertyName)
        {
            if(GetType().GetProperty(propertyName).GetAttribute<IgnoreOnStateAttribute>() != null)
                return false;

            return base.ShouldPropertyChangeUpdateIsDirty(propertyName);
        }

        protected override void SetDirty(string propertyName)
        {
            // Sonst passt das nicht
            // base.SetDirty(propertyName);

            if(ShouldPropertyChangeUpdateIsDirty(propertyName))
            {
                IsDirty = true;
                if(State != Enums.StateEnum.Created)
                    State = Enums.StateEnum.Modified;

                // Deleted weiß ich jetzt nicht
            }
        }

        #endregion
    }
}
