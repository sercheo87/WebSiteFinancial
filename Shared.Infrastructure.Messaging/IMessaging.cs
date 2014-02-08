using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Infrastructure.Messaging
{
    public interface IMessaging
    {
        void ShowMessage(string TextCode);
        void ShowMessage(string TextCode, string CaptionCode);
        void ShowMessage(string TextCode, Buttons Buttons);
        void ShowMessage(string TextCode, ButtonCommandEventHandler ButtonCommandEventHandler);
        void ShowMessage(string TextCode, Icon Icon);
        void ShowMessage(string TextCode, params object[] TextParams);
        void ShowMessage(string TextCode, string CaptionCode, Buttons Buttons);
        void ShowMessage(string TextCode, string CaptionCode, ButtonCommandEventHandler ButtonCommandEventHandler);
        void ShowMessage(string TextCode, string CaptionCode, Icon Icon);
        void ShowMessage(string TextCode, string CaptionCode, params object[] TextParams);
        void ShowMessage(string TextCode, Buttons Buttons, ButtonCommandEventHandler ButtonCommandEventHandler);
        void ShowMessage(string TextCode, Buttons Buttons, Icon Icon);
        void ShowMessage(string TextCode, Buttons Buttons, params object[] TextParams);
        void ShowMessage(string TextCode, ButtonCommandEventHandler ButtonCommandEventHandler, Icon Icon);
        void ShowMessage(string TextCode, ButtonCommandEventHandler ButtonCommandEventHandler, params object[] TextParams);
        void ShowMessage(string TextCode, Icon Icon, params object[] TextParams);
        void ShowMessage(string TextCode, string CaptionCode, Buttons Buttons, ButtonCommandEventHandler ButtonCommandEventHandler);
        void ShowMessage(string TextCode, string CaptionCode, Buttons Buttons, Icon Icon);
        void ShowMessage(string TextCode, string CaptionCode, Buttons Buttons, params object[] TextParams);
        void ShowMessage(string TextCode, string CaptionCode, ButtonCommandEventHandler ButtonCommandEventHandler, Icon Icon);
        void ShowMessage(string TextCode, string CaptionCode, ButtonCommandEventHandler ButtonCommandEventHandler, params object[] TextParams);
        void ShowMessage(string TextCode, string CaptionCode, Icon Icon, params object[] TextParams);
        void ShowMessage(string TextCode, Buttons Buttons, ButtonCommandEventHandler ButtonCommandEventHandler, Icon Icon);
        void ShowMessage(string TextCode, Buttons Buttons, ButtonCommandEventHandler ButtonCommandEventHandler, params object[] TextParams);
        void ShowMessage(string TextCode, ButtonCommandEventHandler ButtonCommandEventHandler, Icon Icon, params object[] TextParams);
        void ShowMessage(string TextCode, string CaptionCode, Buttons Buttons, ButtonCommandEventHandler ButtonCommandEventHandler, Icon Icon);
        void ShowMessage(string TextCode, string CaptionCode, Buttons Buttons, ButtonCommandEventHandler ButtonCommandEventHandler, params object[] TextParams);
        void ShowMessage(string TextCode, Buttons Buttons, ButtonCommandEventHandler ButtonCommandEventHandler, Icon Icon, params object[] TextParams);
        void ShowMessage(string TextCode, string CaptionCode, Buttons Buttons, ButtonCommandEventHandler ButtonCommandEventHandler, Icon Icon, params object[] TextParams);
        void HideMessage();
    }
}
