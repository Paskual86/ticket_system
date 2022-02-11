using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Data;
using System.Windows.Input;
using TicketSystem.Classes.Database;
using TicketSystem.Classes.Enums;
using TicketSystem.Classes.Items;

using TicketSystem.Classes.MagazineProducts;

namespace TicketSystem.Classes.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {
        public string TitleText { get; } = $"TicketSystem v{SettingsManager.AppVersion}";

        public UserItem CurrentUser { get; set; }
        public TerminalItem TerminalData { get; set; }

        #region Commands & Events
        public ICommand DashboardCommand {get; set; }
        public ICommand ModifyGroupCommand {get; set; }
        public ICommand ModifyTicketCommand { get; set; }
        public ICommand ModifyUserCommand { get; set; }
        public ICommand DeleteUserCommand { get; set; }
        public ICommand ModifyItemCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand ExitEntryCommand { get; set; }
        public ICommand SearchUserCommand { get; set; }
        public ICommand MagazineCommand { get; set; }
        public ICommand ProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public ICommand ModifyProductCommand { get; set; }

        public ICommand ProductBuyCommand { get; set; }

        

        public event EventHandler<int> RequestDashboardSelection;
        public event EventHandler<string> ShutDownMessage;
        public event EventHandler<string> WarningMessage;
        #endregion

        public ObservableCollection<MonitoringItem> MonitoringList { get; set; } = new ObservableCollection<MonitoringItem>();

        public ObservableCollection<TicketGroupItem> GroupsList { get; set; }
        public TicketGroupItem SelectedGroup { get; set; }

        

        public string UserSearchText { get; set; }

        public MonitoringItem SelectedMonitoringItem
        {
            get => _selectedMonitoringItem;
            set { _selectedMonitoringItem = value; OnPropertyChanged();}
        }

        public TicketGroupItem SelectedFilterGroup
        {
            get => _selectedFilterGroup;
            set { _selectedFilterGroup = value; OnPropertyChanged(); TicketsFilteredCollection.Refresh();}
        }

        public ObservableCollection<TicketItem> TicketsList { get; set; }
        public ICollectionView TicketsFilteredCollection
        {
            get
            {      
                var source = CollectionViewSource.GetDefaultView(TicketsList);
                source.Filter = p => ((TicketItem) p).GroupID == (SelectedFilterGroup?.ID ?? 0);
                return source;
            }
        }
        public TicketItem SelectedTicket{ get; set; }


        public ObservableCollection<ProductItem> ProductList { get; set; }
        public ICollectionView ProductFilteredCollection
        {
            get
            {
                var source = CollectionViewSource.GetDefaultView(ProductList);
                return source;
            }
        }


        public ObservableCollection<MagazineItem> MagazineList { get; set; }

        /// <summary>
        /// Devuelve todos los productos asociados a un magazine.
        /// </summary>
        public ICollectionView MagazineFilteredCollection
        {
            get
            {
                var source = CollectionViewSource.GetDefaultView(ProductList);
                return source;
            }
        }
        public ProductItem SelectedProduct { get; set; }

        public MagazineItem SelectedMagazine { get; set; }
        #region  Users

        public ObservableCollection<UserItem> LoggedUsersList { get; set; } = new ObservableCollection<UserItem>();

        public ObservableCollection<UserItem> UsersList { get; set; }
        public ICollectionView UsersFilteredCollection
        {
            get
            {      
                var source = CollectionViewSource.GetDefaultView(UsersList);
                var lowerText = UserSearchText?.ToLower();
                source.Filter = p =>
                {
                    if (string.IsNullOrEmpty(lowerText)) return true;
                    var user = (UserItem) p;
                    return user.SecureString.Contains(lowerText);
                };
                return source;
            }
        }
        public UserItem SelectedViewUser{ get; set; }
        #endregion

        public ObservableCollection<ProductCategory> ProductCategoryList => new ObservableCollection<ProductCategory>(DbHelper.GetProductCategory().ToList());

