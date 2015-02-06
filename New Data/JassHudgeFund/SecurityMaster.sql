USE MASTER;

GO

IF EXISTS(select * from dbo.sysdatabases where name='sequriryMaster')
drop database sequriryMaster;

GO

create database sequriryMaster;

GO

use sequriryMaster;

go

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'core')
EXEC sys.sp_executesql N'CREATE SCHEMA [core]'

go

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'eq')
EXEC sys.sp_executesql N'CREATE SCHEMA [eq]'

go

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'cb')
EXEC sys.sp_executesql N'CREATE SCHEMA [cb]'

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_polaris_core_sectype_id' AND TABLE_SCHEMA='core')
drop table core.ivp_polaris_core_sectype_id;

go

create table core.ivp_polaris_core_sectype_id(
code bigint primary key identity,
sectype_name nvarchar(100) not null unique,
sectype_description nvarchar(255) not null unique,
created_by nvarchar(50) not null,
created_on date,
last_modified_by nvarchar(50),
last_modified_on date,
);

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_polaris_core_metadata' AND TABLE_SCHEMA='core')
drop table core.ivp_polaris_core_metadata;

go

create table core.ivp_polaris_core_metadata(
code bigint primary key identity,
attritbute_name nvarchar(100) not null,
sectype_id bigint foreign key references core.ivp_polaris_core_sectype_id(code),
created_by nvarchar(50) not null,
created_on date,
is_active bit
);


go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_polaris_core_mastersecurity' AND TABLE_SCHEMA='core')
drop table core.ivp_polaris_core_mastersecurity;

go

create table core.ivp_polaris_core_mastersecurity(
code bigint primary key identity,
table_name nvarchar(100) not null unique,
sectype_id bigint foreign key references core.ivp_polaris_core_sectype_id(code)
)

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_polaris_core_securityitentifier' AND TABLE_SCHEMA='core')
drop table core.ivp_polaris_core_securityitentifier;

go
create table core.ivp_polaris_core_securityitentifier(
code bigint primary key identity,
fk_security_id bigint,
cusip nvarchar(100),
isin nvarchar(100),
sedol nvarchar(100),
bloomberg_ticker nvarchar(100),
bloomberg_unique_id bigint unique,
bloomberg_global_id bigint unique,
)

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_polaris_core_referencedata' AND TABLE_SCHEMA='core')
drop table core.ivp_polaris_core_referencedata;

go
create table core.ivp_polaris_core_referencedata(
code bigint primary key identity,
fk_security_id bigint,
issue_country nvarchar(100),
exchange nvarchar(100),
issuer nvarchar(100),
issue_currency nvarchar(100),
trading_currency nvarchar(100),
bloomberg_industry_sub_group nvarchar(100),
bloomberg_industry_group nvarchar(100),
bloomberg_industry_sector nvarchar(100),
country_of_incorporation nvarchar(100),
risk_currency nvarchar(100)
)

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_polaris_securitysummary' AND TABLE_SCHEMA='eq')
drop table eq.ivp_polaris_securitysummary;

go

create table eq.ivp_polaris_securitysummary(
security_id bigint primary key identity(100,1),
securiry_name nvarchar(255) not null,
securiry_description nvarchar(255),
has_position bit,
is_active bit not null,
round_lot_size int,
bloomberg_unique_name nvarchar(255) unique,
created_by nvarchar(50) not null,
created_on date,
last_modified_by nvarchar(50),
last_modified_on date,
)

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_polaris_securitydetails' AND TABLE_SCHEMA='eq')
drop table eq.ivp_polaris_securitydetails;

go

create table eq.ivp_polaris_securitydetails(
code bigint primary key identity,
fk_security_id bigint foreign key references  eq.ivp_polaris_securitysummary(security_id),
is_adr bit,
adr_underlying_ticker nvarchar(100),
adr_underlying_currency nvarchar(100),
shares_per_adr nvarchar(100),
ipo_date date,
price_currency nvarchar(100),
settle_days bigint,
shares_outstanding nvarchar(100),
voting_rights_per_share nvarchar(100),
form_pf_asset_class nvarchar(100),
form_pf_country nvarchar(100),
form_pf_credit_rating nvarchar(100),
form_pf_currency nvarchar(100),
form_pf_instrument nvarchar(100),
form_pf_liquid_profile nvarchar(100),
form_pf_maturity nvarchar(100),
form_pf_naics_code nvarchar(100),
form_pf_region nvarchar(100),
form_pf_sector nvarchar(100),
form_pf_sub_asset_class nvarchar(100)
)

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_polaris_risk' AND TABLE_SCHEMA='eq')
drop table eq.ivp_polaris_risk;

go

create table eq.ivp_polaris_risk(
code bigint primary key identity,
fk_security_id bigint foreign key references  eq.ivp_polaris_securitysummary(security_id),
twenty_day_average_volume nvarchar(100),
beta nvarchar(100),
short_interest nvarchar(100),
ytd_return nvarchar(100),
ninty_day_price_volatility nvarchar(100),
)

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_polaris_pricingdetails' AND TABLE_SCHEMA='eq')
drop table eq.ivp_polaris_pricingdetails;

go

create table eq.ivp_polaris_pricingdetails(
code bigint primary key identity,
fk_security_id bigint foreign key references  eq.ivp_polaris_securitysummary(security_id),
open_price money,
close_price money,
volume bigint,
last_price money,
ask_price money,
bid_price money,
pe_ratio float
)

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_polaris_dividendhistory' AND TABLE_SCHEMA='eq')
drop table eq.ivp_polaris_dividendhistory;

go

create table eq.ivp_polaris_dividendhistory(
code bigint primary key identity,
fk_security_id bigint foreign key references  eq.ivp_polaris_securitysummary(security_id),
declared_date date,
ex_date date,
record_date date,
pay_date date,
amount money,
frequency nvarchar(100),
dividend_type nvarchar(100)
)

/***************Corporate Bond**********************/

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_polaris_securitysummary' AND TABLE_SCHEMA='cb')
drop table cb.ivp_polaris_securitysummary;

go

create table cb.ivp_polaris_securitysummary(
security_id bigint primary key identity(100000,1),
security_description nvarchar(100),
security_name nvarchar(100),
asset_type nvarchar(100),
investment_type nvarchar(100),
trading_factor nvarchar(100),
pricing_factor nvarchar(100),
created_by nvarchar(50) not null,
created_on date,
last_modified_by nvarchar(50),
last_modified_on date,
is_active bit
)

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_polaris_securitydetails' AND TABLE_SCHEMA='cb')
drop table cb.ivp_polaris_securitydetails;

go

