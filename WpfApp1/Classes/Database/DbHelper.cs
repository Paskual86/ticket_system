using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using TicketSystem.Classes.Items;
using TicketSystem.Classes.MagazineProducts;

namespace TicketSystem.Classes.Database
{
    public static class DbHelper
    {
        public static void PrepareDatabase(string filename = null)
        {
            if (!string.IsNullOrEmpty(filename))
                File.Create(filename);
        }

        public static IEnumerable<UserItem> GetUsers()
        {
            using (var db = new TicketSystemContext())
                return db.Users.ToList();
        }

        public static void CreateDatabase()
        {
            using (var db = new TicketSystemContext())
                db.CreateDatabase();
        }

        public static void Seed()
        {
            if(SettingsManager.DbProvider == DbProviderEnum.Sqlite)
                using (var db = new TicketSystemContext())
                {
                    if (!db.Users.Any())
                        db.Seed();
                }
        }

        public static TerminalItem GetTerminal(long id)
        {
            using (var db = new TicketSystemContext())
                return db.Terminals.FirstOrDefault(a => a.ID == id);
        }

        public static List<TicketItem> GetTickets()
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    var res = db.Tickets.Include(a => a.TypeMinuteItem).Include(a => a.TypeIntervalItem).Include(a => a.TypeNoLimitItem).Include(a => a.Group);
                    return res.ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<TicketItem>();
            }
        }

        /// <summary>
        /// Return all products
        /// </summary>
        /// <returns></returns>
        public static List<ProductItem> GetProducts()
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    var lst = db.Products.ToList();
                    foreach (var p in lst) db.Entry(p).Reference(h => h.Vat).Load();
                    return lst;
                }
            }
            catch 
            {
                return new List<ProductItem>();
            }
        }
        

        public static List<TicketGroupItem> GetTicketGroups()
        {
            using (var db = new TicketSystemContext())
                return db.TicketGroups.ToList();
        }

        public static UserItem Authenticate(string dataUsername, string dataPassword)
        {
            using (var db = new TicketSystemContext())
                return db.Users.FirstOrDefault(a => a.Login == dataUsername && a.Password == dataPassword);
        }

        public static bool AddGroup(TicketGroupItem item)
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    db.TicketGroups.Add(item);
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(AddGroup), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }

        public static IEnumerable<Vat> GetVats()
        {
            using (var db = new TicketSystemContext())
                return db.Vats.ToList();
        }

        public static IEnumerable<ProductCategory> GetProductCategory()
        {
            using (var db = new TicketSystemContext())
                return db.ProductCategories.ToList();
        }
        

        public static bool AddProduct(ProductItem AProduct)
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    db.Products.Add(AProduct);
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(AddProduct), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }

        public static bool UpdateProduct(ProductItem AProduct)
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    db.Products.Attach(AProduct);
                    db.Entry(AProduct).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(UpdateTicket), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AMagazineItem"></param>
        /// <returns></returns>
        public static bool AddMagazine(MagazineItem AMagazineItem)
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    db.Magazines.Add(AMagazineItem);
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(AddMagazine), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AMagazineItem"></param>
        /// <returns></returns>
        public static bool AddMagazineProduct(MagazineProduct AMagazineProduct)
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    db.MagazineProducts.Add(AMagazineProduct);
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(AddMagazine), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AMagazine"></param>
        /// <returns></returns>
        public static bool UpdateMagazine(MagazineItem AMagazine)
        {
            try
            {
                AMagazine.MagazineProducts = null;
                using (var db = new TicketSystemContext())
                {
                    db.Magazines.Attach(AMagazine);
                    db.Entry(AMagazine).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(UpdateTicket), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }

        public static bool RemoveProduct(ProductItem AProduct)
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    db.Products.Add(AProduct);
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(AddProduct), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }

        public static bool AddUser(UserItem item)
        {
            try
            {
                item.MonitoringItems = null;
                using (var db = new TicketSystemContext())
                {
                    db.Users.Add(item);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(AddUser), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }

        
        public static bool AddItem(ItemItem item)
        {
            try
            {
                item.MonitoringItems = null;
                using (var db = new TicketSystemContext())
                {
                    db.Items.Add(item);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(AddUser), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }

        public static bool AddTicket(TicketItem item)
        {
            try
            {
                item.MonitoringItems = null;
                using (var db = new TicketSystemContext())
                {
                    //item.Group = db.TicketGroups.FirstOrDefault(a => a.ID == item.GroupID);
                    db.TicketGroups.Attach(item.Group);

                    db.Tickets.Add(item);
                    db.TypeMinuteItems.Add(item.TypeMinuteItem);
                    db.TypeIntervalItems.Add(item.TypeIntervalItem);
                    db.TypeNoLimitItems.Add(item.TypeNoLimitItem);
                    db.SaveChanges();

                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(AddTicket), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }

        public static bool RemoveUser(UserItem item)
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    var dbItem = db.Users.FirstOrDefault(a => a.ID == item.ID);
                    if (dbItem != null)
                    {
                        foreach (var workItem in dbItem.WorkItems.ToList())
                        {
                            db.WorkTimeItems.Attach(workItem);
                            db.WorkTimeItems.Remove(workItem);
                        }

                        db.Users.Remove(dbItem);
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(RemoveUser), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }

        public static bool RemoveGroup(TicketGroupItem item)
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    var dbItem = db.TicketGroups.FirstOrDefault(a => a.ID == item.ID);
                    if (dbItem != null)
                    {
                        db.TicketGroups.Remove(dbItem);
                        db.SaveChanges();

                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(RemoveGroup), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }

        public static bool RemoveItem(ItemItem item)
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    var dbItem = db.Items.FirstOrDefault(a => a.EntryID == item.EntryID);
                    if (dbItem != null)
                    {
                        db.Items.Remove(dbItem);
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(RemoveItem), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }

        public static bool RemoveTicket(TicketItem item)
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    var dbItem = db.Tickets.FirstOrDefault(a => a.ID == item.ID);
                    if (dbItem != null)
                    {
                        dbItem.Group = null;
                        db.Tickets.Remove(dbItem);
                        var a1 = db.TypeIntervalItems.FirstOrDefault(a => a.ID == item.ID);
                        if (a1 != null)
                            db.TypeIntervalItems.Remove(a1);
                        var a2 = db.TypeMinuteItems.FirstOrDefault(a => a.ID == item.ID);
                        if (a2 != null)
                            db.TypeMinuteItems.Remove(a2);
                        var a3 = db.TypeNoLimitItems.FirstOrDefault(a => a.ID == item.ID);
                        if (a3 != null)
                            db.TypeNoLimitItems.Remove(a3);
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(RemoveTicket), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }

        public static bool UpdateTicket(TicketItem item)
        {
            try
            {
                item.MonitoringItems = null;
                using (var db = new TicketSystemContext())
                {
                    db.TicketGroups.Attach(item.Group);
                    db.TypeNoLimitItems.Attach(item.TypeNoLimitItem);
                    db.TypeIntervalItems.Attach(item.TypeIntervalItem);
                    db.TypeMinuteItems.Attach(item.TypeMinuteItem);
                    db.Entry(item.TypeNoLimitItem).State = EntityState.Modified;
                    db.Entry(item.TypeIntervalItem).State = EntityState.Modified;
                    db.Entry(item.TypeMinuteItem).State = EntityState.Modified;

                    db.Tickets.Attach(item);
                    db.Entry(item).State = EntityState.Modified;

                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(UpdateTicket), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }

        public static bool UpdateUser(UserItem item)
        {
            try
            {
                item.WorkItems = null;
                using (var db = new TicketSystemContext())
                {
                    db.Users.Attach(item);
                  /*  foreach (var workItem in item.WorkItems)
                    {
                        db.WorkTimeItems.Attach(workItem);
                    }*/
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(UpdateUser), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }

        public static bool UpdateGroup(TicketGroupItem item)
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    db.TicketGroups.Attach(item);
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(UpdateGroup), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }

        
        public static bool UpdateItem(ItemItem item)
        {
            try
            {
                item.MonitoringItems = null;
                using (var db = new TicketSystemContext())
                {
                    var exist = db.Items.FirstOrDefault(a => a.EntryID == item.EntryID);
                    if (exist == null)
                    {
                        //search for entry with old ID
                        var old = item.OldEntryId == null ? null : db.Items.FirstOrDefault(a => a.EntryID == item.OldEntryId);
                        if (old != null)
                        {
                            db.Items.Remove(old);
                            db.SaveChanges();
                        }
                        db.Items.Add(item);
                    }
                    else
                    {
                        db.Items.Remove(exist);
                        db.SaveChanges();
                        db.Items.Add(item);
                    }
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(UpdateItem), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }

        public static bool AddMonitoringItem(MonitoringItem item)
        {
            try
            {
                item.TicketItem.MonitoringItems = null;
                using (var db = new TicketSystemContext())
                {
                    var client = db.Items.FirstOrDefault(a => a.EntryID.Equals(item.EntryID, StringComparison.OrdinalIgnoreCase));
                    if (client == null)
                    {
                        var newItem = new ItemItem
                        {
                            EntryID = item.EntryID
                        };
                        newItem.UnknownFields();
                        if (AddItem(newItem))
                            item.ItemItem = newItem;
                    }
                    else
                        item.ItemItem = client;

                    db.Tickets.Attach(item.TicketItem);
                    db.TypeIntervalItems.Attach(item.TicketItem.TypeIntervalItem);
                    db.TypeMinuteItems.Attach(item.TicketItem.TypeMinuteItem);
                    db.TypeNoLimitItems.Attach(item.TicketItem.TypeNoLimitItem);
                    db.TicketGroups.Attach(item.TicketItem.Group);
                    db.Users.Attach(item.UserItem);
                    db.Items.Attach(item.ItemItem);
                    if (item.TerminalItem != null)
                        db.Terminals.Attach(item.TerminalItem);

                    db.MonitoringItems.Add(item);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(AddMonitoringItem), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }

        public static void UpdateTerminalData(TerminalItem terminalData)
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    var dbEntry = db.Terminals.FirstOrDefault(a => a.ID == terminalData.ID);
                    if (dbEntry == null)
                    {
                        db.Terminals.Add(terminalData);
                    }else
                    {
                        dbEntry.TotalIncome = terminalData.TotalIncome;
                        dbEntry.Name = terminalData.Name;
                    }

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(UpdateTerminalData), ex, LogCat.Data).GetAwaiter().GetResult();
            }
        }

        public static List<MonitoringItem> GetMonitoringItems(long terminalDataID, string currentUserID, bool onlyActive)
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    var res = db.MonitoringItems.Include(a=> a.TicketItem).Include(a=> a.TicketItem.TypeNoLimitItem).Include(a=> a.TicketItem.TypeIntervalItem).Include(a=> a.TicketItem.TypeMinuteItem).Include(a=> a.TicketItem.Group)
                        .Include(a=> a.UserItem).Where(a => a.UserItemID == currentUserID && a.TerminalID == terminalDataID).OrderBy(a => a.EntryTime);
                    var res2 = onlyActive ? res.Where(a => !a.ExitTime.HasValue).ToList() : res.ToList();

                    return res2;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(GetMonitoringItems), ex, LogCat.Data).GetAwaiter().GetResult();
                return  new List<MonitoringItem>();
            }
        }

        public static bool UpdateMonitoringItem(MonitoringItem item)
        {
            try
            {
                item.TicketItem.MonitoringItems = null;
                using (var db = new TicketSystemContext())
                {
                    db.Tickets.Attach(item.TicketItem);
                    db.TypeIntervalItems.Attach(item.TicketItem.TypeIntervalItem);
                    db.TypeMinuteItems.Attach(item.TicketItem.TypeMinuteItem);
                    db.TypeNoLimitItems.Attach(item.TicketItem.TypeNoLimitItem);
                    db.TicketGroups.Attach(item.TicketItem.Group);
                    db.Users.Attach(item.UserItem);
                    db.Items.Attach(item.ItemItem);
                    if (item.TerminalItem != null)
                        db.Terminals.Attach(item.TerminalItem);

                    db.MonitoringItems.Attach(item);
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(UpdateMonitoringItem), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }

        public static TimeSpan GetAverageStayTime()
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    //sadly EF SQLite don't support DiffSeconds method so we have to make calc on client side
                    //UPD: can be optimized for MSSQL later
                    var array =  db.MonitoringItems.Include(a=> a.TicketItem.TypeIntervalItem)
                        .Include(a=> a.TicketItem.TypeMinuteItem).Include(a=> a.TicketItem.TypeNoLimitItem)
                        .Include(a=> a.TicketItem.Group)
                        .Where(a => a.ExitTime.HasValue).Select(a => new List<DateTime?> {a.ExitTime, a.EntryTime}).ToList();
                    if (array.Count > 0)
                    {
                        var value = TimeSpan.FromSeconds(array.Select(a => (int) (a[0] - a[1]).Value.TotalSeconds).Average());
                        return value;
                    }
                    return TimeSpan.Zero;
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(GetAverageStayTime), ex, LogCat.Data).GetAwaiter().GetResult();
                return TimeSpan.Zero;
            }
        }

        public static bool GroupHasTickets(long groupId)
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    return db.Tickets.Any(a => a.GroupID == groupId);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(GroupHasTickets), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }

        public static bool TicketHasEntries(long ticketId)
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    return db.MonitoringItems.Any(a => a.TicketItemID == ticketId);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(TicketHasEntries), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }

        public static bool UserHasEntries(string id)
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    return db.MonitoringItems.Any(a => a.UserItemID == id);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(UserHasEntries), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }

        public static bool UpdateUserWorkingItem(string userId, TimeSpan endHour)
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    var item = db.WorkTimeItems.Where(a => a.UserItemID == userId).OrderByDescending(a => a.ID).FirstOrDefault();
                    item.EndHour = endHour;
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(UpdateUserWorkingItem), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }


        public static bool AddWorkingItem(WorkTimeItem workTimeItem)
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    db.WorkTimeItems.Add(workTimeItem);
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(AddWorkingItem), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }
        }

        public static List<WorkTimeItem> GetWorkTimes()
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    return db.WorkTimeItems.Include(a=> a.UserItem).AsNoTracking().OrderBy(a=> a.UserItemID).ThenByDescending(a=> a.ID).ToList();
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(GetWorkTimes), ex, LogCat.Data).GetAwaiter().GetResult();
                return new List<WorkTimeItem>();
            } 
        }

        public static List<ItemItem> GetItems()
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    return db.Items.AsNoTracking().OrderBy(a=> a.EntryID).ToList();
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(GetItems), ex, LogCat.Data).GetAwaiter().GetResult();
                return new List<ItemItem>();
            } 
        }

        public static dynamic GetProfits()
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    return db.MonitoringItems.Include(a=> a.TicketItem)
                        .Include(a=> a.TicketItem.TypeNoLimitItem)
                        .Include(a=> a.TicketItem.TypeIntervalItem)
                        .Include(a=> a.TicketItem.TypeMinuteItem)
                        .OrderBy(a => a.EntryTime).ToList()
                        .Select(item => new {item.ActualPrice, item.TicketItem.VAT, EntryTime = item.EntryTime.Value}).ToList();
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(GetProfits), ex, LogCat.Data).GetAwaiter().GetResult();
                return null;
            } 
        }

        public static bool ItemHasTickets(string entryId)
        {
            try
            {
                using (var db = new TicketSystemContext())
                {
                    return db.MonitoringItems.Any(a => a.EntryID == entryId);
                }
            }
            catch (Exception ex)
            {
                LogHelper.LogEx(nameof(ItemHasTickets), ex, LogCat.Data).GetAwaiter().GetResult();
                return false;
            }

        }
    }
}
