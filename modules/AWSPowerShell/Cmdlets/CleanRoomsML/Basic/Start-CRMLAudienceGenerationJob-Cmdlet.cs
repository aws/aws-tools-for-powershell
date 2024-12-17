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
using Amazon.CleanRoomsML;
using Amazon.CleanRoomsML.Model;

namespace Amazon.PowerShell.Cmdlets.CRML
{
    /// <summary>
    /// Information necessary to start the audience generation job.
    /// </summary>
    [Cmdlet("Start", "CRMLAudienceGenerationJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the CleanRoomsML StartAudienceGenerationJob API operation.", Operation = new[] {"StartAudienceGenerationJob"}, SelectReturnType = typeof(Amazon.CleanRoomsML.Model.StartAudienceGenerationJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.CleanRoomsML.Model.StartAudienceGenerationJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CleanRoomsML.Model.StartAudienceGenerationJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartCRMLAudienceGenerationJobCmdlet : AmazonCleanRoomsMLClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SqlParameters_AnalysisTemplateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) associated with the analysis template within a collaboration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SeedAudience_SqlParameters_AnalysisTemplateArn")]
        public System.String SqlParameters_AnalysisTemplateArn { get; set; }
        #endregion
        
        #region Parameter CollaborationId
        /// <summary>
        /// <para>
        /// <para>The identifier of the collaboration that contains the audience generation job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CollaborationId { get; set; }
        #endregion
        
        #region Parameter ConfiguredAudienceModelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the configured audience model that is used for this
        /// audience generation job.</para>
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
        public System.String ConfiguredAudienceModelArn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the audience generation job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter IncludeSeedInOutput
        /// <summary>
        /// <para>
        /// <para>Whether the seed audience is included in the audience generation output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeSeedInOutput { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the audience generation job.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Worker_Number
        /// <summary>
        /// <para>
        /// <para>The number of compute workers that are used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SeedAudience_SqlComputeConfiguration_Worker_Number")]
        public System.Int32? Worker_Number { get; set; }
        #endregion
        
        #region Parameter SqlParameters_Parameter
        /// <summary>
        /// <para>
        /// <para>The protected query SQL parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SeedAudience_SqlParameters_Parameters")]
        public System.Collections.Hashtable SqlParameters_Parameter { get; set; }
        #endregion
        
        #region Parameter SqlParameters_QueryString
        /// <summary>
        /// <para>
        /// <para>The query string to be submitted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SeedAudience_SqlParameters_QueryString")]
        public System.String SqlParameters_QueryString { get; set; }
        #endregion
        
        #region Parameter SeedAudience_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that can read the Amazon S3 bucket where the seed audience
        /// is stored.</para>
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
        public System.String SeedAudience_RoleArn { get; set; }
        #endregion
        
        #region Parameter DataSource_S3Uri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location URI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SeedAudience_DataSource_S3Uri")]
        public System.String DataSource_S3Uri { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The optional metadata that you apply to the resource to help you categorize and organize
        /// them. Each tag consists of a key and an optional value, both of which you define.</para><para>The following basic restrictions apply to tags:</para><ul><li><para>Maximum number of tags per resource - 50.</para></li><li><para>For each resource, each tag key must be unique, and each tag key can have only one
        /// value.</para></li><li><para>Maximum key length - 128 Unicode characters in UTF-8.</para></li><li><para>Maximum value length - 256 Unicode characters in UTF-8.</para></li><li><para>If your tagging schema is used across multiple services and resources, remember that
        /// other services may have restrictions on allowed characters. Generally allowed characters
        /// are: letters, numbers, and spaces representable in UTF-8, and the following characters:
        /// + - = . _ : / @.</para></li><li><para>Tag keys and values are case sensitive.</para></li><li><para>Do not use aws:, AWS:, or any upper or lowercase combination of such as a prefix for
        /// keys as it is reserved for AWS use. You cannot edit or delete tag keys with this prefix.
        /// Values can have this prefix. If a tag value has aws as its prefix but the key does
        /// not, then Clean Rooms ML considers it to be a user tag and will count against the
        /// limit of 50 tags. Tags with only the key prefix of aws do not count against your tags
        /// per resource limit.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Worker_Type
        /// <summary>
        /// <para>
        /// <para>The instance type of the compute workers that are used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SeedAudience_SqlComputeConfiguration_Worker_Type")]
        [AWSConstantClassSource("Amazon.CleanRoomsML.WorkerComputeType")]
        public Amazon.CleanRoomsML.WorkerComputeType Worker_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AudienceGenerationJobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CleanRoomsML.Model.StartAudienceGenerationJobResponse).
        /// Specifying the name of a property of type Amazon.CleanRoomsML.Model.StartAudienceGenerationJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AudienceGenerationJobArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CRMLAudienceGenerationJob (StartAudienceGenerationJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CleanRoomsML.Model.StartAudienceGenerationJobResponse, StartCRMLAudienceGenerationJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CollaborationId = this.CollaborationId;
            context.ConfiguredAudienceModelArn = this.ConfiguredAudienceModelArn;
            #if MODULAR
            if (this.ConfiguredAudienceModelArn == null && ParameterWasBound(nameof(this.ConfiguredAudienceModelArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfiguredAudienceModelArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.IncludeSeedInOutput = this.IncludeSeedInOutput;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataSource_S3Uri = this.DataSource_S3Uri;
            context.SeedAudience_RoleArn = this.SeedAudience_RoleArn;
            #if MODULAR
            if (this.SeedAudience_RoleArn == null && ParameterWasBound(nameof(this.SeedAudience_RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SeedAudience_RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Worker_Number = this.Worker_Number;
            context.Worker_Type = this.Worker_Type;
            context.SqlParameters_AnalysisTemplateArn = this.SqlParameters_AnalysisTemplateArn;
            if (this.SqlParameters_Parameter != null)
            {
                context.SqlParameters_Parameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SqlParameters_Parameter.Keys)
                {
                    context.SqlParameters_Parameter.Add((String)hashKey, (System.String)(this.SqlParameters_Parameter[hashKey]));
                }
            }
            context.SqlParameters_QueryString = this.SqlParameters_QueryString;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.CleanRoomsML.Model.StartAudienceGenerationJobRequest();
            
            if (cmdletContext.CollaborationId != null)
            {
                request.CollaborationId = cmdletContext.CollaborationId;
            }
            if (cmdletContext.ConfiguredAudienceModelArn != null)
            {
                request.ConfiguredAudienceModelArn = cmdletContext.ConfiguredAudienceModelArn;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.IncludeSeedInOutput != null)
            {
                request.IncludeSeedInOutput = cmdletContext.IncludeSeedInOutput.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate SeedAudience
            var requestSeedAudienceIsNull = true;
            request.SeedAudience = new Amazon.CleanRoomsML.Model.AudienceGenerationJobDataSource();
            System.String requestSeedAudience_seedAudience_RoleArn = null;
            if (cmdletContext.SeedAudience_RoleArn != null)
            {
                requestSeedAudience_seedAudience_RoleArn = cmdletContext.SeedAudience_RoleArn;
            }
            if (requestSeedAudience_seedAudience_RoleArn != null)
            {
                request.SeedAudience.RoleArn = requestSeedAudience_seedAudience_RoleArn;
                requestSeedAudienceIsNull = false;
            }
            Amazon.CleanRoomsML.Model.S3ConfigMap requestSeedAudience_seedAudience_DataSource = null;
            
             // populate DataSource
            var requestSeedAudience_seedAudience_DataSourceIsNull = true;
            requestSeedAudience_seedAudience_DataSource = new Amazon.CleanRoomsML.Model.S3ConfigMap();
            System.String requestSeedAudience_seedAudience_DataSource_dataSource_S3Uri = null;
            if (cmdletContext.DataSource_S3Uri != null)
            {
                requestSeedAudience_seedAudience_DataSource_dataSource_S3Uri = cmdletContext.DataSource_S3Uri;
            }
            if (requestSeedAudience_seedAudience_DataSource_dataSource_S3Uri != null)
            {
                requestSeedAudience_seedAudience_DataSource.S3Uri = requestSeedAudience_seedAudience_DataSource_dataSource_S3Uri;
                requestSeedAudience_seedAudience_DataSourceIsNull = false;
            }
             // determine if requestSeedAudience_seedAudience_DataSource should be set to null
            if (requestSeedAudience_seedAudience_DataSourceIsNull)
            {
                requestSeedAudience_seedAudience_DataSource = null;
            }
            if (requestSeedAudience_seedAudience_DataSource != null)
            {
                request.SeedAudience.DataSource = requestSeedAudience_seedAudience_DataSource;
                requestSeedAudienceIsNull = false;
            }
            Amazon.CleanRoomsML.Model.ComputeConfiguration requestSeedAudience_seedAudience_SqlComputeConfiguration = null;
            
             // populate SqlComputeConfiguration
            var requestSeedAudience_seedAudience_SqlComputeConfigurationIsNull = true;
            requestSeedAudience_seedAudience_SqlComputeConfiguration = new Amazon.CleanRoomsML.Model.ComputeConfiguration();
            Amazon.CleanRoomsML.Model.WorkerComputeConfiguration requestSeedAudience_seedAudience_SqlComputeConfiguration_seedAudience_SqlComputeConfiguration_Worker = null;
            
             // populate Worker
            var requestSeedAudience_seedAudience_SqlComputeConfiguration_seedAudience_SqlComputeConfiguration_WorkerIsNull = true;
            requestSeedAudience_seedAudience_SqlComputeConfiguration_seedAudience_SqlComputeConfiguration_Worker = new Amazon.CleanRoomsML.Model.WorkerComputeConfiguration();
            System.Int32? requestSeedAudience_seedAudience_SqlComputeConfiguration_seedAudience_SqlComputeConfiguration_Worker_worker_Number = null;
            if (cmdletContext.Worker_Number != null)
            {
                requestSeedAudience_seedAudience_SqlComputeConfiguration_seedAudience_SqlComputeConfiguration_Worker_worker_Number = cmdletContext.Worker_Number.Value;
            }
            if (requestSeedAudience_seedAudience_SqlComputeConfiguration_seedAudience_SqlComputeConfiguration_Worker_worker_Number != null)
            {
                requestSeedAudience_seedAudience_SqlComputeConfiguration_seedAudience_SqlComputeConfiguration_Worker.Number = requestSeedAudience_seedAudience_SqlComputeConfiguration_seedAudience_SqlComputeConfiguration_Worker_worker_Number.Value;
                requestSeedAudience_seedAudience_SqlComputeConfiguration_seedAudience_SqlComputeConfiguration_WorkerIsNull = false;
            }
            Amazon.CleanRoomsML.WorkerComputeType requestSeedAudience_seedAudience_SqlComputeConfiguration_seedAudience_SqlComputeConfiguration_Worker_worker_Type = null;
            if (cmdletContext.Worker_Type != null)
            {
                requestSeedAudience_seedAudience_SqlComputeConfiguration_seedAudience_SqlComputeConfiguration_Worker_worker_Type = cmdletContext.Worker_Type;
            }
            if (requestSeedAudience_seedAudience_SqlComputeConfiguration_seedAudience_SqlComputeConfiguration_Worker_worker_Type != null)
            {
                requestSeedAudience_seedAudience_SqlComputeConfiguration_seedAudience_SqlComputeConfiguration_Worker.Type = requestSeedAudience_seedAudience_SqlComputeConfiguration_seedAudience_SqlComputeConfiguration_Worker_worker_Type;
                requestSeedAudience_seedAudience_SqlComputeConfiguration_seedAudience_SqlComputeConfiguration_WorkerIsNull = false;
            }
             // determine if requestSeedAudience_seedAudience_SqlComputeConfiguration_seedAudience_SqlComputeConfiguration_Worker should be set to null
            if (requestSeedAudience_seedAudience_SqlComputeConfiguration_seedAudience_SqlComputeConfiguration_WorkerIsNull)
            {
                requestSeedAudience_seedAudience_SqlComputeConfiguration_seedAudience_SqlComputeConfiguration_Worker = null;
            }
            if (requestSeedAudience_seedAudience_SqlComputeConfiguration_seedAudience_SqlComputeConfiguration_Worker != null)
            {
                requestSeedAudience_seedAudience_SqlComputeConfiguration.Worker = requestSeedAudience_seedAudience_SqlComputeConfiguration_seedAudience_SqlComputeConfiguration_Worker;
                requestSeedAudience_seedAudience_SqlComputeConfigurationIsNull = false;
            }
             // determine if requestSeedAudience_seedAudience_SqlComputeConfiguration should be set to null
            if (requestSeedAudience_seedAudience_SqlComputeConfigurationIsNull)
            {
                requestSeedAudience_seedAudience_SqlComputeConfiguration = null;
            }
            if (requestSeedAudience_seedAudience_SqlComputeConfiguration != null)
            {
                request.SeedAudience.SqlComputeConfiguration = requestSeedAudience_seedAudience_SqlComputeConfiguration;
                requestSeedAudienceIsNull = false;
            }
            Amazon.CleanRoomsML.Model.ProtectedQuerySQLParameters requestSeedAudience_seedAudience_SqlParameters = null;
            
             // populate SqlParameters
            var requestSeedAudience_seedAudience_SqlParametersIsNull = true;
            requestSeedAudience_seedAudience_SqlParameters = new Amazon.CleanRoomsML.Model.ProtectedQuerySQLParameters();
            System.String requestSeedAudience_seedAudience_SqlParameters_sqlParameters_AnalysisTemplateArn = null;
            if (cmdletContext.SqlParameters_AnalysisTemplateArn != null)
            {
                requestSeedAudience_seedAudience_SqlParameters_sqlParameters_AnalysisTemplateArn = cmdletContext.SqlParameters_AnalysisTemplateArn;
            }
            if (requestSeedAudience_seedAudience_SqlParameters_sqlParameters_AnalysisTemplateArn != null)
            {
                requestSeedAudience_seedAudience_SqlParameters.AnalysisTemplateArn = requestSeedAudience_seedAudience_SqlParameters_sqlParameters_AnalysisTemplateArn;
                requestSeedAudience_seedAudience_SqlParametersIsNull = false;
            }
            Dictionary<System.String, System.String> requestSeedAudience_seedAudience_SqlParameters_sqlParameters_Parameter = null;
            if (cmdletContext.SqlParameters_Parameter != null)
            {
                requestSeedAudience_seedAudience_SqlParameters_sqlParameters_Parameter = cmdletContext.SqlParameters_Parameter;
            }
            if (requestSeedAudience_seedAudience_SqlParameters_sqlParameters_Parameter != null)
            {
                requestSeedAudience_seedAudience_SqlParameters.Parameters = requestSeedAudience_seedAudience_SqlParameters_sqlParameters_Parameter;
                requestSeedAudience_seedAudience_SqlParametersIsNull = false;
            }
            System.String requestSeedAudience_seedAudience_SqlParameters_sqlParameters_QueryString = null;
            if (cmdletContext.SqlParameters_QueryString != null)
            {
                requestSeedAudience_seedAudience_SqlParameters_sqlParameters_QueryString = cmdletContext.SqlParameters_QueryString;
            }
            if (requestSeedAudience_seedAudience_SqlParameters_sqlParameters_QueryString != null)
            {
                requestSeedAudience_seedAudience_SqlParameters.QueryString = requestSeedAudience_seedAudience_SqlParameters_sqlParameters_QueryString;
                requestSeedAudience_seedAudience_SqlParametersIsNull = false;
            }
             // determine if requestSeedAudience_seedAudience_SqlParameters should be set to null
            if (requestSeedAudience_seedAudience_SqlParametersIsNull)
            {
                requestSeedAudience_seedAudience_SqlParameters = null;
            }
            if (requestSeedAudience_seedAudience_SqlParameters != null)
            {
                request.SeedAudience.SqlParameters = requestSeedAudience_seedAudience_SqlParameters;
                requestSeedAudienceIsNull = false;
            }
             // determine if request.SeedAudience should be set to null
            if (requestSeedAudienceIsNull)
            {
                request.SeedAudience = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.CleanRoomsML.Model.StartAudienceGenerationJobResponse CallAWSServiceOperation(IAmazonCleanRoomsML client, Amazon.CleanRoomsML.Model.StartAudienceGenerationJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CleanRoomsML", "StartAudienceGenerationJob");
            try
            {
                #if DESKTOP
                return client.StartAudienceGenerationJob(request);
                #elif CORECLR
                return client.StartAudienceGenerationJobAsync(request).GetAwaiter().GetResult();
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
            public System.String CollaborationId { get; set; }
            public System.String ConfiguredAudienceModelArn { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? IncludeSeedInOutput { get; set; }
            public System.String Name { get; set; }
            public System.String DataSource_S3Uri { get; set; }
            public System.String SeedAudience_RoleArn { get; set; }
            public System.Int32? Worker_Number { get; set; }
            public Amazon.CleanRoomsML.WorkerComputeType Worker_Type { get; set; }
            public System.String SqlParameters_AnalysisTemplateArn { get; set; }
            public Dictionary<System.String, System.String> SqlParameters_Parameter { get; set; }
            public System.String SqlParameters_QueryString { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CleanRoomsML.Model.StartAudienceGenerationJobResponse, StartCRMLAudienceGenerationJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AudienceGenerationJobArn;
        }
        
    }
}