create table cb.ivp_polaris_securitydetails(
code bigint primary key identity,
fk_security_id bigint foreign key references  cb.ivp_polaris_securitysummary(security_id),
first_coupon_date date,
coupon_cap nvarchar(100),
coupon_floor nvarchar(100),
coupon_frequency nvarchar(100),
coupon_rate nvarchar(100),
coupon_type nvarchar(100),
float_spread nvarchar(100),
is_callable bit,
is_fix_to_float bit,
is_putable bit,
issue_date date,
last_reset_date date,
maturity_date date,
maximum_call_notice_days bigint,
maximum_put_notice_days bigint,
penultimate_coupon_date date,
reset_frequency nvarchar(100),
has_position bit,
form_pf_asset_class nvarchar(100),
form_pf_country nvarchar(100),
form_pf_credit_rating nvarchar(100),
form_pf_currency nvarchar(100),
form_pf_instrument nvarchar(100),
form_pf_liquidity_profile nvarchar(100),
form_pf_maturity nvarchar(100),
form_pf_naics_code nvarchar(100),
form_pf_region nvarchar(100),
form_pf_sector nvarchar(100),
form_pf_sub_asset_class nvarchar(100)
)

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_polaris_risk' AND TABLE_SCHEMA='cb')
drop table cb.ivp_polaris_risk;

go

create table cb.ivp_polaris_risk(
code bigint primary key identity,
fk_security_id bigint foreign key references  cb.ivp_polaris_securitysummary(security_id),
firstcouponcode nvarchar(100),
duration nvarchar(100),
volatility_thirtyD nvarchar(100),
volatility_nintyD nvarchar(100),
convexity nvarchar(100),
average_volume_thirtyD nvarchar(100)
)

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_polaris_putschedule' AND TABLE_SCHEMA='cb')
drop table cb.ivp_polaris_putschedule;

go

create table cb.ivp_polaris_putschedule(
code bigint primary key identity,
fk_security_id bigint foreign key references  cb.ivp_polaris_securitysummary(security_id),
put_date date,
put_price money,
)

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_polaris_pricingandanalytics' AND TABLE_SCHEMA='cb')
drop table cb.ivp_polaris_pricingandanalytics;

go

create table cb.ivp_polaris_pricingandanalytics(
code bigint primary key identity,
fk_security_id bigint foreign key references  cb.ivp_polaris_securitysummary(security_id),
ask_price money,
high_price money,
low_price money,
open_price money,
volume bigint,
bid_price money,
last_price money
)

go

IF EXISTS (select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME='ivp_polaris_callschedule' AND TABLE_SCHEMA='cb')
drop table cb.ivp_polaris_pricingandanalytics;

go

create table cb.ivp_polaris_callschedule(
code bigint primary key identity,
fk_security_id bigint foreign key references  cb.ivp_polaris_securitysummary(security_id),
call_date date,
call_price money,
)

go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[eq].[sp_ivp_polaris_iud_security]') AND type in (N'P', N'PC'))
DROP PROCEDURE eq.sp_ivp_polaris_iud_security

GO
/****** Object:  StoredProcedure [eq].[sp_ivp_polaris_iud_security]    Script Date: 21-Jan-15 1:18:16 PM ******/
--- Combine/Generic Store procedure for insert,update,delete --> Equity
create procedure eq.sp_ivp_polaris_iud_security
	(
	@action nvarchar(10),
	@securiry_name nvarchar(255)= null,
	@securiry_description nvarchar(255) = null,
	@has_position nvarchar(10) = null,
	@is_active bit = null,
	@round_lot_size nvarchar(10) = null,
	@bloomberg_unique_name nvarchar(255) = null,
	@is_adr nvarchar(100) = null,
	@adr_underlying_ticker nvarchar(100) = null,
	@adr_underlying_currency nvarchar(100) = null,
	@shares_per_adr nvarchar(100) = null,
	@ipo_date date = null,
	@price_currency nvarchar(100) = null,
	@settle_days bigint = null,
	@shares_outstanding nvarchar(100) = null,
	@voting_rights_per_share nvarchar(100) = null,
	@form_pf_asset_class nvarchar(100) = null,
	@form_pf_country nvarchar(100) = null,
	@form_pf_credit_rating nvarchar(100) = null,
	@form_pf_currency nvarchar(100) = null,
	@form_pf_instrument nvarchar(100) = null,
	@form_pf_liquid_profile nvarchar(100) = null,
	@form_pf_maturity nvarchar(100) = null,
	@form_pf_naics_code nvarchar(100) = null,
	@form_pf_region nvarchar(100) = null,
	@form_pf_sector nvarchar(100) = null,
	@form_pf_sub_asset_class nvarchar(100) = null,
	@created_by nvarchar(50) = null,
	@created_on date = null,
	@last_modified_by nvarchar(50) = null,
	@last_modified_on date = null,
	@security_id bigint output
	)
AS              
BEGIN  
	SET NOCOUNT ON
	DECLARE @flag int
	BEGIN TRY
	BEGIN TRANSACTION 
-------------------------------------------------------	
	-- INSERT PROCEDURE
-------------------------------------------------------
	
	IF @Action = 'INSERT'
	BEGIN
		insert into eq.ivp_polaris_securitysummary
		(
		securiry_Name,
		securiry_Description,
		has_Position,
		is_Active,
		round_Lot_Size,
		bloomberg_Unique_Name,
		created_by,
		created_on,
		last_modified_by,
		last_modified_on
		) 
		values
		(
		@securiry_Name,
		@securiry_Description,
		@has_Position,
		@is_Active,
		@round_Lot_Size,
		@bloomberg_Unique_Name,
		@created_by,
		@created_on,
		@last_modified_by,
		@last_modified_on
		);
		
		SET @security_id=SCOPE_IDENTITY();
		
		insert into eq.ivp_polaris_securitydetails
		(
		fk_security_id,
		is_adr, 
		adr_underlying_ticker,
		adr_underlying_currency,
		shares_per_adr,
		ipo_date,
		price_currency,
		settle_days,
		shares_outstanding,
		voting_rights_per_share,
		form_pf_asset_class,
		form_pf_country,
		form_pf_credit_rating,
		form_pf_currency,
		form_pf_instrument,
		form_pf_liquid_profile,
		form_pf_maturity,
		form_pf_naics_code,
		form_pf_region,
		form_pf_sector,
		form_pf_sub_asset_class
		) 
		values
		( 
		@security_id,
		@is_adr,
		@adr_underlying_ticker,
		@adr_underlying_currency,
		@shares_per_adr,
		@ipo_date,
		@price_currency,
		@settle_days,
		@shares_outstanding,
		@voting_rights_per_share,
		@form_pf_asset_class,
		@form_pf_country,
		@form_pf_credit_rating,
		@form_pf_currency,
		@form_pf_instrument,
		@form_pf_liquid_profile,
		@form_pf_maturity,
		@form_pf_naics_code,
		@form_pf_region,
		@form_pf_sector,
		@form_pf_sub_asset_class
		);
	END


-------------------------------------------------------	
	-- UPDATE PROCEDURE