        public ICollectionView ProductCategories
        {
            get
            {
                var source = CollectionViewSource.GetDefaultView(ProductCategoryList);
                return source;
            }
        }
        #region Item Items
        public ItemItem SelectedViewItem{ get; set; }
        public ObservableCollection<ItemItem> ItemsList { get; set; } = new ObservableCollection<ItemItem>();

        #endregion

        #region WorkTimes
        public ObservableCollection<WorkTimeItem> WorkTimesList { get; set; } = new ObservableCollection<WorkTimeItem>();
        public ICollectionView WorkTimeFilteredCollection
        {
            get
            {      
                var source = CollectionViewSource.GetDefaultView(WorkTimesList);
                var lowerFirstname = _selectedWorkItemsFirstnameFilter?.ToLower();
                var lowerSurname = _selectedWorkItemsSurenameFilter?.ToLower();
                source.Filter = p =>
                {
                    if (string.IsNullOrEmpty(SelectedWorkItemsIdFilter)) return true;
                    var item = (WorkTimeItem) p;
                    return (string.IsNullOrEmpty(_selectedWorkItemsIdFilter) || item.UserItemID == _selectedWorkItemsIdFilter) &&
                           (_selectedWorkItemsFirstnameFilter == null || item.UserItem.Firstname.ToLower().Contains(lowerFirstname)) &&
                           (_selectedWorkItemsSurenameFilter == null || item.UserItem.Surname.ToLower().Contains(lowerSurname));
                };
                return source;
            }
        }

        private string _selectedWorkItemsIdFilter;
        private string _selectedWorkItemsSurenameFilter;
        private string _selectedWorkItemsFirstnameFilter;
        public ObservableCollection<string> WorkItemsIdFiltersList { get; set; }
        public ObservableCollection<string> WorkItemsSurenameFiltersList { get; set; }
        public ObservableCollection<string> WorkItemsFirstnameFiltersList { get; set; }

        public string SelectedWorkItemsIdFilter
        {
            get => _selectedWorkItemsIdFilter;
            set
            {
                _selectedWorkItemsIdFilter = value;
                _selectedWorkItemsFirstnameFilter = null;
                _selectedWorkItemsSurenameFilter = null;
                OnPropertyChanged(nameof(SelectedWorkItemsSurenameFilter));
                OnPropertyChanged(nameof(SelectedWorkItemsFirstnameFilter));
                WorkTimeFilteredCollection.Refresh();
                OnPropertyChanged();
            }
        }

        public string SelectedWorkItemsSurenameFilter
        {
            get => _selectedWorkItemsSurenameFilter;
            set
            {
                _selectedWorkItemsSurenameFilter = value;
                _selectedWorkItemsIdFilter = null;
                OnPropertyChanged(nameof(SelectedWorkItemsIdFilter));
                OnPropertyChanged();
                WorkTimeFilteredCollection.Refresh();
            }
        }

        public string SelectedWorkItemsFirstnameFilter
        {
            get => _selectedWorkItemsFirstnameFilter;
            set
            {
                _selectedWorkItemsFirstnameFilter = value; 
                _selectedWorkItemsIdFilter = null;
                OnPropertyChanged(nameof(SelectedWorkItemsIdFilter));
                OnPropertyChanged();
                WorkTimeFilteredCollection.Refresh();
            }
        }
        #endregion

        private readonly Timer _timer = new Timer(1000);
        private TicketGroupItem _selectedFilterGroup;
        private MonitoringItem _selectedMonitoringItem;

