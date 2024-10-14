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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Starts an asynchronous job that generates a snapshot of a dashboard's output. You
    /// can request one or several of the following format configurations in each API call.
    /// 
    ///  <ul><li><para>
    /// 1 Paginated PDF
    /// </para></li><li><para>
    /// 1 Excel workbook that includes up to 5 table or pivot table visuals
    /// </para></li><li><para>
    /// 5 CSVs from table or pivot table visuals
    /// </para></li></ul><para>
    /// The status of a submitted job can be polled with the <c>DescribeDashboardSnapshotJob</c>
    /// API. When you call the <c>DescribeDashboardSnapshotJob</c> API, check the <c>JobStatus</c>
    /// field in the response. Once the job reaches a <c>COMPLETED</c> or <c>FAILED</c> status,
    /// use the <c>DescribeDashboardSnapshotJobResult</c> API to obtain the URLs for the generated
    /// files. If the job fails, the <c>DescribeDashboardSnapshotJobResult</c> API returns
    /// detailed information about the error that occurred.
    /// </para><para><b>StartDashboardSnapshotJob API throttling</b></para><para>
    /// Amazon QuickSight utilizes API throttling to create a more consistent user experience
    /// within a time span for customers when they call the <c>StartDashboardSnapshotJob</c>.
    /// By default, 12 jobs can run simlutaneously in one Amazon Web Services account and
    /// users can submit up 10 API requests per second before an account is throttled. If
    /// an overwhelming number of API requests are made by the same user in a short period
    /// of time, Amazon QuickSight throttles the API calls to maintin an optimal experience
    /// and reliability for all Amazon QuickSight users.
    /// </para><para><b>Common throttling scenarios</b></para><para>
    /// The following list provides information about the most commin throttling scenarios
    /// that can occur.
    /// </para><ul><li><para><b>A large number of <c>SnapshotExport</c> API jobs are running simultaneously on
    /// an Amazon Web Services account.</b> When a new <c>StartDashboardSnapshotJob</c> is
    /// created and there are already 12 jobs with the <c>RUNNING</c> status, the new job
    /// request fails and returns a <c>LimitExceededException</c> error. Wait for a current
    /// job to comlpete before you resubmit the new job.
    /// </para></li><li><para><b>A large number of API requests are submitted on an Amazon Web Services account.</b>
    /// When a user makes more than 10 API calls to the Amazon QuickSight API in one second,
    /// a <c>ThrottlingException</c> is returned.
    /// </para></li></ul><para>
    /// If your use case requires a higher throttling limit, contact your account admin or
    /// <a href="http://aws.amazon.com/contact-us/">Amazon Web ServicesSupport</a> to explore
    /// options to tailor a more optimal expereince for your account.
    /// </para><para><b>Best practices to handle throttling</b></para><para>
    /// If your use case projects high levels of API traffic, try to reduce the degree of
    /// frequency and parallelism of API calls as much as you can to avoid throttling. You
    /// can also perform a timing test to calculate an estimate for the total processing time
    /// of your projected load that stays within the throttling limits of the Amazon QuickSight
    /// APIs. For example, if your projected traffic is 100 snapshot jobs before 12:00 PM
    /// per day, start 12 jobs in parallel and measure the amount of time it takes to proccess
    /// all 12 jobs. Once you obtain the result, multiply the duration by 9, for example <c>(12
    /// minutes * 9 = 108 minutes)</c>. Use the new result to determine the latest time at
    /// which the jobs need to be started to meet your target deadline.
    /// </para><para>
    /// The time that it takes to process a job can be impacted by the following factors:
    /// </para><ul><li><para>
    /// The dataset type (Direct Query or SPICE).
    /// </para></li><li><para>
    /// The size of the dataset.
    /// </para></li><li><para>
    /// The complexity of the calculated fields that are used in the dashboard.
    /// </para></li><li><para>
    /// The number of visuals that are on a sheet.
    /// </para></li><li><para>
    /// The types of visuals that are on the sheet.
    /// </para></li><li><para>
    /// The number of formats and snapshots that are requested in the job configuration.
    /// </para></li><li><para>
    /// The size of the generated snapshots.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Start", "QSDashboardSnapshotJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.StartDashboardSnapshotJobResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight StartDashboardSnapshotJob API operation.", Operation = new[] {"StartDashboardSnapshotJob"}, SelectReturnType = typeof(Amazon.QuickSight.Model.StartDashboardSnapshotJobResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.StartDashboardSnapshotJobResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.StartDashboardSnapshotJobResponse object containing multiple properties."
    )]
    public partial class StartQSDashboardSnapshotJobCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter UserConfiguration_AnonymousUser
        /// <summary>
        /// <para>
        /// <para>An array of records that describe the anonymous users that the dashboard snapshot
        /// is generated for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserConfiguration_AnonymousUsers")]
        public Amazon.QuickSight.Model.SnapshotAnonymousUser[] UserConfiguration_AnonymousUser { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that the dashboard snapshot job is executed
        /// in.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter DashboardId
        /// <summary>
        /// <para>
        /// <para>The ID of the dashboard that you want to start a snapshot job for. </para>
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
        public System.String DashboardId { get; set; }
        #endregion
        
        #region Parameter Parameters_DateTimeParameter
        /// <summary>
        /// <para>
        /// <para>The parameters that have a data type of date-time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SnapshotConfiguration_Parameters_DateTimeParameters")]
        public Amazon.QuickSight.Model.DateTimeParameter[] Parameters_DateTimeParameter { get; set; }
        #endregion
        
        #region Parameter Parameters_DecimalParameter
        /// <summary>
        /// <para>
        /// <para>The parameters that have a data type of decimal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SnapshotConfiguration_Parameters_DecimalParameters")]
        public Amazon.QuickSight.Model.DecimalParameter[] Parameters_DecimalParameter { get; set; }
        #endregion
        
        #region Parameter SnapshotConfiguration_FileGroup
        /// <summary>
        /// <para>
        /// <para>A list of <c>SnapshotJobResultFileGroup</c> objects that contain information about
        /// the snapshot that is generated. This list can hold a maximum of 6 <c>FileGroup</c>
        /// configurations.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SnapshotConfiguration_FileGroups")]
        public Amazon.QuickSight.Model.SnapshotFileGroup[] SnapshotConfiguration_FileGroup { get; set; }
        #endregion
        
        #region Parameter Parameters_IntegerParameter
        /// <summary>
        /// <para>
        /// <para>The parameters that have a data type of integer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SnapshotConfiguration_Parameters_IntegerParameters")]
        public Amazon.QuickSight.Model.IntegerParameter[] Parameters_IntegerParameter { get; set; }
        #endregion
        
        #region Parameter DestinationConfiguration_S3Destination
        /// <summary>
        /// <para>
        /// <para> A list of <c>SnapshotS3DestinationConfiguration</c> objects that contain Amazon S3
        /// destination configurations. This structure can hold a maximum of 1 <c>S3DestinationConfiguration</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SnapshotConfiguration_DestinationConfiguration_S3Destinations")]
        public Amazon.QuickSight.Model.SnapshotS3DestinationConfiguration[] DestinationConfiguration_S3Destination { get; set; }
        #endregion
        
        #region Parameter SnapshotJobId
        /// <summary>
        /// <para>
        /// <para>An ID for the dashboard snapshot job. This ID is unique to the dashboard while the
        /// job is running. This ID can be used to poll the status of a job with a <c>DescribeDashboardSnapshotJob</c>
        /// while the job runs. You can reuse this ID for another job 24 hours after the current
        /// job is completed.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String SnapshotJobId { get; set; }
        #endregion
        
        #region Parameter Parameters_StringParameter
        /// <summary>
        /// <para>
        /// <para>The parameters that have a data type of string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SnapshotConfiguration_Parameters_StringParameters")]
        public Amazon.QuickSight.Model.StringParameter[] Parameters_StringParameter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.StartDashboardSnapshotJobResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.StartDashboardSnapshotJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SnapshotJobId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SnapshotJobId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SnapshotJobId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-QSDashboardSnapshotJob (StartDashboardSnapshotJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.StartDashboardSnapshotJobResponse, StartQSDashboardSnapshotJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SnapshotJobId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DashboardId = this.DashboardId;
            #if MODULAR
            if (this.DashboardId == null && ParameterWasBound(nameof(this.DashboardId)))
            {
                WriteWarning("You are passing $null as a value for parameter DashboardId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DestinationConfiguration_S3Destination != null)
            {
                context.DestinationConfiguration_S3Destination = new List<Amazon.QuickSight.Model.SnapshotS3DestinationConfiguration>(this.DestinationConfiguration_S3Destination);
            }
            if (this.SnapshotConfiguration_FileGroup != null)
            {
                context.SnapshotConfiguration_FileGroup = new List<Amazon.QuickSight.Model.SnapshotFileGroup>(this.SnapshotConfiguration_FileGroup);
            }
            #if MODULAR
            if (this.SnapshotConfiguration_FileGroup == null && ParameterWasBound(nameof(this.SnapshotConfiguration_FileGroup)))
            {
                WriteWarning("You are passing $null as a value for parameter SnapshotConfiguration_FileGroup which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Parameters_DateTimeParameter != null)
            {
                context.Parameters_DateTimeParameter = new List<Amazon.QuickSight.Model.DateTimeParameter>(this.Parameters_DateTimeParameter);
            }
            if (this.Parameters_DecimalParameter != null)
            {
                context.Parameters_DecimalParameter = new List<Amazon.QuickSight.Model.DecimalParameter>(this.Parameters_DecimalParameter);
            }
            if (this.Parameters_IntegerParameter != null)
            {
                context.Parameters_IntegerParameter = new List<Amazon.QuickSight.Model.IntegerParameter>(this.Parameters_IntegerParameter);
            }
            if (this.Parameters_StringParameter != null)
            {
                context.Parameters_StringParameter = new List<Amazon.QuickSight.Model.StringParameter>(this.Parameters_StringParameter);
            }
            context.SnapshotJobId = this.SnapshotJobId;
            #if MODULAR
            if (this.SnapshotJobId == null && ParameterWasBound(nameof(this.SnapshotJobId)))
            {
                WriteWarning("You are passing $null as a value for parameter SnapshotJobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.UserConfiguration_AnonymousUser != null)
            {
                context.UserConfiguration_AnonymousUser = new List<Amazon.QuickSight.Model.SnapshotAnonymousUser>(this.UserConfiguration_AnonymousUser);
            }
            
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
            var request = new Amazon.QuickSight.Model.StartDashboardSnapshotJobRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.DashboardId != null)
            {
                request.DashboardId = cmdletContext.DashboardId;
            }
            
             // populate SnapshotConfiguration
            var requestSnapshotConfigurationIsNull = true;
            request.SnapshotConfiguration = new Amazon.QuickSight.Model.SnapshotConfiguration();
            List<Amazon.QuickSight.Model.SnapshotFileGroup> requestSnapshotConfiguration_snapshotConfiguration_FileGroup = null;
            if (cmdletContext.SnapshotConfiguration_FileGroup != null)
            {
                requestSnapshotConfiguration_snapshotConfiguration_FileGroup = cmdletContext.SnapshotConfiguration_FileGroup;
            }
            if (requestSnapshotConfiguration_snapshotConfiguration_FileGroup != null)
            {
                request.SnapshotConfiguration.FileGroups = requestSnapshotConfiguration_snapshotConfiguration_FileGroup;
                requestSnapshotConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.SnapshotDestinationConfiguration requestSnapshotConfiguration_snapshotConfiguration_DestinationConfiguration = null;
            
             // populate DestinationConfiguration
            var requestSnapshotConfiguration_snapshotConfiguration_DestinationConfigurationIsNull = true;
            requestSnapshotConfiguration_snapshotConfiguration_DestinationConfiguration = new Amazon.QuickSight.Model.SnapshotDestinationConfiguration();
            List<Amazon.QuickSight.Model.SnapshotS3DestinationConfiguration> requestSnapshotConfiguration_snapshotConfiguration_DestinationConfiguration_destinationConfiguration_S3Destination = null;
            if (cmdletContext.DestinationConfiguration_S3Destination != null)
            {
                requestSnapshotConfiguration_snapshotConfiguration_DestinationConfiguration_destinationConfiguration_S3Destination = cmdletContext.DestinationConfiguration_S3Destination;
            }
            if (requestSnapshotConfiguration_snapshotConfiguration_DestinationConfiguration_destinationConfiguration_S3Destination != null)
            {
                requestSnapshotConfiguration_snapshotConfiguration_DestinationConfiguration.S3Destinations = requestSnapshotConfiguration_snapshotConfiguration_DestinationConfiguration_destinationConfiguration_S3Destination;
                requestSnapshotConfiguration_snapshotConfiguration_DestinationConfigurationIsNull = false;
            }
             // determine if requestSnapshotConfiguration_snapshotConfiguration_DestinationConfiguration should be set to null
            if (requestSnapshotConfiguration_snapshotConfiguration_DestinationConfigurationIsNull)
            {
                requestSnapshotConfiguration_snapshotConfiguration_DestinationConfiguration = null;
            }
            if (requestSnapshotConfiguration_snapshotConfiguration_DestinationConfiguration != null)
            {
                request.SnapshotConfiguration.DestinationConfiguration = requestSnapshotConfiguration_snapshotConfiguration_DestinationConfiguration;
                requestSnapshotConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.Parameters requestSnapshotConfiguration_snapshotConfiguration_Parameters = null;
            
             // populate Parameters
            var requestSnapshotConfiguration_snapshotConfiguration_ParametersIsNull = true;
            requestSnapshotConfiguration_snapshotConfiguration_Parameters = new Amazon.QuickSight.Model.Parameters();
            List<Amazon.QuickSight.Model.DateTimeParameter> requestSnapshotConfiguration_snapshotConfiguration_Parameters_parameters_DateTimeParameter = null;
            if (cmdletContext.Parameters_DateTimeParameter != null)
            {
                requestSnapshotConfiguration_snapshotConfiguration_Parameters_parameters_DateTimeParameter = cmdletContext.Parameters_DateTimeParameter;
            }
            if (requestSnapshotConfiguration_snapshotConfiguration_Parameters_parameters_DateTimeParameter != null)
            {
                requestSnapshotConfiguration_snapshotConfiguration_Parameters.DateTimeParameters = requestSnapshotConfiguration_snapshotConfiguration_Parameters_parameters_DateTimeParameter;
                requestSnapshotConfiguration_snapshotConfiguration_ParametersIsNull = false;
            }
            List<Amazon.QuickSight.Model.DecimalParameter> requestSnapshotConfiguration_snapshotConfiguration_Parameters_parameters_DecimalParameter = null;
            if (cmdletContext.Parameters_DecimalParameter != null)
            {
                requestSnapshotConfiguration_snapshotConfiguration_Parameters_parameters_DecimalParameter = cmdletContext.Parameters_DecimalParameter;
            }
            if (requestSnapshotConfiguration_snapshotConfiguration_Parameters_parameters_DecimalParameter != null)
            {
                requestSnapshotConfiguration_snapshotConfiguration_Parameters.DecimalParameters = requestSnapshotConfiguration_snapshotConfiguration_Parameters_parameters_DecimalParameter;
                requestSnapshotConfiguration_snapshotConfiguration_ParametersIsNull = false;
            }
            List<Amazon.QuickSight.Model.IntegerParameter> requestSnapshotConfiguration_snapshotConfiguration_Parameters_parameters_IntegerParameter = null;
            if (cmdletContext.Parameters_IntegerParameter != null)
            {
                requestSnapshotConfiguration_snapshotConfiguration_Parameters_parameters_IntegerParameter = cmdletContext.Parameters_IntegerParameter;
            }
            if (requestSnapshotConfiguration_snapshotConfiguration_Parameters_parameters_IntegerParameter != null)
            {
                requestSnapshotConfiguration_snapshotConfiguration_Parameters.IntegerParameters = requestSnapshotConfiguration_snapshotConfiguration_Parameters_parameters_IntegerParameter;
                requestSnapshotConfiguration_snapshotConfiguration_ParametersIsNull = false;
            }
            List<Amazon.QuickSight.Model.StringParameter> requestSnapshotConfiguration_snapshotConfiguration_Parameters_parameters_StringParameter = null;
            if (cmdletContext.Parameters_StringParameter != null)
            {
                requestSnapshotConfiguration_snapshotConfiguration_Parameters_parameters_StringParameter = cmdletContext.Parameters_StringParameter;
            }
            if (requestSnapshotConfiguration_snapshotConfiguration_Parameters_parameters_StringParameter != null)
            {
                requestSnapshotConfiguration_snapshotConfiguration_Parameters.StringParameters = requestSnapshotConfiguration_snapshotConfiguration_Parameters_parameters_StringParameter;
                requestSnapshotConfiguration_snapshotConfiguration_ParametersIsNull = false;
            }
             // determine if requestSnapshotConfiguration_snapshotConfiguration_Parameters should be set to null
            if (requestSnapshotConfiguration_snapshotConfiguration_ParametersIsNull)
            {
                requestSnapshotConfiguration_snapshotConfiguration_Parameters = null;
            }
            if (requestSnapshotConfiguration_snapshotConfiguration_Parameters != null)
            {
                request.SnapshotConfiguration.Parameters = requestSnapshotConfiguration_snapshotConfiguration_Parameters;
                requestSnapshotConfigurationIsNull = false;
            }
             // determine if request.SnapshotConfiguration should be set to null
            if (requestSnapshotConfigurationIsNull)
            {
                request.SnapshotConfiguration = null;
            }
            if (cmdletContext.SnapshotJobId != null)
            {
                request.SnapshotJobId = cmdletContext.SnapshotJobId;
            }
            
             // populate UserConfiguration
            var requestUserConfigurationIsNull = true;
            request.UserConfiguration = new Amazon.QuickSight.Model.SnapshotUserConfiguration();
            List<Amazon.QuickSight.Model.SnapshotAnonymousUser> requestUserConfiguration_userConfiguration_AnonymousUser = null;
            if (cmdletContext.UserConfiguration_AnonymousUser != null)
            {
                requestUserConfiguration_userConfiguration_AnonymousUser = cmdletContext.UserConfiguration_AnonymousUser;
            }
            if (requestUserConfiguration_userConfiguration_AnonymousUser != null)
            {
                request.UserConfiguration.AnonymousUsers = requestUserConfiguration_userConfiguration_AnonymousUser;
                requestUserConfigurationIsNull = false;
            }
             // determine if request.UserConfiguration should be set to null
            if (requestUserConfigurationIsNull)
            {
                request.UserConfiguration = null;
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
        
        private Amazon.QuickSight.Model.StartDashboardSnapshotJobResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.StartDashboardSnapshotJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "StartDashboardSnapshotJob");
            try
            {
                #if DESKTOP
                return client.StartDashboardSnapshotJob(request);
                #elif CORECLR
                return client.StartDashboardSnapshotJobAsync(request).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public System.String DashboardId { get; set; }
            public List<Amazon.QuickSight.Model.SnapshotS3DestinationConfiguration> DestinationConfiguration_S3Destination { get; set; }
            public List<Amazon.QuickSight.Model.SnapshotFileGroup> SnapshotConfiguration_FileGroup { get; set; }
            public List<Amazon.QuickSight.Model.DateTimeParameter> Parameters_DateTimeParameter { get; set; }
            public List<Amazon.QuickSight.Model.DecimalParameter> Parameters_DecimalParameter { get; set; }
            public List<Amazon.QuickSight.Model.IntegerParameter> Parameters_IntegerParameter { get; set; }
            public List<Amazon.QuickSight.Model.StringParameter> Parameters_StringParameter { get; set; }
            public System.String SnapshotJobId { get; set; }
            public List<Amazon.QuickSight.Model.SnapshotAnonymousUser> UserConfiguration_AnonymousUser { get; set; }
            public System.Func<Amazon.QuickSight.Model.StartDashboardSnapshotJobResponse, StartQSDashboardSnapshotJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
