using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Infrastructure.Messaging
{
    public enum Button { Accept, Abort, Retry, Ignore, Yes, No, Cancel }
    public enum Buttons { AbortRetryIgnore, Accept, AcceptCancel, RetryCancel, YesNo, YesNoCancel }
    public enum Icon { Asterisk, Error, Exclamation, Hand, Information, None, Question, Stop, Warning }
    public delegate void ButtonCommandEventHandler(Button SelectedButton);
}
