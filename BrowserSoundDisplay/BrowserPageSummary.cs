using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;

namespace BrowserSoundDisplay
{
    public partial class BrowserPageSummary : Form
    {
        private SettingsModel settings;
        private Timer timer;
        private ItemModel loadedModel;

        public BrowserPageSummary()
        {
            InitializeComponent();
            LoadSettings();
            ApplicationStart();            
        }

        /// <summary>
        /// Loads the settings object
        /// </summary>
        private void LoadSettings()
        {
            using (StreamReader r = new StreamReader("settings.json"))
            {
                string json = r.ReadToEnd();
                this.settings = JsonConvert.DeserializeObject<SettingsModel>(json);
            }

            this.ItemLabel.Font = new Font(settings.TextFont, float.Parse(settings.TextSize), FontStyle.Bold);
            this.ItemLabel.ForeColor = ColorTranslator.FromHtml(settings.TextColour);

            this.BackColor = ColorTranslator.FromHtml(settings.BackgroundColour);
            this.Icon = new Icon("Icon.ico");
            this.Text = "Browser Page Summary";
        }

        /// <summary>
        /// Starts running the load item info every 2 seconds
        /// </summary>
        private void ApplicationStart()
        {
            timer = new Timer();
            timer.Tick += new EventHandler(LoadItemInfo);
            timer.Interval = 2000; //2 seconds
            timer.Start();
        }

        /// <summary>
        /// Loads the Item Info to the screen
        /// </summary>
        private void LoadItemInfo(object sender, EventArgs e)
        {
            try
            {
                //Get what the browser is currently displaying
                ItemModel currentItem = GetActiveTabItemModel();

                if (this.loadedModel == null || currentItem.Url != this.loadedModel.Url)
                {
                    this.loadedModel = currentItem;

                    //Try find a match in the settings based off the URL from the browser
                    ItemModel settingsItemMatch = settings.PlaylistInfo.Where(x => currentItem.Url.StartsWith(x.Url) || currentItem.Url.StartsWith(x.Url.Substring(x.Url.IndexOf(".") + 1))).FirstOrDefault();
                    //Load up with values based on previous two
                    ItemModel displayItem = new ItemModel()
                    {
                        Url = currentItem.Url,
                        DisplayName = settingsItemMatch != null && !string.IsNullOrEmpty(settingsItemMatch.DisplayName) ? settingsItemMatch.DisplayName : currentItem.DisplayName,
                        ImageName = settingsItemMatch != null && !string.IsNullOrEmpty(settingsItemMatch.ImageName) ? settingsItemMatch.ImageName : "defaultImage.png"
                    };

                    this.ItemLabel.Text = displayItem.DisplayName;
                    this.ItemImage.Image = Image.FromFile(@"Images\" + displayItem.ImageName);
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("log.txt", ex.ToString());
            }
        }
        

        /// <summary>
        /// Gets the Active tab information from the browser
        /// </summary>
        /// <returns>Filled ItemInfo object based of the tab it found</returns>
        private ItemModel GetActiveTabItemModel()
        {
            ItemModel currentModel = new ItemModel();

            Process[] procsChrome = Process.GetProcessesByName(settings.MusicBrowser);

            if (procsChrome.Length <= 0)
                return null;

            foreach (Process proc in procsChrome)
            {
                // the chrome process must have a window 
                if (proc.MainWindowHandle != IntPtr.Zero)
                {

                    // to find the tabs we first need to locate something reliable - the 'New Tab' button 
                    AutomationElement root = AutomationElement.FromHandle(proc.MainWindowHandle);

                    var SearchBar = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "Address and search bar"));
                    if (SearchBar != null)
                    {
                        currentModel.Url = SearchBar.GetCurrentPropertyValue(ValuePatternIdentifiers.ValueProperty).ToString();
                    }

                    currentModel.DisplayName = proc.MainWindowTitle;
                }

            }

            return currentModel;
        }
    }
}
