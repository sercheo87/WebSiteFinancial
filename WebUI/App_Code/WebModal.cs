using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebControls = System.Web.UI.WebControls;
using Shared.Infrastructure.Messaging;
using Messaging = Shared.Infrastructure.Messaging;
using Resources;

/// <summary>
/// Summary description for WebModal
/// </summary>
public static class WebModal
{
    private static void ConfigureMessageButtons(Page Page, bool ServerSideButtons, Buttons? Buttons)
    {
        if (Page != null)
        {
            HtmlInputButton buttonAccept = WebCommons.FindControl<HtmlInputButton>(Page, "buttonAccept");
            HtmlInputButton buttonCancel = WebCommons.FindControl<HtmlInputButton>(Page, "buttonCancel");
            HtmlInputButton buttonAbort = WebCommons.FindControl<HtmlInputButton>(Page, "buttonAbort");
            HtmlInputButton buttonRetry = WebCommons.FindControl<HtmlInputButton>(Page, "buttonRetry");
            HtmlInputButton buttonIgnore = WebCommons.FindControl<HtmlInputButton>(Page, "buttonIgnore");
            HtmlInputButton buttonYes = WebCommons.FindControl<HtmlInputButton>(Page, "buttonYes");
            HtmlInputButton buttonNo = WebCommons.FindControl<HtmlInputButton>(Page, "buttonNo");

            if (buttonAccept != null) buttonAccept.Visible = !ServerSideButtons && (Buttons == null || Buttons == Messaging.Buttons.Accept || Buttons == Messaging.Buttons.AcceptCancel);
            if (buttonCancel != null) buttonCancel.Visible = !ServerSideButtons && (Buttons == Messaging.Buttons.AcceptCancel || Buttons == Messaging.Buttons.RetryCancel || Buttons == Messaging.Buttons.YesNoCancel);
            if (buttonAbort != null) buttonAbort.Visible = !ServerSideButtons && (Buttons == Messaging.Buttons.AbortRetryIgnore);
            if (buttonRetry != null) buttonRetry.Visible = !ServerSideButtons && (Buttons == Messaging.Buttons.AbortRetryIgnore || Buttons == Messaging.Buttons.RetryCancel);
            if (buttonIgnore != null) buttonIgnore.Visible = !ServerSideButtons && (Buttons == Messaging.Buttons.AbortRetryIgnore);
            if (buttonYes != null) buttonYes.Visible = !ServerSideButtons && (Buttons == Messaging.Buttons.YesNo || Buttons == Messaging.Buttons.YesNoCancel);
            if (buttonNo != null) buttonNo.Visible = !ServerSideButtons && (Buttons == Messaging.Buttons.YesNo || Buttons == Messaging.Buttons.YesNoCancel);

            WebControls.Button buttonServerAccept = WebCommons.FindControl<WebControls.Button>(Page, "buttonServerAccept");
            WebControls.Button buttonServerCancel = WebCommons.FindControl<WebControls.Button>(Page, "buttonServerCancel");
            WebControls.Button buttonServerAbort = WebCommons.FindControl<WebControls.Button>(Page, "buttonServerAbort");
            WebControls.Button buttonServerRetry = WebCommons.FindControl<WebControls.Button>(Page, "buttonServerRetry");
            WebControls.Button buttonServerIgnore = WebCommons.FindControl<WebControls.Button>(Page, "buttonServerIgnore");
            WebControls.Button buttonServerYes = WebCommons.FindControl<WebControls.Button>(Page, "buttonServerYes");
            WebControls.Button buttonServerNo = WebCommons.FindControl<WebControls.Button>(Page, "buttonServerNo");

            if (buttonServerAccept != null) buttonServerAccept.Visible = ServerSideButtons && (Buttons == null || Buttons == Messaging.Buttons.Accept || Buttons == Messaging.Buttons.AcceptCancel);
            if (buttonServerCancel != null) buttonServerCancel.Visible = ServerSideButtons && (Buttons == Messaging.Buttons.AcceptCancel || Buttons == Messaging.Buttons.RetryCancel || Buttons == Messaging.Buttons.YesNoCancel);
            if (buttonServerAbort != null) buttonServerAbort.Visible = ServerSideButtons && (Buttons == Messaging.Buttons.AbortRetryIgnore);
            if (buttonServerRetry != null) buttonServerRetry.Visible = ServerSideButtons && (Buttons == Messaging.Buttons.AbortRetryIgnore || Buttons == Messaging.Buttons.RetryCancel);
            if (buttonServerIgnore != null) buttonServerIgnore.Visible = ServerSideButtons && (Buttons == Messaging.Buttons.AbortRetryIgnore);
            if (buttonServerYes != null) buttonServerYes.Visible = ServerSideButtons && (Buttons == Messaging.Buttons.YesNo || Buttons == Messaging.Buttons.YesNoCancel);
            if (buttonServerNo != null) buttonServerNo.Visible = ServerSideButtons && (Buttons == Messaging.Buttons.YesNo || Buttons == Messaging.Buttons.YesNoCancel);
        }
    }