-------------------------------------------------------
	
	IF @Action = 'UPDATE'
	BEGIN
	update 	eq.ivp_polaris_securitysummary set
	 securiry_Name=@securiry_Name ,
	 securiry_Description=@securiry_Description,
	 has_Position=@has_Position, 
	 is_Active=@is_Active, 
	 round_Lot_Size=@round_Lot_Size, 
	 last_modified_by=@last_modified_by, 
	 last_modified_on=@last_modified_on 
	 where  security_id=@security_id
	
	update eq.ivp_polaris_securitydetails set 
	is_adr=@is_adr, 
	adr_underlying_ticker=@adr_underlying_ticker, 
	adr_underlying_currency=@adr_underlying_currency, 
	shares_per_adr=@shares_per_adr, 
	ipo_date=@ipo_date, 
	price_currency=@price_currency, 
	settle_days=@settle_days, 
	shares_outstanding=@shares_outstanding, 
	voting_rights_per_share=@voting_rights_per_share,
	form_pf_asset_class=@form_pf_asset_class,
	form_pf_country=@form_pf_country,
	form_pf_credit_rating=@form_pf_credit_rating,
	form_pf_currency=@form_pf_currency,
	form_pf_instrument=@form_pf_instrument,
	form_pf_liquid_profile=@form_pf_liquid_profile,
	form_pf_maturity=@form_pf_maturity,
	form_pf_naics_code=@form_pf_naics_code,
	form_pf_region=@form_pf_region,
	form_pf_sector=@form_pf_sector,
	form_pf_sub_asset_class=@form_pf_sub_asset_class 
	where fk_security_id=@security_id
	print 'DONE'
	END


-------------------------------------------------------	
	-- DELETE PROCEDURE
-------------------------------------------------------
	
	IF @Action = 'DELETE'
	BEGIN
	update eq.ivp_polaris_securitysummary set is_active='FALSE' where security_id=@security_id;
	END

	IF @@TRANCOUNT >0 
	BEGIN 
	COMMIT TRANSACTION;
	SET @flag=1;
	END

	END TRY
	BEGIN CATCH
	IF @@TRANCOUNT > 0
	BEGIN
	ROLLBACK TRANSACTION;
	SET @flag=0;
	END
	END CATCH
END

GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[eq].[sp_ivp_polaris_iudfull_security]') AND type in (N'P', N'PC'))
DROP PROCEDURE eq.sp_ivp_polaris_iudfull_security

GO
/****** Object:  StoredProcedure [eq].[sp_ivp_polaris_iud_security]    Script Date: 21-Jan-15 1:18:16 PM ******/
--- Combine/Generic Store procedure for insert,update,delete --> Equity
create procedure eq.sp_ivp_polaris_iudfull_security
	(
	@action nvarchar(10),
	@securiry_name nvarchar(255)= null,
	@securiry_description nvarchar(255) = null,
	@has_position bit = null,
	@is_active bit = null,
	@round_lot_size int = null,
	@bloomberg_unique_name nvarchar(255) = null,
	@created_by nvarchar(50) = null,
	@created_on date = null,
	@last_modified_by nvarchar(50) = null,
	@last_modified_on date = null,
	@is_adr bit = null,
	@adr_underlying_ticker nvarchar(100) = null,
	@adr_underlying_currency nvarchar(100) = null,
	@shares_per_adr nvarchar(100) = null,
	@ipo_date date = null,
	@price_currency nvarchar(100) = null,
	@settle_days bigint = null,
	@shares_outstanding nvarchar(100) = null,
	@voting_rights_per_share nvarchar(100) = null,
	@form_pf_asset_class nvarchar(100) = null,
	@form_pf_country nvarchar(100) = null,
	@form_pf_credit_rating nvarchar(100) = null,
	@form_pf_currency nvarchar(100) = null,
	@form_pf_instrument nvarchar(100) = null,
	@form_pf_liquid_profile nvarchar(100) = null,
	@form_pf_maturity nvarchar(100) = null,
	@form_pf_naics_code nvarchar(100) = null,
	@form_pf_region nvarchar(100) = null,
	@form_pf_sector nvarchar(100) = null,
	@form_pf_sub_asset_class nvarchar(100) = null,
	@twenty_day_average_volume nvarchar(100) = null,
	@beta nvarchar(100) = null,
	@short_interest nvarchar(100) = null,
	@ytd_return nvarchar(100) = null,
	@ninty_day_price_volatility nvarchar(100) = null,
	@issue_country nvarchar(100) = null,
	@exchange nvarchar(100) = null,
	@issuer nvarchar(100) = null,
	@issue_currency nvarchar(100) = null,
	@trading_currency nvarchar(100) = null,
	@bloomberg_industry_sub_group nvarchar(100) = null,
	@bloomberg_industry_group nvarchar(100) = null,
	@bloomberg_industry_sector nvarchar(100) = null,
	@country_of_incorporation nvarchar(100) = null,
	@risk_currency nvarchar(100) = null,
	@cusip nvarchar(100) = null,
	@isin nvarchar(100) = null,
	@sedol nvarchar(100) = null,
	@bloomberg_ticker nvarchar(100) = null,
	@bloomberg_unique_id bigint = null,
	@bloomberg_global_id bigint = null,
	@open_price money = null,
	@close_price money = null,
	@volume bigint = null,
	@last_price money = null,
	@ask_price money = null,
	@bid_price money = null,
	@pe_ratio float = null,
	@declared_date date = null,
	@ex_date date = null,
	@record_date date = null,
	@pay_date date = null,
	@amount money = null,
	@frequency nvarchar(100) = null,
	@dividend_type nvarchar(100) = null,

	@security_id bigint output
	)
AS              
BEGIN  
	SET NOCOUNT ON
	DECLARE @flag int
	BEGIN TRY
	BEGIN TRANSACTION 
-------------------------------------------------------	
	-- INSERT PROCEDURE
