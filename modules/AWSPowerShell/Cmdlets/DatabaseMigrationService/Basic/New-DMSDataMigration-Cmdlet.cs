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
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.DMS
{
    /// <summary>
    /// Creates a data migration using the provided settings.
    /// </summary>
    [Cmdlet("New", "DMSDataMigration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DatabaseMigrationService.Model.DataMigration")]
    [AWSCmdlet("Calls the AWS Database Migration Service CreateDataMigration API operation.", Operation = new[] {"CreateDataMigration"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.CreateDataMigrationResponse))]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.DataMigration or Amazon.DatabaseMigrationService.Model.CreateDataMigrationResponse",
        "This cmdlet returns an Amazon.DatabaseMigrationService.Model.DataMigration object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.CreateDataMigrationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDMSDataMigrationCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DataMigrationName
        /// <summary>
        /// <para>
        /// <para>A user-friendly name for the data migration. Data migration names have the following
        /// constraints:</para><ul><li><para>Must begin with a letter, and can only contain ASCII letters, digits, and hyphens.
        /// </para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens.</para></li><li><para>Length must be from 1 to 255 characters.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataMigrationName { get; set; }
        #endregion
        
        #region Parameter DataMigrationType
        /// <summary>
        /// <para>
        /// <para>Specifies if the data migration is full-load only, change data capture (CDC) only,
        /// or full-load and CDC.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.MigrationTypeValue")]
        public Amazon.DatabaseMigrationService.MigrationTypeValue DataMigrationType { get; set; }
        #endregion
        
        #region Parameter EnableCloudwatchLog
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable CloudWatch logs for the data migration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnableCloudwatchLogs")]
        public System.Boolean? EnableCloudwatchLog { get; set; }
        #endregion
        
        #region Parameter MigrationProjectIdentifier
        /// <summary>
        /// <para>
        /// <para>An identifier for the migration project.</para>
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
        public System.String MigrationProjectIdentifier { get; set; }
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
        /// <para>An optional JSON string specifying what tables, views, and schemas to include or exclude
        /// from the migration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SelectionRules")]
        public System.String SelectionRule { get; set; }
        #endregion
        
        #region Parameter ServiceAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the service access role that you want to use to
        /// create the data migration.</para>
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
        public System.String ServiceAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter SourceDataSetting
        /// <summary>
        /// <para>
        /// <para>Specifies information about the source data provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceDataSettings")]
        public Amazon.DatabaseMigrationService.Model.SourceDataSetting[] SourceDataSetting { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>One or more tags to be assigned to the data migration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DatabaseMigrationService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataMigration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.CreateDataMigrationResponse).
        /// Specifying the name of a property of type Amazon.DatabaseMigrationService.Model.CreateDataMigrationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataMigration";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DMSDataMigration (CreateDataMigration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.CreateDataMigrationResponse, NewDMSDataMigrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DataMigrationName = this.DataMigrationName;
            context.DataMigrationType = this.DataMigrationType;
            #if MODULAR
            if (this.DataMigrationType == null && ParameterWasBound(nameof(this.DataMigrationType)))
            {
                WriteWarning("You are passing $null as a value for parameter DataMigrationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnableCloudwatchLog = this.EnableCloudwatchLog;
            context.MigrationProjectIdentifier = this.MigrationProjectIdentifier;
            #if MODULAR
            if (this.MigrationProjectIdentifier == null && ParameterWasBound(nameof(this.MigrationProjectIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MigrationProjectIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NumberOfJob = this.NumberOfJob;
            context.SelectionRule = this.SelectionRule;
            context.ServiceAccessRoleArn = this.ServiceAccessRoleArn;
            #if MODULAR
            if (this.ServiceAccessRoleArn == null && ParameterWasBound(nameof(this.ServiceAccessRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceAccessRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SourceDataSetting != null)
            {
                context.SourceDataSetting = new List<Amazon.DatabaseMigrationService.Model.SourceDataSetting>(this.SourceDataSetting);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.DatabaseMigrationService.Model.Tag>(this.Tag);
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
            var request = new Amazon.DatabaseMigrationService.Model.CreateDataMigrationRequest();
            
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
            if (cmdletContext.MigrationProjectIdentifier != null)
            {
                request.MigrationProjectIdentifier = cmdletContext.MigrationProjectIdentifier;
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
        
        private Amazon.DatabaseMigrationService.Model.CreateDataMigrationResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.CreateDataMigrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "CreateDataMigration");
            try
            {
                #if DESKTOP
                return client.CreateDataMigration(request);
                #elif CORECLR
                return client.CreateDataMigrationAsync(request).GetAwaiter().GetResult();
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
            public System.String DataMigrationName { get; set; }
            public Amazon.DatabaseMigrationService.MigrationTypeValue DataMigrationType { get; set; }
            public System.Boolean? EnableCloudwatchLog { get; set; }
            public System.String MigrationProjectIdentifier { get; set; }
            public System.Int32? NumberOfJob { get; set; }
            public System.String SelectionRule { get; set; }
            public System.String ServiceAccessRoleArn { get; set; }
            public List<Amazon.DatabaseMigrationService.Model.SourceDataSetting> SourceDataSetting { get; set; }
            public List<Amazon.DatabaseMigrationService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.DatabaseMigrationService.Model.CreateDataMigrationResponse, NewDMSDataMigrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataMigration;
        }
        
    }
}
