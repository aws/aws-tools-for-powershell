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
using Amazon.CodeArtifact;
using Amazon.CodeArtifact.Model;

namespace Amazon.PowerShell.Cmdlets.CA
{
    /// <summary>
    /// Updates a package group. This API cannot be used to update a package group's origin
    /// configuration or pattern. To update a package group's origin configuration, use <a href="https://docs.aws.amazon.com/codeartifact/latest/APIReference/API_UpdatePackageGroupOriginConfiguration.html">UpdatePackageGroupOriginConfiguration</a>.
    /// </summary>
    [Cmdlet("Update", "CAPackageGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeArtifact.Model.PackageGroupDescription")]
    [AWSCmdlet("Calls the AWS CodeArtifact UpdatePackageGroup API operation.", Operation = new[] {"UpdatePackageGroup"}, SelectReturnType = typeof(Amazon.CodeArtifact.Model.UpdatePackageGroupResponse))]
    [AWSCmdletOutput("Amazon.CodeArtifact.Model.PackageGroupDescription or Amazon.CodeArtifact.Model.UpdatePackageGroupResponse",
        "This cmdlet returns an Amazon.CodeArtifact.Model.PackageGroupDescription object.",
        "The service call response (type Amazon.CodeArtifact.Model.UpdatePackageGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCAPackageGroupCmdlet : AmazonCodeArtifactClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ContactInfo
        /// <summary>
        /// <para>
        /// <para> Contact information which you want to update the requested package group with. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContactInfo { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> The description you want to update the requested package group with. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para> The name of the domain which contains the package group to be updated. </para>
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
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter DomainOwner
        /// <summary>
        /// <para>
        /// <para> The 12-digit account number of the Amazon Web Services account that owns the domain.
        /// It does not include dashes or spaces. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainOwner { get; set; }
        #endregion
        
        #region Parameter PackageGroup
        /// <summary>
        /// <para>
        /// <para> The pattern of the package group to be updated. </para>
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
        public System.String PackageGroup { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PackageGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeArtifact.Model.UpdatePackageGroupResponse).
        /// Specifying the name of a property of type Amazon.CodeArtifact.Model.UpdatePackageGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PackageGroup";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PackageGroup), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CAPackageGroup (UpdatePackageGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeArtifact.Model.UpdatePackageGroupResponse, UpdateCAPackageGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContactInfo = this.ContactInfo;
            context.Description = this.Description;
            context.Domain = this.Domain;
            #if MODULAR
            if (this.Domain == null && ParameterWasBound(nameof(this.Domain)))
            {
                WriteWarning("You are passing $null as a value for parameter Domain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DomainOwner = this.DomainOwner;
            context.PackageGroup = this.PackageGroup;
            #if MODULAR
            if (this.PackageGroup == null && ParameterWasBound(nameof(this.PackageGroup)))
            {
                WriteWarning("You are passing $null as a value for parameter PackageGroup which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeArtifact.Model.UpdatePackageGroupRequest();
            
            if (cmdletContext.ContactInfo != null)
            {
                request.ContactInfo = cmdletContext.ContactInfo;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            if (cmdletContext.DomainOwner != null)
            {
                request.DomainOwner = cmdletContext.DomainOwner;
            }
            if (cmdletContext.PackageGroup != null)
            {
                request.PackageGroup = cmdletContext.PackageGroup;
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
        
        private Amazon.CodeArtifact.Model.UpdatePackageGroupResponse CallAWSServiceOperation(IAmazonCodeArtifact client, Amazon.CodeArtifact.Model.UpdatePackageGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeArtifact", "UpdatePackageGroup");
            try
            {
                return client.UpdatePackageGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ContactInfo { get; set; }
            public System.String Description { get; set; }
            public System.String Domain { get; set; }
            public System.String DomainOwner { get; set; }
            public System.String PackageGroup { get; set; }
            public System.Func<Amazon.CodeArtifact.Model.UpdatePackageGroupResponse, UpdateCAPackageGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PackageGroup;
        }
        
    }
}