        public MainViewModel()
        {
            DashboardCommand = new SimpleCommand(OnRequestDashboardSelection);
            ModifyGroupCommand = new SimpleCommand(o => SelectedGroup != null, OnRequestDashboardSelection);
            ModifyTicketCommand = new SimpleCommand(o => SelectedTicket != null, OnRequestDashboardSelection);
            ModifyUserCommand = new SimpleCommand(o => SelectedViewUser != null, OnRequestDashboardSelection);
            DeleteUserCommand = new SimpleCommand(o => SelectedViewUser != null && SelectedViewUser.ID != (CurrentUser?.ID ?? ""), OnRequestDashboardSelection);
            ModifyItemCommand = new SimpleCommand(o=> SelectedViewItem != null, OnRequestDashboardSelection);
            RegisterCommand = new SimpleCommand(o => TicketsList.Any() && GroupsList.Any(), OnRequestDashboardSelection);
            ExitEntryCommand = new SimpleCommand(o => SelectedMonitoringItem != null, OnRequestDashboardSelection);
            SearchUserCommand = new SimpleCommand(o=> true, o => UsersFilteredCollection.Refresh());

            // New Features Added 
            MagazineCommand = new SimpleCommand(o => SelectedMagazine != null, OnRequestDashboardSelection);
            ProductCommand = new SimpleCommand(o => SelectedProduct != null, OnRequestDashboardSelection);
            DeleteProductCommand = new SimpleCommand(o => SelectedProduct != null, OnRequestDashboardSelection);
            ModifyProductCommand = new SimpleCommand(o => SelectedProduct != null, OnRequestDashboardSelection);

            ProductBuyCommand = new SimpleCommand(o => ProductList.Any(), OnRequestDashboardSelection);

            LoadData(false);
            _timer.Elapsed += async (sender, args) =>
            {
                _timer.Stop();
                try
                {
                    foreach (var userItem in LoggedUsersList)
                        userItem.Session.RefreshTime();
                    foreach (var item in MonitoringList)
                        item.RefreshTime();
                    await ProcessTickets();
                }
                finally
                {
                    _timer.Start();
                }
            };
            _timer.Start();
        }

        //private readonly Dictionary<long, TimeSpan> _ticketCheckIntervals = new Dictionary<long, TimeSpan>();

        private async Task ProcessTickets()
        {
            foreach (var item in MonitoringList)
            {
                try
                {
                    switch ((TimerTypeEnum) item.TicketItem.TimeType)
                    {
                        case TimerTypeEnum.NoLimit:
                            continue;
                        case TimerTypeEnum.Interval:
                        {
                            var totalMinutesPassed = (int)(DateTime.Now - item.EntryTime.Value).TotalMinutes+1;
                            var intervals = item.TicketItem.TypeIntervalItem.GetIntervals();
                            //always take above gross if we exceed specified number of minutes
                            if (item.TicketItem.TypeIntervalItem.FromMinutesAbove > 0 && totalMinutesPassed >= item.TicketItem.TypeIntervalItem.FromMinutesAbove)
                            {
                                //if we have proce above set and haven't substracted deposit yet
                                if (item.TicketItem.TypeIntervalItem.GrossPriceAbove > 0 && item.LastIntervalPass != -1)
                                {
                                    UpdateIncomeCalculation(item, item.TicketItem.TypeIntervalItem.GrossPriceAbove);
                                    item.LastIntervalPass = -1;
                                }
                            }
                            else
                            {
                                //search for next interval mark
                                foreach (var interval in intervals)
                                {
                                    if (totalMinutesPassed < interval.Key)
                                        break;
                                    if (item.LastIntervalPass < interval.Key)
                                    {
                                        item.LastIntervalPass = interval.Key;
                                        UpdateIncomeCalculation(item, interval.Value);
                                        break;
                                    }
                                }
                            }
                        }
                            continue;
                        case TimerTypeEnum.Minute:
                        {
                            var totalMinutesPassed = (int)(DateTime.Now - item.EntryTime.Value).TotalMinutes;
                            if (totalMinutesPassed <= item.TicketItem.ForMinutes && item.LastIntervalPass == -1)
                            {
                                UpdateIncomeCalculation(item, item.TicketItem.GrossPrice);
                                item.LastIntervalPass = 0;
                            }

                            if (item.LastIntervalPass >= 1 && item.TicketItem.TypeMinuteItem.IsFixedPrice && totalMinutesPassed >= item.TicketItem.TypeMinuteItem.FromMinutesAbove)
                            {
                                UpdateIncomeCalculation(item, item.TicketItem.TypeMinuteItem.GrossPriceAbove);
                                item.LastIntervalPass = -2;
                            }

                            if (totalMinutesPassed >= item.TicketItem.ForMinutes && item.LastIntervalPass >= 0)
                            {
                                if (item.TicketItem.TypeMinuteItem.ForNextMinutes > 0)
                                {
                                    var timesPassed = (totalMinutesPassed - item.TicketItem.ForMinutes) / item.TicketItem.TypeMinuteItem.ForNextMinutes + 1;
                                    Debug.WriteLine($"Times: {timesPassed} > {item.LastIntervalPass}");
                                    if (item.LastIntervalPass == 0 || timesPassed > item.LastIntervalPass)
                                    {
                                        item.LastIntervalPass++;
                                        UpdateIncomeCalculation(item, item.TicketItem.TypeMinuteItem.ExtraPay);
                                    }
                                }
                            }


                        }
                            continue;
                        default:
                            throw new Exception("Unknown TimerTypeEnum!");
                    }
                }
                catch (Exception ex)
                {
                    await LogHelper.LogEx(nameof(ProcessTickets), ex);
                }
            }
        }

