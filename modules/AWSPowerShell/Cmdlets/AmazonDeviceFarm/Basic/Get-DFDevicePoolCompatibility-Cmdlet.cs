/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;

namespace Amazon.PowerShell.Cmdlets.DF
{
    /// <summary>
    /// Gets information about compatibility with a device pool.
    /// </summary>
    [Cmdlet("Get", "DFDevicePoolCompatibility")]
    [OutputType("Amazon.DeviceFarm.Model.GetDevicePoolCompatibilityResponse")]
    [AWSCmdlet("Calls the AWS Device Farm GetDevicePoolCompatibility API operation.", Operation = new[] {"GetDevicePoolCompatibility"})]
    [AWSCmdletOutput("Amazon.DeviceFarm.Model.GetDevicePoolCompatibilityResponse",
        "This cmdlet returns a Amazon.DeviceFarm.Model.GetDevicePoolCompatibilityResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetDFDevicePoolCompatibilityCmdlet : AmazonDeviceFarmClientCmdlet, IExecutor
    {
        
        #region Parameter AppArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the app that is associated with the specified device pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AppArn { get; set; }
        #endregion
        
        #region Parameter DevicePoolArn
        /// <summary>
        /// <para>
        /// <para>The device pool's ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DevicePoolArn { get; set; }
        #endregion
        
        #region Parameter Test_Filter
        /// <summary>
        /// <para>
        /// <para>The test's filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Test_Filter { get; set; }
        #endregion
        
        #region Parameter Test_Parameter
        /// <summary>
        /// <para>
        /// <para>The test's parameters, such as the following test framework parameters and fixture
        /// settings:</para><para>For Calabash tests:</para><ul><li><para>profile: A cucumber profile, for example, "my_profile_name".</para></li><li><para>tags: You can limit execution to features or scenarios that have (or don't have) certain
        /// tags, for example, "@smoke" or "@smoke,~@wip".</para></li></ul><para>For Appium tests (all types):</para><ul><li><para>appium_version: The Appium version. Currently supported values are "1.4.16", "1.6.3",
        /// "latest", and "default".</para><ul><li><para>“latest” will run the latest Appium version supported by Device Farm (1.6.3).</para></li><li><para>For “default”, Device Farm will choose a compatible version of Appium for the device.
        /// The current behavior is to run 1.4.16 on Android devices and iOS 9 and earlier, 1.6.3
        /// for iOS 10 and later.</para></li><li><para>This behavior is subject to change.</para></li></ul></li></ul><para>For Fuzz tests (Android only):</para><ul><li><para>event_count: The number of events, between 1 and 10000, that the UI fuzz test should
        /// perform.</para></li><li><para>throttle: The time, in ms, between 0 and 1000, that the UI fuzz test should wait between
        /// events.</para></li><li><para>seed: A seed to use for randomizing the UI fuzz test. Using the same seed value between
        /// tests ensures identical event sequences.</para></li></ul><para>For Explorer tests:</para><ul><li><para>username: A username to use if the Explorer encounters a login form. If not supplied,
        /// no username will be inserted.</para></li><li><para>password: A password to use if the Explorer encounters a login form. If not supplied,
        /// no password will be inserted.</para></li></ul><para>For Instrumentation:</para><ul><li><para>filter: A test filter string. Examples:</para><ul><li><para>Running a single test case: "com.android.abc.Test1"</para></li><li><para>Running a single test: "com.android.abc.Test1#smoke"</para></li><li><para>Running multiple tests: "com.android.abc.Test1,com.android.abc.Test2"</para></li></ul></li></ul><para>For XCTest and XCTestUI:</para><ul><li><para>filter: A test filter string. Examples:</para><ul><li><para>Running a single test class: "LoginTests"</para></li><li><para>Running a multiple test classes: "LoginTests,SmokeTests"</para></li><li><para>Running a single test: "LoginTests/testValid"</para></li><li><para>Running multiple tests: "LoginTests/testValid,LoginTests/testInvalid"</para></li></ul></li></ul><para>For UIAutomator:</para><ul><li><para>filter: A test filter string. Examples:</para><ul><li><para>Running a single test case: "com.android.abc.Test1"</para></li><li><para>Running a single test: "com.android.abc.Test1#smoke"</para></li><li><para>Running multiple tests: "com.android.abc.Test1,com.android.abc.Test2"</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Test_Parameters")]
        public System.Collections.Hashtable Test_Parameter { get; set; }
        #endregion
        
        #region Parameter Test_TestPackageArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the uploaded test that will be run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Test_TestPackageArn { get; set; }
        #endregion
        
        #region Parameter TestType
        /// <summary>
        /// <para>
        /// <para>The test type for the specified device pool.</para><para>Allowed values include the following:</para><ul><li><para>BUILTIN_FUZZ: The built-in fuzz type.</para></li><li><para>BUILTIN_EXPLORER: For Android, an app explorer that will traverse an Android app,
        /// interacting with it and capturing screenshots at the same time.</para></li><li><para>APPIUM_JAVA_JUNIT: The Appium Java JUnit type.</para></li><li><para>APPIUM_JAVA_TESTNG: The Appium Java TestNG type.</para></li><li><para>APPIUM_PYTHON: The Appium Python type.</para></li><li><para>APPIUM_WEB_JAVA_JUNIT: The Appium Java JUnit type for Web apps.</para></li><li><para>APPIUM_WEB_JAVA_TESTNG: The Appium Java TestNG type for Web apps.</para></li><li><para>APPIUM_WEB_PYTHON: The Appium Python type for Web apps.</para></li><li><para>CALABASH: The Calabash type.</para></li><li><para>INSTRUMENTATION: The Instrumentation type.</para></li><li><para>UIAUTOMATION: The uiautomation type.</para></li><li><para>UIAUTOMATOR: The uiautomator type.</para></li><li><para>XCTEST: The XCode test type.</para></li><li><para>XCTEST_UI: The XCode UI test type.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DeviceFarm.TestType")]
        public Amazon.DeviceFarm.TestType TestType { get; set; }
        #endregion
        
        #region Parameter Test_Type
        /// <summary>
        /// <para>
        /// <para>The test's type.</para><para>Must be one of the following values:</para><ul><li><para>BUILTIN_FUZZ: The built-in fuzz type.</para></li><li><para>BUILTIN_EXPLORER: For Android, an app explorer that will traverse an Android app,
        /// interacting with it and capturing screenshots at the same time.</para></li><li><para>APPIUM_JAVA_JUNIT: The Appium Java JUnit type.</para></li><li><para>APPIUM_JAVA_TESTNG: The Appium Java TestNG type.</para></li><li><para>APPIUM_PYTHON: The Appium Python type.</para></li><li><para>APPIUM_WEB_JAVA_JUNIT: The Appium Java JUnit type for Web apps.</para></li><li><para>APPIUM_WEB_JAVA_TESTNG: The Appium Java TestNG type for Web apps.</para></li><li><para>APPIUM_WEB_PYTHON: The Appium Python type for Web apps.</para></li><li><para>CALABASH: The Calabash type.</para></li><li><para>INSTRUMENTATION: The Instrumentation type.</para></li><li><para>UIAUTOMATION: The uiautomation type.</para></li><li><para>UIAUTOMATOR: The uiautomator type.</para></li><li><para>XCTEST: The XCode test type.</para></li><li><para>XCTEST_UI: The XCode UI test type.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DeviceFarm.TestType")]
        public Amazon.DeviceFarm.TestType Test_Type { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AppArn = this.AppArn;
            context.DevicePoolArn = this.DevicePoolArn;
            context.Test_Filter = this.Test_Filter;
            if (this.Test_Parameter != null)
            {
                context.Test_Parameters = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Test_Parameter.Keys)
                {
                    context.Test_Parameters.Add((String)hashKey, (String)(this.Test_Parameter[hashKey]));
                }
            }
            context.Test_TestPackageArn = this.Test_TestPackageArn;
            context.Test_Type = this.Test_Type;
            context.TestType = this.TestType;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.DeviceFarm.Model.GetDevicePoolCompatibilityRequest();
            
            if (cmdletContext.AppArn != null)
            {
                request.AppArn = cmdletContext.AppArn;
            }
            if (cmdletContext.DevicePoolArn != null)
            {
                request.DevicePoolArn = cmdletContext.DevicePoolArn;
            }
            
             // populate Test
            bool requestTestIsNull = true;
            request.Test = new Amazon.DeviceFarm.Model.ScheduleRunTest();
            System.String requestTest_test_Filter = null;
            if (cmdletContext.Test_Filter != null)
            {
                requestTest_test_Filter = cmdletContext.Test_Filter;
            }
            if (requestTest_test_Filter != null)
            {
                request.Test.Filter = requestTest_test_Filter;
                requestTestIsNull = false;
            }
            Dictionary<System.String, System.String> requestTest_test_Parameter = null;
            if (cmdletContext.Test_Parameters != null)
            {
                requestTest_test_Parameter = cmdletContext.Test_Parameters;
            }
            if (requestTest_test_Parameter != null)
            {
                request.Test.Parameters = requestTest_test_Parameter;
                requestTestIsNull = false;
            }
            System.String requestTest_test_TestPackageArn = null;
            if (cmdletContext.Test_TestPackageArn != null)
            {
                requestTest_test_TestPackageArn = cmdletContext.Test_TestPackageArn;
            }
            if (requestTest_test_TestPackageArn != null)
            {
                request.Test.TestPackageArn = requestTest_test_TestPackageArn;
                requestTestIsNull = false;
            }
            Amazon.DeviceFarm.TestType requestTest_test_Type = null;
            if (cmdletContext.Test_Type != null)
            {
                requestTest_test_Type = cmdletContext.Test_Type;
            }
            if (requestTest_test_Type != null)
            {
                request.Test.Type = requestTest_test_Type;
                requestTestIsNull = false;
            }
             // determine if request.Test should be set to null
            if (requestTestIsNull)
            {
                request.Test = null;
            }
            if (cmdletContext.TestType != null)
            {
                request.TestType = cmdletContext.TestType;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.DeviceFarm.Model.GetDevicePoolCompatibilityResponse CallAWSServiceOperation(IAmazonDeviceFarm client, Amazon.DeviceFarm.Model.GetDevicePoolCompatibilityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Device Farm", "GetDevicePoolCompatibility");
            try
            {
                #if DESKTOP
                return client.GetDevicePoolCompatibility(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetDevicePoolCompatibilityAsync(request);
                return task.Result;
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String AppArn { get; set; }
            public System.String DevicePoolArn { get; set; }
            public System.String Test_Filter { get; set; }
            public Dictionary<System.String, System.String> Test_Parameters { get; set; }
            public System.String Test_TestPackageArn { get; set; }
            public Amazon.DeviceFarm.TestType Test_Type { get; set; }
            public Amazon.DeviceFarm.TestType TestType { get; set; }
        }
        
    }
}