-------------------------------------------------------
	
	IF @Action = 'INSERT'
	BEGIN
		insert into eq.ivp_polaris_securitysummary
		(
		securiry_Name,
		securiry_Description,
		has_Position,
		is_Active,
		round_Lot_Size,
		bloomberg_Unique_Name,
		created_by,
		created_on,
		last_modified_by,
		last_modified_on
		) 
		values
		(
		@securiry_Name,
		@securiry_Description,
		@has_Position,
		@is_Active,
		@round_Lot_Size,
		@bloomberg_Unique_Name,
		@created_by,
		@created_on,
		@last_modified_by,
		@last_modified_on
		);
		
		SET @security_id=SCOPE_IDENTITY();
		
		insert into eq.ivp_polaris_securitydetails
		(
		fk_security_id,
		is_adr, 
		adr_underlying_ticker,
		adr_underlying_currency,
		shares_per_adr,
		ipo_date,
		price_currency,
		settle_days,
		shares_outstanding,
		voting_rights_per_share,
		form_pf_asset_class,
		form_pf_country,
		form_pf_credit_rating,
		form_pf_currency,
		form_pf_instrument,
		form_pf_liquid_profile,
		form_pf_maturity,
		form_pf_naics_code,
		form_pf_region,
		form_pf_sector,
		form_pf_sub_asset_class
		) 
		values
		( 
		@security_id,
		@is_adr,
		@adr_underlying_ticker,
		@adr_underlying_currency,
		@shares_per_adr,
		@ipo_date,
		@price_currency,
		@settle_days,
		@shares_outstanding,
		@voting_rights_per_share,
		@form_pf_asset_class,
		@form_pf_country,
		@form_pf_credit_rating,
		@form_pf_currency,
		@form_pf_instrument,
		@form_pf_liquid_profile,
		@form_pf_maturity,
		@form_pf_naics_code,
		@form_pf_region,
		@form_pf_sector,
		@form_pf_sub_asset_class
		);

		insert into eq.ivp_polaris_risk(
		fk_security_id,
		twenty_day_average_volume,
		beta,
		short_interest,
		ytd_return,
		ninty_day_price_volatility
		)
		values
		(
		@security_id,
		@twenty_day_average_volume,
		@beta,
		@short_interest,
		@ytd_return,
		@ninty_day_price_volatility
		);

		insert into core.ivp_polaris_core_securityitentifier(
		fk_security_id,
		cusip,
		isin,
		sedol,
		bloomberg_ticker,
		bloomberg_unique_id,
		bloomberg_global_id
		)
		values
		(
		@security_id,
		@cusip,
		@isin,
		@sedol,
		@bloomberg_ticker,
		@bloomberg_unique_id,
		@bloomberg_global_id
		);

		insert into core.ivp_polaris_core_referencedata(
		fk_security_id,
		issue_country,
		exchange,
		issuer,
		issue_currency,
		trading_currency,
		bloomberg_industry_sub_group,
		bloomberg_industry_group,
		bloomberg_industry_sector,
		country_of_incorporation,
		risk_currency)
		values
		(
		@security_id,
		@issue_country,
		@exchange,
		@issuer,
		@issue_currency,
		@trading_currency,
		@bloomberg_industry_sub_group,
		@bloomberg_industry_group,
		@bloomberg_industry_sector,
		@country_of_incorporation,
		@risk_currency
		);

		insert into eq.ivp_polaris_pricingdetails(
		fk_security_id,
		open_price,
		close_price,
		volume,
		last_price,
		ask_price,
		bid_price,
		pe_ratio
		)
		values
		(
		@security_id,
		@open_price,
		@close_price,
		@volume,
		@last_price,
		@ask_price,
		@bid_price,
		@pe_ratio
		);

		insert into eq.ivp_polaris_dividendhistory(
		fk_security_id,
		declared_date,
		ex_date,
		record_date,
		pay_date,
		amount,
		frequency,
		dividend_type
		)
		values
		(
		@security_id,
		@declared_date,
		@ex_date,
		@record_date,
		@pay_date,
		@amount,
		@frequency,
		@dividend_type
		);


	END

-------------------------------------------------------	
	-- UPDATE PROCEDURE
-------------------------------------------------------
	
	IF @Action = 'UPDATE'
	BEGIN
	update 	eq.ivp_polaris_securitysummary set
	 securiry_Name=@securiry_Name ,
	 securiry_Description=@securiry_Description,
	 has_Position=@has_Position, 
	 is_Active=@is_Active, 
	 round_Lot_Size=@round_Lot_Size, 
	 last_modified_by=@last_modified_by, 
	 last_modified_on=@last_modified_on 
	 where  security_id=@security_id
	
	update eq.ivp_polaris_securitydetails set 
	is_adr=@is_adr, 
	adr_underlying_ticker=@adr_underlying_ticker, 
	adr_underlying_currency=@adr_underlying_currency, 
	shares_per_adr=@shares_per_adr, 
	ipo_date=@ipo_date, 
	price_currency=@price_currency, 
	settle_days=@settle_days, 
	shares_outstanding=@shares_outstanding, 
	voting_rights_per_share=@voting_rights_per_share,
	form_pf_asset_class=@form_pf_asset_class,
	form_pf_country=@form_pf_country,
	form_pf_credit_rating=@form_pf_credit_rating,
	form_pf_currency=@form_pf_currency,
	form_pf_instrument=@form_pf_instrument,
	form_pf_liquid_profile=@form_pf_liquid_profile,
	form_pf_maturity=@form_pf_maturity,
	form_pf_naics_code=@form_pf_naics_code,
	form_pf_region=@form_pf_region,
	form_pf_sector=@form_pf_sector,
	form_pf_sub_asset_class=@form_pf_sub_asset_class 
	where fk_security_id=@security_id

	update eq.ivp_polaris_risk set
	twenty_day_average_volume = @twenty_day_average_volume,
	beta = @beta,
	short_interest = @short_interest,
	ytd_return = @ytd_return,
	ninty_day_price_volatility = @ninty_day_price_volatility
	where fk_security_id=@security_id

	update core.ivp_polaris_core_securityitentifier set
	cusip = @cusip,
	isin=@isin,
	sedol=@sedol,
	bloomberg_ticker=@bloomberg_ticker,
	bloomberg_unique_id=@bloomberg_unique_id,
	bloomberg_global_id=@bloomberg_global_id
	where fk_security_id=@security_id

	update core.ivp_polaris_core_referencedata set
	issue_country=@issue_country,
	exchange=@exchange,
	issuer=@issuer,
	issue_currency=@issue_currency,
	trading_currency=@trading_currency,
	bloomberg_industry_sub_group=@bloomberg_industry_sub_group,
	bloomberg_industry_group=@bloomberg_industry_group,
	bloomberg_industry_sector = @bloomberg_industry_sector,
	country_of_incorporation=@country_of_incorporation,
	risk_currency=@risk_currency
	where fk_security_id=@security_id

	update eq.ivp_polaris_pricingdetails set 
	open_price=@open_price,
	close_price=@close_price,
	volume=@volume,
	last_price=@last_price,
	ask_price=@ask_price,
	bid_price=@bid_price,
	pe_ratio=@pe_ratio
	where fk_security_id=@security_id

	update eq.ivp_polaris_dividendhistory set 
	declared_date=@declared_date,
	ex_date=@ex_date,
	record_date=@record_date,
	pay_date=@pay_date,
	amount=@amount,
	frequency=@frequency,
	dividend_type=@dividend_type
	where fk_security_id=@security_id
	print 'DONE'
	END


-------------------------------------------------------	
	-- DELETE PROCEDURE
-------------------------------------------------------
	
	IF @Action = 'DELETE'
	BEGIN
	update eq.ivp_polaris_securitysummary set is_active='FALSE' where security_id=@security_id;
	END

	IF @@TRANCOUNT >0 
	BEGIN 
	COMMIT TRANSACTION;
	SET @flag=1;
	END

	END TRY
	BEGIN CATCH
	IF @@TRANCOUNT > 0
	BEGIN
	ROLLBACK TRANSACTION;
	SET @flag=0;
	END
	END CATCH
END

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cb].[sp_ivp_polaris_iud_security]') AND type in (N'P', N'PC'))
DROP PROCEDURE cb.sp_ivp_polaris_iud_security

GO

/****** Object:  StoredProcedure [cb].[sp_ivp_polaris_iud_security]    Script Date: 21-Jan-15 1:18:16 PM ******/
--- Combine/Generic Store procedure for insert,update,delete --> Corporate Bond

