# 门店管理系统 — 项目方案文档

## 项目背景

本项目为《Windows程序设计》课程的期末综合作业——门店管理系统。该系统旨在为中小型零售门店提供一套轻量级的桌面管理工具，涵盖商品管理、销售收银、库存管理、会员管理和数据统计等核心业务功能。

## 功能需求分析

### 核心功能模块

| 模块 | 功能描述 |
|------|---------|
| 🏪 销售收银 | 商品搜索添加至购物车、数量调整、会员折扣、多种支付方式、结算自动扣库存 |
| 📦 商品管理 | 商品CRUD、分类管理、条码支持、库存预警设置 |
| 📋 库存管理 | 入库/出库记录、商品库存实时更新 |
| 👥 会员管理 | 会员注册、积分累计、等级制度(普通/银卡/金卡) |
| 📊 数据统计 | 日销售额趋势折线图、热销商品Top10柱状图、销售汇总 |

## 技术选型理由

| 技术 | 选型理由 |
|------|---------|
| **.NET 9.0 WinForms** | 课程核心技术，成熟的桌面应用框架，RAD开发 |
| **EF Core + SQLite** | 轻量级ORM，无需安装数据库服务，支持事务和LINQ查询 |
| **WinForms Chart** | 原生图表控件，零额外依赖，满足数据可视化需求 |
| **微软雅黑字体 + 自定义配色** | 提升UI美观度，深色侧边栏+浅色内容区 |

## 系统架构设计

```
┌──────────────────────────────────────────┐
│              UI Layer (Forms)            │
│  MainForm ─┬─ UC_Sale                    │
│            ├─ UC_Product                 │
│            ├─ UC_Stock                   │
│            ├─ UC_Member                  │
│            └─ UC_Report                  │
├──────────────────────────────────────────┤
│          Service Layer (Services)        │
│  ISaleService → SaleService              │
│  IProductService → ProductService        │
│  IInventoryService → InventoryService    │
│  ICustomerService → CustomerService      │
├──────────────────────────────────────────┤
│          Data Layer (EF Core + SQLite)   │
│  AppDbContext → 7 Entity Models          │
│  Category/Product/SaleOrder/SaleItem     │
│  Customer/StockIn/StockOut               │
└──────────────────────────────────────────┘
```

## 开发环境

| 项目 | 版本/工具 |
|------|----------|
| IDE | Visual Studio 2022 / VS Code |
| .NET SDK | 9.0.311 |
| 数据库 | SQLite (Microsoft.EntityFrameworkCore.Sqlite 9.0.4) |
| 图表 | WinForms.DataVisualization 1.10.2 |
| 版本控制 | Git + GitHub |
| OS | Windows 11 |

## 项目地址

**GitHub:** https://github.com/lixinru-git/StoreManagementSystem
