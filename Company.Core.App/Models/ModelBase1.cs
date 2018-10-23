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

            if(IsDirty)
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

        protected void SetDisplayText()
        {
            DisplayText = GetDisplyTextWithState();
        }

        internal void AfterLoad() // Über LoadingService mit in der DB implementierung clearen
        {
            IsDirty = false;
            SetDisplayText();
        }

        protected override void OnPropertyChanged(AdvancedPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
        }

        protected override bool ShouldPropertyChangeUpdateIsDirty(string propertyName)
        {
            if(GetType().GetProperty(propertyName).GetAttribute<IgnoreOnStateAttribute>() != null)
                return false;

            return base.ShouldPropertyChangeUpdateIsDirty(propertyName);
        }

        #endregion
    }
}
