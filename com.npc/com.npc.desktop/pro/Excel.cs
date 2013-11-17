using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace com.npc.desktop.pro
{
    [DefaultPropertyAttribute("SaveOnClose")]
    public class Excel
    {
        private bool saveOnClose = true;
        private string greetingText = "Welcome to your application!";
        private int maxRepeatRate = 10;
        private int itemsInMRU = 4;

        private bool settingsChanged = false;
        private string appVersion = "1.0";

        private Size windowSize = new Size(100, 100);
        private Font windowFont = new Font("Arial", 8, FontStyle.Regular);
        private Color toolbarColor = SystemColors.Control;

        [CategoryAttribute("Document Settings"),
        DefaultValueAttribute(true)]
        public bool SaveOnClose
        {
            get { return saveOnClose; }
            set { saveOnClose = value; }
        }

        [CategoryAttribute("Document Settings")]
        public Size WindowSize
        {
            get { return windowSize; }
            set { windowSize = value; }
        }

        [CategoryAttribute("Document Settings")]
        public Font WindowFont
        {
            get { return windowFont; }
            set { windowFont = value; }
        }

        [CategoryAttribute("Global Settings")]
        public Color ToolbarColor
        {
            get { return toolbarColor; }
            set { toolbarColor = value; }
        }

        [CategoryAttribute("Global Settings"),
        ReadOnlyAttribute(true),
        DefaultValueAttribute("Welcome to your application!")]
        public string GreetingText
        {
            get { return greetingText; }
            set { greetingText = value; }
        }

        [CategoryAttribute("Global Settings"),
        DefaultValueAttribute(4)]
        public int ItemsInMRUList
        {
            get { return itemsInMRU; }
            set { itemsInMRU = value; }
        }

        [DescriptionAttribute("The rate in milliseconds that the text will repeat."),
        CategoryAttribute("Global Settings"),
        DefaultValueAttribute(10)]
        public int MaxRepeatRate
        {
            get { return maxRepeatRate; }
            set { maxRepeatRate = value; }
        }

        [BrowsableAttribute(false),
        DefaultValueAttribute(false)]
        public bool SettingsChanged
        {
            get { return settingsChanged; }
            set { settingsChanged = value; }
        }

        [CategoryAttribute("Version"),
        DefaultValueAttribute("1.0"),
        ReadOnlyAttribute(true)]
        public string AppVersion
        {
            get { return appVersion; }
            set { appVersion = value; }
        }


    }
}