create procedure cb.sp_ivp_polaris_iud_security
	(
	@action nvarchar(10),
	@securiry_name nvarchar(255) = null,
	@securiry_description nvarchar(255) = null,
	@asset_type nvarchar(100) = null,
	@investment_type nvarchar(100) = null,
	@trading_factor nvarchar(100) = null,
	@pricing_factor nvarchar(255) = null,
	@first_coupon_date date = null,
	@coupon_cap nvarchar(100) = null,
	@coupon_floor nvarchar(100) = null,
	@coupon_frequency nvarchar(100) = null,
	@coupon_rate nvarchar(100) = null,
	@coupon_type nvarchar(100) = null,
	@float_spread nvarchar(100) = null,
	@is_callable nvarchar(100) = null,
	@is_fix_to_float nvarchar(100) = null,
	@is_putable nvarchar(100) = null,
	@issue_date date = null,
	@last_reset_date date = null,
	@maturity_date date = null,
	@maximum_call_notice_days bigint = null,
	@maximum_put_notice_days bigint = null,
	@penultimate_coupon_date date = null,
	@reset_frequency nvarchar(100) = null,
	@has_position nvarchar(100) = null,
	@form_pf_asset_class nvarchar(100) = null,
	@form_pf_country nvarchar(100) = null,
	@form_pf_credit_rating nvarchar(100) = null,
	@form_pf_currency nvarchar(100) = null,
	@form_pf_instrument nvarchar(100) = null,
	@form_pf_liquid_profile nvarchar(100) = null,
	@form_pf_maturity nvarchar(100) = null,
	@form_pf_naics_code nvarchar(100) = null,
	@form_pf_region nvarchar(100) = null,
	@form_pf_sector nvarchar(100) = null,
	@form_pf_sub_asset_class nvarchar(100) = null,
	@created_by nvarchar(50) = null,
	@created_on date = null,
	@last_modified_by nvarchar(50) = null,
	@last_modified_on date = null,
	@is_active bit = null,
	@security_id bigint output
	)
AS
BEGIN
	SET NOCOUNT ON
	
	DECLARE @flag int
	BEGIN TRY
	BEGIN TRANSACTION 
-------------------------------------------------------	
	-- INSERT PROCEDURE
-------------------------------------------------------
	
	
	IF @Action = 'INSERT'
	BEGIN
		insert into cb.ivp_polaris_securitysummary
		(
		security_name,
		security_description,
		asset_type, 
		investment_type, 
		trading_factor, 
		pricing_factor, 
		created_by, 
		created_on, 
		last_modified_by, 
		last_modified_on , 
		is_active
		) 
		values
		(
		@securiry_Name,
		@securiry_Description,
		@asset_type,
		@investment_type,
		@trading_factor,
		@pricing_factor,
		@created_by,
		@created_on,
		@last_modified_by,
		@last_modified_on,
		@is_active
		);
		
		SET @security_id=SCOPE_IDENTITY();
		
		insert into cb.ivp_polaris_securitydetails
		(
		fk_security_id,
		first_coupon_date, 
		coupon_cap, coupon_floor , 
		coupon_frequency , 
		coupon_rate , 
		coupon_type, 
		float_spread, 
		is_callable , 
		is_fix_to_float, 
		is_putable , 
		issue_date , 
		last_reset_date , 
		maturity_date , 
		maximum_call_notice_days, 
		maximum_put_notice_days , 
		penultimate_coupon_date, 
		reset_frequency , 
		has_position,
		form_pf_asset_class,
		form_pf_country,
		form_pf_credit_rating,
		form_pf_currency,
		form_pf_instrument,
		form_pf_liquidity_profile,
		form_pf_maturity,
		form_pf_naics_code,
		form_pf_region,
		form_pf_sector,
		form_pf_sub_asset_class
		 )
		values
		(
		@security_id,
		@first_coupon_date,
		@coupon_cap,
		@coupon_floor,
		@coupon_frequency,
		@coupon_rate,
		@coupon_type, 
		@float_spread,
		@is_callable,
		@is_fix_to_float,
		@is_putable,
		@issue_date,
		@last_reset_date,
		@maturity_date,
		@maximum_call_notice_days, 
		@maximum_put_notice_days,
		@penultimate_coupon_date,
		@reset_frequency,
		@has_position,
		@form_pf_asset_class,
		@form_pf_country,
		@form_pf_credit_rating,
		@form_pf_currency,
		@form_pf_instrument,
		@form_pf_liquid_profile,
		@form_pf_maturity,
		@form_pf_naics_code,
		@form_pf_region,
		@form_pf_sector,
		@form_pf_sub_asset_class
		)
	
	END

-------------------------------------------------------	
	-- UPDATE PROCEDURE
-------------------------------------------------------
	
	IF @Action = 'UPDATE'
	BEGIN
	update cb.ivp_polaris_securitysummary set 
	security_name=@securiry_Name , 
	security_description=@securiry_Description, 
	asset_type=@asset_type, 
	investment_type=@investment_type, 
	trading_factor=@trading_factor,
	pricing_factor=@pricing_factor, 
	last_modified_by=@last_modified_by, 
	last_modified_on=@last_modified_on,
	is_active=@is_active 
	where  security_id=@security_id
	
	update cb.ivp_polaris_securitydetails set 
	first_coupon_date=@first_coupon_date, 
	coupon_cap=@coupon_cap, 
	coupon_floor=@coupon_floor, 
	coupon_frequency=@coupon_frequency, 
	coupon_rate=@coupon_rate, 
	coupon_type=@coupon_type, 
	float_spread=@float_spread, 
	is_callable=@is_callable, 
	is_fix_to_float=@is_fix_to_float, 
	is_putable=@is_putable, 
	issue_date=@issue_date, 
	last_reset_date=@last_reset_date, 
	maturity_date=@maturity_date, 
	maximum_call_notice_days=@maximum_call_notice_days, 
	maximum_put_notice_days=@maximum_put_notice_days, 
	reset_frequency=@reset_frequency, 
	has_position=@has_position,
	form_pf_asset_class=@form_pf_asset_class,
	form_pf_country=@form_pf_country,
	form_pf_credit_rating=@form_pf_credit_rating,
	form_pf_currency=@form_pf_currency,
	form_pf_instrument=@form_pf_instrument,
	form_pf_liquidity_profile=@form_pf_liquid_profile,
	form_pf_maturity=@form_pf_maturity,
	form_pf_naics_code=@form_pf_naics_code,
	form_pf_region=@form_pf_region,
	form_pf_sector=@form_pf_sector,
	form_pf_sub_asset_class=@form_pf_sub_asset_class 
	where fk_security_id=@security_id
	print 'DONE'
	
	END

	
-------------------------------------------------------	
	-- DELETE PROCEDURE
-------------------------------------------------------
	

	IF @Action = 'DELETE'
	BEGIN
		update cb.ivp_polaris_securitysummary set is_active='FALSE' where security_id=@security_id;
	END

	IF @@TRANCOUNT >0 
	BEGIN 
	COMMIT TRANSACTION;
	SET @flag=1;
	END

	END TRY
	BEGIN CATCH
	IF @@TRANCOUNT > 0
	BEGIN
	ROLLBACK TRANSACTION;
	SET @flag=0;
	END
	END CATCH
END

GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[cb].[sp_ivp_polaris_iudfull_security]') AND type in (N'P', N'PC'))
DROP PROCEDURE cb.sp_ivp_polaris_iudfull_security

GO

/****** Object:  StoredProcedure [cb].[sp_ivp_polaris_iud_security]    Script Date: 21-Jan-15 1:18:16 PM ******/
--- Combine/Generic Store procedure for insert,update,delete --> Corporate Bond