        private void UpdateIncomeCalculation(MonitoringItem item, decimal gross = 0)
        {
            var netPrice = 0m;
            var ticketPrice = 0m;
            //1. Calculate total gross price according to tickets number
            //2. Calculate ticket gross price with possible discount
            //3. Calculate net price for actual income using VAT tax
            switch ((TimerTypeEnum) item.TicketItem.TimeType)
            {
                case TimerTypeEnum.NoLimit:
                    ticketPrice = item.TicketItem.TypeNoLimitItem.GrossPrice * item.NumberOfTickets;
                    ticketPrice = item.TicketItem.Discount > 0 ? ticketPrice.SubtractPerc(item.TicketItem.Discount) : ticketPrice;
                    netPrice = ticketPrice.SubtractPerc(item.TicketItem.VAT);
                    break;
                case TimerTypeEnum.Interval:
                    ticketPrice = gross * item.NumberOfTickets;
                    ticketPrice = item.TicketItem.Discount > 0 ? ticketPrice.SubtractPerc(item.TicketItem.Discount) : ticketPrice;
                    netPrice = ticketPrice.SubtractPerc(item.TicketItem.VAT);
                    break;
                case TimerTypeEnum.Minute:
                    ticketPrice = gross * item.NumberOfTickets;
                    ticketPrice = item.TicketItem.Discount > 0 ? ticketPrice.SubtractPerc(item.TicketItem.Discount) : ticketPrice;
                    netPrice = ticketPrice.SubtractPerc(item.TicketItem.VAT);
                    break;
                default:
                    throw new Exception("Unknown TimerTypeEnum!");
            }
            TerminalData.TotalIncome += netPrice;
            item.ActualPrice += ticketPrice;
            DbHelper.UpdateTerminalData(TerminalData);
            DbHelper.UpdateMonitoringItem(item);

        }

        public void UpdateItemsList()
        {
            ItemsList = new ObservableCollection<ItemItem>(DbHelper.GetItems());
        }

        public void UpdateWorkTimesList()
        {
            WorkTimesList = new ObservableCollection<WorkTimeItem>(DbHelper.GetWorkTimes());
            WorkItemsIdFiltersList = new ObservableCollection<string>(WorkTimesList.Select(a => a.UserItemID).Distinct().ToList());
            WorkItemsSurenameFiltersList = new ObservableCollection<string>(WorkTimesList.Select(a => a.UserItem?.Surname).Distinct().ToList());
            WorkItemsFirstnameFiltersList = new ObservableCollection<string>(WorkTimesList.Select(a => a.UserItem?.Firstname).Distinct().ToList());
            WorkItemsIdFiltersList.Insert(0, null);
            WorkItemsSurenameFiltersList.Insert(0, null);
            WorkItemsFirstnameFiltersList.Insert(0, null);
            SelectedWorkItemsIdFilter = WorkItemsIdFiltersList.FirstOrDefault();
            SelectedWorkItemsFirstnameFilter = WorkItemsFirstnameFiltersList.FirstOrDefault();
            SelectedWorkItemsSurenameFilter = WorkItemsSurenameFiltersList.FirstOrDefault();
        }

