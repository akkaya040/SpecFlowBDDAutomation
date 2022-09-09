﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SpecFlowAutomation.Specs.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Xunit.TraitAttribute("Category", "Automation")]
    [Xunit.TraitAttribute("Category", "Login")]
    [Xunit.TraitAttribute("Category", "retry")]
    public partial class LoginFeature : object, Xunit.IClassFixture<LoginFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "Automation",
                "Login",
                "retry"};
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Login.feature"
#line hidden
        
        public LoginFeature(LoginFeature.FixtureData fixtureData, SpecFlowAutomation_Specs_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Login", null, ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 7
    #line hidden
#line 8
        testRunner.Given("User navigates to env: QA", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.TraitAttribute("FeatureTitle", "Login")]
        [Xunit.TraitAttribute("Description", "Landing To Login Page")]
        [xRetry.RetryFact(3, 0, new System.Type[] {
                typeof(Xunit.SkipException)}, DisplayName="Landing To Login Page")]
        [Xunit.TraitAttribute("Category", "Smoke")]
        public void LandingToLoginPage()
        {
            string[] tagsOfScenario = new string[] {
                    "Smoke"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Landing To Login Page", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 11
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
    this.FeatureBackground();
#line hidden
#line 12
        testRunner.And("User should see that page title contains \"Swag Labs\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.TraitAttribute("FeatureTitle", "Login")]
        [Xunit.TraitAttribute("Description", "Logins With Different User Credentials From File")]
        [xRetry.RetryTheory(3, 0, new System.Type[] {
                typeof(Xunit.SkipException)}, DisplayName="Logins With Different User Credentials From File")]
        [Xunit.TraitAttribute("Category", "LoginTestUsingDataSource")]
        [Xunit.TraitAttribute("Category", "DataSource:../Data/userdata.xlsx")]
        [Xunit.TraitAttribute("Category", "DataSet:Sheet1")]
        [Xunit.InlineDataAttribute("", "", "Username is required", new string[0])]
        [Xunit.InlineDataAttribute("test", "", "Password is required", new string[0])]
        [Xunit.InlineDataAttribute("test", "test", "Username and password do not match any user in this service", new string[0])]
        [Xunit.InlineDataAttribute("locked_out_user", "secret_sauce", "Sorry, this user has been locked out.", new string[0])]
        [Xunit.InlineDataAttribute("standard_user", "secret_sauce", "", new string[0])]
        [Xunit.InlineDataAttribute("problem_user", "secret_sauce", "", new string[0])]
        [Xunit.InlineDataAttribute("performance_glitch_user", "secret_sauce", "", new string[0])]
        public void LoginsWithDifferentUserCredentialsFromFile(string username, string userpass, string expectedMessage, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "LoginTestUsingDataSource",
                    "DataSource:../Data/userdata.xlsx",
                    "DataSet:Sheet1"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("username", username);
            argumentsOfScenario.Add("userpass", userpass);
            argumentsOfScenario.Add("expectedMessage", expectedMessage);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Logins With Different User Credentials From File", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 17
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
    this.FeatureBackground();
#line hidden
#line 18
        testRunner.And("User should see that page title contains \"Swag Labs\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line hidden
#line 19
        testRunner.And(string.Format("User fills username as \"{0}\"", username), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 20
        testRunner.And(string.Format("User fills password as \"{0}\"", userpass), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 21
        testRunner.And("User clicks login button in the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 22
        testRunner.And(string.Format("User should see \"{0}\" message", expectedMessage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.TraitAttribute("FeatureTitle", "Login")]
        [Xunit.TraitAttribute("Description", "Logins With Different User Credentials Table")]
        [xRetry.RetryTheory(3, 0, new System.Type[] {
                typeof(Xunit.SkipException)}, DisplayName="Logins With Different User Credentials Table")]
        [Xunit.TraitAttribute("Category", "userLogin")]
        [Xunit.InlineDataAttribute("", "", "Username is required", new string[0])]
        [Xunit.InlineDataAttribute("test", "", "Password is required", new string[0])]
        [Xunit.InlineDataAttribute("test", "test", "Username and password do not match any user in this service", new string[0])]
        [Xunit.InlineDataAttribute("locked_out_user", "secret_sauce", "Sorry, this user has been locked out.", new string[0])]
        [Xunit.InlineDataAttribute("standard_user", "secret_sauce", "", new string[0])]
        [Xunit.InlineDataAttribute("problem_user", "secret_sauce", "", new string[0])]
        [Xunit.InlineDataAttribute("performance_glitch_user", "secret_sauce", "", new string[0])]
        public void LoginsWithDifferentUserCredentialsTable(string username, string userpass, string expectedMessage, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "userLogin"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("username", username);
            argumentsOfScenario.Add("userpass", userpass);
            argumentsOfScenario.Add("expectedMessage", expectedMessage);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Logins With Different User Credentials Table", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 25
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
    this.FeatureBackground();
#line hidden
#line 26
        testRunner.And("User should see that page title contains \"Swag Labs\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line hidden
#line 27
        testRunner.And(string.Format("User fills username as \"{0}\"", username), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 28
        testRunner.And(string.Format("User fills password as \"{0}\"", userpass), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 29
        testRunner.And("User clicks login button in the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 30
        testRunner.And(string.Format("User should see \"{0}\" message", expectedMessage), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.TraitAttribute("FeatureTitle", "Login")]
        [Xunit.TraitAttribute("Description", "Login With Correct Username And Password")]
        [xRetry.RetryFact(3, 0, new System.Type[] {
                typeof(Xunit.SkipException)}, DisplayName="Login With Correct Username And Password")]
        [Xunit.TraitAttribute("Category", "Positive")]
        [Xunit.TraitAttribute("Category", "LoginWithCorrectUsernameAndPassword")]
        public void LoginWithCorrectUsernameAndPassword()
        {
            string[] tagsOfScenario = new string[] {
                    "Positive",
                    "LoginWithCorrectUsernameAndPassword"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login With Correct Username And Password", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 44
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
    this.FeatureBackground();
#line hidden
#line 45
        testRunner.And("User should see that page title contains \"Swag Labs\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line hidden
#line 46
        testRunner.And("User fills username as \"standard_user\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 47
        testRunner.And("User fills password as \"secret_sauce\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 48
        testRunner.And("User clicks login button in the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 49
        testRunner.And("User should see \"\" message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.TraitAttribute("FeatureTitle", "Login")]
        [Xunit.TraitAttribute("Description", "Login With Correct Username Wrong Password")]
        [xRetry.RetryFact(3, 0, new System.Type[] {
                typeof(Xunit.SkipException)}, DisplayName="Login With Correct Username Wrong Password")]
        [Xunit.TraitAttribute("Category", "Negative")]
        [Xunit.TraitAttribute("Category", "LoginWithWrongPassword")]
        public void LoginWithCorrectUsernameWrongPassword()
        {
            string[] tagsOfScenario = new string[] {
                    "Negative",
                    "LoginWithWrongPassword"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login With Correct Username Wrong Password", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 53
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
    this.FeatureBackground();
#line hidden
#line 54
        testRunner.And("User should see that page title contains \"Swag Labs\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line hidden
#line 55
        testRunner.And("User fills username as \"standard_user\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 56
        testRunner.And("User fills password as \"secret_sauce_asd\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 57
        testRunner.And("User clicks login button in the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 58
        testRunner.And("User should see \"Username and password do not match any user in this service\" mes" +
                        "sage", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.TraitAttribute("FeatureTitle", "Login")]
        [Xunit.TraitAttribute("Description", "Login Without Password")]
        [xRetry.RetryFact(3, 0, new System.Type[] {
                typeof(Xunit.SkipException)}, DisplayName="Login Without Password")]
        [Xunit.TraitAttribute("Category", "Negative")]
        [Xunit.TraitAttribute("Category", "LoginWithoutPassword")]
        public void LoginWithoutPassword()
        {
            string[] tagsOfScenario = new string[] {
                    "Negative",
                    "LoginWithoutPassword"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login Without Password", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 62
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
    this.FeatureBackground();
#line hidden
#line 63
        testRunner.And("User should see that page title contains \"Swag Labs\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line hidden
#line 64
        testRunner.And("User fills username as \"standard_user\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 65
        testRunner.And("User fills password as \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 66
        testRunner.And("User clicks login button in the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 67
        testRunner.And("User should see \"Password is required\" message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.TraitAttribute("FeatureTitle", "Login")]
        [Xunit.TraitAttribute("Description", "Login Without Username")]
        [xRetry.RetryFact(3, 0, new System.Type[] {
                typeof(Xunit.SkipException)}, DisplayName="Login Without Username")]
        [Xunit.TraitAttribute("Category", "Negative")]
        [Xunit.TraitAttribute("Category", "LoginWithoutUsername")]
        public void LoginWithoutUsername()
        {
            string[] tagsOfScenario = new string[] {
                    "Negative",
                    "LoginWithoutUsername"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login Without Username", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 71
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
    this.FeatureBackground();
#line hidden
#line 72
        testRunner.And("User should see that page title contains \"Swag Labs\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line hidden
#line 73
        testRunner.And("User fills username as \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 74
        testRunner.And("User fills password as \"secret_sauce\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 75
        testRunner.And("User clicks login button in the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 76
        testRunner.And("User should see \"Username is required\" message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.TraitAttribute("FeatureTitle", "Login")]
        [Xunit.TraitAttribute("Description", "Login With Locked Out User")]
        [xRetry.RetryFact(3, 0, new System.Type[] {
                typeof(Xunit.SkipException)}, DisplayName="Login With Locked Out User")]
        [Xunit.TraitAttribute("Category", "Negative")]
        [Xunit.TraitAttribute("Category", "LoginWithLockedOutUser")]
        public void LoginWithLockedOutUser()
        {
            string[] tagsOfScenario = new string[] {
                    "Negative",
                    "LoginWithLockedOutUser"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login With Locked Out User", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 80
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
    this.FeatureBackground();
#line hidden
#line 81
        testRunner.And("User should see that page title contains \"Swag Labs\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line hidden
#line 82
        testRunner.And("User fills username as \"locked_out_user\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 83
        testRunner.And("User fills password as \"secret_sauce\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 84
        testRunner.And("User clicks login button in the page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 85
        testRunner.And("User should see \"Sorry, this user has been locked out.\" message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "* ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                LoginFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                LoginFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