create procedure cb.sp_ivp_polaris_iudfull_security
	(
	@action nvarchar(10),
	@securiry_name nvarchar(255) = null,
	@securiry_description nvarchar(255) = null,
	@asset_type nvarchar(100) = null,
	@investment_type nvarchar(100) = null,
	@trading_factor nvarchar(100) = null,
	@pricing_factor nvarchar(255) = null,
	@created_by nvarchar(50) = null,
	@created_on date = null,
	@last_modified_by nvarchar(50) = null,
	@last_modified_on date = null,
	@is_active bit = null,
	@first_coupon_date date = null,
	@coupon_cap nvarchar(100) = null,
	@coupon_floor nvarchar(100) = null,
	@coupon_frequency nvarchar(100) = null,
	@coupon_rate nvarchar(100) = null,
	@coupon_type nvarchar(100) = null,
	@float_spread nvarchar(100) = null,
	@is_callable bit = null,
	@is_fix_to_float bit = null,
	@is_putable bit = null,
	@issue_date date = null,
	@last_reset_date date = null,
	@maturity_date date = null,
	@maximum_call_notice_days bigint = null,
	@maximum_put_notice_days bigint = null,
	@penultimate_coupon_date date = null,
	@reset_frequency nvarchar(100) = null,
	@has_position bit = null,
	@form_pf_asset_class nvarchar(100) = null,
	@form_pf_country nvarchar(100) = null,
	@form_pf_credit_rating nvarchar(100) = null,
	@form_pf_currency nvarchar(100) = null,
	@form_pf_instrument nvarchar(100) = null,
	@form_pf_liquid_profile nvarchar(100) = null,
	@form_pf_maturity nvarchar(100) = null,
	@form_pf_naics_code nvarchar(100) = null,
	@form_pf_region nvarchar(100) = null,
	@form_pf_sector nvarchar(100) = null,
	@form_pf_sub_asset_class nvarchar(100) = null,
	@firstcouponcode nvarchar(100) = null,
	@duration nvarchar(100) = null,
	@volatility_thirtyD nvarchar(100) = null,
	@volatility_nintyD nvarchar(100) = null,
	@convexity nvarchar(100) = null,
	@average_volume_thirtyD nvarchar(100) = null,
	@issue_country nvarchar(100) = null,
	@exchange nvarchar(100) = null,
	@issuer nvarchar(100) = null,
	@issue_currency nvarchar(100) = null,
	@trading_currency nvarchar(100) = null,
	@bloomberg_industry_sub_group nvarchar(100) = null,
	@bloomberg_industry_group nvarchar(100) = null,
	@bloomberg_industry_sector nvarchar(100) = null,
	@country_of_incorporation nvarchar(100) = null,
	@risk_currency nvarchar(100) = null,
	@cusip nvarchar(100) = null,
	@isin nvarchar(100) = null,
	@sedol nvarchar(100) = null,
	@bloomberg_ticker nvarchar(100) = null,
	@bloomberg_unique_id bigint = null,
	@bloomberg_global_id bigint = null,
	@call_date date = null,
	@call_price money = null,
	@put_date date = null,
	@put_price money = null,
	@ask_price money = null,
	@high_price money = null,
	@low_price money = null,
	@open_price money = null,
	@volume bigint = null,
	@bid_price money = null,
	@last_price money = null,
	@security_id bigint output
	)
AS
BEGIN
	SET NOCOUNT ON
	
	DECLARE @flag int
	BEGIN TRY
	BEGIN TRANSACTION 
-------------------------------------------------------	
	-- INSERT PROCEDURE
-------------------------------------------------------
	
	
	IF @Action = 'INSERT'
	BEGIN
		insert into cb.ivp_polaris_securitysummary
		(
		security_name,
		security_description,
		asset_type, 
		investment_type, 
		trading_factor, 
		pricing_factor, 
		created_by, 
		created_on, 
		last_modified_by, 
		last_modified_on , 
		is_active
		) 
		values
		(
		@securiry_Name,
		@securiry_Description,
		@asset_type,
		@investment_type,
		@trading_factor,
		@pricing_factor,
		@created_by,
		@created_on,
		@last_modified_by,
		@last_modified_on,
		@is_active
		);
		
		SET @security_id=SCOPE_IDENTITY();
		
		insert into cb.ivp_polaris_securitydetails
		(
		fk_security_id,
		first_coupon_date, 
		coupon_cap, coupon_floor , 
		coupon_frequency , 
		coupon_rate , 
		coupon_type, 
		float_spread, 
		is_callable , 
		is_fix_to_float, 
		is_putable , 
		issue_date , 
		last_reset_date , 
		maturity_date , 
		maximum_call_notice_days, 
		maximum_put_notice_days , 
		penultimate_coupon_date, 
		reset_frequency , 
		has_position,
		form_pf_asset_class,
		form_pf_country,
		form_pf_credit_rating,
		form_pf_currency,
		form_pf_instrument,
		form_pf_liquidity_profile,
		form_pf_maturity,
		form_pf_naics_code,
		form_pf_region,
		form_pf_sector,
		form_pf_sub_asset_class
		 )
		values
		(
		@security_id,
		@first_coupon_date,
		@coupon_cap,
		@coupon_floor,
		@coupon_frequency,
		@coupon_rate,
		@coupon_type, 
		@float_spread,
		@is_callable,
		@is_fix_to_float,
		@is_putable,
		@issue_date,
		@last_reset_date,
		@maturity_date,
		@maximum_call_notice_days, 
		@maximum_put_notice_days,
		@penultimate_coupon_date,
		@reset_frequency,
		@has_position,
		@form_pf_asset_class,
		@form_pf_country,
		@form_pf_credit_rating,
		@form_pf_currency,
		@form_pf_instrument,
		@form_pf_liquid_profile,
		@form_pf_maturity,
		@form_pf_naics_code,
		@form_pf_region,
		@form_pf_sector,
		@form_pf_sub_asset_class
		)

		insert into cb.ivp_polaris_risk(
		fk_security_id,
		firstcouponcode,
		duration,
		volatility_thirtyD,
		volatility_nintyD,
		convexity,
		average_volume_thirtyD
		)
		values
		(
		@security_id,
		@firstcouponcode,
		@duration,
		@volatility_thirtyD,
		@volatility_nintyD,
		@convexity,
		@average_volume_thirtyD
		);

		insert into core.ivp_polaris_core_securityitentifier(
		fk_security_id,
		cusip,
		isin,
		sedol,
		bloomberg_ticker,
		bloomberg_unique_id,
		bloomberg_global_id
		)
		values
		(
		@security_id,
		@cusip,
		@isin,
		@sedol,
		@bloomberg_ticker,
		@bloomberg_unique_id,
		@bloomberg_global_id
		);

		insert into core.ivp_polaris_core_referencedata(
		fk_security_id,
		issue_country,
		exchange,
		issuer,
		issue_currency,
		trading_currency,
		bloomberg_industry_sub_group,
		bloomberg_industry_group,
		bloomberg_industry_sector,
		country_of_incorporation,
		risk_currency)
		values
		(
		@security_id,
		@issue_country,
		@exchange,
		@issuer,
		@issue_currency,
		@trading_currency,
		@bloomberg_industry_sub_group,
		@bloomberg_industry_group,
		@bloomberg_industry_sector,
		@country_of_incorporation,
		@risk_currency
		);

		insert into cb.ivp_polaris_putschedule(
		fk_security_id,
		put_date,
		put_price
		) 
		values(
		@security_id,
		@put_date,
		@put_price
		);


		insert into cb.ivp_polaris_pricingandanalytics(
		fk_security_id,
		ask_price,
		high_price,
		low_price,
		open_price,
		volume,
		bid_price,
		last_price
		)
		values
		(
		@security_id,
		@ask_price,
		@high_price,
		@low_price,
		@open_price,
		@volume,
		@bid_price,
		@last_price
		);

		insert into cb.ivp_polaris_callschedule(
		fk_security_id,
		call_date,
		call_price
		)
		values
		(
		@security_id,
		@call_date,
		@call_price
		);

	
	END

