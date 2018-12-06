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
using Amazon.ServerMigrationService;
using Amazon.ServerMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.SMS
{
    /// <summary>
    /// Updates the specified settings for the specified replication job.
    /// </summary>
    [Cmdlet("Update", "SMSReplicationJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Server Migration Service UpdateReplicationJob API operation.", Operation = new[] {"UpdateReplicationJob"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ReplicationJobId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.ServerMigrationService.Model.UpdateReplicationJobResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSMSReplicationJobCmdlet : AmazonServerMigrationServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the replication job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Encrypted
        /// <summary>
        /// <para>
        /// <para>When true, the replication job produces encrypted AMIs . See also <code>KmsKeyId</code>
        /// below.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Encrypted { get; set; }
        #endregion
        
        #region Parameter Frequency
        /// <summary>
        /// <para>
        /// <para>The time between consecutive replication runs, in hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Frequency { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>KMS key ID for replication jobs that produce encrypted AMIs. Can be any of the following:
        /// </para><ul><li><para>KMS key ID</para></li><li><para>KMS key alias</para></li><li><para>ARN referring to KMS key ID</para></li><li><para>ARN referring to KMS key alias</para></li></ul><para> If encrypted is <i>true</i> but a KMS key id is not specified, the customer's default
        /// KMS key for EBS is used. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter LicenseType
        /// <summary>
        /// <para>
        /// <para>The license type to be used for the AMI created by a successful replication run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ServerMigrationService.LicenseType")]
        public Amazon.ServerMigrationService.LicenseType LicenseType { get; set; }
        #endregion
        
        #region Parameter NextReplicationRunStartTime
        /// <summary>
        /// <para>
        /// <para>The start time of the next replication run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime NextReplicationRunStartTime { get; set; }
        #endregion
        
        #region Parameter NumberOfRecentAmisToKeep
        /// <summary>
        /// <para>
        /// <para>The maximum number of SMS-created AMIs to retain. The oldest will be deleted once
        /// the maximum number is reached and a new AMI is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 NumberOfRecentAmisToKeep { get; set; }
        #endregion
        
        #region Parameter ReplicationJobId
        /// <summary>
        /// <para>
        /// <para>The identifier of the replication job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ReplicationJobId { get; set; }
        #endregion
        
        #region Parameter RoleName
        /// <summary>
        /// <para>
        /// <para>The name of the IAM role to be used by AWS SMS.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleName { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the ReplicationJobId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ReplicationJobId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMSReplicationJob (UpdateReplicationJob)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Description = this.Description;
            if (ParameterWasBound("Encrypted"))
                context.Encrypted = this.Encrypted;
            if (ParameterWasBound("Frequency"))
                context.Frequency = this.Frequency;
            context.KmsKeyId = this.KmsKeyId;
            context.LicenseType = this.LicenseType;
            if (ParameterWasBound("NextReplicationRunStartTime"))
                context.NextReplicationRunStartTime = this.NextReplicationRunStartTime;
            if (ParameterWasBound("NumberOfRecentAmisToKeep"))
                context.NumberOfRecentAmisToKeep = this.NumberOfRecentAmisToKeep;
            context.ReplicationJobId = this.ReplicationJobId;
            context.RoleName = this.RoleName;
            
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
            var request = new Amazon.ServerMigrationService.Model.UpdateReplicationJobRequest();
            
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
            if (cmdletContext.NextReplicationRunStartTime != null)
            {
                request.NextReplicationRunStartTime = cmdletContext.NextReplicationRunStartTime.Value;
            }
            if (cmdletContext.NumberOfRecentAmisToKeep != null)
            {
                request.NumberOfRecentAmisToKeep = cmdletContext.NumberOfRecentAmisToKeep.Value;
            }
            if (cmdletContext.ReplicationJobId != null)
            {
                request.ReplicationJobId = cmdletContext.ReplicationJobId;
            }
            if (cmdletContext.RoleName != null)
            {
                request.RoleName = cmdletContext.RoleName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.ReplicationJobId;
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
        
        private Amazon.ServerMigrationService.Model.UpdateReplicationJobResponse CallAWSServiceOperation(IAmazonServerMigrationService client, Amazon.ServerMigrationService.Model.UpdateReplicationJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Server Migration Service", "UpdateReplicationJob");
            try
            {
                #if DESKTOP
                return client.UpdateReplicationJob(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateReplicationJobAsync(request);
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
            public System.String Description { get; set; }
            public System.Boolean? Encrypted { get; set; }
            public System.Int32? Frequency { get; set; }
            public System.String KmsKeyId { get; set; }
            public Amazon.ServerMigrationService.LicenseType LicenseType { get; set; }
            public System.DateTime? NextReplicationRunStartTime { get; set; }
            public System.Int32? NumberOfRecentAmisToKeep { get; set; }
            public System.String ReplicationJobId { get; set; }
            public System.String RoleName { get; set; }
        }
        
    }
}
