﻿CREATE TABLE [dbo].[Doctors] (
    [DoctorId] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](max),
    [Surname] [nvarchar](max),
    [DateOfBirth] [datetime] NOT NULL,
    [PESEL] [nvarchar](max),
    [Mobile] [nvarchar](max),
    [Adress] [nvarchar](max),
    [PostalCode] [nvarchar](max),
    [Medicine_MedicineId] [int],
    CONSTRAINT [PK_dbo.Doctors] PRIMARY KEY ([DoctorId])
)
CREATE INDEX [IX_Medicine_MedicineId] ON [dbo].[Doctors]([Medicine_MedicineId])
CREATE TABLE [dbo].[Medicines] (
    [MedicineId] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](max),
    [Category] [nvarchar](max),
    [Producent] [nvarchar](max),
    [ExpiredDate] [datetime] NOT NULL,
    [PriceOfSell] [float] NOT NULL,
    [QuantityInPackage] [int] NOT NULL,
    [QuantityOfPackages] [int] NOT NULL,
    [IsRefunded] [bit] NOT NULL,
    [PercentageOfRefunding] [float],
    [PriceAfterRefunding] [float],
    [ActiveSubstance] [nvarchar](max),
    [IsAntibiotique] [bit] NOT NULL,
    [IsOnReciept] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.Medicines] PRIMARY KEY ([MedicineId])
)
CREATE TABLE [dbo].[Deliveries] (
    [DeliveryId] [int] NOT NULL IDENTITY,
    [DateOfDelivery] [date] NOT NULL,
    [DateOfCreate] [datetime] NOT NULL,
    [PharmaceutOrdering] [int] NOT NULL,
    [Value] [float] NOT NULL,
    CONSTRAINT [PK_dbo.Deliveries] PRIMARY KEY ([DeliveryId])
)
CREATE TABLE [dbo].[Reciepts] (
    [RecieptId] [int] NOT NULL IDENTITY,
    [DateOfRegistry] [datetime] NOT NULL,
    [DateOfExpire] [datetime] NOT NULL,
    [DoctorId] [int] NOT NULL,
    [PatientId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Reciepts] PRIMARY KEY ([RecieptId])
)
CREATE INDEX [IX_DoctorId] ON [dbo].[Reciepts]([DoctorId])
CREATE INDEX [IX_PatientId] ON [dbo].[Reciepts]([PatientId])
CREATE TABLE [dbo].[Patients] (
    [PatientId] [int] NOT NULL IDENTITY,
    [Comment] [nvarchar](max),
    [PharmaceutId] [int],
    [Name] [nvarchar](20) NOT NULL,
    [Surname] [nvarchar](20) NOT NULL,
    [DateOfBirth] [date] NOT NULL,
    [PESEL] [nvarchar](max),
    [Mobile] [nvarchar](15),
    [Adress] [nvarchar](100),
    [PostalCode] [nvarchar](max),
    CONSTRAINT [PK_dbo.Patients] PRIMARY KEY ([PatientId])
)
CREATE INDEX [IX_PharmaceutId] ON [dbo].[Patients]([PharmaceutId])
CREATE TABLE [dbo].[Pharmaceuts] (
    [PharmaceutId] [int] NOT NULL IDENTITY,
    [DateOfHire] [date] NOT NULL,
    [Name] [nvarchar](20) NOT NULL,
    [Surname] [nvarchar](20) NOT NULL,
    [DateOfBirth] [date] NOT NULL,
    [PESEL] [nvarchar](max),
    [Mobile] [nvarchar](15),
    [Adress] [nvarchar](100),
    [PostalCode] [nvarchar](max),
    CONSTRAINT [PK_dbo.Pharmaceuts] PRIMARY KEY ([PharmaceutId])
)
CREATE TABLE [dbo].[MedicineDeliveries] (
    [MedicineId] [int] NOT NULL,
    [DeliveryId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.MedicineDeliveries] PRIMARY KEY ([MedicineId], [DeliveryId])
)
CREATE INDEX [IX_MedicineId] ON [dbo].[MedicineDeliveries]([MedicineId])
CREATE INDEX [IX_DeliveryId] ON [dbo].[MedicineDeliveries]([DeliveryId])
CREATE TABLE [dbo].[RecieptMedicines] (
    [Reciept_RecieptId] [int] NOT NULL,
    [Medicine_MedicineId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.RecieptMedicines] PRIMARY KEY ([Reciept_RecieptId], [Medicine_MedicineId])
)
CREATE INDEX [IX_Reciept_RecieptId] ON [dbo].[RecieptMedicines]([Reciept_RecieptId])
CREATE INDEX [IX_Medicine_MedicineId] ON [dbo].[RecieptMedicines]([Medicine_MedicineId])
ALTER TABLE [dbo].[Doctors] ADD CONSTRAINT [FK_dbo.Doctors_dbo.Medicines_Medicine_MedicineId] FOREIGN KEY ([Medicine_MedicineId]) REFERENCES [dbo].[Medicines] ([MedicineId])
ALTER TABLE [dbo].[Reciepts] ADD CONSTRAINT [FK_dbo.Reciepts_dbo.Doctors_DoctorId] FOREIGN KEY ([DoctorId]) REFERENCES [dbo].[Doctors] ([DoctorId]) ON DELETE CASCADE
ALTER TABLE [dbo].[Reciepts] ADD CONSTRAINT [FK_dbo.Reciepts_dbo.Patients_PatientId] FOREIGN KEY ([PatientId]) REFERENCES [dbo].[Patients] ([PatientId]) ON DELETE CASCADE
ALTER TABLE [dbo].[Patients] ADD CONSTRAINT [FK_dbo.Patients_dbo.Pharmaceuts_PharmaceutId] FOREIGN KEY ([PharmaceutId]) REFERENCES [dbo].[Pharmaceuts] ([PharmaceutId])
ALTER TABLE [dbo].[MedicineDeliveries] ADD CONSTRAINT [FK_dbo.MedicineDeliveries_dbo.Medicines_MedicineId] FOREIGN KEY ([MedicineId]) REFERENCES [dbo].[Medicines] ([MedicineId]) ON DELETE CASCADE
ALTER TABLE [dbo].[MedicineDeliveries] ADD CONSTRAINT [FK_dbo.MedicineDeliveries_dbo.Deliveries_DeliveryId] FOREIGN KEY ([DeliveryId]) REFERENCES [dbo].[Deliveries] ([DeliveryId]) ON DELETE CASCADE
ALTER TABLE [dbo].[RecieptMedicines] ADD CONSTRAINT [FK_dbo.RecieptMedicines_dbo.Reciepts_Reciept_RecieptId] FOREIGN KEY ([Reciept_RecieptId]) REFERENCES [dbo].[Reciepts] ([RecieptId]) ON DELETE CASCADE
ALTER TABLE [dbo].[RecieptMedicines] ADD CONSTRAINT [FK_dbo.RecieptMedicines_dbo.Medicines_Medicine_MedicineId] FOREIGN KEY ([Medicine_MedicineId]) REFERENCES [dbo].[Medicines] ([MedicineId]) ON DELETE CASCADE
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'202405221651311_SetProperties', N'Obsługa_Apteki.Migrations.Configuration',  0x1F8B0800000000000400ED1D5D6FE3B8F1BD40FF83A0A7B6D88B932C0AB4817D87AC93ED19B759A771F6D0B7809668475859F2E9234850DC4BFF561FFAD4DFD3BF50EA8BE2B74889B2738B6081C55A2487C3E1CC7066C899FDDFBFFF33FDE179173A4F304983389AB96727A7AE03232FF683683B73F36CF3DD5FDC1FBEFFFDEFA6D7FEEED9F9B9E9F7BEE8874646E9CC7DCCB2FDC564927A8F7007D2935DE025711A6FB2132FDE4D801F4FCE4F4FFF3A393B9B4004C245B01C677A974759B083E50FF4731E471EDC6739086F621F8669FD1DB5AC4AA8CE67B083E91E7870E62ED7E97FFF956FC1C3E53E835F83936B04290B60EA3A976100103E2B186E5C0744519C810C617BF12585AB2C89A3ED6A8F3E80F0FE650F51BF0D085358AFE2A2EDAEBBA0D3F3624193766003CACBD32CDE19023C7B5F5368C20EEF4567175310D1B0A4D04BB1EA928E33F72AF6B238711D76AA8B799814DD78225723DE39CD77A7FAFE0E7304629CE2CF3B679E87599EC05904F32C01E13BE7365F8781F7137CB98FBFC26816E561486287F0436DD407F4E93689F730C95EEEE086C279E1BBCE841E3D6187E3C1DCC86A6D8B287B7FEE3A9F1122601D42CC08041D566800FC1B8C600232E8DF822C8309DAC7850F4B5272383033167F37B321CE43A2E43A37E0F9138CB6D9E3CC45FF749D8FC133F49B2F35065FA200491E1A942539EC9A649527D121E6B94224586E3E0449F6D8CC557CBA0F8AB93922AA61DD5EAFAE3F8D8EF14DBC0EC2F10973E927304D479FE6364E3310CE517FCB534D27AD6250AA8B1BE8075E10411385D18C39A6CA6870E8A334C8B1DF94DA9823D4B671F2323EDF26B19F7B68E5A3CF74FDBC0F12E8175A69B8864A020FA93B64438418568CD8D11CD2DF7350EEFA22BA05DE57B0855D8CA4076EB9A9C1A5C3E02D52242879E443CCE01FE23884203227194C8A6D46282D3715CC729B69E26950FD7283C4A527804B2F0B9EE02A5F235D894CC9D1596E915EA2DD58077116FC92C3A1145CA4CBE80E7A0132818D417D064FC1B6543FECB90D434492A4B48CEF605876491F837D65206305FD40F6FB98C4BBBB3824F41FD1FCB08AF3A4A46D2CEF730F922DCC0CB0AC4D512586751F1176659302B3AADD14AB7A33C494AB1B1F9A4928BA718D78EE0637BE47837DAFC3B9A6FD8B91355F8F39AA3D5FE3D0CBA227C61EEA70AECCE096DA03CF990ADC3C81560EAD4790EC90739C67CBC48709A13DFB9D0D3F83B0556ABAC79F54984A9CA04F888B1D75C40A964A65F5122DAC92F525AB1E724CC1AA51E82357C4D0C38AD51DDC0669664DAC2A83703830CDC0418770223A215A1883E9736436670B7F62D22DDC81C9349B9E976AD9363C3065B8F147AA2E7AF5160891ABDB1EEA593E213E24D11334738A47D46790E2C1F8EA2B9E7AC831150FC1E8A68A475B46EC299E79BCDB1DC2396DCF666E7583A201E7A75AC8192AABEEA0E238F37E8341C6B33F1F22C67876AAB71F478A312AB532960CB162C6CD0FB57AA0CE0D4133AF98057D448A59C315ACCE053BE7077BC0A9CE987EE70741598323048F3AEA2942E94BE38344AE6D4737627FB46173BE69FD37ADFF6D6B7DACCBEDE87C4E992ACE051D657A99A6B117948831CE0D199AA0177B1DF98E46D8B4223119ED4094466A34D823C5895099B97FE2E8A8068D0FBC16741BA152829E4E8885EAAEBFF22ABB11647CCCEE759F9E9C9C692D9D764FC965D71EAFAD45339EB40C33995BDD22868348FA3B2D71C63B577BE6B2C7EB3242EC0033E814F723C54B9439483DE0F3E28A84C1A7BFA0131926C5F15768882845677C1065FCF11D445EB007A112736694D1F38E02373C0BDB7205F7302ACE68E56E0C9D1ECFC290AC8B423DB8AD8D9074F186205C6285E704F716C66ACB60E122852F4351A9FD5B2449E3D748CB283D0A027E139CE9226E2F09522C52878F55D6B39128298861038F03C894C831936EBDCA4BEBDC7AAB7A578D94801FB585BD1F3FCA29A3C507B298A01933CA29311809EB9C589995684C8646C0A431E90B3F1ADCC334BB5A176DF059E49B7F4961ED9EA7B55DCD3247017B0533EAD84236726BCB321602A7ED680044489E03D16AFB0E20E4951D8F08B6473BA0B477EE1C0CCCE21D205A9F81038145B70B04565C4228C4D9C20022B881272F75AB49F4545C7EB28CAAE763E0E5505BCB71BD9E57410023F1675518BD7223AAD44CAAA288C0FED6F23A06508236BB492A34E2369804EC451D4F019503A2E3821068B792A558BEC4E91875F5C4C6C80920B18935ADE2BE64E0ED601D86EA410B61C883A746A7A1AC6D2A13EBA0949D82282ACB980487F11F4E1551545D40952E1B4FDBCAD35886B671A6C1730A923481296C41E0B6E9A4CA86A93F4C2792B499E90DD8EF83684BA4D1D45F9C55954333FF6E659E56B2AB604CBC54905D82B1C533215D01B690692DEE5D7DF83148901D0432B006452471EEEFB86E227B4972723733D22611BF75CD59DEF42FFE5DBF5092A4149D88956F4BCF8F6889C52D72B95AC8E94A7EA0536434811024D2A726F338CC77515754420EA9BA4020A1545FF421E0DB001208FEA80F878AEE53CB221BF4E1D5117E1252FD491F4613BF278134DFF4A134F179124AF3CD603D44F89D5A14F19D87369D30BCC779341CA7732E272D385A62A53A857B0816F62DCC454B3E54BAE9442E07B5F1D2FC1015B4E102D6A6609050DAAF062CD4E658501CD47ED68745655190D0A80613DC884C0A1A3BA2411F9E209F82842A6836874D2657888093EDFAD0C9540B122AF9DD80AEE2740B8AC2E22E867BC7E663707BC8763050A06CBA06A549D946134AD3691934B5E93613A8447A060D92687835AA5A1944E8630435119C1E669074A8D468209EF6533683345D40098D79B4CF5B21B2F05437D4E6ED3E0FB369319037C1037E4ADC04EDFAD0EBE7FC24C0FAD3ABE159EC2759E1D84626CD19563A52465BE2C93C495FE923FC6EBE6ADFC2F39CD5B699426D9EC4F3309B160388D69C1522324FB1BB3C607F340E55445D7A7068138E36E750E9489B34965AAECDA369CA706D3EF6D1771C5ACA8B4339C437B75705E3CDEDED2BF54484D48EE0B737483D645F31F870A246BE76E5F9FB47C3C3E44D705530DE04B74B70E938BA3868455DBF1A44A7A871B23894CCC7292E0B248128C1CD2D4F376BA1ACF2914903A71F92D2C716D67C383992EC55C9002EA82F5B8D38A01EA317E05792B3E35162AFFD7E1865E33B5E6F5A710A94C8CDE3C80FCAB75C8BB4C803C08FCE0D693098770437D5FAFE27394AE268CA82D982ED91DE716B6E90DA537D5078AC867C24BD423F2ECF77F30277F3CA76C16719BE81656E5AA7F5AD67771543EE1AB4EAE23A08F7A7C02FAE40572F69067727458793D52FE13CAC1E30351D6E40146C609A55E956EEF9E9D9395302F1F594239CA4A91F0A6E8DF99A84F4961DB8326050D0B733176C404657F404120F99DD7FD881E73F92907A14FC1B044B9079E5A34FD9E0CCAB4158D1D9558340D129548340F16952C31629526304FF718F4217910F9F67EE3FCBF117CEE21F0F0210EF9C32327CE19C3ABFAA31B251F60FA3F4EBF1EBF2BD6EA165CBED0DE344B6A4DE206882B279FD75005F366F13C620B35735AFDC666B35F3FA40E32BE6AD03732892BB5909CDF4B8425A3CAF173C492DBD41BC26AE97D7877E825A79DD606C54531BA6F3EC963B1B45E7892B9CF9A57AB050DDACBF6E915637EB23C5546D331D1D65A15CD830D6B159D06B44C6616B78F5DE6F510DAFFEC04426BE8689D58C93D955FD4A7FE9CE8E071A4C6FA1BAD4303EB559FF69143E654A3E0D33C5048546B4779718AB6FB7EB19A95CD58E61A5406C8195F89BAFCED7E46A79D8F03AF9D21D077440ED140D1AA819ACD7F419F11CFB913976ACF88E6F62F92696C3A230E26BC6A10117EBBECAF0A0D6409B4BE22CE9987C78E4185697F2C2C7C811505ED5C8375F794DA6E9483C881D0A0DE27200066DF26163A806DBAE553D4A787127C844D6AABD3252F1094EED8870D1AC35E5F4AC3DA1481232D471FAA526BA5E75F498FB00B54E74DF6C101B2CDC58D9867EC34C66B4D1EA172CE332997AEE8332995E1D381B95DFC8273B2695DE7E4B2A479A64DCEB2C3F103368D6C7D3DEBF91340C73537080824906BB69B3E6DD6FB2CA5D972164B07BE3F28F50A5716DA3F093C9FE2ADF70997294912AD47A45761416EB30835E83AD7D7C263BC6B1D787CD5ECFF9D7AF70A5A54295CD05CE11AA521EB80AA5344DCE7CD2D75972F288F5250F6F1B196DA795CA9126A7E76B2813C9574762774F54005251FFB17A563C73FD758C36BA8A67C90AB9B1C0DB438703DF36892690D747E3F0C7CE3DBF02DC245C83BC20213B07E6696E0ADC229A415ABA8B858FA596838F5B44F0A5D5D238F8C439C14F41340A6791977893EEB76253F82EAAFD37DF2405CB713D149B266740DD329DB8309C56B54E492A86D0CE14A49009148E2A48A64A42EB4880E9498CA6B29D1E31C4E91EC2D823995125ADC4F12A8861B154A9390FD06A9E4C401BBE448BA548B5D114DB217C7A94C5E5F1A541354A8E76CBB501F26A9F4F911B360611E412AD9BBE6585B10F4B86916BAD4A6AAB2A09C0180F54890F0B0B1EB18CAA0ECA23C8B94179543E190FD9EB7954BC23AD7E5DC134D8B6208AB4D3087A94A58EFB2CA24DDCF80C0C464D17EE923A033E32E32F932CD8002F43CD1E4CD3F2FD72F90A79E65EEFD6D05F44CB3CDBE7195A32DCAD43EAD82A1C0FD5FC650D581AE7E9725FFEAF4A369680D00C8A0741CBE8431E843EC6FBA3E0465C02A2F068EA375AC55E66C55BADED0B86F43966255B06A8261F76C4EEE16E1F2260E9325A8127D807B72F29FC04B7C07B69722AE540BA378226FBF42A00DB04ECD21A463B1EFD443CECEF9EBFFF3F3807803A7F8B0000 , N'6.4.4')