-------------------------------------------------------	
	-- UPDATE PROCEDURE
-------------------------------------------------------
	
	IF @Action = 'UPDATE'
	BEGIN
	update cb.ivp_polaris_securitysummary set 
	security_name=@securiry_Name , 
	security_description=@securiry_Description, 
	asset_type=@asset_type, 
	investment_type=@investment_type, 
	trading_factor=@trading_factor,
	pricing_factor=@pricing_factor, 
	last_modified_by=@last_modified_by, 
	last_modified_on=@last_modified_on,
	is_active=@is_active 
	where  security_id=@security_id
	
	update cb.ivp_polaris_securitydetails set 
	first_coupon_date=@first_coupon_date, 
	coupon_cap=@coupon_cap, 
	coupon_floor=@coupon_floor, 
	coupon_frequency=@coupon_frequency, 
	coupon_rate=@coupon_rate, 
	coupon_type=@coupon_type, 
	float_spread=@float_spread, 
	is_callable=@is_callable, 
	is_fix_to_float=@is_fix_to_float, 
	is_putable=@is_putable, 
	issue_date=@issue_date, 
	last_reset_date=@last_reset_date, 
	maturity_date=@maturity_date, 
	maximum_call_notice_days=@maximum_call_notice_days, 
	maximum_put_notice_days=@maximum_put_notice_days, 
	reset_frequency=@reset_frequency, 
	has_position=@has_position,
	form_pf_asset_class=@form_pf_asset_class,
	form_pf_country=@form_pf_country,
	form_pf_credit_rating=@form_pf_credit_rating,
	form_pf_currency=@form_pf_currency,
	form_pf_instrument=@form_pf_instrument,
	form_pf_liquidity_profile=@form_pf_liquid_profile,
	form_pf_maturity=@form_pf_maturity,
	form_pf_naics_code=@form_pf_naics_code,
	form_pf_region=@form_pf_region,
	form_pf_sector=@form_pf_sector,
	form_pf_sub_asset_class=@form_pf_sub_asset_class 
	where fk_security_id=@security_id

	update cb.ivp_polaris_risk set 
	firstcouponcode=@firstcouponcode,
	duration=@duration,
	volatility_thirtyD=@volatility_thirtyD,
	volatility_nintyD=@volatility_nintyD,
	convexity=@convexity,
	average_volume_thirtyD=@average_volume_thirtyD
	where fk_security_id=@security_id;

	update core.ivp_polaris_core_securityitentifier set
	cusip = @cusip,
	isin=@isin,
	sedol=@sedol,
	bloomberg_ticker=@bloomberg_ticker,
	bloomberg_unique_id=@bloomberg_unique_id,
	bloomberg_global_id=@bloomberg_global_id
	where fk_security_id=@security_id

	update core.ivp_polaris_core_referencedata set
	issue_country=@issue_country,
	exchange=@exchange,
	issuer=@issuer,
	issue_currency=@issue_currency,
	trading_currency=@trading_currency,
	bloomberg_industry_sub_group=@bloomberg_industry_sub_group,
	bloomberg_industry_group=@bloomberg_industry_group,
	bloomberg_industry_sector = @bloomberg_industry_sector,
	country_of_incorporation=@country_of_incorporation,
	risk_currency=@risk_currency
	where fk_security_id=@security_id

	update cb.ivp_polaris_putschedule set 
	put_date=@put_date,
	put_price=@put_price
	where fk_security_id=@security_id

	update cb.ivp_polaris_pricingandanalytics set 
	ask_price=@ask_price,
	high_price=@high_price,
	low_price=@low_price,
	open_price=@open_price,
	volume=@volume,
	bid_price=@bid_price,
	last_price=@last_price
	where fk_security_id=@security_id

	update cb.ivp_polaris_callschedule set 
	call_date=@call_date,
	call_price=@call_price
	where fk_security_id=@security_id

	print 'DONE'
	END

	
-------------------------------------------------------	
	-- DELETE PROCEDURE
-------------------------------------------------------
	

	IF @Action = 'DELETE'
	BEGIN
		update cb.ivp_polaris_securitysummary set is_active='FALSE' where security_id=@security_id;
	END

	IF @@TRANCOUNT >0 
	BEGIN 
	COMMIT TRANSACTION;
	SET @flag=1;
	END

	END TRY
	BEGIN CATCH
	IF @@TRANCOUNT > 0
	BEGIN
	ROLLBACK TRANSACTION;
	SET @flag=0;
	END
	END CATCH
END

GO

-------------------------------------------------------	
	-- INSERT QUERIES
-------------------------------------------------------
	
-------------------------------------------------------	
	-- CORE QUERIES
-------------------------------------------------------
	
insert into core.ivp_polaris_core_sectype_id(sectype_name,sectype_description,created_by,created_on,last_modified_by,last_modified_on) values('EQUITY','Equity SHARES','jaskeerat',GETDATE(),'xyz',GETDATE());

GO

insert into core.ivp_polaris_core_sectype_id(sectype_name,sectype_description,created_by,created_on,last_modified_by,last_modified_on) values('Bonds',' Corporate Bonds','jaskeerat',GETDATE(),'xyz',GETDATE());

GO

insert into core.ivp_polaris_core_mastersecurity(table_name,sectype_id) values('ivp_polaris_securitysummary',1)

GO

insert into core.ivp_polaris_core_securityitentifier(cusip,isin,sedol,bloomberg_ticker,bloomberg_unique_id,bloomberg_global_id)
values('cusip','10524','sedol','ticker',102214,457554);

GO

insert into core.ivp_polaris_core_referencedata(issue_country,exchange,issuer,issue_currency,trading_currency,bloomberg_industry_sub_group,bloomberg_industry_group,bloomberg_industry_sector,country_of_incorporation,risk_currency)
values
('US','MAIL','GOVT','DOLLER','INR','SUB_GROUP','IND_GROUP','IND_SECTOR','US-INDIA','NONE');

GO

-------------------------------------------------------	
	-- EQUITY QUERIES
-------------------------------------------------------

GO
	
insert into eq.ivp_polaris_securitysummary(securiry_name,securiry_description,has_position,is_active,round_lot_size,bloomberg_unique_name,created_by,created_on,last_modified_by,last_modified_on)
values
('EQUITY','EQUITY SHARES','TRUE','TRUE',1,'BLOOMBERG','jaskeerat',GETDATE(),'xyz',GETDATE());

