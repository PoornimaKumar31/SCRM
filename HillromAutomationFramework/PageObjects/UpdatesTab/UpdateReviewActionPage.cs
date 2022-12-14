using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace HillromAutomationFramework.PageObjects
{
    class UpdateReviewActionPage
    {
        public static class Locators
        {
            public const string HeadingID = "select_review";
            public const string PushItemsID = "push-item";
            public const string ItemToPushLabelID = "lbl_push_item";
            public const string ItemToPushValueID = "push_item_value";
            public const string DestinationLabelXpath = "//span[@id=\"lbl_destination\"]";
            public const string DestinationValueID = "destination_value";
            public const string ConfirmButtonID = "confirm";


            //csm updates
            public const string DateOrTimePushLabelID = "lbl_date_time";
            public const string ImmediateLabelID = "immediately";
            public const string ImmediateCheckboxID = "setInfo";
            public const string ScheduleCheckboxID = "UpgradeInfo";
            public const string ScheduleLabelID = "schedule";

            public const string DateLabelID = "lbl_date";
            public const string CalendarIconClassName = "mat-datepicker-toggle";

            public const string TimeLabelID = "lbl_time";
            public const string HourDDLID = "upgrade_hour";
            public const string MinuteDDLID = "upgrade_minute";
            public const string PreviousButtonID = "previousbtn";
            public const string DateClassName = "mat-calendar-body-cell-content";

        }

        public UpdateReviewActionPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = Locators.HeadingID)]
        public IWebElement Heading { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PushItemsID)]
        public IWebElement PushItems { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ItemToPushLabelID)]
        public IWebElement ItemToPushLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ItemToPushValueID)]
        public IWebElement ItemToPushValue { get; set; }

        [FindsBy(How = How.XPath, Using = Locators.DestinationLabelXpath)]
        public IWebElement DestinationLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DestinationValueID)]
        public IWebElement DestinationValue { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ConfirmButtonID)]
        public IWebElement ConfirmButton { get; set; }

        //CSM upgrade
        [FindsBy(How = How.Id, Using = Locators.DateOrTimePushLabelID)]
        public IWebElement DateOrTimePushLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ImmediateLabelID)]
        public IWebElement ImmediateLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ImmediateCheckboxID)]
        public IWebElement ImmediateCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ScheduleCheckboxID)]
        public IWebElement ScheduleCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = Locators.ScheduleLabelID)]
        public IWebElement ScheduleLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.DateLabelID)]
        public IWebElement DateLabel { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.CalendarIconClassName)]
        public IWebElement CalendarIcon { get; set; }

        [FindsBy(How = How.Id, Using = Locators.TimeLabelID)]
        public IWebElement TimeLabel { get; set; }

        [FindsBy(How = How.Id, Using = Locators.HourDDLID)]
        public IWebElement HourDDL { get; set; }

        [FindsBy(How = How.Id, Using = Locators.MinuteDDLID)]
        public IWebElement MinuteDDL { get; set; }

        [FindsBy(How = How.Id, Using = Locators.PreviousButtonID)]
        public IWebElement PreviousButton { get; set; }

        [FindsBy(How = How.ClassName, Using = Locators.DateClassName)]
        public IWebElement Date { get; set; }

    }
}