    private static void ConfigureMessageIcon(Page Page, Icon? Icon)
    {
        if (Page != null)
        {
            HtmlGenericControl messageAsteriskIcon = WebCommons.FindControl<HtmlGenericControl>(Page, "messageAsteriskIcon");
            HtmlGenericControl messageErrorIcon = WebCommons.FindControl<HtmlGenericControl>(Page, "messageErrorIcon");
            HtmlGenericControl messageExclamationIcon = WebCommons.FindControl<HtmlGenericControl>(Page, "messageExclamationIcon");
            HtmlGenericControl messageHandIcon = WebCommons.FindControl<HtmlGenericControl>(Page, "messageHandIcon");
            HtmlGenericControl messageInformationIcon = WebCommons.FindControl<HtmlGenericControl>(Page, "messageInformationIcon");
            HtmlGenericControl messageQuestionIcon = WebCommons.FindControl<HtmlGenericControl>(Page, "messageQuestionIcon");
            HtmlGenericControl messageStopIcon = WebCommons.FindControl<HtmlGenericControl>(Page, "messageStopIcon");
            HtmlGenericControl messageWarningIcon = WebCommons.FindControl<HtmlGenericControl>(Page, "messageWarningIcon");

            if (Icon == null) Icon = Messaging.Icon.Information;

            if (messageAsteriskIcon != null) messageAsteriskIcon.Style["display"] = (Icon == Messaging.Icon.Asterisk ? "block" : "none");
            if (messageErrorIcon != null) messageErrorIcon.Style["display"] = (Icon == Messaging.Icon.Error ? "block" : "none");
            if (messageExclamationIcon != null) messageExclamationIcon.Style["display"] = (Icon == Messaging.Icon.Exclamation ? "block" : "none");
            if (messageHandIcon != null) messageHandIcon.Style["display"] = (Icon == Messaging.Icon.Hand ? "block" : "none");
            if (messageInformationIcon != null) messageInformationIcon.Style["display"] = (Icon == Messaging.Icon.Information ? "block" : "none");
            if (messageQuestionIcon != null) messageQuestionIcon.Style["display"] = (Icon == Messaging.Icon.Question ? "block" : "none");
            if (messageStopIcon != null) messageStopIcon.Style["display"] = (Icon == Messaging.Icon.Stop ? "block" : "none");
            if (messageWarningIcon != null) messageWarningIcon.Style["display"] = (Icon == Messaging.Icon.Warning ? "block" : "none");
        }
    }

    public static void ShowMessage(Page Page, string TextCode, string CaptionCode, bool ServerSideButtons, Buttons? Buttons, Icon? Icon, params object[] TextParams)
    {
        UpdatePanel messagesPanel = WebCommons.FindControl<UpdatePanel>(Page, "messagesPanel");
        Panel messagesOverlay = WebCommons.FindControl<Panel>(Page, "messagesOverlay");
        Literal messageCaption = WebCommons.FindControl<Literal>(Page, "messageCaption");
        Literal messageText = WebCommons.FindControl<Literal>(Page, "messageText");

        if (!string.IsNullOrWhiteSpace(TextCode) && messagesPanel != null && messagesOverlay != null && messageCaption != null && messageText != null)
        {
            string caption = string.IsNullOrWhiteSpace(CaptionCode) ? WebUIMessages.DefaultMessageCaption : WebUIMessages.ResourceManager.GetString(CaptionCode.Trim());
            string text = WebUIMessages.ResourceManager.GetString(TextCode.Trim());
            string error = string.Empty;

            if (caption == null)
                error = string.Format(WebUIMessages.UnknownCaptionCode, CaptionCode.Trim());

            if (text == null)
                error += (error.Length == 0 ? string.Empty : "<br/>") + string.Format(WebUIMessages.UnknownMessageCode, TextCode.Trim());

            if (error.Length == 0)
            {
                messageCaption.Text = caption;

                if (TextParams != null && TextParams.Length > 0)
                    text = string.Format(text, TextParams);
                    
                messageText.Text = text;
            }
            else
            {
                messageCaption.Text = WebUIMessages.ApplicationError;
                messageText.Text = error;
                ServerSideButtons = false;
                Buttons = Messaging.Buttons.Accept;
                Icon = Messaging.Icon.Error;
            }

            ConfigureMessageButtons(Page, ServerSideButtons, Buttons);
            ConfigureMessageIcon(Page, Icon);

            messagesOverlay.Style["display"] = "block";
            messagesPanel.Update();
        }
    }

    public static void HideMessage(Page Page)
    {
        UpdatePanel messagesPanel = WebCommons.FindControl<UpdatePanel>(Page, "messagesPanel");
        Panel messagesOverlay = WebCommons.FindControl<Panel>(Page, "messagesOverlay");

        if (messagesPanel != null && messagesOverlay != null)
        {
            messagesOverlay.Style["display"] = "none";
            messagesPanel.Update();
        }
    }
}