GO

insert into eq.ivp_polaris_securitydetails(fk_security_id,is_adr,adr_underlying_ticker,adr_underlying_currency,shares_per_adr,ipo_date,price_currency,settle_days,shares_outstanding,voting_rights_per_share,form_pf_asset_class,form_pf_country,form_pf_credit_rating,form_pf_currency,form_pf_instrument,form_pf_liquid_profile,form_pf_maturity,form_pf_naics_code,form_pf_region,form_pf_sector,form_pf_sub_asset_class)
values
(100,'TRUE','tickter','INR','100',GETDATE(),'100',20,'N','500','assets','INDIA','NONE','INR','INST','PRO','10 END','NICS','DELHI','SECTOR','SUB_ASSETS');

GO

insert into eq.ivp_polaris_risk(fk_security_id,twenty_day_average_volume,beta,short_interest,ytd_return,ninty_day_price_volatility)
values
(100,'LACKS','NONE','INR','RETURN','VALALITY');

GO

insert into eq.ivp_polaris_pricingdetails(fk_security_id,open_price,close_price,volume,last_price,ask_price,bid_price,pe_ratio)
values
(100,20,15,1000,22,14,16,'10');

GO

insert into eq.ivp_polaris_dividendhistory(fk_security_id,declared_date,ex_date,record_date,pay_date,amount,frequency,dividend_type)
values
(100,GETDATE(),GETDATE(),GETDATE(),GETDATE(),2000,'FRE','TYPE');

GO

-------------------------------------------------------	
	-- CORPORATE BONDS QUERIES
-------------------------------------------------------

GO
	
insert into cb.ivp_polaris_securitysummary(security_name,security_description,asset_type,investment_type,trading_factor,pricing_factor,created_by,created_on,last_modified_by,last_modified_on,is_active)
values
('CORPORATE BONDS','CORPORATE','DEBANTURES','FIXED','NONE','REGULAR','Jaskeerat',GETDATE(),'xyz',GETDATE(),'TRUE');

GO

insert into cb.ivp_polaris_securitydetails( fk_security_id,first_coupon_date,coupon_cap,coupon_floor,coupon_frequency,coupon_rate,coupon_type,float_spread,is_callable,is_fix_to_float,is_putable,issue_date,last_reset_date,maturity_date,maximum_call_notice_days,maximum_put_notice_days,penultimate_coupon_date,reset_frequency,has_position,form_pf_asset_class,form_pf_country,form_pf_credit_rating,form_pf_currency,form_pf_instrument,form_pf_liquidity_profile,form_pf_maturity,form_pf_naics_code,form_pf_region,form_pf_sector,form_pf_sub_asset_class)
values
(100000,GETDATE(),'CAP','FLOOR','FREQUENCY','RATE','TYPE','FLOAT','TRUE','FALSE','TRUE',GETDATE(),GETDATE(),GETDATE(),10,5,GETDATE(),'NONE','TRUE','assets','INDIA','NONE','INR','INST','PRO','10 END','NICS','DELHI','SECTOR','SUB_ASSETS');

GO

insert into cb.ivp_polaris_risk(fk_security_id,firstcouponcode,duration,volatility_thirtyD,volatility_nintyD,convexity,average_volume_thirtyD)
values
(100000,'COUPON','10','20','40','BO','si');

GO

insert into cb.ivp_polaris_putschedule(fk_security_id,put_date,put_price) 
values(100000,GETDATE(),100);

GO

insert into cb.ivp_polaris_pricingandanalytics(fk_security_id,ask_price,high_price,low_price,open_price,volume,bid_price,last_price)
values
(100000,20,30,15,22,10,25,27);

GO

insert into cb.ivp_polaris_callschedule(fk_security_id,call_date,call_price)
values
(100000,GETDATE(),100);

GO


-------------------------------------------------------	
	-- STORED PROCEDURE QUERIES
-------------------------------------------------------

-------------------------------------------------------	
	-- ENTITY
-------------------------------------------------------

GO

DECLARE @SECID bigint
exec eq.sp_ivp_polaris_iud_security 'INSERT','EQU0','EQUAL','POS','TRUE','LOT','B_NAME1','ADR','TICKTER','INR','SHR','2015-01-20','US',10,'OUT','VOTING','assets','IND','CR','INR','INSTR','LIQPRO','MATURITY','naics','REGIN','SECTOR','SUB_ASSETS','jaskeerat','2015-01-20','XYZ','2015-01-20',@SECID out;
print @SECID;

GO

DECLARE @SECID bigint=101
exec eq.sp_ivp_polaris_iud_security 'UPDATE','EQU0','EQUAL','POS','TRUE','LOT','B_NAME1','ADR','TICKTER','INR','SHR','2015-01-20','US',10,'OUT','VOTING','assets','IND','CR','INR','INSTR','LIQPRO','MATURITY','naics','REGIN','SECTOR','SUB_ASSETS','jaskeerat','2015-01-20','XYZ','2015-01-20',@SECID out;
print @SECID;

GO

DECLARE @SECID bigint=101
exec eq.sp_ivp_polaris_iud_security @action='DELETE',  @security_id=@SECID out;
print @SECID;

-------------------------------------------------------	
	-- CORPORATE BOND
-------------------------------------------------------

GO

DECLARE @SECID bigint
exec cb.sp_ivp_polaris_iud_security
'INSERT','SEQ','DESC','BOND','FIXED','FACTOR','PRICE','2015-01-20','CAP','FLOOR','FREQ','RATE','TYPE','FLOAT','Y','N','Y','2015-01-20','2015-01-20','2015-01-20',20,10,'2015-01-20','FREQ','500','assets','INDIA','NONE','INR','INST','PRO','10 END','NICS','DELHI','SECTOR','SUB_ASSETS','jaskeerat','2015-01-20','XYZ','2015-01-20','true',@SECID out;
print @SECID;

GO

DECLARE @SECID bigint=100001
exec cb.sp_ivp_polaris_iud_security
'UPDATE','SEQ','DESC','BOND','FIXED','FACTOR','PRICE','2015-01-20','CAP','FLOOR','FREQ','RATE','TYPE','FLOAT','Y','N','Y','2015-01-20','2015-01-20','2015-01-20',20,10,'2015-01-20','FREQ','500','assets','INDIA','NONE','INR','INST','PRO','10 END','NICS','DELHI','SECTOR','SUB_ASSETS','jaskeerat','2015-01-20','XYZ','2015-01-20','true',@SECID out;
print @SECID;

GO

DECLARE @SECID bigint=100001
exec cb.sp_ivp_polaris_iud_security @action='DELETE',  @security_id=@SECID out;
print @SECID;


-------------------------------------------------------	
	-- INDEXED
-------------------------------------------------------

CREATE INDEX in_polaris_core_sectype_id ON core.ivp_polaris_core_mastersecurity(sectype_id);

-- SECID COLUMN NOT EXIST IN secuiryidentifier and referencedata TABLE
--Secid of secuiryidentifier\ and referencedata which r global to both 