        private async void LoadData(bool authed)
        {
            if (authed)
            {
                MonitoringList = new ObservableCollection<MonitoringItem>(DbHelper.GetMonitoringItems(TerminalData.ID, CurrentUser.ID, true));
                UpdatePeoplesCount();
                TerminalData.AverageLengthOfStay = DbHelper.GetAverageStayTime();

                TicketsList = new ObservableCollection<TicketItem>(DbHelper.GetTickets());
                foreach (var item in TicketsList)
                    SubscribeToIsDefault(item, true);
                GroupsList = new ObservableCollection<TicketGroupItem>(DbHelper.GetTicketGroups());

                SelectedFilterGroup = GroupsList.FirstOrDefault();


                ProductList = new ObservableCollection<ProductItem>(DbHelper.GetProducts());
            }
            else
            {
                UsersList = new ObservableCollection<UserItem>(DbHelper.GetUsers());
                TerminalData = DbHelper.GetTerminal(SettingsManager.TerminalID);
                if (TerminalData == null)
                {
                    var msg = $"Terminal #{SettingsManager.TerminalID} not found in DB!";
                    OnShutdownMessage(msg);
                    await LogHelper.LogError(msg);
                }
            }
        }

        private void SubscribeToIsDefault(TicketItem item, bool subscribe)
        {
            if(subscribe)
                item.PropertyChanged += OnItemOnPropertyChanged;
            else
                item.PropertyChanged -= OnItemOnPropertyChanged;
        }

