/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.DeviceFarm;
using Amazon.DeviceFarm.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DF
{
    /// <summary>
    /// Gets information about compatibility with a device pool.
    /// </summary>
    [Cmdlet("Get", "DFDevicePoolCompatibility")]
    [OutputType("Amazon.DeviceFarm.Model.GetDevicePoolCompatibilityResponse")]
    [AWSCmdlet("Calls the AWS Device Farm GetDevicePoolCompatibility API operation.", Operation = new[] {"GetDevicePoolCompatibility"}, SelectReturnType = typeof(Amazon.DeviceFarm.Model.GetDevicePoolCompatibilityResponse))]
    [AWSCmdletOutput("Amazon.DeviceFarm.Model.GetDevicePoolCompatibilityResponse",
        "This cmdlet returns an Amazon.DeviceFarm.Model.GetDevicePoolCompatibilityResponse object containing multiple properties."
    )]
    public partial class GetDFDevicePoolCompatibilityCmdlet : AmazonDeviceFarmClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CustomerArtifactPaths_AndroidPath
        /// <summary>
        /// <para>
        /// <para>Comma-separated list of paths on the Android device where the artifacts generated
        /// by the customer's tests are pulled from.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CustomerArtifactPaths_AndroidPaths")]
        public System.String[] CustomerArtifactPaths_AndroidPath { get; set; }
        #endregion
        
        #region Parameter AppArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the app that is associated with the specified device pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AppArn { get; set; }
        #endregion
        
        #region Parameter Configuration_AuxiliaryApp
        /// <summary>
        /// <para>
        /// <para>A list of upload ARNs for app packages to be installed with your app.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_AuxiliaryApps")]
        public System.String[] Configuration_AuxiliaryApp { get; set; }
        #endregion
        
        #region Parameter Configuration_BillingMethod
        /// <summary>
        /// <para>
        /// <para>Specifies the billing method for a test run: <c>metered</c> or <c>unmetered</c>. If
        /// the parameter is not specified, the default value is <c>metered</c>.</para><note><para>If you have purchased unmetered device slots, you must set this parameter to <c>unmetered</c>
        /// to make use of them. Otherwise, your run counts against your metered time.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DeviceFarm.BillingMethod")]
        public Amazon.DeviceFarm.BillingMethod Configuration_BillingMethod { get; set; }
        #endregion
        
        #region Parameter Radios_Bluetooth
        /// <summary>
        /// <para>
        /// <para>True if Bluetooth is enabled at the beginning of the test. Otherwise, false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Radios_Bluetooth")]
        public System.Boolean? Radios_Bluetooth { get; set; }
        #endregion
        
        #region Parameter CustomerArtifactPaths_DeviceHostPath
        /// <summary>
        /// <para>
        /// <para>Comma-separated list of paths in the test execution environment where the artifacts
        /// generated by the customer's tests are pulled from.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CustomerArtifactPaths_DeviceHostPaths")]
        public System.String[] CustomerArtifactPaths_DeviceHostPath { get; set; }
        #endregion
        
        #region Parameter DevicePoolArn
        /// <summary>
        /// <para>
        /// <para>The device pool's ARN.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DevicePoolArn { get; set; }
        #endregion
        
        #region Parameter Configuration_ExtraDataPackageArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the extra data for the run. The extra data is a .zip file that AWS Device
        /// Farm extracts to external data for Android or the app's sandbox for iOS.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_ExtraDataPackageArn { get; set; }
        #endregion
        
        #region Parameter Test_Filter
        /// <summary>
        /// <para>
        /// <para>The test's filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Test_Filter { get; set; }
        #endregion
        
        #region Parameter Radios_Gp
        /// <summary>
        /// <para>
        /// <para>True if GPS is enabled at the beginning of the test. Otherwise, false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Radios_Gps")]
        public System.Boolean? Radios_Gp { get; set; }
        #endregion
        
        #region Parameter DeviceProxy_Host
        /// <summary>
        /// <para>
        /// <para>Hostname or IPv4 address of the proxy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_DeviceProxy_Host")]
        public System.String DeviceProxy_Host { get; set; }
        #endregion
        
        #region Parameter CustomerArtifactPaths_IosPath
        /// <summary>
        /// <para>
        /// <para>Comma-separated list of paths on the iOS device where the artifacts generated by the
        /// customer's tests are pulled from.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CustomerArtifactPaths_IosPaths")]
        public System.String[] CustomerArtifactPaths_IosPath { get; set; }
        #endregion
        
        #region Parameter Location_Latitude
        /// <summary>
        /// <para>
        /// <para>The latitude.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Location_Latitude")]
        public System.Double? Location_Latitude { get; set; }
        #endregion
        
        #region Parameter Configuration_Locale
        /// <summary>
        /// <para>
        /// <para>Information about the locale that is used for the run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Locale { get; set; }
        #endregion
        
        #region Parameter Location_Longitude
        /// <summary>
        /// <para>
        /// <para>The longitude.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Location_Longitude")]
        public System.Double? Location_Longitude { get; set; }
        #endregion
        
        #region Parameter Configuration_NetworkProfileArn
        /// <summary>
        /// <para>
        /// <para>Reserved for internal use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_NetworkProfileArn { get; set; }
        #endregion
        
        #region Parameter Radios_Nfc
        /// <summary>
        /// <para>
        /// <para>True if NFC is enabled at the beginning of the test. Otherwise, false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Radios_Nfc")]
        public System.Boolean? Radios_Nfc { get; set; }
        #endregion
        
        #region Parameter Test_Parameter
        /// <summary>
        /// <para>
        /// <para>The test's parameters, such as test framework parameters and fixture settings. Parameters
        /// are represented by name-value pairs of strings.</para><para>For all tests:</para><ul><li><para><c>app_performance_monitoring</c>: Performance monitoring is enabled by default.
        /// Set this parameter to false to disable it.</para></li></ul><para>For Appium tests (all types):</para><ul><li><para>appium_version: The Appium version. Currently supported values are 1.6.5 (and later),
        /// latest, and default.</para><ul><li><para>latest runs the latest Appium version supported by Device Farm (1.9.1).</para></li><li><para>For default, Device Farm selects a compatible version of Appium for the device. The
        /// current behavior is to run 1.7.2 on Android devices and iOS 9 and earlier and 1.7.2
        /// for iOS 10 and later.</para></li><li><para>This behavior is subject to change.</para></li></ul></li></ul><para>For fuzz tests (Android only):</para><ul><li><para>event_count: The number of events, between 1 and 10000, that the UI fuzz test should
        /// perform.</para></li><li><para>throttle: The time, in ms, between 0 and 1000, that the UI fuzz test should wait between
        /// events.</para></li><li><para>seed: A seed to use for randomizing the UI fuzz test. Using the same seed value between
        /// tests ensures identical event sequences.</para></li></ul><para>For Instrumentation:</para><ul><li><para>filter: A test filter string. Examples:</para><ul><li><para>Running a single test case: <c>com.android.abc.Test1</c></para></li><li><para>Running a single test: <c>com.android.abc.Test1#smoke</c></para></li><li><para>Running multiple tests: <c>com.android.abc.Test1,com.android.abc.Test2</c></para></li></ul></li></ul><para>For XCTest and XCTestUI:</para><ul><li><para>filter: A test filter string. Examples:</para><ul><li><para>Running a single test class: <c>LoginTests</c></para></li><li><para>Running a multiple test classes: <c>LoginTests,SmokeTests</c></para></li><li><para>Running a single test: <c>LoginTests/testValid</c></para></li><li><para>Running multiple tests: <c>LoginTests/testValid,LoginTests/testInvalid</c></para></li></ul></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Test_Parameters")]
        public System.Collections.Hashtable Test_Parameter { get; set; }
        #endregion
        
        #region Parameter DeviceProxy_Port
        /// <summary>
        /// <para>
        /// <para>The port number on which the http/s proxy is listening.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_DeviceProxy_Port")]
        public System.Int32? DeviceProxy_Port { get; set; }
        #endregion
        
        #region Parameter ProjectArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the project for which you want to check device pool compatibility.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProjectArn { get; set; }
        #endregion
        
        #region Parameter Test_TestPackageArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the uploaded test to be run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Test_TestPackageArn { get; set; }
        #endregion
        
        #region Parameter Test_TestSpecArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the YAML-formatted test specification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Test_TestSpecArn { get; set; }
        #endregion
        
        #region Parameter TestType
        /// <summary>
        /// <para>
        /// <para>The test type for the specified device pool.</para><para>Allowed values include the following:</para><ul><li><para>BUILTIN_FUZZ.</para></li><li><para>APPIUM_JAVA_JUNIT.</para></li><li><para>APPIUM_JAVA_TESTNG.</para></li><li><para>APPIUM_PYTHON.</para></li><li><para>APPIUM_NODE.</para></li><li><para>APPIUM_RUBY.</para></li><li><para>APPIUM_WEB_JAVA_JUNIT.</para></li><li><para>APPIUM_WEB_JAVA_TESTNG.</para></li><li><para>APPIUM_WEB_PYTHON.</para></li><li><para>APPIUM_WEB_NODE.</para></li><li><para>APPIUM_WEB_RUBY.</para></li><li><para>INSTRUMENTATION.</para></li><li><para>XCTEST.</para></li><li><para>XCTEST_UI.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DeviceFarm.TestType")]
        public Amazon.DeviceFarm.TestType TestType { get; set; }
        #endregion
        
        #region Parameter Test_Type
        /// <summary>
        /// <para>
        /// <para>The test's type.</para><para>Must be one of the following values:</para><ul><li><para>BUILTIN_FUZZ</para></li><li><para>APPIUM_JAVA_JUNIT</para></li><li><para>APPIUM_JAVA_TESTNG</para></li><li><para>APPIUM_PYTHON</para></li><li><para>APPIUM_NODE</para></li><li><para>APPIUM_RUBY</para></li><li><para>APPIUM_WEB_JAVA_JUNIT</para></li><li><para>APPIUM_WEB_JAVA_TESTNG</para></li><li><para>APPIUM_WEB_PYTHON</para></li><li><para>APPIUM_WEB_NODE</para></li><li><para>APPIUM_WEB_RUBY</para></li><li><para>INSTRUMENTATION</para></li><li><para>XCTEST</para></li><li><para>XCTEST_UI</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DeviceFarm.TestType")]
        public Amazon.DeviceFarm.TestType Test_Type { get; set; }
        #endregion
        
        #region Parameter Configuration_VpceConfigurationArn
        /// <summary>
        /// <para>
        /// <para>An array of ARNs for your VPC endpoint configurations.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_VpceConfigurationArns")]
        public System.String[] Configuration_VpceConfigurationArn { get; set; }
        #endregion
        
        #region Parameter Radios_Wifi
        /// <summary>
        /// <para>
        /// <para>True if Wi-Fi is enabled at the beginning of the test. Otherwise, false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Radios_Wifi")]
        public System.Boolean? Radios_Wifi { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DeviceFarm.Model.GetDevicePoolCompatibilityResponse).
        /// Specifying the name of a property of type Amazon.DeviceFarm.Model.GetDevicePoolCompatibilityResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DeviceFarm.Model.GetDevicePoolCompatibilityResponse, GetDFDevicePoolCompatibilityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppArn = this.AppArn;
            if (this.Configuration_AuxiliaryApp != null)
            {
                context.Configuration_AuxiliaryApp = new List<System.String>(this.Configuration_AuxiliaryApp);
            }
            context.Configuration_BillingMethod = this.Configuration_BillingMethod;
            if (this.CustomerArtifactPaths_AndroidPath != null)
            {
                context.CustomerArtifactPaths_AndroidPath = new List<System.String>(this.CustomerArtifactPaths_AndroidPath);
            }
            if (this.CustomerArtifactPaths_DeviceHostPath != null)
            {
                context.CustomerArtifactPaths_DeviceHostPath = new List<System.String>(this.CustomerArtifactPaths_DeviceHostPath);
            }
            if (this.CustomerArtifactPaths_IosPath != null)
            {
                context.CustomerArtifactPaths_IosPath = new List<System.String>(this.CustomerArtifactPaths_IosPath);
            }
            context.DeviceProxy_Host = this.DeviceProxy_Host;
            context.DeviceProxy_Port = this.DeviceProxy_Port;
            context.Configuration_ExtraDataPackageArn = this.Configuration_ExtraDataPackageArn;
            context.Configuration_Locale = this.Configuration_Locale;
            context.Location_Latitude = this.Location_Latitude;
            context.Location_Longitude = this.Location_Longitude;
            context.Configuration_NetworkProfileArn = this.Configuration_NetworkProfileArn;
            context.Radios_Bluetooth = this.Radios_Bluetooth;
            context.Radios_Gp = this.Radios_Gp;
            context.Radios_Nfc = this.Radios_Nfc;
            context.Radios_Wifi = this.Radios_Wifi;
            if (this.Configuration_VpceConfigurationArn != null)
            {
                context.Configuration_VpceConfigurationArn = new List<System.String>(this.Configuration_VpceConfigurationArn);
            }
            context.DevicePoolArn = this.DevicePoolArn;
            #if MODULAR
            if (this.DevicePoolArn == null && ParameterWasBound(nameof(this.DevicePoolArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DevicePoolArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProjectArn = this.ProjectArn;
            context.Test_Filter = this.Test_Filter;
            if (this.Test_Parameter != null)
            {
                context.Test_Parameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Test_Parameter.Keys)
                {
                    context.Test_Parameter.Add((String)hashKey, (System.String)(this.Test_Parameter[hashKey]));
                }
            }
            context.Test_TestPackageArn = this.Test_TestPackageArn;
            context.Test_TestSpecArn = this.Test_TestSpecArn;
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
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.DeviceFarm.Model.ScheduleRunConfiguration();
            List<System.String> requestConfiguration_configuration_AuxiliaryApp = null;
            if (cmdletContext.Configuration_AuxiliaryApp != null)
            {
                requestConfiguration_configuration_AuxiliaryApp = cmdletContext.Configuration_AuxiliaryApp;
            }
            if (requestConfiguration_configuration_AuxiliaryApp != null)
            {
                request.Configuration.AuxiliaryApps = requestConfiguration_configuration_AuxiliaryApp;
                requestConfigurationIsNull = false;
            }
            Amazon.DeviceFarm.BillingMethod requestConfiguration_configuration_BillingMethod = null;
            if (cmdletContext.Configuration_BillingMethod != null)
            {
                requestConfiguration_configuration_BillingMethod = cmdletContext.Configuration_BillingMethod;
            }
            if (requestConfiguration_configuration_BillingMethod != null)
            {
                request.Configuration.BillingMethod = requestConfiguration_configuration_BillingMethod;
                requestConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_ExtraDataPackageArn = null;
            if (cmdletContext.Configuration_ExtraDataPackageArn != null)
            {
                requestConfiguration_configuration_ExtraDataPackageArn = cmdletContext.Configuration_ExtraDataPackageArn;
            }
            if (requestConfiguration_configuration_ExtraDataPackageArn != null)
            {
                request.Configuration.ExtraDataPackageArn = requestConfiguration_configuration_ExtraDataPackageArn;
                requestConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_Locale = null;
            if (cmdletContext.Configuration_Locale != null)
            {
                requestConfiguration_configuration_Locale = cmdletContext.Configuration_Locale;
            }
            if (requestConfiguration_configuration_Locale != null)
            {
                request.Configuration.Locale = requestConfiguration_configuration_Locale;
                requestConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_NetworkProfileArn = null;
            if (cmdletContext.Configuration_NetworkProfileArn != null)
            {
                requestConfiguration_configuration_NetworkProfileArn = cmdletContext.Configuration_NetworkProfileArn;
            }
            if (requestConfiguration_configuration_NetworkProfileArn != null)
            {
                request.Configuration.NetworkProfileArn = requestConfiguration_configuration_NetworkProfileArn;
                requestConfigurationIsNull = false;
            }
            List<System.String> requestConfiguration_configuration_VpceConfigurationArn = null;
            if (cmdletContext.Configuration_VpceConfigurationArn != null)
            {
                requestConfiguration_configuration_VpceConfigurationArn = cmdletContext.Configuration_VpceConfigurationArn;
            }
            if (requestConfiguration_configuration_VpceConfigurationArn != null)
            {
                request.Configuration.VpceConfigurationArns = requestConfiguration_configuration_VpceConfigurationArn;
                requestConfigurationIsNull = false;
            }
            Amazon.DeviceFarm.Model.DeviceProxy requestConfiguration_configuration_DeviceProxy = null;
            
             // populate DeviceProxy
            var requestConfiguration_configuration_DeviceProxyIsNull = true;
            requestConfiguration_configuration_DeviceProxy = new Amazon.DeviceFarm.Model.DeviceProxy();
            System.String requestConfiguration_configuration_DeviceProxy_deviceProxy_Host = null;
            if (cmdletContext.DeviceProxy_Host != null)
            {
                requestConfiguration_configuration_DeviceProxy_deviceProxy_Host = cmdletContext.DeviceProxy_Host;
            }
            if (requestConfiguration_configuration_DeviceProxy_deviceProxy_Host != null)
            {
                requestConfiguration_configuration_DeviceProxy.Host = requestConfiguration_configuration_DeviceProxy_deviceProxy_Host;
                requestConfiguration_configuration_DeviceProxyIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_DeviceProxy_deviceProxy_Port = null;
            if (cmdletContext.DeviceProxy_Port != null)
            {
                requestConfiguration_configuration_DeviceProxy_deviceProxy_Port = cmdletContext.DeviceProxy_Port.Value;
            }
            if (requestConfiguration_configuration_DeviceProxy_deviceProxy_Port != null)
            {
                requestConfiguration_configuration_DeviceProxy.Port = requestConfiguration_configuration_DeviceProxy_deviceProxy_Port.Value;
                requestConfiguration_configuration_DeviceProxyIsNull = false;
            }
             // determine if requestConfiguration_configuration_DeviceProxy should be set to null
            if (requestConfiguration_configuration_DeviceProxyIsNull)
            {
                requestConfiguration_configuration_DeviceProxy = null;
            }
            if (requestConfiguration_configuration_DeviceProxy != null)
            {
                request.Configuration.DeviceProxy = requestConfiguration_configuration_DeviceProxy;
                requestConfigurationIsNull = false;
            }
            Amazon.DeviceFarm.Model.Location requestConfiguration_configuration_Location = null;
            
             // populate Location
            var requestConfiguration_configuration_LocationIsNull = true;
            requestConfiguration_configuration_Location = new Amazon.DeviceFarm.Model.Location();
            System.Double? requestConfiguration_configuration_Location_location_Latitude = null;
            if (cmdletContext.Location_Latitude != null)
            {
                requestConfiguration_configuration_Location_location_Latitude = cmdletContext.Location_Latitude.Value;
            }
            if (requestConfiguration_configuration_Location_location_Latitude != null)
            {
                requestConfiguration_configuration_Location.Latitude = requestConfiguration_configuration_Location_location_Latitude.Value;
                requestConfiguration_configuration_LocationIsNull = false;
            }
            System.Double? requestConfiguration_configuration_Location_location_Longitude = null;
            if (cmdletContext.Location_Longitude != null)
            {
                requestConfiguration_configuration_Location_location_Longitude = cmdletContext.Location_Longitude.Value;
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
            Amazon.DeviceFarm.Model.CustomerArtifactPaths requestConfiguration_configuration_CustomerArtifactPaths = null;
            
             // populate CustomerArtifactPaths
            var requestConfiguration_configuration_CustomerArtifactPathsIsNull = true;
            requestConfiguration_configuration_CustomerArtifactPaths = new Amazon.DeviceFarm.Model.CustomerArtifactPaths();
            List<System.String> requestConfiguration_configuration_CustomerArtifactPaths_customerArtifactPaths_AndroidPath = null;
            if (cmdletContext.CustomerArtifactPaths_AndroidPath != null)
            {
                requestConfiguration_configuration_CustomerArtifactPaths_customerArtifactPaths_AndroidPath = cmdletContext.CustomerArtifactPaths_AndroidPath;
            }
            if (requestConfiguration_configuration_CustomerArtifactPaths_customerArtifactPaths_AndroidPath != null)
            {
                requestConfiguration_configuration_CustomerArtifactPaths.AndroidPaths = requestConfiguration_configuration_CustomerArtifactPaths_customerArtifactPaths_AndroidPath;
                requestConfiguration_configuration_CustomerArtifactPathsIsNull = false;
            }
            List<System.String> requestConfiguration_configuration_CustomerArtifactPaths_customerArtifactPaths_DeviceHostPath = null;
            if (cmdletContext.CustomerArtifactPaths_DeviceHostPath != null)
            {
                requestConfiguration_configuration_CustomerArtifactPaths_customerArtifactPaths_DeviceHostPath = cmdletContext.CustomerArtifactPaths_DeviceHostPath;
            }
            if (requestConfiguration_configuration_CustomerArtifactPaths_customerArtifactPaths_DeviceHostPath != null)
            {
                requestConfiguration_configuration_CustomerArtifactPaths.DeviceHostPaths = requestConfiguration_configuration_CustomerArtifactPaths_customerArtifactPaths_DeviceHostPath;
                requestConfiguration_configuration_CustomerArtifactPathsIsNull = false;
            }
            List<System.String> requestConfiguration_configuration_CustomerArtifactPaths_customerArtifactPaths_IosPath = null;
            if (cmdletContext.CustomerArtifactPaths_IosPath != null)
            {
                requestConfiguration_configuration_CustomerArtifactPaths_customerArtifactPaths_IosPath = cmdletContext.CustomerArtifactPaths_IosPath;
            }
            if (requestConfiguration_configuration_CustomerArtifactPaths_customerArtifactPaths_IosPath != null)
            {
                requestConfiguration_configuration_CustomerArtifactPaths.IosPaths = requestConfiguration_configuration_CustomerArtifactPaths_customerArtifactPaths_IosPath;
                requestConfiguration_configuration_CustomerArtifactPathsIsNull = false;
            }
             // determine if requestConfiguration_configuration_CustomerArtifactPaths should be set to null
            if (requestConfiguration_configuration_CustomerArtifactPathsIsNull)
            {
                requestConfiguration_configuration_CustomerArtifactPaths = null;
            }
            if (requestConfiguration_configuration_CustomerArtifactPaths != null)
            {
                request.Configuration.CustomerArtifactPaths = requestConfiguration_configuration_CustomerArtifactPaths;
                requestConfigurationIsNull = false;
            }
            Amazon.DeviceFarm.Model.Radios requestConfiguration_configuration_Radios = null;
            
             // populate Radios
            var requestConfiguration_configuration_RadiosIsNull = true;
            requestConfiguration_configuration_Radios = new Amazon.DeviceFarm.Model.Radios();
            System.Boolean? requestConfiguration_configuration_Radios_radios_Bluetooth = null;
            if (cmdletContext.Radios_Bluetooth != null)
            {
                requestConfiguration_configuration_Radios_radios_Bluetooth = cmdletContext.Radios_Bluetooth.Value;
            }
            if (requestConfiguration_configuration_Radios_radios_Bluetooth != null)
            {
                requestConfiguration_configuration_Radios.Bluetooth = requestConfiguration_configuration_Radios_radios_Bluetooth.Value;
                requestConfiguration_configuration_RadiosIsNull = false;
            }
            System.Boolean? requestConfiguration_configuration_Radios_radios_Gp = null;
            if (cmdletContext.Radios_Gp != null)
            {
                requestConfiguration_configuration_Radios_radios_Gp = cmdletContext.Radios_Gp.Value;
            }
            if (requestConfiguration_configuration_Radios_radios_Gp != null)
            {
                requestConfiguration_configuration_Radios.Gps = requestConfiguration_configuration_Radios_radios_Gp.Value;
                requestConfiguration_configuration_RadiosIsNull = false;
            }
            System.Boolean? requestConfiguration_configuration_Radios_radios_Nfc = null;
            if (cmdletContext.Radios_Nfc != null)
            {
                requestConfiguration_configuration_Radios_radios_Nfc = cmdletContext.Radios_Nfc.Value;
            }
            if (requestConfiguration_configuration_Radios_radios_Nfc != null)
            {
                requestConfiguration_configuration_Radios.Nfc = requestConfiguration_configuration_Radios_radios_Nfc.Value;
                requestConfiguration_configuration_RadiosIsNull = false;
            }
            System.Boolean? requestConfiguration_configuration_Radios_radios_Wifi = null;
            if (cmdletContext.Radios_Wifi != null)
            {
                requestConfiguration_configuration_Radios_radios_Wifi = cmdletContext.Radios_Wifi.Value;
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
            if (cmdletContext.ProjectArn != null)
            {
                request.ProjectArn = cmdletContext.ProjectArn;
            }
            
             // populate Test
            var requestTestIsNull = true;
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
            if (cmdletContext.Test_Parameter != null)
            {
                requestTest_test_Parameter = cmdletContext.Test_Parameter;
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
            System.String requestTest_test_TestSpecArn = null;
            if (cmdletContext.Test_TestSpecArn != null)
            {
                requestTest_test_TestSpecArn = cmdletContext.Test_TestSpecArn;
            }
            if (requestTest_test_TestSpecArn != null)
            {
                request.Test.TestSpecArn = requestTest_test_TestSpecArn;
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
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
                return client.GetDevicePoolCompatibilityAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Configuration_AuxiliaryApp { get; set; }
            public Amazon.DeviceFarm.BillingMethod Configuration_BillingMethod { get; set; }
            public List<System.String> CustomerArtifactPaths_AndroidPath { get; set; }
            public List<System.String> CustomerArtifactPaths_DeviceHostPath { get; set; }
            public List<System.String> CustomerArtifactPaths_IosPath { get; set; }
            public System.String DeviceProxy_Host { get; set; }
            public System.Int32? DeviceProxy_Port { get; set; }
            public System.String Configuration_ExtraDataPackageArn { get; set; }
            public System.String Configuration_Locale { get; set; }
            public System.Double? Location_Latitude { get; set; }
            public System.Double? Location_Longitude { get; set; }
            public System.String Configuration_NetworkProfileArn { get; set; }
            public System.Boolean? Radios_Bluetooth { get; set; }
            public System.Boolean? Radios_Gp { get; set; }
            public System.Boolean? Radios_Nfc { get; set; }
            public System.Boolean? Radios_Wifi { get; set; }
            public List<System.String> Configuration_VpceConfigurationArn { get; set; }
            public System.String DevicePoolArn { get; set; }
            public System.String ProjectArn { get; set; }
            public System.String Test_Filter { get; set; }
            public Dictionary<System.String, System.String> Test_Parameter { get; set; }
            public System.String Test_TestPackageArn { get; set; }
            public System.String Test_TestSpecArn { get; set; }
            public Amazon.DeviceFarm.TestType Test_Type { get; set; }
            public Amazon.DeviceFarm.TestType TestType { get; set; }
            public System.Func<Amazon.DeviceFarm.Model.GetDevicePoolCompatibilityResponse, GetDFDevicePoolCompatibilityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
