using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITCLib;

namespace ITCFrontEndReader
{
    // TODO format unicode translations 
    public partial class TranslationViewer : Form
    {
        List<Translation> Translations;
        BindingSource bs;
        public TranslationViewer(int QID)
        {
            InitializeComponent();

            Translations = DBAction.GetQuestionTranslations(QID);
            bs = new BindingSource();
            bs.DataSource = Translations;

            navTranslations.BindingSource = bs;

            txtSurvey.DataBindings.Add(new Binding("Text", bs, "Survey"));
            txtVarName.DataBindings.Add(new Binding("Text", bs, "VarName"));
            txtLanguage.DataBindings.Add(new Binding("Text", bs, "Language"));
            Translation t = (Translation)bs.Current;
            rtbTranslationText.DataBindings.Add(new Binding("Rtf", bs, "TranslationRTF"));
        }

        static string GetRtfUnicodeEscapedString(string s)
        {
            var sb = new StringBuilder();
            foreach (var c in s)
            {
                if (c == '\\' || c == '{' || c == '}')
                    sb.Append(@"\" + c);
                else if (c <= 0x7f)
                    sb.Append(c);
                else
                    sb.Append("\\u" + Convert.ToUInt32(c) + "?");
            }
            return sb.ToString();
        }
    }

    
}
