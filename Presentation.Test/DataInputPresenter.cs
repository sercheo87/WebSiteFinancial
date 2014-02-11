using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Presentation.Commons;
using Shared.Infrastructure.Messaging;

namespace Presentation.Test
{
    public class DataInputPresenter : Presenter<IDataInput>
    {
        public void Execute()
        {
            View.ShowMessage("_TestBody", new ButtonCommandEventHandler(OnResponse));
        }

        public void OnResponse(Button SelectedButton)
        {
            string code = View.Code;
            //throw new Exception("Custom exception!");
        }
    }
}
