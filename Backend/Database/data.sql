USE [AvtoZapchasti]
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (N'aa9cfdaf-73f4-47e6-3524-08d9af4d5c95', N'Двигатель и выхлопная система')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (N'8918cdd8-655e-4753-3523-08d9af4d5c95', N'Запчасти для ТО')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (N'27b05c43-0595-4131-3527-08d9af4d5c95', N'Охлаждение и Отопление')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (N'ba778589-0ad5-40df-3525-08d9af4d5c95', N'Подвеска и Рулевое')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (N'ac3b1d09-ab0e-44b6-352a-08d9af4d5c95', N'Составляющие детали кузова автомобиля')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (N'54742378-12a5-443b-3526-08d9af4d5c95', N'Сцепление и коробка передач')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (N'9054cc56-d512-4b30-352b-08d9af4d5c95', N'Топливная система')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (N'3c0ce9ad-9f9f-4649-3529-08d9af4d5c95', N'Тормозная система')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (N'bd86540e-6675-4e27-3528-08d9af4d5c95', N'Электрическая часть')
GO
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (N'7f0deda9-e595-4915-83aa-f90d477b5afe', N'Audi')
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (N'9195fb2c-9cb4-43a1-9779-c91f0aaf3bbf', N'BMW')
INSERT [dbo].[Brands] ([Id], [Name]) VALUES (N'02c86c53-e3ea-41d9-a11e-65f227f53b9c', N'Mercedes')
GO
INSERT [dbo].[Models] ([Id], [Name], [BrandId]) VALUES (N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'100', N'7f0deda9-e595-4915-83aa-f90d477b5afe')
GO
INSERT [dbo].[Providers] ([Id], [Name], [SiteUrl]) VALUES (N'144f1f90-8779-4267-2975-08d9af4d5b17', N'https://autocompass.com.ua', N'https://autocompass.com.ua')
INSERT [dbo].[Providers] ([Id], [Name], [SiteUrl]) VALUES (N'2fd98a32-aaed-4548-1828-08d9af50ca65', N'https://www.autoklad.ua', N'https://www.autoklad.ua')
INSERT [dbo].[Providers] ([Id], [Name], [SiteUrl]) VALUES (N'53bf02fd-cc81-42bb-5878-08d9af561cb1', N'https://teman.com.ua', N'https://teman.com.ua')
GO
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'd7cb2ea5-dd8b-4bff-d48d-08d9af4d606e', N'Антифриз febi синій концентрат (каністра 1,5л) 01089 Febi', CAST(227.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/009/316/28540_460x330.jpg', N'Производитель: $Febi
Каталожный номер: $01089
Цвет: $синий
Объем [л]: $1.5
Спецификация: $MB 325.2 MB 325.0
Вес [кг]: $1.78
Соблюдать сервисную информацию: $1
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'8918cdd8-655e-4753-3523-08d9af4d5c95', N'https://autocompass.com.ua/9316-antifriz-febi-sin-y-koncentrat-kan-stra-1-5l.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'37551cb8-8fac-47c6-d48e-08d9af4d606e', N'Антифриз febi ліловий концентрат g12+ (каністра 5л) 19402 Febi', CAST(696.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/062/992/42189_460x330.jpg', N'Производитель: $Febi
Каталожный номер: $19402
Цвет: $сиреневый
Объем [л]: $5
Спецификация: $G 12 Plus
Вес [кг]: $5.705
Соблюдать сервисную информацию: $1
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'8918cdd8-655e-4753-3523-08d9af4d5c95', N'https://autocompass.com.ua/62992-antifriz-febi-l-loviy-koncentrat-g12-kan-stra-5l.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'6580680c-6faa-40e2-d48f-08d9af4d606e', N'Антифриз febi синій концентрат (каністра 5л) 22268 Febi', CAST(696.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/010/645/28716_460x330.jpg', N'Производитель: $Febi
Каталожный номер: $22268
Цвет: $синий
Объем [л]: $5
Вес [кг]: $6
Соблюдать сервисную информацию: $1
Необходимое количество: $MB 325.0
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'8918cdd8-655e-4753-3523-08d9af4d5c95', N'https://autocompass.com.ua/10645-antifriz-febi-sin-y-koncentrat-kan-stra-5l.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'1b2eb503-fbe2-406e-d490-08d9af4d606e', N'Антифриз розовый(-80С)1,5л.(G012A8FA1) FEBI 19400 Febi', CAST(259.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/037/608/33807_460x330.jpg', N'Производитель: $Febi
Каталожный номер: $19400
Цвет: $сиреневый
Объем [л]: $1.5
Спецификация: $G 12 Plus MB 325.3 VW TL 774 F Ford WSS-M97B44-D
Вес [кг]: $1.741
Соблюдать сервисную информацию: $1
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'8918cdd8-655e-4753-3523-08d9af4d5c95', N'https://autocompass.com.ua/37608-antifriz-rozovyy-80s-1-5l-g012a8fa1-19400-febi.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'68ed3329-da4a-4d4c-d491-08d9af4d606e', N'Антифриз hepu blue g11 концентрат (каниістра 1,5л) P999 Hepu', CAST(245.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/002/296/811526_460x330.jpg', N'Производитель: $Hepu
Каталожный номер: $P999
Цвет: $синий
Объем [л]: $1.5
Тип контейнера: $Бутылка
Спецификация: $MB 325.2 MB 325.0
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'8918cdd8-655e-4753-3523-08d9af4d5c95', N'https://autocompass.com.ua/2296-antifriz-hepu-blue-g11-koncentrat-kani-stra-1-5l.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'69ea649f-5729-4da1-d492-08d9af4d606e', N'Антифриз febi концентрат (каністра 1,5л) 38200 Febi', CAST(292.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/007/324/28195_460x330.jpg', N'Производитель: $Febi
Каталожный номер: $38200
Объем [л]: $1.5
Спецификация: $G 13
Соблюдать сервисную информацию: $1
Необходимое количество: $сиреневый
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'8918cdd8-655e-4753-3523-08d9af4d5c95', N'https://autocompass.com.ua/7324-antifriz-febi-koncentrat-kan-stra-1-5l.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'c9a51342-3e87-4e22-d493-08d9af4d606e', N'Антифриз febi червоний концентрат g12 (каністра 5л) 22272 Febi', CAST(747.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/008/677/28428_460x330.jpg', N'Производитель: $Febi
Каталожный номер: $22272
Цвет: $красный
Объем [л]: $5
Спецификация: $G 12
Вес [кг]: $6
Соблюдать сервисную информацию: $1
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'8918cdd8-655e-4753-3523-08d9af4d5c95', N'https://autocompass.com.ua/8677-antifriz-febi-chervoniy-koncentrat-g12-kan-stra-5l.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'bd6c9d76-4334-4b74-d494-08d9af4d606e', N'Антифриз febi червоний концентрат g12 (каністра 20л) 22274 Febi', CAST(2539.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/062/991/42188_460x330.jpg', N'Производитель: $Febi
Каталожный номер: $22274
Цвет: $красный
Объем [л]: $20
Спецификация: $G 12
Вес [кг]: $22
Соблюдать сервисную информацию: $1
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'8918cdd8-655e-4753-3523-08d9af4d5c95', N'https://autocompass.com.ua/62991-antifriz-febi-chervoniy-koncentrat-g12-kan-stra-20l.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'8da6cbd4-5fe3-43e4-d495-08d9af4d606e', N'Антифриз синий 60л FEBI 05011 Febi', CAST(6135.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/160/959/76203_460x330.jpg', N'Производитель: $Febi
Каталожный номер: $05011
Цвет: $синий
Объем [л]: $60
Вес [кг]: $60
Соблюдать сервисную информацию: $1
Необходимое количество: $MB 325.0
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'8918cdd8-655e-4753-3523-08d9af4d5c95', N'https://autocompass.com.ua/160959-antifriz-siniy-60l-05011-febi.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'809c0e4f-466b-4f17-d496-08d9af4d606e', N'Антифриз синій g11 (-35°c "ready mix) - "готовий до применяемость 1l 171998 Febi', CAST(88.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/002/680/774/2680774_460x330.jpg', N'Производитель: $Febi
Каталожный номер: $171998
Цвет: $синий
Объем [л]: $1
Спецификация: $G11 (-35°C)
Вес [кг]: $1.06
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'8918cdd8-655e-4753-3523-08d9af4d5c95', N'https://autocompass.com.ua/2680774-antifriz-sin-y-g11-35-c-ready-mix-gotoviy-do-zastosuvannya-1l.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'1adb0343-6265-4151-d497-08d9af4d606e', N'Поршень в комплекте на 1 цилиндр, 1-й ремонт (+0,25) 029 55 01 Mahle', CAST(1148.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/126/341/64195_460x330.jpg', N'Производитель: $Mahle
Каталожный номер: $029 55 01
Дополнительный артикул / Дополнительная информация: $с поршневыми кольцами
Диаметр цилиндра [мм]: $77.01
Длина [мм]: $71.7
Степень сжатия (компрессии) [мм]: $41.7
Глубина вогнутости 1 [мм]: $1.6
Высота пожарного мостка [мм]: $12.5
&empty; болта [мм]: $24
Длина болта [мм]: $64
Номер продукции: $76 V 30
Дополнительный артикул / дополнительная информация 2: $с опорой поршневого кольца
Номер компонента: $2. M 2.0 IFU
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'aa9cfdaf-73f4-47e6-3524-08d9af4d5c95', N'https://autocompass.com.ua/126341-porshen-v-komplekte-na-1-cilindr-1-y-remont-0-25.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'11ccd7c2-9724-442a-d498-08d9af4d606e', N'Поршень MAHLE 02982 01 Mahle', CAST(1180.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/731/414/169883_460x330.jpg', N'Производитель: $Mahle
Каталожный номер: $02982 01
Дополнительный артикул / Дополнительная информация: $с поршневыми кольцами
Диаметр цилиндра [мм]: $79.76
Длина [мм]: $65.65
Степень сжатия (компрессии) [мм]: $39.65
Глубина вогнутости 1 [мм]: $1.9
Диаметр вогнутости [мм]: $26.5
Высота пожарного мостка [мм]: $11.1
&empty; болта [мм]: $24
Длина болта [мм]: $64
Номер продукции: $79 V 97
Дополнительный артикул / дополнительная информация 2: $с опорой поршневого кольца
Механически обработанный: $с пазом/фаской для масляной форсунки
Номер компонента: $2.M2.0 IFU Cr P
Тип конструкции шатуна: $Трапецеидальный шатун
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'aa9cfdaf-73f4-47e6-3524-08d9af4d5c95', N'https://autocompass.com.ua/731414-porshen-mahle-02982-01.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'904b863a-208b-44c6-d499-08d9af4d606e', N'Поршень VAG 80.0 1.9D, 2.4D 1Y, 1X, AAB, AJA 029 82 12 Mahle', CAST(1320.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/068/635/43180_460x330.jpg', N'Производитель: $Mahle
Каталожный номер: $029 82 12
Дополнительный артикул / Дополнительная информация: $с поршневыми кольцами
Диаметр цилиндра [мм]: $80.01
Длина [мм]: $65.65
Степень сжатия (компрессии) [мм]: $39.4
Глубина вогнутости 1 [мм]: $1.9
Диаметр вогнутости [мм]: $26.5
Высота пожарного мостка [мм]: $11.1
&empty; болта [мм]: $24
Длина болта [мм]: $64
Номер продукции: $79 V 97
Дополнительный артикул / дополнительная информация 2: $с опорой поршневого кольца
Механически обработанный: $с пазом/фаской для масляной форсунки
Номер компонента: $2.M2.0 IFU Cr P
Тип конструкции шатуна: $Трапецеидальный шатун
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'aa9cfdaf-73f4-47e6-3524-08d9af4d5c95', N'https://autocompass.com.ua/68635-porshen-vag-80-0-1-9d-2-4d-1y-1x-aab-aja.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'1127468e-53aa-4c01-d49a-08d9af4d606e', N'Поршень в комплекте на 1 цилиндр, 2-й ремонт (+0,50) 034 78 02 Mahle', CAST(1318.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/190/091/83041_460x330.jpg', N'Производитель: $Mahle
Каталожный номер: $034 78 02
Дополнительный артикул / Дополнительная информация: $с поршневыми кольцами
Диаметр цилиндра [мм]: $81.51
Длина [мм]: $62.2
Степень сжатия (компрессии) [мм]: $31.9
Глубина вогнутости 1 [мм]: $8.1
Диаметр вогнутости [мм]: $56.8
Высота пожарного мостка [мм]: $6.1
&empty; болта [мм]: $20
Длина болта [мм]: $57
Номер продукции: $81 V 54
Номер компонента: $1. R 1.5 IW Cr 2. NM 1.75 3. 3S 3.0 Cr
Дополнительный артикул / дополнительная информация 2: $без охлаждающего канала
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'aa9cfdaf-73f4-47e6-3524-08d9af4d5c95', N'https://autocompass.com.ua/190091-porshen-v-komplekte-na-1-cilindr-2-y-remont-0-50.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'5a87728e-afe6-40f9-d49b-08d9af4d606e', N'Поршень MAHLE 02955 00 Mahle', CAST(1341.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/731/416/169885_460x330.jpg', N'Производитель: $Mahle
Каталожный номер: $02955 00
Дополнительный артикул / Дополнительная информация: $с поршневыми кольцами
Стандартный размер [стд.]: $76.51
Диаметр цилиндра [мм]: $71.7
Длина [мм]: $41.7
Степень сжатия (компрессии) [мм]: $1.6
Глубина вогнутости 1 [мм]: $12.5
Высота пожарного мостка [мм]: $24
&empty; болта [мм]: $64
Длина болта [мм]: $76 V 30
Номер продукции: $с опорой поршневого кольца
Дополнительный артикул / дополнительная информация 2: $2. M 2.0 IFU
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'aa9cfdaf-73f4-47e6-3524-08d9af4d5c95', N'https://autocompass.com.ua/731416-porshen-mahle-02955-00.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'd08d23b3-7955-47cc-d49c-08d9af4d606e', N'Поршень AUDI, VW, VOLVO 100,80,Golf,Jetta,LT 28-35,40-55,760,940,960 1,6TD-2,4TD -96 0297912 Mahle', CAST(1514.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/737/830/170307_460x330.jpg', N'Производитель: $Mahle
Каталожный номер: $0297912
Дополнительный артикул / Дополнительная информация: $с поршневыми кольцами
Диаметр цилиндра [мм]: $77.01
Длина [мм]: $71.7
Степень сжатия (компрессии) [мм]: $41.7
Глубина вогнутости 1 [мм]: $1.6
Высота пожарного мостка [мм]: $12.5
&empty; болта [мм]: $24
Длина болта [мм]: $64
Поверхность: $анодированный в жесткой воде
Номер продукции: $76 V 54
Дополнительный артикул / дополнительная информация 2: $с опорой поршневого кольца
Механически обработанный: $с пазом/фаской для масляной форсунки
Номер компонента: $2.M2.0 IFU Cr P
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'aa9cfdaf-73f4-47e6-3524-08d9af4d5c95', N'https://autocompass.com.ua/737830-porshen-mahle-audi-vw-volvo-100-80-golf-jetta-lt-28-35-40-55-760-940-960-1-6td-2-4td-96.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'd9ceb672-c8e6-4e2b-d49d-08d9af4d606e', N'Поршень VAG 80.51 1.9D, 2.4D 1Y, 1X, AAB, AJA 029 82 13 Mahle', CAST(999.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/063/146/42265_460x330.jpg', N'Производитель: $Mahle
Каталожный номер: $029 82 13
Дополнительный артикул / Дополнительная информация: $с поршневыми кольцами
Диаметр цилиндра [мм]: $80.51
Длина [мм]: $65.65
Степень сжатия (компрессии) [мм]: $39.4
Глубина вогнутости 1 [мм]: $1.9
Диаметр вогнутости [мм]: $26.5
Высота пожарного мостка [мм]: $11.1
&empty; болта [мм]: $24
Длина болта [мм]: $64
Номер продукции: $79 V 97
Дополнительный артикул / дополнительная информация 2: $с опорой поршневого кольца
Механически обработанный: $с пазом/фаской для масляной форсунки
Номер компонента: $2.M2.0 IFU Cr P
Тип конструкции шатуна: $Трапецеидальный шатун
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'aa9cfdaf-73f4-47e6-3524-08d9af4d5c95', N'https://autocompass.com.ua/63146-porshen-vag-80-51-1-9d-2-4d-1y-1x-aab-aja.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'4c69b940-073d-4dd0-d49e-08d9af4d606e', N'Поршень в комплекте на 1 цилиндр, 2-й ремонт (+0,50) MAHLE 0297902 Mahle', CAST(1318.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/001/446/959/661223_460x330.jpg', N'Производитель: $Mahle
Каталожный номер: $0297902
Дополнительный артикул / Дополнительная информация: $с поршневыми кольцами
Диаметр цилиндра [мм]: $77.01
Длина [мм]: $71.7
Степень сжатия (компрессии) [мм]: $41.45
Глубина вогнутости 1 [мм]: $1.6
Высота пожарного мостка [мм]: $12.5
&empty; болта [мм]: $24
Длина болта [мм]: $64
Поверхность: $анодированный в жесткой воде
Номер продукции: $76 V 54
Дополнительный артикул / дополнительная информация 2: $с опорой поршневого кольца
Механически обработанный: $с пазом/фаской для масляной форсунки
Номер компонента: $2.M2.0 IFU Cr P
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'aa9cfdaf-73f4-47e6-3524-08d9af4d5c95', N'https://autocompass.com.ua/1446959-porshen-v-komplekte-na-1-cilindr-2-y-remont-0-50-0297902-mahle.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'0dfc5c85-8491-4948-d49f-08d9af4d606e', N'Поршень (вир-во ks) 91386630 Kolbenschmidt', CAST(1212.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/035/878/526434_460x330.jpg', N'Производитель: $Kolbenschmidt
Каталожный номер: $91386630
Завышение размера [мм]: $1
&empty; болта [мм]: $24
Длина болта [мм]: $64
Номер компонента: $81201 81202 81203
Количество: $3
Номер продукции: $079119
&empty; отверстия [мм]: $80.51
Степень сжатия (компрессии) [мм]: $39.4
Длина [мм]: $65.7
Глубина вогнутости 1 [мм]: $1.9
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'aa9cfdaf-73f4-47e6-3524-08d9af4d5c95', N'https://autocompass.com.ua/35878-porshen-vir-vo-ks.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'50093659-ae93-4968-d4a0-08d9af4d606e', N'Поршень (вир-во ks) 91386600 Kolbenschmidt', CAST(1037.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/035/879/526435_460x330.jpg', N'Производитель: $Kolbenschmidt
Каталожный номер: $91386600
Стандартный размер [стд.]: $24
&empty; болта [мм]: $64
Длина болта [мм]: $79999 80004 80007
Номер компонента: $3
Количество: $079119
Номер продукции: $79.51
&empty; отверстия [мм]: $39.65
Степень сжатия (компрессии) [мм]: $65.7
Длина [мм]: $1.9
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'aa9cfdaf-73f4-47e6-3524-08d9af4d5c95', N'https://autocompass.com.ua/35879-porshen-vir-vo-ks.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'24cf956c-64d8-41e6-d4a1-08d9af4d606e', N'Амортизатор SATO TECH 21267F SATO tech', CAST(1155.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/001/591/187/1591187_460x330.jpg', N'Производитель: $SATO tech
Каталожный номер: $21267F
Сторона установки: $Передние
Вид амортизатора: $Вставка амортизатора давление газа
Система амортизатора: $двухтрубный
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'ba778589-0ad5-40df-3525-08d9af4d5c95', N'https://autocompass.com.ua/1591187-amortizator-sato-tech.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'23d3d42c-2809-490c-d4a2-08d9af4d606e', N'Амортизатор SATO TECH 33342F SATO tech', CAST(962.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/002/548/933/2548933_460x330.jpg', N'Производитель: $SATO tech
Каталожный номер: $33342F
Сторона установки: $Передние
Вид амортизатора: $Вставка амортизатора Давление масла
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'ba778589-0ad5-40df-3525-08d9af4d5c95', N'https://autocompass.com.ua/2548933-amortizator-sato-tech-sato-tech.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'30099751-fef8-4eff-d4a3-08d9af4d606e', N'Амортизатор SATO TECH 21555R SATO tech', CAST(1168.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/002/682/818/2682818_460x330.jpg', N'Производитель: $SATO tech
Каталожный номер: $21555R
Вид амортизатора: $давление газа
Система амортизатора: $двухтрубный
Способ крепления амортизатора: $верхний стержень
Сторона установки: $Задний мост
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'ba778589-0ad5-40df-3525-08d9af4d5c95', N'https://autocompass.com.ua/2682818-amortizator-sato-tech.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'605ecf10-9dc5-4afb-d4a4-08d9af4d606e', N'Амортизатор 126 725 0008 MEYLE', CAST(961.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/150/662/234773_460x330.jpg', N'Производитель: $MEYLE
Каталожный номер: $126 725 0008
Сторона установки: $Задние
Вид амортизатора: $давление газа Телескопический амортизатор
Система амортизатора: $двухтрубный
Способ крепления амортизатора: $верхний стержень нижнее отверстие
Номера артикулов рекомендуемых комплектующих: $100 512 0024
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'ba778589-0ad5-40df-3525-08d9af4d5c95', N'https://autocompass.com.ua/150662-amortizator-126-725-0008-meyle.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'21f25ab3-7ae4-4251-d4a5-08d9af4d606e', N'Амортизатор 126 725 0004 MEYLE', CAST(1000.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/150/663/234774_460x330.jpg', N'Производитель: $MEYLE
Каталожный номер: $126 725 0004
Сторона установки: $Задние
Вид амортизатора: $давление газа амортизатор
Система амортизатора: $двухтрубный
Способ крепления амортизатора: $верхний стержень нижнее отверстие
Номера артикулов рекомендуемых комплектующих: $100 512 0024
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'ba778589-0ad5-40df-3525-08d9af4d5c95', N'https://autocompass.com.ua/150663-amortizator-126-725-0004-meyle.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'0e0f0e45-18c8-43b4-d4a6-08d9af4d606e', N'Амортизатор 126 624 0001 MEYLE', CAST(919.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/150/667/234778_460x330.jpg', N'Производитель: $MEYLE
Каталожный номер: $126 624 0001
Сторона установки: $Передние
Вид амортизатора: $давление газа Вставка амортизатора
Система амортизатора: $двухтрубный
Способ крепления амортизатора: $верхний стержень
Номера артикулов рекомендуемых комплектующих: $100 640 0002
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'ba778589-0ad5-40df-3525-08d9af4d5c95', N'https://autocompass.com.ua/150667-amortizator-126-624-0001-meyle.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'e6efb8a9-210d-491d-d4a7-08d9af4d606e', N'Амортизатор excel-g газовый задний 341133 Kayaba', CAST(2167.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/004/089/774789_460x330.jpg', N'Производитель: $Kayaba
Каталожный номер: $341133
Сторона установки: $Задние
Вид амортизатора: $давление газа
Способ крепления амортизатора: $верхний стержень нижнее отверстие
Система амортизатора: $двухтрубный
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'ba778589-0ad5-40df-3525-08d9af4d5c95', N'https://autocompass.com.ua/4089-amortizator-excel-g-gazovyy-zadniy.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'a780a207-2ebc-434a-d4a8-08d9af4d606e', N'Картрідж амортизатора масляний передній 666001 Kayaba', CAST(1252.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/004/612/1008291_460x330.jpg', N'Производитель: $Kayaba
Каталожный номер: $666001
Сторона установки: $Передние
Вид амортизатора: $давление масла Вставка амортизатора
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'ba778589-0ad5-40df-3525-08d9af4d5c95', N'https://autocompass.com.ua/4612-kartr-dzh-amortizatora-maslyaniy-peredn-y.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'3532dd3d-bca1-4e48-d4a9-08d9af4d606e', N'Амортизатор пiдв. audi 100 задн. (вир-во kayaba) 441040 Kayaba', CAST(1436.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/005/019/1008023_460x330.jpg', N'Производитель: $Kayaba
Каталожный номер: $441040
Сторона установки: $Задние
Способ крепления амортизатора: $верхний стержень нижнее отверстие
Вид амортизатора: $давление масла
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'ba778589-0ad5-40df-3525-08d9af4d5c95', N'https://autocompass.com.ua/5019-amortizator-pidv-audi-100-zadn-vir-vo-kayaba.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'efff1693-3a43-422d-d4aa-08d9af4d606e', N'Сальник распредвала CORTECO 12001192B Corteco', CAST(220.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/015/742/198619_460x330.jpg', N'Производитель: $Corteco
Каталожный номер: $12001192B
Сторона установки: $Задние
Внутренний диаметр 1(мм): $30
Наружный диаметр 1 [мм]: $47
Высота 1 [мм]: $7
Материал: $FPM (Fluor-Kautschuk)
Тип кручения: $переменное кручение
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'ba778589-0ad5-40df-3525-08d9af4d5c95', N'https://autocompass.com.ua/15742-salnik-raspredvala-corteco-12001192b-corteco.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'bff532f4-2749-4083-d4ab-08d9af4d606e', N'Центрирующий подшипник 410 0015 10 LUK', CAST(691.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/062/238/1006191_460x330.jpg', N'Производитель: $LUK
Каталожный номер: $410 0015 10
SVHC: $Не содержит веществ SVHC!
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'54742378-12a5-443b-3526-08d9af4d5c95', N'https://autocompass.com.ua/62238-centriruyuschiy-podshipnik-luk-410-0015-10-luk.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'84f16d37-1b9e-4a2a-d4ac-08d9af4d606e', N'Центрирующий опорный подшипник, система сцеплен 1863 869 001 Sachs', CAST(167.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/172/065/79526_460x330.jpg', N'Производитель: $Sachs
Каталожный номер: $1863 869 001
Диаметр [мм]: $21
Наружный диаметр [мм]: $21
Внутренний диаметр: $15
Ширина (мм): $15
Конструкция подшипника: $игольчатый подшипник
SVHC: $Нет информации. обратитесь. пожалуйста. к производителю!
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'54742378-12a5-443b-3526-08d9af4d5c95', N'https://autocompass.com.ua/172065-centriruyuschiy-opornyy-podshipnik-sistema-sceplen.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'22081576-2cb4-432f-d4ad-08d9af4d606e', N'Выжимной подшипник 500105010 LUK', CAST(561.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/276/148/1006212_460x330.jpg', N'Производитель: $LUK
Каталожный номер: $500105010
SVHC: $Не содержит веществ SVHC!
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'54742378-12a5-443b-3526-08d9af4d5c95', N'https://autocompass.com.ua/276148-vyzhimnoy-podshipnik.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'8465478b-3eef-413a-d4ae-08d9af4d606e', N'Подшипник игольчатый FEBI 14098 Febi', CAST(153.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/142/604/517449_460x330.jpg', N'Производитель: $Febi
Каталожный номер: $14098
Ширина (мм): $15
Внутренний диаметр: $15.4
Наружный диаметр [мм]: $21
Конструкция подшипника: $игольчатый подшипник
Вес [кг]: $0.04
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'54742378-12a5-443b-3526-08d9af4d5c95', N'https://autocompass.com.ua/142604-podshipnik-igolchatyy-14098-febi.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'1ff7e20d-a555-4179-d4af-08d9af4d606e', N'Центрирующий подшипник, сцепление 100 105 0004 MEYLE', CAST(180.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/811/214/356150_460x330.jpg', N'Производитель: $MEYLE
Каталожный номер: $100 105 0004
Наружный диаметр [мм]: $21
Внутренний диаметр: $14
Высота [мм]: $15
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'54742378-12a5-443b-3526-08d9af4d5c95', N'https://autocompass.com.ua/811214-centriruyuschiy-podshipnik-sceplenie.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'1e086a55-d295-45ad-d4b0-08d9af4d606e', N'Центрирующий опорный подшипник, система сцепления 1110450300 JP GROUP', CAST(50.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/636/947/329807_460x330.jpg', N'Производитель: $JP GROUP
Каталожный номер: $1110450300
Ширина (мм): $15
Внутренний диаметр: $15.4
Наружный диаметр [мм]: $21
Конструкция подшипника: $игольчатый подшипник
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'54742378-12a5-443b-3526-08d9af4d5c95', N'https://autocompass.com.ua/636947-centriruyuschiy-opornyy-podshipnik-sistema-scepleniya.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'81cf38f8-e11f-418c-d4b1-08d9af4d606e', N'Направляющая гильза, система сцепления 8130300100 JP GROUP', CAST(116.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/638/924/330938_460x330.jpg', N'Производитель: $JP GROUP
Каталожный номер: $8130300100
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'54742378-12a5-443b-3526-08d9af4d5c95', N'https://autocompass.com.ua/638924-napravlyayuschaya-gilza-sistema-scepleniya.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'bff21b22-3440-4ff3-d4b2-08d9af4d606e', N'Выжимной подшипник SACHS SACHS 3151 271 937 Sachs', CAST(512.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/057/684/40228_460x330.jpg', N'Производитель: $Sachs
Каталожный номер: $3151 271 937
Параметр: $KZIS-0
SVHC: $Нет информации. обратитесь. пожалуйста. к производителю!
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'54742378-12a5-443b-3526-08d9af4d5c95', N'https://autocompass.com.ua/57684-vyzhimnoy-podshipnik-sachs-3151-271-937-sachs.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'25dc47d6-5941-4098-d4b3-08d9af4d606e', N'Центрирующий подшипник 410 0009 10 LUK', CAST(154.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/062/239/1006189_460x330.jpg', N'Производитель: $LUK
Каталожный номер: $410 0009 10
SVHC: $Не содержит веществ SVHC!
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'54742378-12a5-443b-3526-08d9af4d5c95', N'https://autocompass.com.ua/62239-centriruyuschiy-podshipnik-luk-410-0009-10-luk.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'83f5f734-146b-4d3d-d4b4-08d9af4d606e', N'Выжимной подшипник VKC 2601 SKF', CAST(389.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/102/424/1009621_460x330.jpg', N'Производитель: $SKF
Каталожный номер: $VKC 2601
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'54742378-12a5-443b-3526-08d9af4d5c95', N'https://autocompass.com.ua/102424-vyzhimnoy-podshipnik-skf-vkc-2601-skf.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'c8eb46cd-17ae-407a-d4b5-08d9af4d606e', N'Насос водяной Audi A6, VW Crafter 30-50, LT28-35, Transporter T4, Volvo S80 2.5 TDi WP0289 LPR', CAST(654.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/002/048/1058459_460x330.jpg', N'Производитель: $LPR
Каталожный номер: $WP0289
Число зубцов: $20
Вид эксплуатации: $механический
Для артикула №: $WP0289
Ременной шкив: $со ременным шкивом
Исполнение водяного насоса: $для зубчато-ременного привода
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'27b05c43-0595-4131-3527-08d9af4d5c95', N'https://autocompass.com.ua/2048-nasos-vodyanoy-audi-a6-vw-crafter-30-50-lt28-35-transporter-t4-volvo-s80-2-5-tdi.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'e27927e8-9819-4be3-d4b6-08d9af4d606e', N'Прокладка водяного насоса 164.111 Elring', CAST(127.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/072/155/45186_460x330.jpg', N'Производитель: $Elring
Каталожный номер: $164.111
Толщина [мм]: $1
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'27b05c43-0595-4131-3527-08d9af4d5c95', N'https://autocompass.com.ua/72155-prokladka-vodyanogo-nasosa-164-111-elring.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'43d2aa58-b23c-464d-d4b7-08d9af4d606e', N'Водяной насос Audi 100, LT 2.0, 2.4 TD -92 (20z.) PA380P Saleri SIL', CAST(740.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/001/427/759/634249_460x330.jpg', N'Производитель: $Saleri SIL
Каталожный номер: $PA380P
&empty; шкива [мм]: $59.175
Версия: $pulley H. 43.2mm
Число зубцов: $20
Количество уплотнений: $1
Материал прокладки: $Резина
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'27b05c43-0595-4131-3527-08d9af4d5c95', N'https://autocompass.com.ua/1427759-vodyanoy-nasos-audi-100-lt-2-0-2-4-td-92-20z.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'ac588008-0fea-4743-d4b8-08d9af4d606e', N'Водяной насос 538 0045 10 INA', CAST(1152.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/007/921/522943_460x330.jpg', N'Производитель: $INA
Каталожный номер: $538 0045 10
Ременной шкив: $со ременным шкивом
Исполнение водяного насоса: $для зубчато-ременного привода
Число зубцов: $20
SVHC: $Не содержит веществ SVHC!
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'27b05c43-0595-4131-3527-08d9af4d5c95', N'https://autocompass.com.ua/7921-vodyanoy-nasos.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'2c8bb0c8-c628-4f01-d4b9-08d9af4d606e', N'Водяной насос Audi 80, 100, A6, Seat Cordoba, Toledo, Skoda Superb, VW Golf, Passat, T4 WP0079 LPR', CAST(450.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/005/679/520863_460x330.jpg', N'Производитель: $LPR
Каталожный номер: $WP0079
Диаметр лопастного колеса [мм]: $60
Размер резьбы: $M8
Вид эксплуатации: $механический
Для артикула №: $WP0079
Оснащение / оборудование: $для автомобилей без усиленного рулевого механизма
Тип корпуса: $без корпуса
Количество резьбовых отверстий: $3
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'27b05c43-0595-4131-3527-08d9af4d5c95', N'https://autocompass.com.ua/5679-vodyanoy-nasos-audi-80-100-a6-seat-cordoba-toledo-skoda-superb-vw-golf-passat-t4.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'271e18a7-c49b-4d0d-d4ba-08d9af4d606e', N'Насос водяної vw/audi 100/a6/t2/t4 (85-) (вир-во febi) 01286 Febi', CAST(504.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/008/189/28350_460x330.jpg', N'Производитель: $Febi
Каталожный номер: $01286
Вес [кг]: $1.001
Соблюдать сервисную информацию: $1
Необходимое количество: $Металл
Материал крыльчатки водяного насоса: $бумага
Материал прокладки: $Алюминиевое литье
Материал: $6
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'27b05c43-0595-4131-3527-08d9af4d5c95', N'https://autocompass.com.ua/8189-nasos-vodyano-vw-audi-100-a6-t2-t4-85-vir-vo-febi.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'1f948c57-ff0e-46a9-d4bb-08d9af4d606e', N'Водяний насос audi (вир-во lpr) WP0043 LPR', CAST(776.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/010/612/196588_460x330.jpg', N'Производитель: $LPR
Каталожный номер: $WP0043
Для артикула №: $WP0043
Диаметр лопастного колеса [мм]: $79
Количество резьбовых отверстий: $1
Вид эксплуатации: $механический
&empty; шкива [мм]: $83
Ременной шкив: $со ременным шкивом
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'27b05c43-0595-4131-3527-08d9af4d5c95', N'https://autocompass.com.ua/10612-vodyaniy-nasos-audi-vir-vo-lpr.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'8ace9081-902c-452c-d4bc-08d9af4d606e', N'Водяний насос (вир-во magneti marelli кор.код. wpq1193) 352316171193 Magneti Marelli', CAST(775.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/034/538/203285_460x330.jpg', N'Производитель: $Magneti Marelli
Каталожный номер: $352316171193
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'27b05c43-0595-4131-3527-08d9af4d5c95', N'https://autocompass.com.ua/34538-vodyaniy-nasos-vir-vo-magneti-marelli-kor-kod-wpq1193.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'de5c0c05-ad5f-474d-d4bd-08d9af4d606e', N'Водяной насос (пр-во magneti marelli кор.код. wpq1183) 352316171183 Magneti Marelli', CAST(681.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/034/542/203289_460x330.jpg', N'Производитель: $Magneti Marelli
Каталожный номер: $352316171183
Число зубцов: $20
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'27b05c43-0595-4131-3527-08d9af4d5c95', N'https://autocompass.com.ua/34542-vodyanoy-nasos-pr-vo-magneti-marelli-kor-kod-wpq1183.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'ac3d872f-c570-44c5-d4be-08d9af4d606e', N'Водяной насос (пр-во magneti marelli кор.код. wpq1181) 352316171181 Magneti Marelli', CAST(751.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/034/543/203290_460x330.jpg', N'Производитель: $Magneti Marelli
Каталожный номер: $352316171181
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'27b05c43-0595-4131-3527-08d9af4d5c95', N'https://autocompass.com.ua/34543-vodyanoy-nasos-pr-vo-magneti-marelli-kor-kod-wpq1181.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'641ee0d9-8777-4c28-d4bf-08d9af4d606e', N'Генератор CARGO 112729 Cargo', CAST(3117.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/001/891/075/909527_460x330.jpg', N'Производитель: $Cargo
Каталожный номер: $112729
Напряжение [В]: $14
Ток зарядки от генератора (А): $90
Ременной шкив: $со ременным шкивом
Модель генератора: $искл. вакуумный насос
Диаметр [мм]: $75.5
Количество канавок: $1
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'bd86540e-6675-4e27-3528-08d9af4d5c95', N'https://autocompass.com.ua/1891075-generator-cargo-112729.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'83b34e3d-8e47-4af8-d4c0-08d9af4d606e', N'Генератор CARGO 112750 Cargo', CAST(4546.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/001/891/076/909424_460x330.jpg', N'Производитель: $Cargo
Каталожный номер: $112750
Напряжение [В]: $14
Ток зарядки от генератора (А): $90
Ременной шкив: $со ременным шкивом
Модель генератора: $искл. вакуумный насос
Диаметр [мм]: $67
Количество канавок: $1
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'bd86540e-6675-4e27-3528-08d9af4d5c95', N'https://autocompass.com.ua/1891076-generator-cargo-112750.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'0edec967-c4a2-48e3-d4c1-08d9af4d606e', N'Генератор 80, 90, 100, A4, A6, Passat, 1.3-4.2 73-05 89213064 POWERMAX', CAST(3654.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/002/069/955/2069955_460x330.jpg', N'Производитель: $POWERMAX
Каталожный номер: $89213064
Расстояние от ременного шкива до генератора [мм]: $32
Диапазон разброса [мм]: $82
Напряжение заряда [В]: $14
Ток зарядки от генератора (А): $115
&empty; шкива [мм]: $68.5
Напряжение [В]: $14
Ременной шкив: $с клиноременным шкифом реберным
Количество канавок: $1
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'bd86540e-6675-4e27-3528-08d9af4d5c95', N'https://autocompass.com.ua/2069955-generator-80-90-100-a4-a6-passat-1-3-4-2-73-05.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'c6e29f73-0ce4-4ded-d4c2-08d9af4d606e', N'Генератор 112806 Cargo', CAST(5133.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/002/580/939/1159272_460x330.jpg', N'Производитель: $Cargo
Каталожный номер: $112806
Напряжение [В]: $14
Ток зарядки от генератора (А): $120
Ременной шкив: $с многоручейковым ручейковым шкивом
Модель генератора: $искл. вакуумный насос
Диаметр [мм]: $64.2
Количество канавок: $6
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'bd86540e-6675-4e27-3528-08d9af4d5c95', N'https://autocompass.com.ua/2580939-generator.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'5c7b4242-0c8e-4e3d-d4c3-08d9af4d606e', N'Генератор 113758 Cargo', CAST(2928.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/002/024/693/930723_460x330.jpg', N'Производитель: $Cargo
Каталожный номер: $113758
Напряжение [В]: $14
Ток зарядки от генератора (А): $120
Ременной шкив: $с многоручейковым ручейковым шкивом
Модель генератора: $искл. вакуумный насос
Диаметр [мм]: $64.5
Количество канавок: $6
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'bd86540e-6675-4e27-3528-08d9af4d5c95', N'https://autocompass.com.ua/2024693-generator.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'54afe0d0-ca99-4755-d4c4-08d9af4d606e', N'Генератор 210339A ERA', CAST(2887.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/apps/autocompass//templates/img/no_photo.png', N'Производитель: $ERA
Каталожный номер: $210339A
Напряжение [В]: $14
Ток зарядки от генератора (А): $65
Идентификационный номер исполнения штекерного разъема: $B+D+W
&empty; шкива [мм]: $65
Направление вращения: $по часовой стрелке
Ремень: $без клинового ремня
Количество крепежных отверстий: $3
Количество канавок: $1
Расстояние от ременного шкива до генератора [мм]: $110
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'bd86540e-6675-4e27-3528-08d9af4d5c95', N'https://autocompass.com.ua/2833992-generator.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'eecfb08f-aac8-45bd-d4c5-08d9af4d606e', N'Генератор, 65A, Audi 80, 100, VW Golf1,2, Passat B2 1,6-1,8-2,0i T4 2,0i, LT 2,4D, TD CMA298IR MSG', CAST(2488.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/002/142/286/2142286_460x330.jpg', N'Производитель: $MSG
Каталожный номер: $CMA298IR
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'bd86540e-6675-4e27-3528-08d9af4d5c95', N'https://autocompass.com.ua/2142286-generator-65a-audi-80-100-vw-golf1-2-passat-b2-1-6-1-8-2-0i-t4-2-0i-lt-2-4d-td.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'9cff1914-0da7-48ef-d4c6-08d9af4d606e', N'Генератор, 90A, Audi 100, 80, 200, 90, VW Caddy, Passat, T III, T IV -92 CMA320IR MSG', CAST(2646.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/001/445/750/1445750_460x330.jpg', N'Производитель: $MSG
Каталожный номер: $CMA320IR
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'bd86540e-6675-4e27-3528-08d9af4d5c95', N'https://autocompass.com.ua/1445750-generator-90a-audi-100-80-200-90-vw-caddy-passat-t-iii-t-iv-92.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'aa6cd6bf-a7bd-4d92-d4c7-08d9af4d606e', N'Генератор 28-0944 ELSTOCK', CAST(4399.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/001/850/727/903680_460x330.jpg', N'Производитель: $ELSTOCK
Каталожный номер: $28-0944
Модель бортовой сети: $для транспортного средства с 12В бортовой сетью
Напряжение [В]: $14
Ток зарядки от генератора (А): $65
Количество ребер: $1
&empty; шкива [мм]: $66
Идентификационный номер исполнения штекерного разъема: $M8 B+ M5 D+
Длина 2 [мм]: $74
Длина 1 [мм]: $54
&empty; отверстия 1 [мм]: $8
Толщина 1 [мм]: $56
Вес нетто [кг]: $5.1
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'bd86540e-6675-4e27-3528-08d9af4d5c95', N'https://autocompass.com.ua/1850727-generator.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'7e4f9b5b-6563-49eb-d4c8-08d9af4d606e', N'Генератор 28-1817 ELSTOCK', CAST(5114.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/002/834/469/1191863_460x330.jpg', N'Производитель: $ELSTOCK
Каталожный номер: $28-1817
Модель бортовой сети: $для транспортного средства с 12В бортовой сетью
Напряжение [В]: $14
Ток зарядки от генератора (А): $120
Количество ребер: $6
&empty; шкива [мм]: $63
Клемма: $M8 B+
Идентификационный номер исполнения штекерного разъема: $M5 D+
Длина 2 [мм]: $45
Длина 1 [мм]: $31
&empty; отверстия 1 [мм]: $10
Длина 3 [мм]: $82
Толщина 1 [мм]: $14
Вес нетто [кг]: $7.2
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'bd86540e-6675-4e27-3528-08d9af4d5c95', N'https://autocompass.com.ua/2834469-generator.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'8cddeeba-4c71-4ea5-d4c9-08d9af4d606e', N'Колодки гальмівні барабанні (вир-во lpr) 00140 LPR', CAST(261.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/008/006/195628_460x330.jpg', N'Производитель: $LPR
Каталожный номер: $00140
Сторона установки: $Задние
Диаметр [мм]: $180
Дополнительный артикул / дополнительная информация 2: $с рычагом ручного стояночного тормоза
Тормозная система: $ATE
Ширина (мм): $31
Для артикула №: $00140
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'3c0ce9ad-9f9f-4649-3529-08d9af4d5c95', N'https://autocompass.com.ua/8006-kolodki-galm-vn-barabann-vir-vo-lpr.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'36e25886-c1d0-4f95-d4ca-08d9af4d606e', N'Колодки гальмівні барабанні 4046.00 REMSA', CAST(443.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/043/399/205916_460x330.jpg', N'Производитель: $REMSA
Каталожный номер: $4046.00
Сторона установки: $Задние
Проверочное значение: $E9-90R-01701/004
Диаметр [мм]: $200
Ширина (мм): $40
Дополнительный артикул / Дополнительная информация: $с рычагом
Тормозная система: $Ate-Teves
Вес [кг]: $1.55
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'3c0ce9ad-9f9f-4649-3529-08d9af4d5c95', N'https://autocompass.com.ua/43399-kolodki-galm-vn-barabann.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'c51230e7-c2fb-440d-d4cb-08d9af4d606e', N'Тормозные колодки Audi 100 задние 5000-0222 PROFIT', CAST(289.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/705/657/569118_460x330.jpg', N'Производитель: $PROFIT
Каталожный номер: $5000-0222
Сторона установки: $Задние
Толщина [мм]: $16.5
Длина [мм]: $88
Высота [мм]: $68
Тормозная система: $TRW
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'3c0ce9ad-9f9f-4649-3529-08d9af4d5c95', N'https://autocompass.com.ua/705657-tormoznye-kolodki-audi-100-zadnie.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'b573c0a2-2d44-495a-d4cc-08d9af4d606e', N'Гальмівні колодки 66981101201 VIKA', CAST(353.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/871/166/739480_460x330.jpg', N'Производитель: $VIKA
Каталожный номер: $66981101201
Толщина [мм]: $15.8
Ширина (мм): $87.1
Высота [мм]: $66.8
Дополнительный артикул / дополнительная информация 2: $с инструкцией по сборке
Датчик износа: $без датчика износа
Материал: $Low-Metallic
Сторона установки: $Задний мост
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'3c0ce9ad-9f9f-4649-3529-08d9af4d5c95', N'https://autocompass.com.ua/871166-galm-vn-kolodki.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'632dad99-8060-4853-d4cd-08d9af4d606e', N'Тормозные колодки перед Caddy II >9.96, Passat B4, Audi 80 RM1082 GOODREM', CAST(372.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/836/387/1022316_460x330.jpg', N'Производитель: $GOODREM
Каталожный номер: $RM1082
Сторона установки: $Передние
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'3c0ce9ad-9f9f-4649-3529-08d9af4d5c95', N'https://autocompass.com.ua/836387-tormoznye-kolodki-pered-caddy-ii-9-96-passat-b4-audi-80.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'7543b577-e615-4653-d4ce-08d9af4d606e', N'Колодки гальмівні дискові передние 05P453 LPR', CAST(505.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/002/187/193283_460x330.jpg', N'Производитель: $LPR
Каталожный номер: $05P453
Сторона установки: $Передние
Для артикула №: $05P453
Толщина [мм]: $20.3
Тормозная система: $ATE
Длина предупреждающего контакта [мм]: $200
Количество датчиков износа [на ось]: $2
Ширина (мм): $156.4
Высота [мм]: $74.2
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'3c0ce9ad-9f9f-4649-3529-08d9af4d5c95', N'https://autocompass.com.ua/2187-kolodki-galm-vn-diskov-peredn.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'1706acd3-a0f4-4fa0-d4cf-08d9af4d606e', N'Тормозные колодки дисковые 05P440 LPR', CAST(310.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/004/511/194388_460x330.jpg', N'Производитель: $LPR
Каталожный номер: $05P440
Сторона установки: $Задние
Тормозная система: $TRW
Толщина [мм]: $16.5
Ширина (мм): $87
Высота [мм]: $66.8
Для артикула №: $05P440
Дополнительный артикул / дополнительная информация 2: $с винтами
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'3c0ce9ad-9f9f-4649-3529-08d9af4d5c95', N'https://autocompass.com.ua/4511-tormoznye-kolodki-diskovye.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'0355dadc-ea60-4203-d4d0-08d9af4d606e', N'Комплект гальмівних колодок 05P216 LPR', CAST(370.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/004/795/194513_460x330.jpg', N'Производитель: $LPR
Каталожный номер: $05P216
Сторона установки: $Передние
Для артикула №: $05P216
Тормозная система: $TRW
Ширина (мм): $119.3
Толщина [мм]: $19.4
Высота [мм]: $69.6
Дополнительный артикул / дополнительная информация 2: $с винтами
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'3c0ce9ad-9f9f-4649-3529-08d9af4d5c95', N'https://autocompass.com.ua/4795-komplekt-galm-vnih-kolodok.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'9a3328f2-7d2a-403b-d4d1-08d9af4d606e', N'Тормозные колодки барабанные 0 986 487 281 BOSCH 0986487281 Bosch', CAST(575.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/008/510/3805_460x330.jpg', N'Производитель: $Bosch
Каталожный номер: $0986487281
Сторона установки: $Задние
Диаметр 1 [мм]: $230
Тормозная колодка: $с накладками
Ширина 1 [мм]: $40
Диаметр [мм]: $230
Ширина (мм): $40
Ширина поверхности трения [мм]: $40
Внутрен. диаметр торм.барабан [мм]: $230
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'3c0ce9ad-9f9f-4649-3529-08d9af4d5c95', N'https://autocompass.com.ua/8510-tormoznye-kolodki-barabannye-bosch-0-986-487-281-bosch.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'a610c429-fee9-416e-d4d2-08d9af4d606e', N'Колодки гальмівні барабанні (вир-во lpr) 06830 LPR', CAST(380.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/015/076/197944_460x330.jpg', N'Производитель: $LPR
Каталожный номер: $06830
Сторона установки: $Задние
Дополнительный артикул / дополнительная информация 2: $с рычагом ручного стояночного тормоза
Диаметр [мм]: $200
Ширина (мм): $40
Для артикула №: $06830
Тормозная система: $VAG
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'3c0ce9ad-9f9f-4649-3529-08d9af4d5c95', N'https://autocompass.com.ua/15076-kolodki-galm-vn-barabann-vir-vo-lpr.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'1c6ecb41-941d-48f0-d4d3-08d9af4d606e', N'Щетка стеклоочистителя DUR-045L Denso', CAST(368.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/058/119/511347_460x330.jpg', N'Производитель: $Denso
Каталожный номер: $DUR-045L
Длина [мм]: $450
Длина [дюйм]: $18
Вес [г]: $247
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'ac3b1d09-ab0e-44b6-352a-08d9af4d5c95', N'https://autocompass.com.ua/58119-schetka-stekloochistitelya-denso-dur-045l-denso.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'97e8c587-bdcf-41da-d4d4-08d9af4d606e', N'Щетка стеклоочистителя (550 мм) TWIN BOSCH 3 397 004 585 Bosch', CAST(255.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/023/029/9878_460x330.jpg', N'Производитель: $Bosch
Каталожный номер: $3 397 004 585
Длина [мм]: $550
Дизайн щетки стеклоочистителя: $Изогнутая щетка стеклоочистителя без спойлера
Длина 1 [мм]: $550
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'ac3b1d09-ab0e-44b6-352a-08d9af4d5c95', N'https://autocompass.com.ua/23029-schetka-stekloochistitelya-550-mm-twin-3-397-004-585-bosch.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'f0d92c12-d295-454c-d4d5-08d9af4d606e', N'Щетка стеклоочистителя First 55 (блистер 1шт) VALEO 575555 Valeo', CAST(116.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/016/078/7137_460x330.jpg', N'Производитель: $Valeo
Каталожный номер: $575555
Количество: $1
Длина [мм]: $550
Длина [дюйм]: $22
Подходящий адаптер: $U
Тип контейнера: $блистерная упаковка
Вес [кг]: $0.17
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'ac3b1d09-ab0e-44b6-352a-08d9af4d5c95', N'https://autocompass.com.ua/16078-schetka-stekloochistitelya-first-55-blister-1sht-valeo-575555-valeo.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'cb70530d-72cc-48a5-d4d6-08d9af4d606e', N'Щетка стеклоочистителя DM-555 Denso', CAST(258.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/067/524/42840_460x330.jpg', N'Производитель: $Denso
Каталожный номер: $DM-555
Длина [мм]: $550
Длина [дюйм]: $22
Вес [г]: $207
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'ac3b1d09-ab0e-44b6-352a-08d9af4d5c95', N'https://autocompass.com.ua/67524-schetka-stekloochistitelya-denso-dm-555-denso.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'c57750f1-ced1-4b2d-d4d7-08d9af4d606e', N'Щетка стеклоочистителя DM-045 Denso', CAST(209.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/067/532/511372_460x330.jpg', N'Производитель: $Denso
Каталожный номер: $DM-045
Длина [мм]: $450
Длина [дюйм]: $18
Вес [г]: $146
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'ac3b1d09-ab0e-44b6-352a-08d9af4d5c95', N'https://autocompass.com.ua/67532-schetka-stekloochistitelya-denso-dm-045-denso.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'2f74e0ca-b4fd-4f00-d4d8-08d9af4d606e', N'Щетка стеклоочистителя 450 мм каркасная airline AWB-K-450 AirLine (СПб- РФ)', CAST(41.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/481/021/720031_460x330.jpg', N'Производитель: $AirLine (СПб- РФ)
Каталожный номер: $AWB-K-450
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'ac3b1d09-ab0e-44b6-352a-08d9af4d5c95', N'https://autocompass.com.ua/481021-schetka-stekloochistitelya-450-mm-karkasnaya-airline.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'7924b16b-1719-4c03-d4d9-08d9af4d606e', N'Щетки стеклоочистителя (2х530) LADA 2108, 2111; AUDI 100, 80, A4; RENAULT; VW; VOLVO 3397118401 Bosch', CAST(553.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/007/575/3307_460x330.jpg', N'Производитель: $Bosch
Каталожный номер: $3397118401
Количественная единица: $комплект
Оформление: $со спойлером
Длина 1 [мм]: $530
Длина 2 [мм]: $530
Дизайн щетки стеклоочистителя: $Изгнутая щетка стеклоочистителя со спойлером
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'ac3b1d09-ab0e-44b6-352a-08d9af4d5c95', N'https://autocompass.com.ua/7575-schetki-stekloochistitelya-2h530-lada-2108-2111-audi-100-80-a4-renault-vw-volvo.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'65784c3c-962d-4b6c-d4da-08d9af4d606e', N'К-т стеклоочистителя (530, 530 мм) TWIN 3 397 118 400 BOSCH 3397118400 Bosch', CAST(430.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/007/595/3312_460x330.jpg', N'Производитель: $Bosch
Каталожный номер: $3397118400
Сторона установки: $спереди
Количественная единица: $комплект
Длина 1 [мм]: $530
Длина 2 [мм]: $530
Дизайн щетки стеклоочистителя: $Изогнутая щетка стеклоочистителя без спойлера
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'ac3b1d09-ab0e-44b6-352a-08d9af4d5c95', N'https://autocompass.com.ua/7595-k-t-stekloochistitelya-530-530-mm-twin-3-397-118-400-bosch.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'758926e6-2cb8-4f23-d4db-08d9af4d606e', N'Щетки стеклоочистителя (2х550) AUDI 100, A6, CITROEN; FORD; FIAT; RENAULT 3397118421 Bosch', CAST(426.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/010/664/4613_460x330.jpg', N'Производитель: $Bosch
Каталожный номер: $3397118421
Количественная единица: $комплект
Оформление: $со спойлером
Длина 1 [мм]: $550
Длина 2 [мм]: $550
Дизайн щетки стеклоочистителя: $Изгнутая щетка стеклоочистителя со спойлером
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'ac3b1d09-ab0e-44b6-352a-08d9af4d5c95', N'https://autocompass.com.ua/10664-schetki-stekloochistitelya-2h550-audi-100-a6-citroen-ford-fiat-renault.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'71324cee-d554-4832-d4dc-08d9af4d606e', N'К-т стеклоочистителя (550, 530 мм) AEROTWIN RETRO 3 397 118 906 BOSCH 3397118906 Bosch', CAST(621.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/013/349/5720_460x330.jpg', N'Производитель: $Bosch
Каталожный номер: $3397118906
Сторона установки: $спереди
Количественная единица: $комплект
Длина 1 [мм]: $550
Длина 2 [мм]: $530
Дизайн щетки стеклоочистителя: $Прямая щетка стеклоочистителя
Автомобиль с лево- / правосторонним расположением руля: $для левостороннего расположения руля
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'ac3b1d09-ab0e-44b6-352a-08d9af4d5c95', N'https://autocompass.com.ua/13349-k-t-stekloochistitelya-550-530-mm-aerotwin-retro-3-397-118-906-bosch.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'5a4df8ca-139a-4c33-d4dd-08d9af4d606e', N'Электро-бензонасос AUDI; BMW; PEUGEOT; VOLVO; VW (5 bar, L=180mm) 0580464126 Bosch', CAST(1907.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/015/168/6630_460x330.jpg', N'Производитель: $Bosch
Каталожный номер: $0580464126
Сторона установки: $Топливопровод
Дополнительный артикул / дополнительная информация 2: $без соединительных деталей
Вид эксплуатации: $электрический
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'9054cc56-d512-4b30-352b-08d9af4d5c95', N'https://autocompass.com.ua/15168-elektro-benzonasos-audi-bmw-peugeot-volvo-vw-5-bar-l-180mm.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'612e346e-8d50-421d-d4de-08d9af4d606e', N'Паливний насос (ви-во magneti marelli кор.код. mam00010) 313011300010 Magneti Marelli', CAST(706.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/046/065/206879_460x330.jpg', N'Производитель: $Magneti Marelli
Каталожный номер: $313011300010
Производительность [л/ч]: $120
Вид эксплуатации: $электрический
Рабочее давление [бар]: $4
Входное напряжение [В]: $12
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'9054cc56-d512-4b30-352b-08d9af4d5c95', N'https://autocompass.com.ua/46065-palivniy-nasos-vi-vo-magneti-marelli-kor-kod-mam00010.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'0aa19a19-da85-4307-d4df-08d9af4d606e', N'Насос паливний електричний (карб) AUDI, BMW, CITROEN, DAIHATSU, FIAT, FORD, HONDA, HYUNDAI, LADA 7.21440.51.0 Pierburg', CAST(1668.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/460/219/321949_460x330.jpg', N'Производитель: $Pierburg
Каталожный номер: $7.21440.51.0
Вид эксплуатации: $электрический
Диаметр [мм]: $38
Длина [мм]: $133.5
Диаметр 1 [мм]: $8
Диаметр 2 (мм): $8
Сила тока до [А]: $2
Количество присоединений: $2
Давление (бар) от: $0.27
Давление (бар) до: $0.38
Давление [пси] до: $5.51
Напряжение [В]: $12
Давление [пси] от: $3.19
Номер технической информации: $PI 0034 SI 0058 SI 0080 SI 0097 SI 1064
Общая длина [мм]: $133.5
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'9054cc56-d512-4b30-352b-08d9af4d5c95', N'https://autocompass.com.ua/460219-nasos-palivniy-elektrichniy-karb-audi-bmw-citroen-daihatsu-fiat-ford-honda-hyundai-lada.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'1f75fff3-464f-4827-d4e0-08d9af4d606e', N'Насос топливный электрический 0 580 464 125 BOSCH 0580464125 Bosch', CAST(2226.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/014/164/6208_460x330.jpg', N'Производитель: $Bosch
Каталожный номер: $0580464125
Сторона установки: $Топливопровод
Дополнительный артикул / дополнительная информация 2: $с соединительными деталями
Вид эксплуатации: $электрический
Подача топлива: $Сенсор уровня топлива в дополнительном баке
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'9054cc56-d512-4b30-352b-08d9af4d5c95', N'https://autocompass.com.ua/14164-nasos-toplivnyy-elektricheskiy-0-580-464-125-bosch.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'7ef79ff0-8b22-47c7-d4e1-08d9af4d606e', N'Електробензонасос audi 80,100,a4,a6 2.0e,2.6,2.8 -97 (вир-во bosch) 0 580 314 068 Bosch', CAST(1929.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/040/821/15996_460x330.jpg', N'Производитель: $Bosch
Каталожный номер: $0 580 314 068
Сторона установки: $в топливном баке
Дополнительный артикул / Дополнительная информация: $с дополнительными материалами
Вид эксплуатации: $электрический
Дополнительный артикул / дополнительная информация 2: $с соединительными деталями
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'9054cc56-d512-4b30-352b-08d9af4d5c95', N'https://autocompass.com.ua/40821-elektrobenzonasos-audi-80-100-a4-a6-2-0e-2-6-2-8-97-vir-vo-bosch.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'b87b665a-62ee-4635-d4e2-08d9af4d606e', N'Топливный насос 100 127 0003 MEYLE', CAST(520.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/116/178/225405_460x330.jpg', N'Производитель: $MEYLE
Каталожный номер: $100 127 0003
Напряжение [В]: $12
Вид топлива: $бензин
Вид эксплуатации: $механический
Дополнительный артикул / Дополнительная информация: $с прокладкой
Количество полюсов: $1
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'9054cc56-d512-4b30-352b-08d9af4d5c95', N'https://autocompass.com.ua/116178-toplivnyy-nasos-100-127-0003-meyle.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'a87b8815-d5d6-4b61-d4e3-08d9af4d606e', N'Электро-бензонасос AUDI 80, 90 -91; VW (6.5 bar, L=180mm) 0580254921 Bosch', CAST(3638.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/022/611/9671_460x330.jpg', N'Производитель: $Bosch
Каталожный номер: $0580254921
Сторона установки: $Топливопровод
Дополнительный артикул / дополнительная информация 2: $без соединительных деталей
Вид эксплуатации: $электрический
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'9054cc56-d512-4b30-352b-08d9af4d5c95', N'https://autocompass.com.ua/22611-elektro-benzonasos-audi-80-90-91-vw-6-5-bar-l-180mm.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'9de62456-5316-4268-d4e4-08d9af4d606e', N'Топливный насос, подвесной (12V 0,10 bar 95 l, h) 76041 MEAT&DORIA', CAST(556.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/038/751/204462_460x330.jpg', N'Производитель: $MEAT&DORIA
Каталожный номер: $76041
Вид эксплуатации: $электрический
Рабочее давление [бар]: $0.1
Производительность [л/ч]: $95
Напряжение [В]: $12
Подготовка топлива: $карбюратор
Внутренний диаметр: $8
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'9054cc56-d512-4b30-352b-08d9af4d5c95', N'https://autocompass.com.ua/38751-toplivnyy-nasos-podvesnoy-12v-0-10-bar-95-l-h.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'82d22550-f08f-45da-d4e5-08d9af4d606e', N'Паливний насос (вир-во era) 770102A ERA', CAST(1201.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/322/224/322224_460x330.jpg', N'Производитель: $ERA
Каталожный номер: $770102A
Вес [кг]: $1.08
Давление [бар]: $6.5
Вид эксплуатации: $электрический
Количество присоединений: $2
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'9054cc56-d512-4b30-352b-08d9af4d5c95', N'https://autocompass.com.ua/322224-palivniy-nasos-vir-vo-era.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
INSERT [dbo].[Spares] ([Id], [Name], [Price], [ImageUrl], [Description], [ModelId], [CategoryId], [Url], [ProviderId]) VALUES (N'bf846ede-2cbb-4853-d4e6-08d9af4d606e', N'Паливний насос (вир-во era) 770090A ERA', CAST(798.0000 AS Decimal(18, 4)), N'https://autocompass.com.ua/imgs/000/322/225/322225_460x330.jpg', N'Производитель: $ERA
Каталожный номер: $770090A
Вес [кг]: $0.395
Давление [бар]: $4
Вид эксплуатации: $электрический
Количество присоединений: $2
Производительность [л/ч]: $110
Версия: $Bosch
', N'7e761884-e744-4b0f-3252-08d9af4d5c8e', N'9054cc56-d512-4b30-352b-08d9af4d5c95', N'https://autocompass.com.ua/322225-palivniy-nasos-vir-vo-era.html', N'144f1f90-8779-4267-2975-08d9af4d5b17')
GO