        private void OnItemOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsDefault")
            {
                var it = (TicketItem) sender;
                DbHelper.UpdateTicket(it);
                if (it.IsDefault)
                {
                    var changed = TicketsList.Where(a => a.IsDefault).ToList();
                    changed.Remove(it);
                    foreach (var c in changed)
                    {
                        c.IsDefault = false;
                        DbHelper.UpdateTicket(c);
                    }
                }
            }
        }

        public bool Authenticate(string dataUsername, string dataPassword)
        {
            try
            {
                var user = DbHelper.Authenticate(dataUsername, dataPassword);
                if (user != null)
                {
                    LoggedUsersList.Add(user);
                    CurrentUser = user;
                    SettingsManager.LastUserName = user.Login;
                    CurrentUser.Session.ResetStats();
                    DbHelper.AddWorkingItem(new WorkTimeItem { UserItemID = CurrentUser.ID, StartHour = TimeSpan.FromHours(DateTime.Now.Hour).Add(TimeSpan.FromMinutes(DateTime.Now.Minute))});
                    LoadData(true);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                OnWarningMessage("There was an error during user authentication!");
                LogHelper.LogEx(nameof(Authenticate), ex).GetAwaiter().GetResult();
                return false;
            }
        }

        protected void OnRequestDashboardSelection(object value)
        {
            RequestDashboardSelection?.Invoke(this, Convert.ToInt32(value));
        }

        protected void OnShutdownMessage(string value)
        {
            ShutDownMessage?.Invoke(this, value);
        }

        protected void OnWarningMessage(string value)
        {
            WarningMessage?.Invoke(this, value);
        }

        public void LogOutUser()
        {
            if(CurrentUser == null) return;
            DbHelper.UpdateUserWorkingItem(CurrentUser.ID, TimeSpan.FromHours(DateTime.Now.Hour).Add(TimeSpan.FromMinutes(DateTime.Now.Minute)));

            LoggedUsersList.Remove(CurrentUser);
            CurrentUser = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void AddGroup(TicketGroupItem item)
        {
            if(DbHelper.AddGroup(item))
                GroupsList.Add(item);
            else OnWarningMessage($"There was problem creating new group {item?.Name}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AProduct"></param>
        public void AddProduct(ProductItem AProduct)
        {
            if (DbHelper.AddProduct(AProduct))
            ProductList.Add(AProduct);
            else OnWarningMessage($"There was problem creating new Product {AProduct?.Name}");
        }

        public void UpdateProduct(ProductItem AProduct)
        {
            if (!DbHelper.UpdateProduct(AProduct))
               OnWarningMessage($"There was problem updating Product {AProduct?.Name}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AProduct"></param>
        public void AddMagazine(MagazineItem AMagazineItem)
        {
            if (DbHelper.AddMagazine(AMagazineItem))
                MagazineList.Add(AMagazineItem);
            else OnWarningMessage($"There was problem a new magazine");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AMagazineProduct"></param>
        public void AddMagazineProduct(MagazineProduct AMagazineProduct)
        {
            if (DbHelper.AddMagazineProduct(AMagazineProduct))
                SelectedMagazine.MagazineProducts.Add(AMagazineProduct);
            else OnWarningMessage($"There was problem a new magazine");
        }

        /// <summary>
        /// 
        /// </summary>
        public void RemoveProduct()
        {
            if (SelectedProduct == null) return;
            if (DbHelper.RemoveProduct(SelectedProduct))
            {
                //SubscribeToIsDefault(SelectedTicket, false);
                ProductList.Remove(SelectedProduct);
            }
            else OnWarningMessage($"There was problem removing selected group {SelectedProduct?.Name}");
        }

        public void DuplicateProduct()
        {
            if (SelectedProduct == null) return;
            var newItem = SelectedProduct.Clone();
            newItem.ClearIdentificators();
            newItem.Name += " duplicate";
            AddProduct(newItem);
        }
        public void RemoveGroup()
        {            
            if(SelectedGroup == null) return;
            if(DbHelper.RemoveGroup(SelectedGroup))
                GroupsList.Remove(SelectedGroup);
            else OnWarningMessage($"There was problem removing selected group {SelectedGroup?.Name}");
        }

        public void DuplicateGroup()
        {
            if (SelectedGroup == null) return;
            AddGroup(new TicketGroupItem
            {
                Name = $"{SelectedGroup.Name} duplicate",
                Description = SelectedGroup.Description
            });
        }

        public void AddTicket(TicketItem item)
        {
            if (DbHelper.AddTicket(item))
            {
                SubscribeToIsDefault(item, true);
                TicketsList.Add(item);
            }
            else OnWarningMessage($"There was problem creating new ticket {item?.Name}");
        }

        public void RemoveTicket()
        {
            if(SelectedTicket == null) return;
            if (DbHelper.RemoveTicket(SelectedTicket))
            {
                SubscribeToIsDefault(SelectedTicket, false);
                TicketsList.Remove(SelectedTicket);
            }
            else OnWarningMessage($"There was problem removing selected group {SelectedTicket?.Name}");
        }

        public void RemoveUser()
        {
            if(SelectedViewUser == null) return;
            if (DbHelper.RemoveUser(SelectedViewUser))
            {
                if (LoggedUsersList.Contains(SelectedViewUser))
                    LoggedUsersList.Remove(SelectedViewUser);
                if(WorkTimesList.Any())
                    foreach (var item in WorkTimesList.Where(a => a.UserItem == null || a.UserItem.ID == SelectedViewUser.ID).ToList())
                        WorkTimesList.Remove(item);
                UsersList.Remove(SelectedViewUser);
            }
            else OnWarningMessage($"There was problem removing selected user {SelectedViewUser?.Surname}");
        }
        
        public void RemoveItem()
        {
            if(SelectedViewItem == null) return;
            if(DbHelper.RemoveItem(SelectedViewItem))
                ItemsList.Remove(SelectedViewItem);
            else OnWarningMessage($"There was problem removing selected item {SelectedViewItem?.EntryID}");
        }

        public void DuplicateTicket()
        {
            if (SelectedTicket == null) return;
            var newItem = SelectedTicket.Clone();
            newItem.ClearIdentificators();
            newItem.Name += " duplicate";
            AddTicket(newItem);
        }

        public void DuplicateUser()
        {
            if (SelectedViewUser == null) return;
            var newItem = SelectedViewUser.Clone();
            newItem.ClearIdentificators();
            AddUser(newItem);
        }

        public void DuplicateItem()
        {
            if (SelectedViewItem == null) return;
            var newItem = SelectedViewItem.Clone();
            newItem.ClearIdentifiers();
            AddItem(newItem);
        }

        public void AddItem(ItemItem item)
        {
            if (DbHelper.AddItem(item))
            {
                ItemsList.Add(item);
            }
            else OnWarningMessage($"There was problem creating new item {item?.EntryID}");
        }

        public void AddUser(UserItem user)
        {
            if (DbHelper.AddUser(user))
            {
                UsersList.Add(user);
                UsersFilteredCollection.Refresh();
            }
            else OnWarningMessage($"There was problem creating new user {user?.Surname}");
        }

        public void UpdateTicket(TicketItem item)
        {
            if(!DbHelper.UpdateTicket(item))
                OnWarningMessage($"There was problem updating ticket {item?.Name}");
        }

        public void UpdateItem(ItemItem item)
        {
            if(!DbHelper.UpdateItem(item))
                OnWarningMessage($"There was problem updating item {item?.EntryID}");
        }

        public void UpdateGroup(TicketGroupItem item)
        {
            if(!DbHelper.UpdateGroup(item))
                OnWarningMessage($"There was problem updating group {item?.Name}");
        }

        public void UpdateUser(UserItem item)
        {
            if(!DbHelper.UpdateUser(item))
                OnWarningMessage($"There was problem updating user {item?.Surname}");
        }

        public void AddMonitoringItem(MonitoringItem item)
        {
            if (!DbHelper.AddMonitoringItem(item))
            {
                OnWarningMessage($"There was problem adding new entry {item?.EntryID}");
                return;
            }
            //_ticketCheckIntervals.Add(item.ID, TimeSpan.Zero);
            MonitoringList.Add(item);
            UpdatePeoplesCount();
            if((TimerTypeEnum)item.TicketItem.TimeType == TimerTypeEnum.NoLimit)
                UpdateIncomeCalculation(item);
            else DbHelper.UpdateTerminalData(TerminalData);
        }



        private void UpdatePeoplesCount()
        {
            TerminalData.PeoplesCount = MonitoringList.Sum(a => a.NumberOfTickets);
        }

        public void ExitEntry()
        {
            if(SelectedMonitoringItem == null) return;
            SelectedMonitoringItem.ExitTime = DateTime.Now;
            if (DbHelper.UpdateMonitoringItem(SelectedMonitoringItem))
            {
                TerminalData.AverageLengthOfStay = DbHelper.GetAverageStayTime();
                //_ticketCheckIntervals.Remove(SelectedMonitoringItem.ID);
                MonitoringList.Remove(SelectedMonitoringItem);
                UpdatePeoplesCount();
                DbHelper.UpdateTerminalData(TerminalData);
            }

        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public bool CanDeleteGroup()
        {
            return !DbHelper.GroupHasTickets(SelectedGroup.ID);
        }

        public bool CanDeleteTicket()
        {
            return !DbHelper.TicketHasEntries(SelectedTicket.ID);
        }

        public bool CanDeleteUser()
        {
            return !DbHelper.UserHasEntries(SelectedViewUser.ID);
        }

        public bool CanDeleteItem()
        {
            return !DbHelper.ItemHasTickets(SelectedViewItem.EntryID);
        }
    }
}
