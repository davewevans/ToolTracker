using System.Windows.Forms;
using ToolTracker.ViewModels;
using smb = SuperMessageBox;

namespace ToolTracker.Services
{
    static class NotifyUser
    {
        public static void ExceptionOccured(string message, string caption)
        {
            SuperMsgBoxViewModel.ShowSuperMessageBox(message, caption,
                smb.SMB.Buttons.OK,
                smb.SMB.MsgIcon.EmoteSad);
        }

        public static void SomethingIsMissing(string message, string caption)
        {
            SuperMsgBoxViewModel.ShowSuperMessageBox(message, caption,
                smb.SMB.Buttons.OK,
                smb.SMB.MsgIcon.EmotePlain);
        }

        public static void InvalidEntry(string message, string caption)
        {
            SuperMsgBoxViewModel.ShowSuperMessageBox(message, caption,
                smb.SMB.Buttons.OK,
                smb.SMB.MsgIcon.Warning3D);
        }

        public static void Forbidden(string message, string caption)
        {
            SuperMsgBoxViewModel.ShowSuperMessageBox(message, caption,
                smb.SMB.Buttons.OK,
                smb.SMB.MsgIcon.EmotePlain);
        }

        public static void TimeOut(string message, string caption)
        {
            SuperMsgBoxViewModel.ShowSuperMessageBox(message, caption,
                smb.SMB.Buttons.OK,
                smb.SMB.MsgIcon.TimeOut);
        }

        public static void AllGood(string message, string caption)
        {
            SuperMsgBoxViewModel.ShowSuperMessageBox(message, caption,
                smb.SMB.Buttons.OK,
                smb.SMB.MsgIcon.EmoteNormalSmile);
        }

        public static void Inform(string message, string caption)
        {
            SuperMsgBoxViewModel.ShowSuperMessageBox(message, caption,
                smb.SMB.Buttons.OK,
                smb.SMB.MsgIcon.WinInfo);
        }

        public static DialogResult AskYesNo(string message, string caption)
        {
            DialogResult result = SuperMsgBoxViewModel.ShowSuperMessageBox(message, caption,
                smb.SMB.Buttons.YesNoCancel,
                smb.SMB.MsgIcon.Question3D);
            return result;
        }

        public static DialogResult AskToConfirm(string message, string caption)
        {
            DialogResult result = SuperMsgBoxViewModel.ShowSuperMessageBox(message, caption,
                smb.SMB.Buttons.YesNoCancel,
                smb.SMB.MsgIcon.Important);
            return result;
        }
    }
}
