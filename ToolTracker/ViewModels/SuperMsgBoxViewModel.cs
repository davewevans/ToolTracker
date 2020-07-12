using System.Windows.Forms;
using System.Drawing;
using smb = SuperMessageBox;

namespace ToolTracker.ViewModels
{
    static class SuperMsgBoxViewModel
    {

        public static DialogResult ShowSuperMessageBox(string msg,
                                                       string header,
                                                       smb.SMB.Buttons buttons,
                                                       smb.SMB.MsgIcon icon)
        {
           
            // #FFEAEAF3 -- Ver ligth blue
            Color topBGcolor = new Color();
            byte a = 0xFF; byte r = 0xEA; byte g = 0xEA; byte b = 0xF3;
            topBGcolor = System.Drawing.Color.FromArgb(a, r, g, b);


            smb.ColorScheme colorScheme = new smb.ColorScheme(topBGcolor,
                                                              Color.SteelBlue,
                                                              Color.Black);
            smb.SMB superMsgBox = new smb.SMB(colorScheme, true);
            DialogResult dialogResult = superMsgBox.Show(msg, header, buttons, icon);
            return dialogResult;
        }
    }
}
