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
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.DMS
{
    /// <summary>
    /// Modifies an existing DMS data migration.
    /// </summary>
    [Cmdlet("Edit", "DMSDataMigration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DatabaseMigrationService.Model.DataMigration")]
    [AWSCmdlet("Calls the AWS Database Migration Service ModifyDataMigration API operation.", Operation = new[] {"ModifyDataMigration"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.ModifyDataMigrationResponse))]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.DataMigration or Amazon.DatabaseMigrationService.Model.ModifyDataMigrationResponse",
        "This cmdlet returns an Amazon.DatabaseMigrationService.Model.DataMigration object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.ModifyDataMigrationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditDMSDataMigrationCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DataMigrationIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier (name or ARN) of the data migration to modify.</para>
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
        public System.String DataMigrationIdentifier { get; set; }
        #endregion
        
        #region Parameter DataMigrationName
        /// <summary>
        /// <para>
        /// <para>The new name for the data migration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataMigrationName { get; set; }
        #endregion
        
        #region Parameter DataMigrationType
        /// <summary>
        /// <para>
        /// <para>The new migration type for the data migration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.MigrationTypeValue")]
        public Amazon.DatabaseMigrationService.MigrationTypeValue DataMigrationType { get; set; }
        #endregion
        
        #region Parameter EnableCloudwatchLog
        /// <summary>
        /// <para>
        /// <para>Whether to enable Cloudwatch logs for the data migration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnableCloudwatchLogs")]
        public System.Boolean? EnableCloudwatchLog { get; set; }
        #endregion
        
        #region Parameter NumberOfJob
        /// <summary>
        /// <para>
        /// <para>The number of parallel jobs that trigger parallel threads to unload the tables from
        /// the source, and then load them to the target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NumberOfJobs")]
        public System.Int32? NumberOfJob { get; set; }
        #endregion
        
        #region Parameter SelectionRule
        /// <summary>
        /// <para>
        /// <para>A JSON-formatted string that defines what objects to include and exclude from the
        /// migration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SelectionRules")]
        public System.String SelectionRule { get; set; }
        #endregion
        
        #region Parameter ServiceAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The new service access role ARN for the data migration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter SourceDataSetting
        /// <summary>
        /// <para>
        /// <para>The new information about the source data provider for the data migration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceDataSettings")]
        public Amazon.DatabaseMigrationService.Model.SourceDataSetting[] SourceDataSetting { get; set; }
        #endregion
        
        #region Parameter TargetDataSetting
        /// <summary>
        /// <para>
        /// <para>The new information about the target data provider for the data migration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetDataSettings")]
        public Amazon.DatabaseMigrationService.Model.TargetDataSetting[] TargetDataSetting { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataMigration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.ModifyDataMigrationResponse).
        /// Specifying the name of a property of type Amazon.DatabaseMigrationService.Model.ModifyDataMigrationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataMigration";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DataMigrationIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DataMigrationIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DataMigrationIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DataMigrationIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-DMSDataMigration (ModifyDataMigration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.ModifyDataMigrationResponse, EditDMSDataMigrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DataMigrationIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DataMigrationIdentifier = this.DataMigrationIdentifier;
            #if MODULAR
            if (this.DataMigrationIdentifier == null && ParameterWasBound(nameof(this.DataMigrationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DataMigrationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataMigrationName = this.DataMigrationName;
            context.DataMigrationType = this.DataMigrationType;
            context.EnableCloudwatchLog = this.EnableCloudwatchLog;
            context.NumberOfJob = this.NumberOfJob;
            context.SelectionRule = this.SelectionRule;
            context.ServiceAccessRoleArn = this.ServiceAccessRoleArn;
            if (this.SourceDataSetting != null)
            {
                context.SourceDataSetting = new List<Amazon.DatabaseMigrationService.Model.SourceDataSetting>(this.SourceDataSetting);
            }
            if (this.TargetDataSetting != null)
            {
                context.TargetDataSetting = new List<Amazon.DatabaseMigrationService.Model.TargetDataSetting>(this.TargetDataSetting);
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
            var request = new Amazon.DatabaseMigrationService.Model.ModifyDataMigrationRequest();
            
            if (cmdletContext.DataMigrationIdentifier != null)
            {
                request.DataMigrationIdentifier = cmdletContext.DataMigrationIdentifier;
            }
            if (cmdletContext.DataMigrationName != null)
            {
                request.DataMigrationName = cmdletContext.DataMigrationName;
            }
            if (cmdletContext.DataMigrationType != null)
            {
                request.DataMigrationType = cmdletContext.DataMigrationType;
            }
            if (cmdletContext.EnableCloudwatchLog != null)
            {
                request.EnableCloudwatchLogs = cmdletContext.EnableCloudwatchLog.Value;
            }
            if (cmdletContext.NumberOfJob != null)
            {
                request.NumberOfJobs = cmdletContext.NumberOfJob.Value;
            }
            if (cmdletContext.SelectionRule != null)
            {
                request.SelectionRules = cmdletContext.SelectionRule;
            }
            if (cmdletContext.ServiceAccessRoleArn != null)
            {
                request.ServiceAccessRoleArn = cmdletContext.ServiceAccessRoleArn;
            }
            if (cmdletContext.SourceDataSetting != null)
            {
                request.SourceDataSettings = cmdletContext.SourceDataSetting;
            }
            if (cmdletContext.TargetDataSetting != null)
            {
                request.TargetDataSettings = cmdletContext.TargetDataSetting;
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
        
        private Amazon.DatabaseMigrationService.Model.ModifyDataMigrationResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.ModifyDataMigrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "ModifyDataMigration");
            try
            {
                #if DESKTOP
                return client.ModifyDataMigration(request);
                #elif CORECLR
                return client.ModifyDataMigrationAsync(request).GetAwaiter().GetResult();
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
            public System.String DataMigrationIdentifier { get; set; }
            public System.String DataMigrationName { get; set; }
            public Amazon.DatabaseMigrationService.MigrationTypeValue DataMigrationType { get; set; }
            public System.Boolean? EnableCloudwatchLog { get; set; }
            public System.Int32? NumberOfJob { get; set; }
            public System.String SelectionRule { get; set; }
            public System.String ServiceAccessRoleArn { get; set; }
            public List<Amazon.DatabaseMigrationService.Model.SourceDataSetting> SourceDataSetting { get; set; }
            public List<Amazon.DatabaseMigrationService.Model.TargetDataSetting> TargetDataSetting { get; set; }
            public System.Func<Amazon.DatabaseMigrationService.Model.ModifyDataMigrationResponse, EditDMSDataMigrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataMigration;
        }
        
    }
}
