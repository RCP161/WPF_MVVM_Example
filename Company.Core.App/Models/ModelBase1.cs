using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Catel.Data;

namespace Company.Core.App.Models
{
    public abstract class ModelBase1 : ModelBase
    {
        protected ModelBase1()
        {
            PropertyChanged += ModelBase1_PropertyChanged; 
        }

        private void ModelBase1_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //State = Enums.StateEnum.Modified;
        }

        protected ModelBase1(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        /// <summary>
        /// State
        /// </summary>
        [NotMapped]
        public Enums.StateEnum State
        {
            get { return GetValue<Enums.StateEnum>(StateProperty); }
            private set { SetValue(StateProperty, value); }
        }
        public static readonly PropertyData StateProperty = RegisterProperty(nameof(State), typeof(Enums.StateEnum));


        /// <summary>
        /// DisplayText
        /// </summary>
        [NotMapped]
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

            if(State == Enums.StateEnum.Created || State == Enums.StateEnum.Modified)
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
            State = Enums.StateEnum.Unchanged;
            SetDisplayText();
        }

        #endregion
    }
}
