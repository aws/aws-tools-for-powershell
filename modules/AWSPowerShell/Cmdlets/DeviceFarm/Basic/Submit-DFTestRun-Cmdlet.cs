/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [AWSCmdlet("Calls the AWS Device Farm ScheduleRun API operation.", Operation = new[] {"ScheduleRun"}, SelectReturnType = typeof(Amazon.DeviceFarm.Model.ScheduleRunResponse))]
    [AWSCmdletOutput("Amazon.DeviceFarm.Model.Run or Amazon.DeviceFarm.Model.ScheduleRunResponse",
        "This cmdlet returns an Amazon.DeviceFarm.Model.Run object.",
        "The service call response (type Amazon.DeviceFarm.Model.ScheduleRunResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SubmitDFTestRunCmdlet : AmazonDeviceFarmClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExecutionConfiguration_AccountsCleanup
        /// <summary>
        /// <para>
        /// <para>True if account cleanup is enabled at the beginning of the test. Otherwise, false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ExecutionConfiguration_AccountsCleanup { get; set; }
        #endregion
        
        #region Parameter CustomerArtifactPaths_AndroidPath
        /// <summary>
        /// <para>
        /// <para>Comma-separated list of paths on the Android device where the artifacts generated
        /// by the customer's tests are pulled from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CustomerArtifactPaths_AndroidPaths")]
        public System.String[] CustomerArtifactPaths_AndroidPath { get; set; }
        #endregion
        
        #region Parameter AppArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an application package to run tests against, created with <a>CreateUpload</a>.
        /// See <a>ListUploads</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AppArn { get; set; }
        #endregion
        
        #region Parameter ExecutionConfiguration_AppPackagesCleanup
        /// <summary>
        /// <para>
        /// <para>True if app package cleanup is enabled at the beginning of the test. Otherwise, false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ExecutionConfiguration_AppPackagesCleanup { get; set; }
        #endregion
        
        #region Parameter Configuration_AuxiliaryApp
        /// <summary>
        /// <para>
        /// <para>A list of upload ARNs for app packages to be installed with your app.</para>
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
        /// generated by the customer's tests are pulled from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CustomerArtifactPaths_DeviceHostPaths")]
        public System.String[] CustomerArtifactPaths_DeviceHostPath { get; set; }
        #endregion
        
        #region Parameter DevicePoolArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the device pool for the run to be scheduled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        
        #region Parameter DeviceSelectionConfiguration_Filter
        /// <summary>
        /// <para>
        /// <para>Used to dynamically select a set of devices for a test run. A filter is made up of
        /// an attribute, an operator, and one or more values.</para><ul><li><para><b>Attribute</b></para><para>The aspect of a device such as platform or model used as the selection criteria in
        /// a device filter.</para><para>Allowed values include:</para><ul><li><para>ARN: The Amazon Resource Name (ARN) of the device (for example, <c>arn:aws:devicefarm:us-west-2::device:12345Example</c>).</para></li><li><para>PLATFORM: The device platform. Valid values are ANDROID or IOS.</para></li><li><para>OS_VERSION: The operating system version (for example, 10.3.2).</para></li><li><para>MODEL: The device model (for example, iPad 5th Gen).</para></li><li><para>AVAILABILITY: The current availability of the device. Valid values are AVAILABLE,
        /// HIGHLY_AVAILABLE, BUSY, or TEMPORARY_NOT_AVAILABLE.</para></li><li><para>FORM_FACTOR: The device form factor. Valid values are PHONE or TABLET.</para></li><li><para>MANUFACTURER: The device manufacturer (for example, Apple).</para></li><li><para>REMOTE_ACCESS_ENABLED: Whether the device is enabled for remote access. Valid values
        /// are TRUE or FALSE.</para></li><li><para>REMOTE_DEBUG_ENABLED: Whether the device is enabled for remote debugging. Valid values
        /// are TRUE or FALSE. Because remote debugging is <a href="https://docs.aws.amazon.com/devicefarm/latest/developerguide/history.html">no
        /// longer supported</a>, this filter is ignored.</para></li><li><para>INSTANCE_ARN: The Amazon Resource Name (ARN) of the device instance.</para></li><li><para>INSTANCE_LABELS: The label of the device instance.</para></li><li><para>FLEET_TYPE: The fleet type. Valid values are PUBLIC or PRIVATE.</para></li></ul></li><li><para><b>Operator</b></para><para>The filter operator.</para><ul><li><para>The EQUALS operator is available for every attribute except INSTANCE_LABELS.</para></li><li><para>The CONTAINS operator is available for the INSTANCE_LABELS and MODEL attributes.</para></li><li><para>The IN and NOT_IN operators are available for the ARN, OS_VERSION, MODEL, MANUFACTURER,
        /// and INSTANCE_ARN attributes.</para></li><li><para>The LESS_THAN, GREATER_THAN, LESS_THAN_OR_EQUALS, and GREATER_THAN_OR_EQUALS operators
        /// are also available for the OS_VERSION attribute.</para></li></ul></li><li><para><b>Values</b></para><para>An array of one or more filter values.</para><para><b>Operator Values</b></para><ul><li><para>The IN and NOT_IN operators can take a values array that has more than one element.</para></li><li><para>The other operators require an array with a single element.</para></li></ul><para><b>Attribute Values</b></para><ul><li><para>The PLATFORM attribute can be set to ANDROID or IOS.</para></li><li><para>The AVAILABILITY attribute can be set to AVAILABLE, HIGHLY_AVAILABLE, BUSY, or TEMPORARY_NOT_AVAILABLE.</para></li><li><para>The FORM_FACTOR attribute can be set to PHONE or TABLET.</para></li><li><para>The FLEET_TYPE attribute can be set to PUBLIC or PRIVATE.</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeviceSelectionConfiguration_Filters")]
        public Amazon.DeviceFarm.Model.DeviceFilter[] DeviceSelectionConfiguration_Filter { get; set; }
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
        
        #region Parameter CustomerArtifactPaths_IosPath
        /// <summary>
        /// <para>
        /// <para>Comma-separated list of paths on the iOS device where the artifacts generated by the
        /// customer's tests are pulled from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CustomerArtifactPaths_IosPaths")]
        public System.String[] CustomerArtifactPaths_IosPath { get; set; }
        #endregion
        
        #region Parameter ExecutionConfiguration_JobTimeoutMinute
        /// <summary>
        /// <para>
        /// <para>The number of minutes a test run executes before it times out.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExecutionConfiguration_JobTimeoutMinutes")]
        public System.Int32? ExecutionConfiguration_JobTimeoutMinute { get; set; }
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
        
        #region Parameter DeviceSelectionConfiguration_MaxDevice
        /// <summary>
        /// <para>
        /// <para>The maximum number of devices to be included in a test run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeviceSelectionConfiguration_MaxDevices")]
        public System.Int32? DeviceSelectionConfiguration_MaxDevice { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name for the run to be scheduled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
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
        /// tests ensures identical event sequences.</para></li></ul><para>For Instrumentation:</para><ul><li><para>filter: A test filter string. Examples:</para><ul><li><para>Running a single test case: <c>com.android.abc.Test1</c></para></li><li><para>Running a single test: <c>com.android.abc.Test1#smoke</c></para></li><li><para>Running multiple tests: <c>com.android.abc.Test1,com.android.abc.Test2</c></para></li></ul></li></ul><para>For XCTest and XCTestUI:</para><ul><li><para>filter: A test filter string. Examples:</para><ul><li><para>Running a single test class: <c>LoginTests</c></para></li><li><para>Running a multiple test classes: <c>LoginTests,SmokeTests</c></para></li><li><para>Running a single test: <c>LoginTests/testValid</c></para></li><li><para>Running multiple tests: <c>LoginTests/testValid,LoginTests/testInvalid</c></para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Test_Parameters")]
        public System.Collections.Hashtable Test_Parameter { get; set; }
        #endregion
        
        #region Parameter ProjectArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the project for the run to be scheduled.</para>
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
        public System.String ProjectArn { get; set; }
        #endregion
        
        #region Parameter ExecutionConfiguration_SkipAppResign
        /// <summary>
        /// <para>
        /// <para>When set to <c>true</c>, for private devices, Device Farm does not sign your app again.
        /// For public devices, Device Farm always signs your apps again.</para><para>For more information about how Device Farm re-signs your apps, see <a href="http://aws.amazon.com/device-farm/faqs/">Do
        /// you modify my app?</a> in the <i>AWS Device Farm FAQs</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ExecutionConfiguration_SkipAppResign { get; set; }
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
        
        #region Parameter Test_Type
        /// <summary>
        /// <para>
        /// <para>The test's type.</para><para>Must be one of the following values:</para><ul><li><para>BUILTIN_FUZZ</para></li><li><para>APPIUM_JAVA_JUNIT</para></li><li><para>APPIUM_JAVA_TESTNG</para></li><li><para>APPIUM_PYTHON</para></li><li><para>APPIUM_NODE</para></li><li><para>APPIUM_RUBY</para></li><li><para>APPIUM_WEB_JAVA_JUNIT</para></li><li><para>APPIUM_WEB_JAVA_TESTNG</para></li><li><para>APPIUM_WEB_PYTHON</para></li><li><para>APPIUM_WEB_NODE</para></li><li><para>APPIUM_WEB_RUBY</para></li><li><para>INSTRUMENTATION</para></li><li><para>XCTEST</para></li><li><para>XCTEST_UI</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DeviceFarm.TestType")]
        public Amazon.DeviceFarm.TestType Test_Type { get; set; }
        #endregion
        
        #region Parameter ExecutionConfiguration_VideoCapture
        /// <summary>
        /// <para>
        /// <para>Set to true to enable video capture. Otherwise, set to false. The default is true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ExecutionConfiguration_VideoCapture { get; set; }
        #endregion
        
        #region Parameter Configuration_VpceConfigurationArn
        /// <summary>
        /// <para>
        /// <para>An array of ARNs for your VPC endpoint configurations.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Run'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DeviceFarm.Model.ScheduleRunResponse).
        /// Specifying the name of a property of type Amazon.DeviceFarm.Model.ScheduleRunResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Run";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Submit-DFTestRun (ScheduleRun)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DeviceFarm.Model.ScheduleRunResponse, SubmitDFTestRunCmdlet>(Select) ??
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
            if (this.DeviceSelectionConfiguration_Filter != null)
            {
                context.DeviceSelectionConfiguration_Filter = new List<Amazon.DeviceFarm.Model.DeviceFilter>(this.DeviceSelectionConfiguration_Filter);
            }
            context.DeviceSelectionConfiguration_MaxDevice = this.DeviceSelectionConfiguration_MaxDevice;
            context.ExecutionConfiguration_AccountsCleanup = this.ExecutionConfiguration_AccountsCleanup;
            context.ExecutionConfiguration_AppPackagesCleanup = this.ExecutionConfiguration_AppPackagesCleanup;
            context.ExecutionConfiguration_JobTimeoutMinute = this.ExecutionConfiguration_JobTimeoutMinute;
            context.ExecutionConfiguration_SkipAppResign = this.ExecutionConfiguration_SkipAppResign;
            context.ExecutionConfiguration_VideoCapture = this.ExecutionConfiguration_VideoCapture;
            context.Name = this.Name;
            context.ProjectArn = this.ProjectArn;
            #if MODULAR
            if (this.ProjectArn == null && ParameterWasBound(nameof(this.ProjectArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            #if MODULAR
            if (this.Test_Type == null && ParameterWasBound(nameof(this.Test_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Test_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.DeviceFarm.Model.ScheduleRunRequest();
            
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
            
             // populate DeviceSelectionConfiguration
            var requestDeviceSelectionConfigurationIsNull = true;
            request.DeviceSelectionConfiguration = new Amazon.DeviceFarm.Model.DeviceSelectionConfiguration();
            List<Amazon.DeviceFarm.Model.DeviceFilter> requestDeviceSelectionConfiguration_deviceSelectionConfiguration_Filter = null;
            if (cmdletContext.DeviceSelectionConfiguration_Filter != null)
            {
                requestDeviceSelectionConfiguration_deviceSelectionConfiguration_Filter = cmdletContext.DeviceSelectionConfiguration_Filter;
            }
            if (requestDeviceSelectionConfiguration_deviceSelectionConfiguration_Filter != null)
            {
                request.DeviceSelectionConfiguration.Filters = requestDeviceSelectionConfiguration_deviceSelectionConfiguration_Filter;
                requestDeviceSelectionConfigurationIsNull = false;
            }
            System.Int32? requestDeviceSelectionConfiguration_deviceSelectionConfiguration_MaxDevice = null;
            if (cmdletContext.DeviceSelectionConfiguration_MaxDevice != null)
            {
                requestDeviceSelectionConfiguration_deviceSelectionConfiguration_MaxDevice = cmdletContext.DeviceSelectionConfiguration_MaxDevice.Value;
            }
            if (requestDeviceSelectionConfiguration_deviceSelectionConfiguration_MaxDevice != null)
            {
                request.DeviceSelectionConfiguration.MaxDevices = requestDeviceSelectionConfiguration_deviceSelectionConfiguration_MaxDevice.Value;
                requestDeviceSelectionConfigurationIsNull = false;
            }
             // determine if request.DeviceSelectionConfiguration should be set to null
            if (requestDeviceSelectionConfigurationIsNull)
            {
                request.DeviceSelectionConfiguration = null;
            }
            
             // populate ExecutionConfiguration
            var requestExecutionConfigurationIsNull = true;
            request.ExecutionConfiguration = new Amazon.DeviceFarm.Model.ExecutionConfiguration();
            System.Boolean? requestExecutionConfiguration_executionConfiguration_AccountsCleanup = null;
            if (cmdletContext.ExecutionConfiguration_AccountsCleanup != null)
            {
                requestExecutionConfiguration_executionConfiguration_AccountsCleanup = cmdletContext.ExecutionConfiguration_AccountsCleanup.Value;
            }
            if (requestExecutionConfiguration_executionConfiguration_AccountsCleanup != null)
            {
                request.ExecutionConfiguration.AccountsCleanup = requestExecutionConfiguration_executionConfiguration_AccountsCleanup.Value;
                requestExecutionConfigurationIsNull = false;
            }
            System.Boolean? requestExecutionConfiguration_executionConfiguration_AppPackagesCleanup = null;
            if (cmdletContext.ExecutionConfiguration_AppPackagesCleanup != null)
            {
                requestExecutionConfiguration_executionConfiguration_AppPackagesCleanup = cmdletContext.ExecutionConfiguration_AppPackagesCleanup.Value;
            }
            if (requestExecutionConfiguration_executionConfiguration_AppPackagesCleanup != null)
            {
                request.ExecutionConfiguration.AppPackagesCleanup = requestExecutionConfiguration_executionConfiguration_AppPackagesCleanup.Value;
                requestExecutionConfigurationIsNull = false;
            }
            System.Int32? requestExecutionConfiguration_executionConfiguration_JobTimeoutMinute = null;
            if (cmdletContext.ExecutionConfiguration_JobTimeoutMinute != null)
            {
                requestExecutionConfiguration_executionConfiguration_JobTimeoutMinute = cmdletContext.ExecutionConfiguration_JobTimeoutMinute.Value;
            }
            if (requestExecutionConfiguration_executionConfiguration_JobTimeoutMinute != null)
            {
                request.ExecutionConfiguration.JobTimeoutMinutes = requestExecutionConfiguration_executionConfiguration_JobTimeoutMinute.Value;
                requestExecutionConfigurationIsNull = false;
            }
            System.Boolean? requestExecutionConfiguration_executionConfiguration_SkipAppResign = null;
            if (cmdletContext.ExecutionConfiguration_SkipAppResign != null)
            {
                requestExecutionConfiguration_executionConfiguration_SkipAppResign = cmdletContext.ExecutionConfiguration_SkipAppResign.Value;
            }
            if (requestExecutionConfiguration_executionConfiguration_SkipAppResign != null)
            {
                request.ExecutionConfiguration.SkipAppResign = requestExecutionConfiguration_executionConfiguration_SkipAppResign.Value;
                requestExecutionConfigurationIsNull = false;
            }
            System.Boolean? requestExecutionConfiguration_executionConfiguration_VideoCapture = null;
            if (cmdletContext.ExecutionConfiguration_VideoCapture != null)
            {
                requestExecutionConfiguration_executionConfiguration_VideoCapture = cmdletContext.ExecutionConfiguration_VideoCapture.Value;
            }
            if (requestExecutionConfiguration_executionConfiguration_VideoCapture != null)
            {
                request.ExecutionConfiguration.VideoCapture = requestExecutionConfiguration_executionConfiguration_VideoCapture.Value;
                requestExecutionConfigurationIsNull = false;
            }
             // determine if request.ExecutionConfiguration should be set to null
            if (requestExecutionConfigurationIsNull)
            {
                request.ExecutionConfiguration = null;
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
        
        private Amazon.DeviceFarm.Model.ScheduleRunResponse CallAWSServiceOperation(IAmazonDeviceFarm client, Amazon.DeviceFarm.Model.ScheduleRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Device Farm", "ScheduleRun");
            try
            {
                #if DESKTOP
                return client.ScheduleRun(request);
                #elif CORECLR
                return client.ScheduleRunAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Configuration_AuxiliaryApp { get; set; }
            public Amazon.DeviceFarm.BillingMethod Configuration_BillingMethod { get; set; }
            public List<System.String> CustomerArtifactPaths_AndroidPath { get; set; }
            public List<System.String> CustomerArtifactPaths_DeviceHostPath { get; set; }
            public List<System.String> CustomerArtifactPaths_IosPath { get; set; }
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
            public List<Amazon.DeviceFarm.Model.DeviceFilter> DeviceSelectionConfiguration_Filter { get; set; }
            public System.Int32? DeviceSelectionConfiguration_MaxDevice { get; set; }
            public System.Boolean? ExecutionConfiguration_AccountsCleanup { get; set; }
            public System.Boolean? ExecutionConfiguration_AppPackagesCleanup { get; set; }
            public System.Int32? ExecutionConfiguration_JobTimeoutMinute { get; set; }
            public System.Boolean? ExecutionConfiguration_SkipAppResign { get; set; }
            public System.Boolean? ExecutionConfiguration_VideoCapture { get; set; }
            public System.String Name { get; set; }
            public System.String ProjectArn { get; set; }
            public System.String Test_Filter { get; set; }
            public Dictionary<System.String, System.String> Test_Parameter { get; set; }
            public System.String Test_TestPackageArn { get; set; }
            public System.String Test_TestSpecArn { get; set; }
            public Amazon.DeviceFarm.TestType Test_Type { get; set; }
            public System.Func<Amazon.DeviceFarm.Model.ScheduleRunResponse, SubmitDFTestRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Run;
        }
        
    }
}
