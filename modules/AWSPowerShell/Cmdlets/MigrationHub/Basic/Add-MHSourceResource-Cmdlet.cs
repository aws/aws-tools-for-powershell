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
using Amazon.MigrationHub;
using Amazon.MigrationHub.Model;

namespace Amazon.PowerShell.Cmdlets.MH
{
    /// <summary>
    /// Associates a source resource with a migration task. For example, the source resource
    /// can be a source server, an application, or a migration wave.
    /// </summary>
    [Cmdlet("Add", "MHSourceResource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Migration Hub AssociateSourceResource API operation.", Operation = new[] {"AssociateSourceResource"}, SelectReturnType = typeof(Amazon.MigrationHub.Model.AssociateSourceResourceResponse))]
    [AWSCmdletOutput("None or Amazon.MigrationHub.Model.AssociateSourceResourceResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.MigrationHub.Model.AssociateSourceResourceResponse) be returned by specifying '-Select *'."
    )]
    public partial class AddMHSourceResourceCmdlet : AmazonMigrationHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SourceResource_Description
        /// <summary>
        /// <para>
        /// <para>A description that can be free-form text to record additional detail about the resource
        /// for clarity or later reference.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceResource_Description { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>This is an optional parameter that you can use to test whether the call will succeed.
        /// Set this parameter to <c>true</c> to verify that you have the permissions that are
        /// required to make the call, and that you have specified the other parameters in the
        /// call correctly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter MigrationTaskName
        /// <summary>
        /// <para>
        /// <para>A unique identifier that references the migration task. <i>Do not include sensitive
        /// data in this field.</i></para>
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
        public System.String MigrationTaskName { get; set; }
        #endregion
        
        #region Parameter SourceResource_Name
        /// <summary>
        /// <para>
        /// <para>This is the name that you want to use to identify the resource. If the resource is
        /// an AWS resource, we recommend that you set this parameter to the ARN of the resource.</para>
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
        public System.String SourceResource_Name { get; set; }
        #endregion
        
        #region Parameter ProgressUpdateStream
        /// <summary>
        /// <para>
        /// <para>The name of the progress-update stream, which is used for access control as well as
        /// a namespace for migration-task names that is implicitly linked to your AWS account.
        /// The progress-update stream must uniquely identify the migration tool as it is used
        /// for all updates made by the tool; however, it does not need to be unique for each
        /// AWS account because it is scoped to the AWS account.</para>
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
        public System.String ProgressUpdateStream { get; set; }
        #endregion
        
        #region Parameter SourceResource_StatusDetail
        /// <summary>
        /// <para>
        /// <para>A free-form description of the status of the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceResource_StatusDetail { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MigrationHub.Model.AssociateSourceResourceResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MigrationTaskName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-MHSourceResource (AssociateSourceResource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MigrationHub.Model.AssociateSourceResourceResponse, AddMHSourceResourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            context.MigrationTaskName = this.MigrationTaskName;
            #if MODULAR
            if (this.MigrationTaskName == null && ParameterWasBound(nameof(this.MigrationTaskName)))
            {
                WriteWarning("You are passing $null as a value for parameter MigrationTaskName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProgressUpdateStream = this.ProgressUpdateStream;
            #if MODULAR
            if (this.ProgressUpdateStream == null && ParameterWasBound(nameof(this.ProgressUpdateStream)))
            {
                WriteWarning("You are passing $null as a value for parameter ProgressUpdateStream which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceResource_Description = this.SourceResource_Description;
            context.SourceResource_Name = this.SourceResource_Name;
            #if MODULAR
            if (this.SourceResource_Name == null && ParameterWasBound(nameof(this.SourceResource_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceResource_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceResource_StatusDetail = this.SourceResource_StatusDetail;
            
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
            var request = new Amazon.MigrationHub.Model.AssociateSourceResourceRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.MigrationTaskName != null)
            {
                request.MigrationTaskName = cmdletContext.MigrationTaskName;
            }
            if (cmdletContext.ProgressUpdateStream != null)
            {
                request.ProgressUpdateStream = cmdletContext.ProgressUpdateStream;
            }
            
             // populate SourceResource
            var requestSourceResourceIsNull = true;
            request.SourceResource = new Amazon.MigrationHub.Model.SourceResource();
            System.String requestSourceResource_sourceResource_Description = null;
            if (cmdletContext.SourceResource_Description != null)
            {
                requestSourceResource_sourceResource_Description = cmdletContext.SourceResource_Description;
            }
            if (requestSourceResource_sourceResource_Description != null)
            {
                request.SourceResource.Description = requestSourceResource_sourceResource_Description;
                requestSourceResourceIsNull = false;
            }
            System.String requestSourceResource_sourceResource_Name = null;
            if (cmdletContext.SourceResource_Name != null)
            {
                requestSourceResource_sourceResource_Name = cmdletContext.SourceResource_Name;
            }
            if (requestSourceResource_sourceResource_Name != null)
            {
                request.SourceResource.Name = requestSourceResource_sourceResource_Name;
                requestSourceResourceIsNull = false;
            }
            System.String requestSourceResource_sourceResource_StatusDetail = null;
            if (cmdletContext.SourceResource_StatusDetail != null)
            {
                requestSourceResource_sourceResource_StatusDetail = cmdletContext.SourceResource_StatusDetail;
            }
            if (requestSourceResource_sourceResource_StatusDetail != null)
            {
                request.SourceResource.StatusDetail = requestSourceResource_sourceResource_StatusDetail;
                requestSourceResourceIsNull = false;
            }
             // determine if request.SourceResource should be set to null
            if (requestSourceResourceIsNull)
            {
                request.SourceResource = null;
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
        
        private Amazon.MigrationHub.Model.AssociateSourceResourceResponse CallAWSServiceOperation(IAmazonMigrationHub client, Amazon.MigrationHub.Model.AssociateSourceResourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Migration Hub", "AssociateSourceResource");
            try
            {
                return client.AssociateSourceResourceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public System.String MigrationTaskName { get; set; }
            public System.String ProgressUpdateStream { get; set; }
            public System.String SourceResource_Description { get; set; }
            public System.String SourceResource_Name { get; set; }
            public System.String SourceResource_StatusDetail { get; set; }
            public System.Func<Amazon.MigrationHub.Model.AssociateSourceResourceResponse, AddMHSourceResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
