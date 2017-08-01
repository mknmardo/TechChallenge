# TechChallenge

Solution Name: WH.RiskApplication.TechChallenge (Swagger Enabled)

Developer: Mark Kenneth N. Mardo


Note: To test the API please use SWAGGER. 
Link: /swagger/ui/index#/


Projects:

WH.RiskApplication.TechChallenge.API 
	
	-Controller

		-BetController.cs
			
			-Route Prefix: "api/"bet"
			
			endpoints:
				-/unusualbetwinners   (Get all unusual bet winners)
				-/betanalysis 	(Analyze unsettled bets based on Betting history)
				-/analysisresults  (returns both unusualbetWinners & betAnalysis)
			

WH.RiskApplication.TechChallenge.API.IntegrationTests

	-End to End testing comsuming the Owin Self-Hosted API

WH.RiskApplication.TechChallenge.Business

	-Business Logic Layer
	
	impl (implementing class)
		-BetManager.cs
	interfaces
		-IBetManager.cs

	using dependency injection via constructor injection
	   

WH.RiskApplication.TechChallenge.Business.Tests
	
	-Sample Test methods using Moq and Autofixtures to Mock dependencies


WH.RiskApplication.TechChallenge.Common
	
	Common Classes (Model) used by all projects inside the solution

		Models
			-BetAnalysisModel.cs
			-BetDetailsModel.cs
			-UnusualWinnerModel.cs
		ViewModels
			
			ResultsViewModel



WH.RiskApplication.TechChallenge.DAL

	Data Layer
		
		impl
			-BetDALManager.cs
		interfaces
			-IBetDALManager.cs

	using dependency injection via constructor injection
	

WH.RiskApplication.TechChallenge.Utils

	Utilities Layer

		-HttpHelper.cs
			-Generic Class handling all the http requests (GET,POST,PUT,DELETE)





