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
using Amazon.ServerMigrationService;
using Amazon.ServerMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.SMS
{
    /// <summary>
    /// Creates a replication job. The replication job schedules periodic replication runs
    /// to replicate your server to Amazon Web Services. Each replication run creates an Amazon
    /// Machine Image (AMI).
    /// </summary>
    [Cmdlet("New", "SMSReplicationJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Server Migration Service CreateReplicationJob API operation.", Operation = new[] {"CreateReplicationJob"}, SelectReturnType = typeof(Amazon.ServerMigrationService.Model.CreateReplicationJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.ServerMigrationService.Model.CreateReplicationJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ServerMigrationService.Model.CreateReplicationJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMSReplicationJobCmdlet : AmazonServerMigrationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the replication job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Encrypted
        /// <summary>
        /// <para>
        /// <para>Indicates whether the replication job produces encrypted AMIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Encrypted { get; set; }
        #endregion
        
        #region Parameter Frequency
        /// <summary>
        /// <para>
        /// <para>The time between consecutive replication runs, in hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Frequency { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The ID of the KMS key for replication jobs that produce encrypted AMIs. This value
        /// can be any of the following:</para><ul><li><para>KMS key ID</para></li><li><para>KMS key alias</para></li><li><para>ARN referring to the KMS key ID</para></li><li><para>ARN referring to the KMS key alias</para></li></ul><para> If encrypted is <i>true</i> but a KMS key ID is not specified, the customer's default
        /// KMS key for Amazon EBS is used. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter LicenseType
        /// <summary>
        /// <para>
        /// <para>The license type to be used for the AMI created by a successful replication run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ServerMigrationService.LicenseType")]
        public Amazon.ServerMigrationService.LicenseType LicenseType { get; set; }
        #endregion
        
        #region Parameter NumberOfRecentAmisToKeep
        /// <summary>
        /// <para>
        /// <para>The maximum number of SMS-created AMIs to retain. The oldest is deleted after the
        /// maximum number is reached and a new AMI is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NumberOfRecentAmisToKeep { get; set; }
        #endregion
        
        #region Parameter RoleName
        /// <summary>
        /// <para>
        /// <para>The name of the IAM role to be used by the Server Migration Service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleName { get; set; }
        #endregion
        
        #region Parameter RunOnce
        /// <summary>
        /// <para>
        /// <para>Indicates whether to run the replication job one time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RunOnce { get; set; }
        #endregion
        
        #region Parameter SeedReplicationTime
        /// <summary>
        /// <para>
        /// <para>The seed replication time.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? SeedReplicationTime { get; set; }
        #endregion
        
        #region Parameter ServerId
        /// <summary>
        /// <para>
        /// <para>The ID of the server.</para>
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
        public System.String ServerId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReplicationJobId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServerMigrationService.Model.CreateReplicationJobResponse).
        /// Specifying the name of a property of type Amazon.ServerMigrationService.Model.CreateReplicationJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReplicationJobId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServerId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMSReplicationJob (CreateReplicationJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServerMigrationService.Model.CreateReplicationJobResponse, NewSMSReplicationJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.Encrypted = this.Encrypted;
            context.Frequency = this.Frequency;
            context.KmsKeyId = this.KmsKeyId;
            context.LicenseType = this.LicenseType;
            context.NumberOfRecentAmisToKeep = this.NumberOfRecentAmisToKeep;
            context.RoleName = this.RoleName;
            context.RunOnce = this.RunOnce;
            context.SeedReplicationTime = this.SeedReplicationTime;
            #if MODULAR
            if (this.SeedReplicationTime == null && ParameterWasBound(nameof(this.SeedReplicationTime)))
            {
                WriteWarning("You are passing $null as a value for parameter SeedReplicationTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServerId = this.ServerId;
            #if MODULAR
            if (this.ServerId == null && ParameterWasBound(nameof(this.ServerId)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ServerMigrationService.Model.CreateReplicationJobRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Encrypted != null)
            {
                request.Encrypted = cmdletContext.Encrypted.Value;
            }
            if (cmdletContext.Frequency != null)
            {
                request.Frequency = cmdletContext.Frequency.Value;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.LicenseType != null)
            {
                request.LicenseType = cmdletContext.LicenseType;
            }
            if (cmdletContext.NumberOfRecentAmisToKeep != null)
            {
                request.NumberOfRecentAmisToKeep = cmdletContext.NumberOfRecentAmisToKeep.Value;
            }
            if (cmdletContext.RoleName != null)
            {
                request.RoleName = cmdletContext.RoleName;
            }
            if (cmdletContext.RunOnce != null)
            {
                request.RunOnce = cmdletContext.RunOnce.Value;
            }
            if (cmdletContext.SeedReplicationTime != null)
            {
                request.SeedReplicationTime = cmdletContext.SeedReplicationTime.Value;
            }
            if (cmdletContext.ServerId != null)
            {
                request.ServerId = cmdletContext.ServerId;
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
        
        private Amazon.ServerMigrationService.Model.CreateReplicationJobResponse CallAWSServiceOperation(IAmazonServerMigrationService client, Amazon.ServerMigrationService.Model.CreateReplicationJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Server Migration Service", "CreateReplicationJob");
            try
            {
                #if DESKTOP
                return client.CreateReplicationJob(request);
                #elif CORECLR
                return client.CreateReplicationJobAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.Boolean? Encrypted { get; set; }
            public System.Int32? Frequency { get; set; }
            public System.String KmsKeyId { get; set; }
            public Amazon.ServerMigrationService.LicenseType LicenseType { get; set; }
            public System.Int32? NumberOfRecentAmisToKeep { get; set; }
            public System.String RoleName { get; set; }
            public System.Boolean? RunOnce { get; set; }
            public System.DateTime? SeedReplicationTime { get; set; }
            public System.String ServerId { get; set; }
            public System.Func<Amazon.ServerMigrationService.Model.CreateReplicationJobResponse, NewSMSReplicationJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReplicationJobId;
        }
        
    }
}
