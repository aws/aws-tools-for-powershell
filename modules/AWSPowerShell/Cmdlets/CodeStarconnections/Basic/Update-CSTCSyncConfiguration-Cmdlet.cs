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
using Amazon.CodeStarconnections;
using Amazon.CodeStarconnections.Model;

namespace Amazon.PowerShell.Cmdlets.CSTC
{
    /// <summary>
    /// Updates the sync configuration for your connection and a specified external Git repository.
    /// </summary>
    [Cmdlet("Update", "CSTCSyncConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeStarconnections.Model.SyncConfiguration")]
    [AWSCmdlet("Calls the AWS CodeStar Connections UpdateSyncConfiguration API operation.", Operation = new[] {"UpdateSyncConfiguration"}, SelectReturnType = typeof(Amazon.CodeStarconnections.Model.UpdateSyncConfigurationResponse))]
    [AWSCmdletOutput("Amazon.CodeStarconnections.Model.SyncConfiguration or Amazon.CodeStarconnections.Model.UpdateSyncConfigurationResponse",
        "This cmdlet returns an Amazon.CodeStarconnections.Model.SyncConfiguration object.",
        "The service call response (type Amazon.CodeStarconnections.Model.UpdateSyncConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCSTCSyncConfigurationCmdlet : AmazonCodeStarconnectionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Branch
        /// <summary>
        /// <para>
        /// <para>The branch for the sync configuration to be updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Branch { get; set; }
        #endregion
        
        #region Parameter ConfigFile
        /// <summary>
        /// <para>
        /// <para>The configuration file for the sync configuration to be updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigFile { get; set; }
        #endregion
        
        #region Parameter PublishDeploymentStatus
        /// <summary>
        /// <para>
        /// <para>Whether to enable or disable publishing of deployment status to source providers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeStarconnections.PublishDeploymentStatus")]
        public Amazon.CodeStarconnections.PublishDeploymentStatus PublishDeploymentStatus { get; set; }
        #endregion
        
        #region Parameter RepositoryLinkId
        /// <summary>
        /// <para>
        /// <para>The ID of the repository link for the sync configuration to be updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RepositoryLinkId { get; set; }
        #endregion
        
        #region Parameter ResourceName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Web Services resource for the sync configuration to be updated.</para>
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
        public System.String ResourceName { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role for the sync configuration to be updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter SyncType
        /// <summary>
        /// <para>
        /// <para>The sync type for the sync configuration to be updated.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodeStarconnections.SyncConfigurationType")]
        public Amazon.CodeStarconnections.SyncConfigurationType SyncType { get; set; }
        #endregion
        
        #region Parameter TriggerResourceUpdateOn
        /// <summary>
        /// <para>
        /// <para>When to trigger Git sync to begin the stack update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeStarconnections.TriggerResourceUpdateOn")]
        public Amazon.CodeStarconnections.TriggerResourceUpdateOn TriggerResourceUpdateOn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SyncConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeStarconnections.Model.UpdateSyncConfigurationResponse).
        /// Specifying the name of a property of type Amazon.CodeStarconnections.Model.UpdateSyncConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SyncConfiguration";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CSTCSyncConfiguration (UpdateSyncConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeStarconnections.Model.UpdateSyncConfigurationResponse, UpdateCSTCSyncConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Branch = this.Branch;
            context.ConfigFile = this.ConfigFile;
            context.PublishDeploymentStatus = this.PublishDeploymentStatus;
            context.RepositoryLinkId = this.RepositoryLinkId;
            context.ResourceName = this.ResourceName;
            #if MODULAR
            if (this.ResourceName == null && ParameterWasBound(nameof(this.ResourceName)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            context.SyncType = this.SyncType;
            #if MODULAR
            if (this.SyncType == null && ParameterWasBound(nameof(this.SyncType)))
            {
                WriteWarning("You are passing $null as a value for parameter SyncType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TriggerResourceUpdateOn = this.TriggerResourceUpdateOn;
            
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
            var request = new Amazon.CodeStarconnections.Model.UpdateSyncConfigurationRequest();
            
            if (cmdletContext.Branch != null)
            {
                request.Branch = cmdletContext.Branch;
            }
            if (cmdletContext.ConfigFile != null)
            {
                request.ConfigFile = cmdletContext.ConfigFile;
            }
            if (cmdletContext.PublishDeploymentStatus != null)
            {
                request.PublishDeploymentStatus = cmdletContext.PublishDeploymentStatus;
            }
            if (cmdletContext.RepositoryLinkId != null)
            {
                request.RepositoryLinkId = cmdletContext.RepositoryLinkId;
            }
            if (cmdletContext.ResourceName != null)
            {
                request.ResourceName = cmdletContext.ResourceName;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.SyncType != null)
            {
                request.SyncType = cmdletContext.SyncType;
            }
            if (cmdletContext.TriggerResourceUpdateOn != null)
            {
                request.TriggerResourceUpdateOn = cmdletContext.TriggerResourceUpdateOn;
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
        
        private Amazon.CodeStarconnections.Model.UpdateSyncConfigurationResponse CallAWSServiceOperation(IAmazonCodeStarconnections client, Amazon.CodeStarconnections.Model.UpdateSyncConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeStar Connections", "UpdateSyncConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateSyncConfiguration(request);
                #elif CORECLR
                return client.UpdateSyncConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String Branch { get; set; }
            public System.String ConfigFile { get; set; }
            public Amazon.CodeStarconnections.PublishDeploymentStatus PublishDeploymentStatus { get; set; }
            public System.String RepositoryLinkId { get; set; }
            public System.String ResourceName { get; set; }
            public System.String RoleArn { get; set; }
            public Amazon.CodeStarconnections.SyncConfigurationType SyncType { get; set; }
            public Amazon.CodeStarconnections.TriggerResourceUpdateOn TriggerResourceUpdateOn { get; set; }
            public System.Func<Amazon.CodeStarconnections.Model.UpdateSyncConfigurationResponse, UpdateCSTCSyncConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SyncConfiguration;
        }
        
    }
}
