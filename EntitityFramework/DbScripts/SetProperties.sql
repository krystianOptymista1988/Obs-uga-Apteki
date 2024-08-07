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

