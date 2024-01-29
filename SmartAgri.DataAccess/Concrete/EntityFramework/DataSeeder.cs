using Microsoft.EntityFrameworkCore;
using SmartAgri.Entities.Concrete;
using SmartAgri.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.DataAccess.Concrete.EntityFramework
{
    internal class DataSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            decimal[][] pastPrices = new decimal[9][];
            pastPrices[0] = new decimal[5] { 1614, 1595, 1554, 1560, 1567 };
            pastPrices[1] = new decimal[5] { 180, 175, 172, 159, 148 };
            pastPrices[2] = new decimal[5] { 2905, 3124, 3346, 3434, 3629 };
            pastPrices[3] = new decimal[5] { 268, 266, 235, 207, 223 };
            pastPrices[4] = new decimal[5] { 93, 92, 93, 95, 97 };
            pastPrices[5] = new decimal[5] { 508, 526, 555, 510, 487 };
            pastPrices[6] = new decimal[5] { 21, 20, 21, 21, 21 };
            pastPrices[7] = new decimal[5] { 1129, 1108, 1253, 1182, 1084 };
            pastPrices[8] = new decimal[5] { 299, 282, 278, 241, 229 };
            //banana 1614 1595 1554 1560 1567
            //Barley 180 175 172 159 148
            //Cocoa 2905 3124 3346 3434 3629
            //Corn 268 266 235 207 223
            //Cotton 93 92 93 95 97 
            //Soybean 508 526 555 510 487
            //Sugar 21 20 21 21 21
            //Sunflower 1129 1108 1253 1182 1084 
            //Wheat 299 282 278 241 229
            decimal[][] activeSellPrices = new decimal[9][];
            activeSellPrices[0] = new decimal[5] { 1540, 1550, 1560, 1570, 1580 };
            activeSellPrices[1] = new decimal[5] { 155, 156, 157, 158, 159 };
            activeSellPrices[2] = new decimal[5] { 3450, 3460, 3470, 3480, 3490 };
            activeSellPrices[3] = new decimal[5] { 200, 210, 220, 230, 240 };
            activeSellPrices[4] = new decimal[5] { 100, 110, 120, 130, 140 };
            activeSellPrices[5] = new decimal[5] { 510, 520, 530, 540, 550 };
            activeSellPrices[6] = new decimal[5] { 22, 23, 24, 25, 26 };
            activeSellPrices[7] = new decimal[5] { 1150, 1160, 1270, 1180, 1090 };
            activeSellPrices[8] = new decimal[5] { 230, 240, 250, 260, 270 };


            decimal[][] activeBuyPrices = new decimal[9][];
            activeBuyPrices[0] = new decimal[5] { 1530, 1520, 1510, 1500, 1490 };
            activeBuyPrices[1] = new decimal[5] { 150, 145, 140, 135, 130 };
            activeBuyPrices[2] = new decimal[5] { 3440, 3430, 3420, 3410, 3400 };
            activeBuyPrices[3] = new decimal[5] { 190, 180, 170, 160, 150 };
            activeBuyPrices[4] = new decimal[5] { 95, 90, 85, 80, 75 };
            activeBuyPrices[5] = new decimal[5] { 500, 490, 480, 470, 460 };
            activeBuyPrices[6] = new decimal[5] { 21, 20, 19, 18, 17 };
            activeBuyPrices[7] = new decimal[5] { 1140, 1130, 1120, 1110, 1100 };
            activeBuyPrices[8] = new decimal[5] { 220, 210, 200, 190, 180 };
            //1540,272
            //154,6281
            //3451,764
            //195,1501
            //97,24159
            //500,4919
            //21,55432
            //1144,215
            //228,4078

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = (int)UserRoleEnum.Admin,
                    Name = UserRoleEnum.Admin.ToString()
                },
                new Role
                {
                    Id = (int)UserRoleEnum.User,
                    Name = UserRoleEnum.User.ToString()
                });

            List<User> users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Name = "admin",
                    Surname = "admin",
                    Email = "admin@admin.com",
                    RoleId = (int)UserRoleEnum.Admin,
                    Password = "admin123",
                    CoinAccountId = Guid.Empty,
                    CoinAddress = "",
                },
                new User
                {
                    Id = 2,
                    Name = "Habil Mevlut",
                    Surname = "Sayar",
                    Email = "hms45267@gmail.com",
                    RoleId = (int)UserRoleEnum.User,
                    Password = "admin123",
                    CoinAccountId = Guid.Parse("1fbef5d8-950a-47df-b03d-755b9cb90aae"),
                    CoinAddress = "RRZ6bNDpVSywsMZvNmwtD1AYFtnupWaEH4",
                }
            };

            for (int i = 3; i < 15; i++)
            {
                users.Add(new User
                {
                    Id = i,
                    Name = "User" + i,
                    Surname = "User" + i,
                    Email = "user" + i + "@user.com",
                    RoleId = (int)UserRoleEnum.User,
                    Password = "user123",
                    CoinAccountId = Guid.NewGuid(),
                    CoinAddress = "",
                });
            }

            modelBuilder.Entity<User>().HasData(users);

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = (int)ProductEnum.Banana,
                    Name = ProductEnum.Banana.ToString(),
                    ImagePath = ProductEnum.Banana.ToString().ToLower() + ".png"
                }, new Product
                {
                    Id = (int)ProductEnum.Barley,
                    Name = ProductEnum.Barley.ToString(),
                    ImagePath = ProductEnum.Barley.ToString().ToLower() + ".png"
                }, new Product
                {
                    Id = (int)ProductEnum.Cocoa,
                    Name = ProductEnum.Cocoa.ToString(),
                    ImagePath = ProductEnum.Cocoa.ToString().ToLower() + ".png"
                }, new Product
                {
                    Id = (int)ProductEnum.Corn,
                    Name = ProductEnum.Corn.ToString(),
                    ImagePath = ProductEnum.Corn.ToString().ToLower() + ".png"
                }, new Product
                {
                    Id = (int)ProductEnum.Cotton,
                    Name = ProductEnum.Cotton.ToString(),
                    ImagePath = ProductEnum.Cotton.ToString().ToLower() + ".png"
                }, new Product
                {
                    Id = (int)ProductEnum.Soybean,
                    Name = ProductEnum.Soybean.ToString(),
                    ImagePath = ProductEnum.Soybean.ToString().ToLower() + ".png"
                }, new Product
                {
                    Id = (int)ProductEnum.Sugar,
                    Name = ProductEnum.Sugar.ToString(),
                    ImagePath = ProductEnum.Sugar.ToString().ToLower() + ".png"
                }, new Product
                {
                    Id = (int)ProductEnum.SunflowerOil,
                    Name = ProductEnum.SunflowerOil.ToString(),
                    ImagePath = ProductEnum.SunflowerOil.ToString().ToLower() + ".png"
                }, new Product
                {
                    Id = (int)ProductEnum.Wheat,
                    Name = ProductEnum.Wheat.ToString(),
                    ImagePath = ProductEnum.Wheat.ToString().ToLower() + ".png"
                });

            modelBuilder.Entity<AdvertStatus>().HasData(
                new AdvertStatus
                {
                    Id = (int)AdvertStatusEnum.Active,
                    Name = AdvertStatusEnum.Active.ToString()
                },
                new AdvertStatus
                {
                    Id = (int)AdvertStatusEnum.notProccess,
                    Name = AdvertStatusEnum.notProccess.ToString()
                },
                new AdvertStatus
                {
                    Id = (int)AdvertStatusEnum.complated,
                    Name = AdvertStatusEnum.complated.ToString()
                });

            int advertId = 1;
            int transactionId = 1;
            List<AdvertSell> advertSells = new List<AdvertSell>();
            List<AdvertBuy> advertBuys = new List<AdvertBuy>();
            List<Transaction> transactions = new List<Transaction>();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    advertSells.Add(new AdvertSell
                    {
                        Id = advertId,
                        ProductId = i + 1,
                        UnitPrice = pastPrices[i][j],
                        Quantity = 100,
                        UserId = i + 3,
                        StatusId = (int)AdvertStatusEnum.complated,
                        CreatedAt = DateTime.Now
                    });
                    advertId++;
                    advertBuys.Add(new AdvertBuy
                    {
                        Id = advertId,
                        ProductId = i + 1,
                        UnitPrice = pastPrices[i][j],
                        Quantity = 100,
                        UserId = i + 4,
                        StatusId = (int)AdvertStatusEnum.complated,
                        CreatedAt = DateTime.Now
                    });
                    advertId++;
                    transactions.Add(new Transaction
                    {
                        Id = transactionId,
                        BuyAdvertId = advertId - 1,
                        SellAdvertId = advertId - 2,
                        CreatedAt = DateTime.Now
                    });
                    transactionId++;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    advertSells.Add(new AdvertSell
                    {
                        Id = advertId,
                        ProductId = i + 1,
                        UnitPrice = activeSellPrices[i][j],
                        Quantity = 100,
                        UserId = 13 - i,
                        StatusId = (int)AdvertStatusEnum.Active,
                        CreatedAt = DateTime.Now
                    });
                    advertId++;
                    advertBuys.Add(new AdvertBuy
                    {
                        Id = advertId,
                        ProductId = i + 1,
                        UnitPrice = activeBuyPrices[i][j],
                        Quantity = 100,
                        UserId = 12 - i,
                        StatusId = (int)AdvertStatusEnum.Active,
                        CreatedAt = DateTime.Now
                    });
                    advertId++;
                }
            }

            modelBuilder.Entity<AdvertSell>().HasData(advertSells);
            modelBuilder.Entity<AdvertBuy>().HasData(advertBuys);
            modelBuilder.Entity<Transaction>().HasData(transactions);

            //modelBuilder.Entity<AdvertSell>().HasData(
            //    new AdvertSell
            //    {
            //        Id = 1,
            //        ProductId = 9,
            //        UnitPrice = 295,
            //        Quantity = 100,
            //        UserId = 2,
            //        StatusId = 1,
            //        CreatedAt = DateTime.Now
            //    },
            //    new AdvertSell
            //    {
            //        Id = 2,
            //        ProductId = 9,
            //        UnitPrice = 285,
            //        Quantity = 200,
            //        UserId = 2,
            //        StatusId = 1,
            //        CreatedAt = DateTime.Now
            //    },
            //    new AdvertSell
            //    {
            //        Id = 3,
            //        ProductId = 9,
            //        UnitPrice = 280,
            //        Quantity = 250,
            //        UserId = 2,
            //        StatusId = 1,
            //        CreatedAt = DateTime.Now
            //    },
            //    new AdvertSell
            //    {
            //        Id = 4,
            //        ProductId = 9,
            //        UnitPrice = 240,
            //        Quantity = 125,
            //        UserId = 2,
            //        StatusId = 1,
            //        CreatedAt = DateTime.Now
            //    },
            //    new AdvertSell
            //    {
            //        Id = 5,
            //        ProductId = 9,
            //        UnitPrice = 230,
            //        Quantity = 175,
            //        UserId = 2,
            //        StatusId = 1,
            //        CreatedAt = DateTime.Now
            //    });

            //modelBuilder.Entity<AdvertBuy>().HasData(
            //    new AdvertBuy
            //    {
            //        Id = 6,
            //        ProductId = 9,
            //        UnitPrice = 220,
            //        Quantity = 300,
            //        UserId = 2,
            //        StatusId = 1,
            //        CreatedAt = DateTime.Now
            //    },
            //    new AdvertBuy
            //    {
            //        Id = 7,
            //        ProductId = 9,
            //        UnitPrice = 210,
            //        Quantity = 200,
            //        UserId = 2,
            //        StatusId = 1,
            //        CreatedAt = DateTime.Now
            //    },
            //    new AdvertBuy
            //    {
            //        Id = 8,
            //        ProductId = 9,
            //        UnitPrice = 200,
            //        Quantity = 180,
            //        UserId = 2,
            //        StatusId = 1,
            //        CreatedAt = DateTime.Now
            //    },
            //    new AdvertBuy
            //    {
            //        Id = 9,
            //        ProductId = 9,
            //        UnitPrice = 190,
            //        Quantity = 150,
            //        UserId = 2,
            //        StatusId = 1,
            //        CreatedAt = DateTime.Now
            //    },
            //    new AdvertBuy
            //    {
            //        Id = 10,
            //        ProductId = 9,
            //        UnitPrice = 180,
            //        Quantity = 200,
            //        UserId = 2,
            //        StatusId = 1,
            //        CreatedAt = DateTime.Now
            //    });
        }
    }
}
