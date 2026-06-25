# 门店管理系统 (StoreManagementSystem)

基于 .NET 9.0 WinForms + EF Core + SQLite 的桌面门店管理应用。

## 功能模块

| 模块 | 说明 |
|------|------|
| 🏪 销售收银 | 商品搜索添加至购物车、会员折扣、多种支付方式、结算自动扣库存 |
| 📦 商品管理 | 商品 CRUD、分类管理、条码支持、库存预警设置 |
| 📋 库存管理 | 入库/出库记录、商品库存实时更新 |
| 👥 会员管理 | 会员注册、积分累计、等级制度（普通/银卡/金卡） |
| 📊 数据统计 | 日销售额趋势折线图、热销商品 Top10 柱状图 |

## 快速开始

### 环境要求
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Windows 操作系统（WinForms 应用）

### 运行方式

```bash
# 克隆仓库
git clone https://github.com/lixinru-git/StoreManagementSystem.git

# 进入项目目录
cd StoreManagementSystem

# 运行
dotnet run
```

首次启动会自动创建 SQLite 数据库，并初始化示例分类和商品数据。

## 技术选型

| 技术 | 用途 |
|------|------|
| .NET 9.0 WinForms | 桌面应用程序框架 |
| Entity Framework Core | ORM 数据持久化 |
| SQLite | 本地文件数据库 |
| WinForms Chart | 数据可视化图表 |

## 项目文档

- [项目方案文档](Project_Proposal.md) — 项目背景、需求分析、技术选型、架构设计
- [测试说明文档](Testing_Report.md) — 测试用例、TDD 实践说明

## 项目结构

```
├── Data/
│   ├── Models/          # 实体类 (7个)
│   └── AppDbContext.cs  # 数据库上下文
├── Services/            # 业务逻辑层
├── Forms/               # UI 界面层 (5个模块)
├── Program.cs           # 入口 + DI 配置
├── Project_Proposal.md  # 项目方案
└── Testing_Report.md    # 测试报告
```

## 额外说明

本项目为《Windows程序设计》课程综合作业。
