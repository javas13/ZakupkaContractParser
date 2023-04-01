using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ZakupkaObj> listZakupok = new List<ZakupkaObj>();
        ObservableCollection<ZakupkaObj> listZakupokUklon = new ObservableCollection<ZakupkaObj>();
        string okrug;
        string dateFrom;
        string dateTo;
        string zakupka;
        string totalRes;
        string totalResReal;
        string pageNmb = "1";
        bool ischecked = false;
        public MainWindow()
        {
            InitializeComponent();
            zakupkaLstBox.ItemsSource = listZakupokUklon.ToList();
            listZakupokUklon.CollectionChanged += ZakupkaChanged;
        }
        void ZakupkaChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            zakupkaLstBox.ItemsSource = listZakupokUklon.ToList();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            listZakupokUklon.Clear();
            listZakupok.Clear();
            logiLstbox.Items.Clear();
            if(dateTotxt.Text == "" || dateFrtxt.Text == "" || ischecked == false)
            {
                MessageBox.Show("Введите даты начала и конца!");                
            }
            else
            {
                dateTo = dateTotxt.Text;
                dateFrom = dateFrtxt.Text;
                if (privoljRadio.IsChecked == true)
                {
                    okrug = "5277362";
                }
                else if (sibirRadio.IsChecked == true)
                {
                    okrug = "5277399";
                }
                else if (centalRadio.IsChecked == true)
                {
                    okrug = "5277317";
                }
                else if (dalnevostochniyRadio.IsChecked == true)
                {
                    okrug = "5277399";
                }
                else if (severoZapadRadio.IsChecked == true)
                {
                    okrug = "5277336";
                }
                else if (southRadio.IsChecked == true)
                {
                    okrug = "6325041";
                }
                else if (uralRadio.IsChecked == true)
                {
                    okrug = "5277377";
                }
                else if (severoKavkasRadio.IsChecked == true)
                {
                    okrug = "9409197";
                }
                if(dateZapusktxt.Text == "")
                {

                }
                else
                {
                    var dateToday = DateTime.Now;
                    var dateLaunch = Convert.ToDateTime(dateZapusktxt.Text);
                    var mils = (dateLaunch - dateToday).TotalMilliseconds;
                    var kl = Convert.ToInt32(mils);
                    dateOfZapuskTxtVivod.Text = dateZapusktxt.Text;
                    await Task.Delay(Convert.ToInt32(mils));
                }
                
                ChromeOptions options = new ChromeOptions();
                options.AddArgument("headless");               
                IWebDriver driver = new ChromeDriver(options);
                driver.Url = $"https://zakupki.gov.ru/epz/order/extendedsearch/results.html?searchString=&morphology=on&savedSearchSettingsIdHidden=&exclTextHidden=&sortBy=UPDATE_DATE&pageNumber={pageNmb}&sortDirection=false&recordsPerPage=_100&showLotsInfoHidden=false&fz44=on&pc=on&placingWayList=&selectedLaws=&etp=&bankSupportTag=&priceContractAdvantages44IdHidden=&priceContractAdvantages44IdNameHidden=%7B%7D&priceContractAdvantages94IdHidden=&priceContractAdvantages94IdNameHidden=%7B%7D&requirementsToPurchase44IdMap=&npaHidden=&restrictionsToPurchase44=&priceFromGeneral=&priceFromGWS=&priceFromUnitGWS=&priceToGeneral=&priceToGWS=&priceToUnitGWS=&currencyIdGeneral=-1&advancePercentFrom=&advancePercentTo=&publishDateFrom=&publishDateTo=&updateDateFrom={dateFrom}&updateDateTo={dateTo}&applSubmissionCloseDateFrom=&applSubmissionCloseDateTo=&EADateFrom=&EADateTo=&kbkChapter=&kbkSection=&kbkArticle=&kbkExpense=&customerIdOrg=&customerFz94id=&customerTitle=&agencyIdOrg=&customerFz94id=&customerTitle=&customerPlace={okrug}&customerPlaceCodes=OKER30&oktmoIds=&oktmoIdsCodes=&delKladrIds=&delKladrIdsCodes=&headAgency=&headAgencySelectedRoots=&taxpayerCode=&okpd2Ids=&okpd2IdsCodes=&okpdIds=&okpdIdsCodes=&okdpIds=&okdpIdsCodes=&ktruCodeNameList=&ktruSelectedChcs=&ktruSelectedChcsNames=&ktruSelectedCharItemVersionIdList=&ktruSelectedRubricatorIdList=&ktruSelectedRubricatorName=&clItemsHiddenId=&clGroupHiddenId=&ktruSelectedPageNum=&okved2Ids=&okved2IdsCodes=&okvedIds=&okvedIdsCodes=&worktypeIds=&worktypeNames=&worktypeIdsParent=&selectedSubjectsIdHidden=&selectedSubjectsIdNameHidden=%7B%7D&okdpGroupIdsIdHidden=&okdpGroupIdsIdNameHidden=%7B%7D&kvrIds=&kvrIdsCodes=&koksIdsIdHidden=&koksIdsIdNameHidden=%7B%7D&participantName=&orderIKZInputNameYear=&orderIKZInputNameIkz=&orderIKZInputNameNumPZ=&orderIKZInputNameNumPGZ=&orderIKZInputNameOkpd2=&orderIKZInputNameKvr=&mnnFarmNameIdMap=&tradeFarmNameIdMap=&medFormIdMap=&farmDosageIdMap=&OrderPlacementSmallBusinessSubject=on&OrderPlacementRnpData=on&OrderPlacementExecutionRequirement=on&orderPlacement94_0=0&orderPlacement94_1=0&orderPlacement94_2=0&registryRecordNumber=&budgetName=&contractConclusionDateFrom=&contractConclusionDateTo=&contractPriceFrom=&contractPriceTo=&contractPriceCurrencyId=-1&budgetLevelIdHidden=&budgetLevelIdNameHidden=%7B%7D&nonBudgetTypesIdHidden=&nonBudgetTypesIdNameHidden=%7B%7D&complaintNumber=&complaintCustomerIdOrg=&customerFz94id=&customerTitle=&controlCustomerIdOrg=&customerFz94id=&customerTitle=&inspectionRegistryNumber=&inspectionActPrescriptionNumber=&inspectionSubjectIdOrg=&customerFz94id=&customerTitle=&inspectionAuthorityIdOrg=&customerFz94id=&customerTitle=&inspectionDecisionDateFrom=&inspectionDecisionDateTo=&gws=%D0%92%D1%8B%D0%B1%D0%B5%D1%80%D0%B8%D1%82%D0%B5+%D1%82%D0%B8%D0%BF+%D0%B7%D0%B0%D0%BA%D1%83%D0%BF%D0%BA%D0%B8&searchTextInAttachedFile=";
                var totNumb = driver.FindElement(By.ClassName("search-results__total"));

                totalRes = totNumb.Text.Trim(new char[] { '\n', ' ', '/', });
                if (totalRes.Contains("более"))//Количество страниц
                {
                    string totalResRep = totalRes.Replace("записей", "");
                    string totalResRep2 = totalResRep.Replace(" ", "");
                    string totalResRep1 = totalResRep2.Replace("более", "");
                    var totResConv = Convert.ToInt32(totalResRep1);
                    totResConv = totResConv + 1;
                    var numbFor = totResConv / 100;
                    if (totResConv % 100 != 0)
                    {
                        numbFor++;
                    }
                    //var lastNumb = driver.FindElement(By.XPath("(//a[@class='page__link'])[3]"));
                    //totalResReal = lastNumb.Text;
                    //var totResConv = Convert.ToInt32(totalResReal);
                    string dateNowPer = DateTime.Now.ToString();
                    logiLstbox.Items.Add("Дата запуска: " + dateNowPer);
                    logiLstbox.Items.Add("Количество страниц: " + totResConv);
                    for (int i = 0; i < numbFor; i++)
                    {
                        var kolPars = i + 1;
                        logiLstbox.Items.Add("Парсинг" + " " + kolPars + " " + "страницы" + " " + "из" + " " + numbFor);
                        if (i == 0)
                        {
                            await Task.Delay(1000);
                            var nmbPlus = i + 1;
                            pageNmb = nmbPlus.ToString();
                            var p = driver.FindElements(By.ClassName("registry-entry__header-mid__number"));
                            foreach (var l in p)
                            {
                                var k = l.FindElement(By.TagName("a"));
                                ZakupkaObj zakupka = new ZakupkaObj() { ZakupkaId = k.Text };
                                listZakupok.Add(zakupka);
                            }
                        }
                        else
                        {
                            await Task.Delay(1000);
                            var nmbPlus = i + 1;
                            pageNmb = nmbPlus.ToString();
                            driver.Url = $"https://zakupki.gov.ru/epz/order/extendedsearch/results.html?searchString=&morphology=on&savedSearchSettingsIdHidden=&exclTextHidden=&sortBy=UPDATE_DATE&pageNumber={pageNmb}&sortDirection=false&recordsPerPage=_100&showLotsInfoHidden=false&fz44=on&pc=on&placingWayList=&selectedLaws=&etp=&bankSupportTag=&priceContractAdvantages44IdHidden=&priceContractAdvantages44IdNameHidden=%7B%7D&priceContractAdvantages94IdHidden=&priceContractAdvantages94IdNameHidden=%7B%7D&requirementsToPurchase44IdMap=&npaHidden=&restrictionsToPurchase44=&priceFromGeneral=&priceFromGWS=&priceFromUnitGWS=&priceToGeneral=&priceToGWS=&priceToUnitGWS=&currencyIdGeneral=-1&advancePercentFrom=&advancePercentTo=&publishDateFrom=&publishDateTo=&updateDateFrom={dateFrom}&updateDateTo={dateTo}&applSubmissionCloseDateFrom=&applSubmissionCloseDateTo=&EADateFrom=&EADateTo=&kbkChapter=&kbkSection=&kbkArticle=&kbkExpense=&customerIdOrg=&customerFz94id=&customerTitle=&agencyIdOrg=&customerFz94id=&customerTitle=&customerPlace={okrug}&customerPlaceCodes=OKER30&oktmoIds=&oktmoIdsCodes=&delKladrIds=&delKladrIdsCodes=&headAgency=&headAgencySelectedRoots=&taxpayerCode=&okpd2Ids=&okpd2IdsCodes=&okpdIds=&okpdIdsCodes=&okdpIds=&okdpIdsCodes=&ktruCodeNameList=&ktruSelectedChcs=&ktruSelectedChcsNames=&ktruSelectedCharItemVersionIdList=&ktruSelectedRubricatorIdList=&ktruSelectedRubricatorName=&clItemsHiddenId=&clGroupHiddenId=&ktruSelectedPageNum=&okved2Ids=&okved2IdsCodes=&okvedIds=&okvedIdsCodes=&worktypeIds=&worktypeNames=&worktypeIdsParent=&selectedSubjectsIdHidden=&selectedSubjectsIdNameHidden=%7B%7D&okdpGroupIdsIdHidden=&okdpGroupIdsIdNameHidden=%7B%7D&kvrIds=&kvrIdsCodes=&koksIdsIdHidden=&koksIdsIdNameHidden=%7B%7D&participantName=&orderIKZInputNameYear=&orderIKZInputNameIkz=&orderIKZInputNameNumPZ=&orderIKZInputNameNumPGZ=&orderIKZInputNameOkpd2=&orderIKZInputNameKvr=&mnnFarmNameIdMap=&tradeFarmNameIdMap=&medFormIdMap=&farmDosageIdMap=&OrderPlacementSmallBusinessSubject=on&OrderPlacementRnpData=on&OrderPlacementExecutionRequirement=on&orderPlacement94_0=0&orderPlacement94_1=0&orderPlacement94_2=0&registryRecordNumber=&budgetName=&contractConclusionDateFrom=&contractConclusionDateTo=&contractPriceFrom=&contractPriceTo=&contractPriceCurrencyId=-1&budgetLevelIdHidden=&budgetLevelIdNameHidden=%7B%7D&nonBudgetTypesIdHidden=&nonBudgetTypesIdNameHidden=%7B%7D&complaintNumber=&complaintCustomerIdOrg=&customerFz94id=&customerTitle=&controlCustomerIdOrg=&customerFz94id=&customerTitle=&inspectionRegistryNumber=&inspectionActPrescriptionNumber=&inspectionSubjectIdOrg=&customerFz94id=&customerTitle=&inspectionAuthorityIdOrg=&customerFz94id=&customerTitle=&inspectionDecisionDateFrom=&inspectionDecisionDateTo=&gws=%D0%92%D1%8B%D0%B1%D0%B5%D1%80%D0%B8%D1%82%D0%B5+%D1%82%D0%B8%D0%BF+%D0%B7%D0%B0%D0%BA%D1%83%D0%BF%D0%BA%D0%B8&searchTextInAttachedFile=";
                            var p = driver.FindElements(By.ClassName("registry-entry__header-mid__number"));
                            foreach (var l in p)
                            {
                                var k = l.FindElement(By.TagName("a"));
                                ZakupkaObj zakupka = new ZakupkaObj() { ZakupkaId = k.Text };
                                listZakupok.Add(zakupka);
                            }
                        }

                    }
                }
                else//Количество элементов
                {
                    string totalResRep = totalRes.Replace("записей", "");
                    string totalResRep1 = totalResRep.Replace("более", "");
                    var totResConv = Convert.ToInt32(totalResRep1);
                    var numbFor = totResConv / 100;
                    if (totResConv % 100 != 0)
                    {
                        numbFor++;
                    }
                    string dateNowPer = DateTime.Now.ToString();
                    logiLstbox.Items.Add("Дата запуска: " + dateNowPer);
                    logiLstbox.Items.Add("Количество страниц: " + numbFor);
                    for (int i = 0; i < numbFor; i++)
                    {
                        var kolPars = i + 1;
                        logiLstbox.Items.Add("Парсинг" + " " + kolPars + " " + "страницы" + " " + "из" + " " + numbFor);
                        if (i == 0)
                        {
                            await Task.Delay(1000);
                            var nmbPlus = i + 1;
                            pageNmb = nmbPlus.ToString();
                            var p = driver.FindElements(By.ClassName("registry-entry__header-mid__number"));
                            foreach (var l in p)
                            {
                                var k = l.FindElement(By.TagName("a"));
                                ZakupkaObj zakupka = new ZakupkaObj() { ZakupkaId = k.Text };
                                listZakupok.Add(zakupka);
                            }
                        }
                        else
                        {
                            await Task.Delay(1000);
                            var nmbPlus = i + 1;
                            pageNmb = nmbPlus.ToString();
                            driver.Url = $"https://zakupki.gov.ru/epz/order/extendedsearch/results.html?searchString=&morphology=on&savedSearchSettingsIdHidden=&exclTextHidden=&sortBy=UPDATE_DATE&pageNumber={pageNmb}&sortDirection=false&recordsPerPage=_100&showLotsInfoHidden=false&fz44=on&pc=on&placingWayList=&selectedLaws=&etp=&bankSupportTag=&priceContractAdvantages44IdHidden=&priceContractAdvantages44IdNameHidden=%7B%7D&priceContractAdvantages94IdHidden=&priceContractAdvantages94IdNameHidden=%7B%7D&requirementsToPurchase44IdMap=&npaHidden=&restrictionsToPurchase44=&priceFromGeneral=&priceFromGWS=&priceFromUnitGWS=&priceToGeneral=&priceToGWS=&priceToUnitGWS=&currencyIdGeneral=-1&advancePercentFrom=&advancePercentTo=&publishDateFrom=&publishDateTo=&updateDateFrom={dateFrom}&updateDateTo={dateTo}&applSubmissionCloseDateFrom=&applSubmissionCloseDateTo=&EADateFrom=&EADateTo=&kbkChapter=&kbkSection=&kbkArticle=&kbkExpense=&customerIdOrg=&customerFz94id=&customerTitle=&agencyIdOrg=&customerFz94id=&customerTitle=&customerPlace={okrug}&customerPlaceCodes=OKER30&oktmoIds=&oktmoIdsCodes=&delKladrIds=&delKladrIdsCodes=&headAgency=&headAgencySelectedRoots=&taxpayerCode=&okpd2Ids=&okpd2IdsCodes=&okpdIds=&okpdIdsCodes=&okdpIds=&okdpIdsCodes=&ktruCodeNameList=&ktruSelectedChcs=&ktruSelectedChcsNames=&ktruSelectedCharItemVersionIdList=&ktruSelectedRubricatorIdList=&ktruSelectedRubricatorName=&clItemsHiddenId=&clGroupHiddenId=&ktruSelectedPageNum=&okved2Ids=&okved2IdsCodes=&okvedIds=&okvedIdsCodes=&worktypeIds=&worktypeNames=&worktypeIdsParent=&selectedSubjectsIdHidden=&selectedSubjectsIdNameHidden=%7B%7D&okdpGroupIdsIdHidden=&okdpGroupIdsIdNameHidden=%7B%7D&kvrIds=&kvrIdsCodes=&koksIdsIdHidden=&koksIdsIdNameHidden=%7B%7D&participantName=&orderIKZInputNameYear=&orderIKZInputNameIkz=&orderIKZInputNameNumPZ=&orderIKZInputNameNumPGZ=&orderIKZInputNameOkpd2=&orderIKZInputNameKvr=&mnnFarmNameIdMap=&tradeFarmNameIdMap=&medFormIdMap=&farmDosageIdMap=&OrderPlacementSmallBusinessSubject=on&OrderPlacementRnpData=on&OrderPlacementExecutionRequirement=on&orderPlacement94_0=0&orderPlacement94_1=0&orderPlacement94_2=0&registryRecordNumber=&budgetName=&contractConclusionDateFrom=&contractConclusionDateTo=&contractPriceFrom=&contractPriceTo=&contractPriceCurrencyId=-1&budgetLevelIdHidden=&budgetLevelIdNameHidden=%7B%7D&nonBudgetTypesIdHidden=&nonBudgetTypesIdNameHidden=%7B%7D&complaintNumber=&complaintCustomerIdOrg=&customerFz94id=&customerTitle=&controlCustomerIdOrg=&customerFz94id=&customerTitle=&inspectionRegistryNumber=&inspectionActPrescriptionNumber=&inspectionSubjectIdOrg=&customerFz94id=&customerTitle=&inspectionAuthorityIdOrg=&customerFz94id=&customerTitle=&inspectionDecisionDateFrom=&inspectionDecisionDateTo=&gws=%D0%92%D1%8B%D0%B1%D0%B5%D1%80%D0%B8%D1%82%D0%B5+%D1%82%D0%B8%D0%BF+%D0%B7%D0%B0%D0%BA%D1%83%D0%BF%D0%BA%D0%B8&searchTextInAttachedFile=";
                            var p = driver.FindElements(By.ClassName("registry-entry__header-mid__number"));
                            foreach (var l in p)
                            {
                                var k = l.FindElement(By.TagName("a"));
                                ZakupkaObj zakupka = new ZakupkaObj() { ZakupkaId = k.Text };
                                listZakupok.Add(zakupka);
                            }
                        }

                    }

                    //Код для журнала

                }
                int numberOfSCan = 0;
                var total = listZakupok.Count();
                foreach (var l in listZakupok)
                {
                    var k = listZakupok.IndexOf(l);
                    logiLstbox.Items.Add("Смотрим" + " " + k + " " + "элемент" + " " + "из" + " " + total);
                    if (numberOfSCan == 100)
                    {
                        logiLstbox.Items.Add("Ждем 50 секунд...");
                        await Task.Delay(50000);
                        numberOfSCan = 0;
                    }
                    else
                    {
                        await Task.Delay(1000);
                        numberOfSCan++;
                    }
                    string h = l.ZakupkaId.Replace("№", "");
                    string d = h.Replace(" ", "");
                    zakupka = d;
                    driver.Url = $"https://zakupki.gov.ru/epz/order/notice/ea20/view/event-journal.html?regNumber={zakupka}";
                    var p = driver.FindElements(By.ClassName("table__cell-body"));
                    foreach (var h2 in p)
                    {
                        if (h2.Text.Contains("Протокол признания участника уклонившимся от заключения контракта"))
                        {
                            listZakupokUklon.Add(l);
                        }
                    }
                }
                //Скачивание контрактов
                foreach (var cl5 in listZakupokUklon)
                {
                    await Task.Delay(3000);
                    driver.Url = $"https://zakupki.gov.ru/epz/order/notice/ea20/view/supplier-results.html?regNumber={cl5.ZakupkaId}";
                    var dl2 = driver.FindElements(By.ClassName("chevronRight"));
                    foreach (var dl3 in dl2)//Получаем все галки для раскрывания и раскрываем чтобы было видно ссылки на контракты
                    {
                        var dl8 = dl3.GetAttribute("data-id");
                        IWebElement Signinbutton = driver.FindElement(By.XPath($"//span[contains(@data-id,'{dl8}')]"));
                        IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)driver;
                        javascriptExecutor.ExecuteScript("arguments[0].click();", Signinbutton);
                    }
                    await Task.Delay(2000);
                    var p4 = driver.FindElements(By.TagName("a"));
                    List<IWebElement> nad6 = new List<IWebElement>();
                    //List<string> nadoLst = new List<string>();
                    foreach (var h2 in p4)//Находим все ссылки на контракты
                    {
                        if (h2.Text.Contains("контракт") && h2.Text.Contains("Сведения процедуры") == false && h2.Text.Contains("Электронные документы") == false)
                        {
                            nad6.Add(h2);                            
                        }                      
                    }
                    foreach (var h3 in nad6)//Переходим по ссылкам и скачиваем файлы и записываем их в папку
                    {
                        await Task.Delay(2000);
                        var fileHref = h3.GetAttribute("href");
                        WebClient client = new WebClient();
                        client.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36";
                        await client.DownloadFileTaskAsync(new Uri(fileHref), @"C:\ContractsParser\" + h3.Text + cl5.ZakupkaId + ".doc");
                    }                   
                }
                //driver.Url = "https://zakupki.gov.ru/epz/order/notice/ea20/view/event-journal.html?regNumber=0318100010023000006";
                //var p3 = driver.FindElements(By.ClassName("table__cell-body"));
                //foreach (var h2 in p3)
                //{
                //    if (h2.Text.Contains("Протокол признания участника уклонившимся от заключения контракта"))
                //    {
                //        listZakupokUklon.Add(new ZakupkaObj() { ZakupkaId = "03181000100230000060006" });
                //    }
                //}
                //driver.Url = "https://zakupki.gov.ru/epz/order/notice/ea20/view/supplier-results.html?regNumber=0318100010023000006";
                //await Task.Delay(3000);
                //var dl2 = driver.FindElements(By.ClassName("chevronRight"));
                //foreach(var dl3 in dl2)
                //{
                //    var dl8 = dl3.GetAttribute("data-id");
                //    IWebElement Signinbutton = driver.FindElement(By.XPath($"//span[contains(@data-id,'{dl8}')]"));
                //    IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)driver;
                //    javascriptExecutor.ExecuteScript("arguments[0].click();", Signinbutton);
                //}
                //IWebElement Signinbutton = driver.FindElement(By.XPath("//span[contains(@data-id,'10123221')]"));
                //IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)driver;
                //javascriptExecutor.ExecuteScript("arguments[0].click();", Signinbutton);
                //executor.ExecuteScript("arguments[0].click();", Signinbutton);
                // var dl2 = driver.FindElement(By.XPath("//span[contains(@data-id,'10123221')]"));
                //dl2.Click();
                //await Task.Delay(2000);
                //var dl = driver.FindElement(By.XPath("//a[@title='контракт.doc']"));
                //var cl = dl.Text;
                //var p4 = driver.FindElements(By.TagName("a"));
                //var p4 = driver.FindElements(By.ClassName("tableBlock__col"));
                //int nado = 0;
                //List<IWebElement> nad6 = new List<IWebElement>();
                //List<string> nadoLst = new List<string>();
                //foreach (var h2 in p4)
                //{                
                //    if (h2.Text.Contains("контракт") && h2.Text.Contains("Сведения процедуры") == false && h2.Text.Contains("Электронные документы") == false)
                //    {
                //        nad6.Add(h2);
                        //nado = nado + 1;
                        //nadoLst.Add(h2.Text);
                    //}
                    //var cl = h2.FindElements(By.TagName("a"));
                    //foreach (var kl in cl)
                    //{
                    //    if(kl.Text.Contains("контракт") && kl.Text.Contains("Сведения процедуры") == false)
                    //    {
                    //        nadoLst.Add(kl.Text);
                    //    }

                    //}
                //}
                
                //foreach (var h3 in nad6)
                //{
                //    await Task.Delay(2000);
                //    var fileHref = h3.GetAttribute("href");
                //    WebClient client = new WebClient();
                //    client.Headers["User-Agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36";
                //    await client.DownloadFileTaskAsync(new Uri(fileHref), @"C:\ContractsParser\" + h3.Text + ".doc");
                //}
                
                zakupkaLstBox.ItemsSource = listZakupokUklon.ToList();               
                string dateToday1 = Convert.ToString(DateTime.Now);
                logiLstbox.Items.Add("Готово!" + " " + "Выборка велась из" + " " + listZakupok.Count() + " " + "элементов." + " " + "Время завершения парсинга:" + " " + dateToday1 + " " + "элементов найдено:" + " " + listZakupokUklon.Count());
                driver.Close();
                driver.Quit();
            }

        }
       

        private void severoKavkasRadio_Checked(object sender, RoutedEventArgs e)
        {
            ischecked = true;
        }
    }
}