CREATE TABLE [dbo].[ExpiredDates] (
    [EpiredDateId] [int] NOT NULL IDENTITY,
    [DateofExpire] [datetime] NOT NULL,
    CONSTRAINT [PK_dbo.ExpiredDates] PRIMARY KEY ([EpiredDateId])
)
CREATE TABLE [dbo].[ExpiredDateDeliveries] (
    [ExpiredDate_EpiredDateId] [int] NOT NULL,
    [Delivery_DeliveryId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ExpiredDateDeliveries] PRIMARY KEY ([ExpiredDate_EpiredDateId], [Delivery_DeliveryId])
)
CREATE TABLE [dbo].[ExpiredDateMedicines] (
    [ExpiredDate_EpiredDateId] [int] NOT NULL,
    [Medicine_MedicineId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ExpiredDateMedicines] PRIMARY KEY ([ExpiredDate_EpiredDateId], [Medicine_MedicineId])
)
CREATE INDEX [IX_ExpiredDate_EpiredDateId] ON [dbo].[ExpiredDateDeliveries]([ExpiredDate_EpiredDateId])
CREATE INDEX [IX_Delivery_DeliveryId] ON [dbo].[ExpiredDateDeliveries]([Delivery_DeliveryId])
CREATE INDEX [IX_ExpiredDate_EpiredDateId] ON [dbo].[ExpiredDateMedicines]([ExpiredDate_EpiredDateId])
CREATE INDEX [IX_Medicine_MedicineId] ON [dbo].[ExpiredDateMedicines]([Medicine_MedicineId])
DECLARE @var0 nvarchar(128)
SELECT @var0 = name
FROM sys.default_constraints
WHERE parent_object_id = object_id(N'dbo.Medicines')
AND col_name(parent_object_id, parent_column_id) = 'ExpiredDate';
IF @var0 IS NOT NULL
    EXECUTE('ALTER TABLE [dbo].[Medicines] DROP CONSTRAINT [' + @var0 + ']')
