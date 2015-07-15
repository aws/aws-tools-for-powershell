/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Schedules a run.
    /// </summary>
    [Cmdlet("Submit", "DFTestRun", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DeviceFarm.Model.Run")]
    [AWSCmdlet("Invokes the ScheduleRun operation against AWS Device Farm.", Operation = new[] {"ScheduleRun"})]
    [AWSCmdletOutput("Amazon.DeviceFarm.Model.Run",
        "This cmdlet returns a Run object.",
        "The service call response (type ScheduleRunResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class SubmitDFTestRunCmdlet : AmazonDeviceFarmClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The ARN of the app to schedule a run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String AppArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of auxiliary apps for the run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Configuration_AuxiliaryApps")]
        public System.String[] Configuration_AuxiliaryApp { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>True if Bluetooth is enabled at the beginning of the test; otherwise, false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Configuration_Radios_Bluetooth")]
        public Boolean Radios_Bluetooth { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ARN of the device pool for the run to be scheduled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DevicePoolArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ARN of the extra data for the run. The extra data is a .zip file that AWS Device
        /// Farm will extract to external data for Android or the app's sandbox for iOS.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Configuration_ExtraDataPackageArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The test's filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Test_Filter { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>True if GPS is enabled at the beginning of the test; otherwise, false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Configuration_Radios_Gps")]
        public Boolean Radios_Gps { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The latitude.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Configuration_Location_Latitude")]
        public Double Location_Latitude { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Information about the locale that is used for the run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Configuration_Locale { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The longitude.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Configuration_Location_Longitude")]
        public Double Location_Longitude { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name for the run to be scheduled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Name { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ARN of the network profile for the run. A network profile describes network shaping
        /// parameters that are used to shape a Wi-Fi signal and to simulate various network environments.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Configuration_NetworkProfileArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>True if NFC is enabled at the beginning of the test; otherwise, false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Configuration_Radios_Nfc")]
        public Boolean Radios_Nfc { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The test's parameters, such as test framework parameters and fixture settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Test_Parameters")]
        public System.Collections.Hashtable Test_Parameter { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ARN of the project for the run to be scheduled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String ProjectArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ARN of the uploaded test that will be run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Test_TestPackageArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The test's type.</para><para>Must be one of the following values:</para><ul><li><para>ANDROID_APP: An Android app.</para></li><li><para>APPIUM_JAVA_TEST_PACKAGE: An Appium Java test package.</para></li><li><para>CALABASH_TEST_PACKAGE: A Calabash test package.</para></li><li><para>EXTERNAL_DATA: External data.</para></li><li><para>INSTRUMENTATION_TEST_PACKAGE: An instrumentation test package.</para></li><li><para>IOS_APP: An iOS app.</para></li><li><para>UIAUTOMATION_TEST_PACKAGE: A UI Automation test package.</para></li><li><para>UIAUTOMATOR_TEST_PACKAGE: A uiautomator test package.</para></li><li><para>XCTEST_TEST_PACKAGE: An XCTest test package.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public TestType Test_Type { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>True if Wi-Fi is enabled at the beginning of the test; otherwise, false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Configuration_Radios_Wifi")]
        public Boolean Radios_Wifi { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Submit-DFTestRun (ScheduleRun)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AppArn = this.AppArn;
            if (this.Configuration_AuxiliaryApp != null)
            {
                context.Configuration_AuxiliaryApps = new List<String>(this.Configuration_AuxiliaryApp);
            }
            context.Configuration_ExtraDataPackageArn = this.Configuration_ExtraDataPackageArn;
            context.Configuration_Locale = this.Configuration_Locale;
            if (ParameterWasBound("Location_Latitude"))
                context.Configuration_Location_Latitude = this.Location_Latitude;
            if (ParameterWasBound("Location_Longitude"))
                context.Configuration_Location_Longitude = this.Location_Longitude;
            context.Configuration_NetworkProfileArn = this.Configuration_NetworkProfileArn;
            if (ParameterWasBound("Radios_Bluetooth"))
                context.Configuration_Radios_Bluetooth = this.Radios_Bluetooth;
            if (ParameterWasBound("Radios_Gps"))
                context.Configuration_Radios_Gps = this.Radios_Gps;
            if (ParameterWasBound("Radios_Nfc"))
                context.Configuration_Radios_Nfc = this.Radios_Nfc;
            if (ParameterWasBound("Radios_Wifi"))
                context.Configuration_Radios_Wifi = this.Radios_Wifi;
            context.DevicePoolArn = this.DevicePoolArn;
            context.Name = this.Name;
            context.ProjectArn = this.ProjectArn;
            context.Test_Filter = this.Test_Filter;
            if (this.Test_Parameter != null)
            {
                context.Test_Parameters = new Dictionary<String, String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Test_Parameter.Keys)
                {
                    context.Test_Parameters.Add((String)hashKey, (String)(this.Test_Parameter[hashKey]));
                }
            }
            context.Test_TestPackageArn = this.Test_TestPackageArn;
            context.Test_Type = this.Test_Type;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new ScheduleRunRequest();
            
            if (cmdletContext.AppArn != null)
            {
                request.AppArn = cmdletContext.AppArn;
            }
            
             // populate Configuration
            bool requestConfigurationIsNull = true;
            request.Configuration = new ScheduleRunConfiguration();
            List<String> requestConfiguration_configuration_AuxiliaryApp = null;
            if (cmdletContext.Configuration_AuxiliaryApps != null)
            {
                requestConfiguration_configuration_AuxiliaryApp = cmdletContext.Configuration_AuxiliaryApps;
            }
            if (requestConfiguration_configuration_AuxiliaryApp != null)
            {
                request.Configuration.AuxiliaryApps = requestConfiguration_configuration_AuxiliaryApp;
                requestConfigurationIsNull = false;
            }
            String requestConfiguration_configuration_ExtraDataPackageArn = null;
            if (cmdletContext.Configuration_ExtraDataPackageArn != null)
            {
                requestConfiguration_configuration_ExtraDataPackageArn = cmdletContext.Configuration_ExtraDataPackageArn;
            }
            if (requestConfiguration_configuration_ExtraDataPackageArn != null)
            {
                request.Configuration.ExtraDataPackageArn = requestConfiguration_configuration_ExtraDataPackageArn;
                requestConfigurationIsNull = false;
            }
            String requestConfiguration_configuration_Locale = null;
            if (cmdletContext.Configuration_Locale != null)
            {
                requestConfiguration_configuration_Locale = cmdletContext.Configuration_Locale;
            }
            if (requestConfiguration_configuration_Locale != null)
            {
                request.Configuration.Locale = requestConfiguration_configuration_Locale;
                requestConfigurationIsNull = false;
            }
            String requestConfiguration_configuration_NetworkProfileArn = null;
            if (cmdletContext.Configuration_NetworkProfileArn != null)
            {
                requestConfiguration_configuration_NetworkProfileArn = cmdletContext.Configuration_NetworkProfileArn;
            }
            if (requestConfiguration_configuration_NetworkProfileArn != null)
            {
                request.Configuration.NetworkProfileArn = requestConfiguration_configuration_NetworkProfileArn;
                requestConfigurationIsNull = false;
            }
            Location requestConfiguration_configuration_Location = null;
            
             // populate Location
            bool requestConfiguration_configuration_LocationIsNull = true;
            requestConfiguration_configuration_Location = new Location();
            Double? requestConfiguration_configuration_Location_location_Latitude = null;
            if (cmdletContext.Configuration_Location_Latitude != null)
            {
                requestConfiguration_configuration_Location_location_Latitude = cmdletContext.Configuration_Location_Latitude.Value;
            }
            if (requestConfiguration_configuration_Location_location_Latitude != null)
            {
                requestConfiguration_configuration_Location.Latitude = requestConfiguration_configuration_Location_location_Latitude.Value;
                requestConfiguration_configuration_LocationIsNull = false;
            }
            Double? requestConfiguration_configuration_Location_location_Longitude = null;
            if (cmdletContext.Configuration_Location_Longitude != null)
            {
                requestConfiguration_configuration_Location_location_Longitude = cmdletContext.Configuration_Location_Longitude.Value;
            }
            if (requestConfiguration_configuration_Location_location_Longitude != null)
            {
                requestConfiguration_configuration_Location.Longitude = requestConfiguration_configuration_Location_location_Longitude.Value;
                requestConfiguration_configuration_LocationIsNull = false;
            }
             // determine if requestConfiguration_configuration_Location should be set to null
            if (requestConfiguration_configuration_LocationIsNull)
            {
                requestConfiguration_configuration_Location = null;
            }
            if (requestConfiguration_configuration_Location != null)
            {
                request.Configuration.Location = requestConfiguration_configuration_Location;
                requestConfigurationIsNull = false;
            }
            Radios requestConfiguration_configuration_Radios = null;
            
             // populate Radios
            bool requestConfiguration_configuration_RadiosIsNull = true;
            requestConfiguration_configuration_Radios = new Radios();
            Boolean? requestConfiguration_configuration_Radios_radios_Bluetooth = null;
            if (cmdletContext.Configuration_Radios_Bluetooth != null)
            {
                requestConfiguration_configuration_Radios_radios_Bluetooth = cmdletContext.Configuration_Radios_Bluetooth.Value;
            }
            if (requestConfiguration_configuration_Radios_radios_Bluetooth != null)
            {
                requestConfiguration_configuration_Radios.Bluetooth = requestConfiguration_configuration_Radios_radios_Bluetooth.Value;
                requestConfiguration_configuration_RadiosIsNull = false;
            }
            Boolean? requestConfiguration_configuration_Radios_radios_Gps = null;
            if (cmdletContext.Configuration_Radios_Gps != null)
            {
                requestConfiguration_configuration_Radios_radios_Gps = cmdletContext.Configuration_Radios_Gps.Value;
            }
            if (requestConfiguration_configuration_Radios_radios_Gps != null)
            {
                requestConfiguration_configuration_Radios.Gps = requestConfiguration_configuration_Radios_radios_Gps.Value;
                requestConfiguration_configuration_RadiosIsNull = false;
            }
            Boolean? requestConfiguration_configuration_Radios_radios_Nfc = null;
            if (cmdletContext.Configuration_Radios_Nfc != null)
            {
                requestConfiguration_configuration_Radios_radios_Nfc = cmdletContext.Configuration_Radios_Nfc.Value;
            }
            if (requestConfiguration_configuration_Radios_radios_Nfc != null)
            {
                requestConfiguration_configuration_Radios.Nfc = requestConfiguration_configuration_Radios_radios_Nfc.Value;
                requestConfiguration_configuration_RadiosIsNull = false;
            }
            Boolean? requestConfiguration_configuration_Radios_radios_Wifi = null;
            if (cmdletContext.Configuration_Radios_Wifi != null)
            {
                requestConfiguration_configuration_Radios_radios_Wifi = cmdletContext.Configuration_Radios_Wifi.Value;
            }
            if (requestConfiguration_configuration_Radios_radios_Wifi != null)
            {
                requestConfiguration_configuration_Radios.Wifi = requestConfiguration_configuration_Radios_radios_Wifi.Value;
                requestConfiguration_configuration_RadiosIsNull = false;
            }
             // determine if requestConfiguration_configuration_Radios should be set to null
            if (requestConfiguration_configuration_RadiosIsNull)
            {
                requestConfiguration_configuration_Radios = null;
            }
            if (requestConfiguration_configuration_Radios != null)
            {
                request.Configuration.Radios = requestConfiguration_configuration_Radios;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.DevicePoolArn != null)
            {
                request.DevicePoolArn = cmdletContext.DevicePoolArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ProjectArn != null)
            {
                request.ProjectArn = cmdletContext.ProjectArn;
            }
            
             // populate Test
            bool requestTestIsNull = true;
            request.Test = new ScheduleRunTest();
            String requestTest_test_Filter = null;
            if (cmdletContext.Test_Filter != null)
            {
                requestTest_test_Filter = cmdletContext.Test_Filter;
            }
            if (requestTest_test_Filter != null)
            {
                request.Test.Filter = requestTest_test_Filter;
                requestTestIsNull = false;
            }
            Dictionary<String, String> requestTest_test_Parameter = null;
            if (cmdletContext.Test_Parameters != null)
            {
                requestTest_test_Parameter = cmdletContext.Test_Parameters;
            }
            if (requestTest_test_Parameter != null)
            {
                request.Test.Parameters = requestTest_test_Parameter;
                requestTestIsNull = false;
            }
            String requestTest_test_TestPackageArn = null;
            if (cmdletContext.Test_TestPackageArn != null)
            {
                requestTest_test_TestPackageArn = cmdletContext.Test_TestPackageArn;
            }
            if (requestTest_test_TestPackageArn != null)
            {
                request.Test.TestPackageArn = requestTest_test_TestPackageArn;
                requestTestIsNull = false;
            }
            TestType requestTest_test_Type = null;
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ScheduleRun(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Run;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String AppArn { get; set; }
            public List<String> Configuration_AuxiliaryApps { get; set; }
            public String Configuration_ExtraDataPackageArn { get; set; }
            public String Configuration_Locale { get; set; }
            public Double? Configuration_Location_Latitude { get; set; }
            public Double? Configuration_Location_Longitude { get; set; }
            public String Configuration_NetworkProfileArn { get; set; }
            public Boolean? Configuration_Radios_Bluetooth { get; set; }
            public Boolean? Configuration_Radios_Gps { get; set; }
            public Boolean? Configuration_Radios_Nfc { get; set; }
            public Boolean? Configuration_Radios_Wifi { get; set; }
            public String DevicePoolArn { get; set; }
            public String Name { get; set; }
            public String ProjectArn { get; set; }
            public String Test_Filter { get; set; }
            public Dictionary<String, String> Test_Parameters { get; set; }
            public String Test_TestPackageArn { get; set; }
            public TestType Test_Type { get; set; }
        }
        
    }
}