ALTER TABLE [dbo].[Medicines] DROP COLUMN [ExpiredDate]
ALTER TABLE [dbo].[ExpiredDateDeliveries] ADD CONSTRAINT [FK_dbo.ExpiredDateDeliveries_dbo.ExpiredDates_ExpiredDate_EpiredDateId] FOREIGN KEY ([ExpiredDate_EpiredDateId]) REFERENCES [dbo].[ExpiredDates] ([EpiredDateId]) ON DELETE CASCADE
ALTER TABLE [dbo].[ExpiredDateDeliveries] ADD CONSTRAINT [FK_dbo.ExpiredDateDeliveries_dbo.Deliveries_Delivery_DeliveryId] FOREIGN KEY ([Delivery_DeliveryId]) REFERENCES [dbo].[Deliveries] ([DeliveryId]) ON DELETE CASCADE
ALTER TABLE [dbo].[ExpiredDateMedicines] ADD CONSTRAINT [FK_dbo.ExpiredDateMedicines_dbo.ExpiredDates_ExpiredDate_EpiredDateId] FOREIGN KEY ([ExpiredDate_EpiredDateId]) REFERENCES [dbo].[ExpiredDates] ([EpiredDateId]) ON DELETE CASCADE
ALTER TABLE [dbo].[ExpiredDateMedicines] ADD CONSTRAINT [FK_dbo.ExpiredDateMedicines_dbo.Medicines_Medicine_MedicineId] FOREIGN KEY ([Medicine_MedicineId]) REFERENCES [dbo].[Medicines] ([MedicineId]) ON DELETE CASCADE
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'202405222045380_AutomaticMigration', N'Obsługa_Apteki.Migrations.Configuration',  0x1F8B0800000000000400ED1D5D6FE3B8F1BD40FF83E0A7B6D88B935D146803E70E5927DB356EB34EE3ECA16F0123D18EB0B2E4D34790A0B897FEAD3EF4A9BFA77FA1942D51FC164951B213040BECAE4572381CCE0C6786E4F07FFFFECFE4A7A775E43DC2340B93F86C7472743CF260EC274118AFCE4645BEFCE12FA39F7EFCFDEF2697C1FAC9FBA5AEF7A1AC875AC6D9D9E821CF37A7E371E63FC035C88ED6A19F2659B2CC8FFC643D0641327E7F7CFCD7F1C9C91822102304CBF32637459C876BB8FD817E4E93D8879BBC00D15512C028ABBEA392C516AAF715AC61B6013E3C1BCDEFB3FFFEAB5881BBF34D0EBF87479708521EC26CE49D472140F82C60B41C79208E931CE408DBD36F195CE46912AF161BF40144B7CF1B88EA2D4194C16A14A74D75DD011DBF2F07346E1AD6A0FC22CB93B521C0930F1585C66C732B3A8F3005110DB7147A2E47BDA5E3D9E822F1F3241D796C57A7D3282DABF144DEB578E7D5DFBDDDF777982310E3947FDE79D322CA8B149EC5B0C85310BDF3AE8BFB28F47F86CFB7C977189FC5451491D821FC5019F5017DBA4E930D4CF3E71BB8A4709E05236F4CB71EB3CD7163AEE56E6CB338FFF07EE47D458880FB08624620E8B0400DE0DF600C5390C3E01AE4394CD13CCE02B825258703D363F977DD1BE23C244A23EF0A3C7D81F12A7F381BA1FF8EBC4FE1130CEA2F1506DFE210491E6A94A7056CEB6451A4F110FD5C2012CC971FC3347FA8FB2A3FDD8665DF1C11D5B0AE2F17975F7AC7F82AB90FA3FE09731EA430CB7AEFE63AC972104D517DC75D4DC68D6250AA8B2B18847E1843138551B7D9A7CAA871B0511A64DB57A536A608B555923EF7CFB76912143E1AF9003D853E525168DD8FB0864A100B99EBA7BF17603B53B3F81AF8DFC10AB64DBE1EB8F9B20297758337CB107317710031537E4C920882D85C11C3B49C1A84D27CB983B99D1A9A781A543F5F2216B70470EEE7E1235C14F748BF21F3AF77369965E76836EEC3240F7F2D60570ACEB2797C03FD1099ADC6A0BE82C770B55519EC5A0B234492746BCDDEC0685B257B08373BA3162BD53BB2DEA73459DF2411A1B388E2BB4552A45BDA26F23AB7205DC1DC00CBCA7C546258D51161B72D5260B62B37C5EAF26913A630286D1331F5880A77756714FD8415301E359EE25AF56874B1AD58478C695528C6922BE430E46B88B0D35EFE2B4E7936F217AA367BF5182A1CAC7C06A2ED50CBFFCED06EA8DDD1D6DE819BA610FDDBDD707F00E91AB9DF453E4F039812BADE6E25FB05448D0AD65DACDD88BE58778A6B28855FA0657511DE121106847CBBD1F62CBAAA15C14A1710E337F206CAA80E24A7619F8AE1126361A31AE8D6432A8764B923A0B934DB1A1CD672C32EEE2DE2A58BAE5A602C177815AEFC226B2536D850D41799AAC93EE5A442C1464888A6C32E9F37701566B9B3E5D356E02C43902D8B30A213A28531181B43BEB621793B9E2EE1A48729762BE18686B10C37B554ABD0ABA640885C557657F5F205F121899EA0985BAF45753AADD7185F7DC55335D9A7E22118DD54F168CB883BC5334DD6EB41C25CD806E746D729AEF8FE580B394365D5BE3DD14FBFAF70BBE2E4CF43EC569C1CEBCDC79E762B945A194B865831E3E2BB4A3D50EB86A09857CC823A96219FDDBAE066FD601738D51A63B77E109435584270ABBDAE2294BE345E48E4DAB67723F6B30B9BF34DEBBF69FDD7ADF5B12E77A3F33965AA58177494E97996257EB8458C8F9E91E1147ABC9771E0E9C556768466221F88E4489F861BA441114E67A33F71046DED002F7E4D074D545A097D322606AD4F8BC69DD3C154E0DF39A5846063A581DF9C8570450851985786A67287CF18C956D0833002BB65D88E201378681FF7F1D1D189D6D0E9980539EC2A0CE26AD04C784586992CD6D22086238BFA332D89D0B48EF664C4DA5CF318B103CCA1576EE597071DA720F341C0EB70A42103FA0B32D3605ADA44E5B21167C8F00BE39CB7E9C2D80F37205262CEB4323A3D58E2867B614B2EE006C6A5E1A69C8DAEDDE35E1892B551C882DBDAF5AC2286E684E706D6AD222B4086A2D2246890243D22232DA3743309F875C4AE8DB85612A418A40E1FAB5C2A23515210C3051E03C894C85B974EBDCA756F9D7AA77A578D94801FB585DD8E1FE594D1E20359A0D88C19E594E88C84734EDCF91AA84D8E5AC0B4F6F3CAE00AB885597E715F96C12751C0E65B06AB984D56395B2C7394B01730A7962DE438350E0E632170DA8E0640ECD370201A6DDF0284DC78E611C1F6680B14FA8C080787F21B5A403567B73830585A5A40343E2907026B81361058070AA110CB140388602C2179A89D7EA2B2FA4C00CBF9DA6E2C1E173B479C30693BAE0448722CAC72A40961482482B5D53492185D06EE6D570AF146170191184767FA084F2CF1D469F578B57D5E9D71687BB97D710D7726564511813FA8E50577A004ED069254A8D57F6712B0A709780AA81C621D979840BB51CF8AE14B9CE05E47AF54192D3E9AA697664B86C15484302ECB53A3D571D376DD8871502BA682282A4F8D0487F1EF4E15D1D69F802A6D3E87B6D7A1310C6D674183E71424A9A3E7D8A2C56593F1EEF26FF5613296DC129E5C81CD268C57C4ADE1EA8BB7D85D199EFEB030BF45BBDEC118FB14E7B1F637EE09E90AB0824C69793824809FC214D9E52007F7A0DCEE98066BAE9AC87E97987F758FB489CE4F5D6D10D6F5CBFF57A78F2537A88FC4CAB7A1E72734C4F2A8CB76B490D3957C43AFBCC00D22904ACFC34D93A858C76D513239A4DD2E270965F7451F02DEB22481E08FFA70A82D486A5864813EBC6A1B9284547DD287516F329240EA6FFA50EA4D44124AFDCD603CC41E213528E23B0F6D3266788FF3B0394EE74220B4E06889956A15B6102CECEB9A8B96BCA974D289ABABD4C44BAFC3AAA07517B0E6C62909A5F96AC042CD95528A839ACF26B0884BA33434A2401F9EE0EA280955506C0E9BBC472A024E96EB43276F959250C9EF067415DF2CA5282CAE623877ECD5536E0ED90A060A8FBD994A693EB6D084D2F40D549ADA74990954E2262A0D92283818D5AA74FA6D8C963A026861B6489B4A1779E25E20B5C64BEF1A2AA13137FE78AB4116DE6C875A5FFCE361D62506F226B8FD47899BA05C1F7A75179004587D3A189EA5C26E4EB8968C379B33AEB2B58CCEF4C53592DCAA0B716D9CD65C4A6339AD29399879C4FEA99339AC75ABF9FC495BCA284DDCA722C92CBDA1D5366BE445295E433465A65065BC3057F042FF4E22B14347A92DF9C6DDDE385411EDB2E0D07A2FC99C43A52D5DD258EA31D4376A2887A1FE68B36E7168290F10C821BE851B5430DEC20DB6524F44A6DD087EB3FD6B21FB8AC6C3891A791582E7EFCF868BC99BE0AA60BC096E9BE0D2FB1752EF80DAF9367303A8A60A835FE6B496BB35F2BC2882DD739E86A66E03015EED426C0FA2D570ADF1969EC9B272D5EF543EBB1C61762BAB13B7103BAB86CC42B454F08A2C78DC42736E5FF965B00AB789AD89765BC0FC4E1539EF915384C7690C761B941AA5AE64A04E1427711C51DA0143284EF838521C7BE382EAF08C1107546DF4366C95E46CB9F430A46469616A38E986C1062572D3240EC2ED59F159565E3EC5371D0D69D0997704278FF4E35AAA35A6AA62B0BE48CF2C694E903A0276A7888419F291F448D4A1AF26DC491AB60AB691AB2FF8373E49539D62694FC2CF1D6BD955197908F7C730288FB42C9EB31CAE8FCA0A478B5FA369B43BD55C57B80271B88459BEBBE33F7A7F7CF29EC9E07F38D9F4C75916502908A429F5E9291B38B17D58D2B7350141873402F123487DE4CEFF610D9EFE4842B2C857DF0996E0BA7F803EE59DAFFB77C28ABED2DF09147D6FBF1328FE6E7EB7418AD418C17FDCA593591CC0A7B3D13FB7ED4FBDD93FEE0420DE79DB9DC353EFD8FB4D8D918BACF518A5DFF69F56FEB08596CD16DF8D13D98CF01DA17159DF975102727749DFB753E32CE5BB0D343EE1FB7D680E4572DE4642336DDA8B73BF5BC193A482EFC41FE274EF36F413A47A6F07E322BD76373DE536FF752F7A4A9CF23AD81E4F7190EEDADE2690A6BBB691622AD9B58E8EB24AC76CC121EE1321F7C6256CEE63CDA97590A1B79B10BACCA1DBA308B26973AD25479436D71E98C8C1D13030EB7632ABD22EDBAE6EEFB8A141F70E12BA76E3539729577BE15326CB6A37D35190DB4F7B7689B6FA5E8B9E89CE25CAEB967DCF155889B77D709E36973ECF85CFCD67CB1BD0FD7693A7B3A366709E46B3C775EC33B3EC38F19CDFC4F24D2C3BDBE7E27D564D3B5D7FF75CEE062ACE3B68D8FA520CCC564F199C4E969A70848616230FA20FEBADF568C600FCA0B5EFF8A2F961D81075177E501FC2E81A8E761E15EA4E4F47926E2FE0FDCCA3723BDC2850A0DCC8EE4998055D9B119703F03AC55737A1B3F064833837936EEEE29E72008AEC1309469A897F3DCB4480EAFB7066A14BCF24F99FC6C9DAAE6BF010E9280D8ECC12F32F9C74D94CBF7A1E349A7FF569C0DED94FF314F3C09CA73EDC75E82AB0393120C6483FADFA8B55818A44252F4A05AA0FEF09D2E06925A27EF52C6834FDEA738CBD739FE679CA01184FF75CFC81B11DE77C8A70E979C9DD07C3B5DD7CB0E87B4F4CF602ACBB4360B27DD875564CB6775BCEF42D1617AFAF90D75A4C5E5B79492A479A58F1909735CD376AB4E7AF270DC39CCC1BE0D10283D974F9EECC8B7C69A6CD103298BD7EF947A8D2B8B25EF8C9647E95F79C4C39CA48156ADDB4DA0B8BBD00176FFF4CB68F65CF86CD0E67FDB37B3CCAD16351F5313F12D8402F430DFC129434459579A787F9ECD31EDF781ADE36329A4E27AF3799AC9E87F054139F119E9D3DD1234C8A379876576FCF46C17D82267AB7AB297BBC8205DE2C3A1CF8A648D481FC4D080E7FECDCF323C045C231C81F6161FBA0B60DB86EA852514FAA577564AF3FA91E7F12F5217D1A81858F3504071F9788E04B5FA3E0E0136B12DF055128EC45FE84866A52143C20ACD53249769CA1E07561AD1624F425800F7349854D4D02A696CEF839E352C6B5EA713395F87E0D1E15C38F90E8BE2D26C91421DB4E24D254285E7593B56727499A7E8B5B873B3D2726788F4A9B3CE2FC14C240309902469A5AFAA008C3BF71A4F9DCDAA05CC3CA973411575FC4D1639AB69C2642AF9918916C18074016C5269CDE1374EDFC624F12D90A20CEC4D50F31E41CA29F32CB894ED91F311CBEBF67CE03B41D4F66E1EA3E4487EFEB69A32976348966B2B7501D3CA0A7906CDD3C5376C8AB837A7C7B870A4EFE549F0E117AD4F7C392A1E70704250F062A09C0786C54FE740703EEF16D401D947B90738337FFF88C6493F14D1197D7C977BF2E6016AE1A1065EEBD18FA542806D799C5CBA40E0A3118D555B8B3E83908400ECED33C5C023F47C53ECCB26D42886D5A0764CEACEF61308BE745BE29723464B8BE8FA865AB8C2CA9FADF3E6C48E33C996FCA5F998B212034C3F25EE03CFE58845180F1FE2438F82E015186ACAAAB9AE55CE6E595CDD53386F43561255B06A8221F8EB4DDC2F5262AA32EF378011EA10D6EDF32F805AE80FF5C27969303699F089AEC938B10AC52B0CE2A184D7BF413F170B07EFAF1FF59F1CC4A43AF0000 , N'6.4.4')
