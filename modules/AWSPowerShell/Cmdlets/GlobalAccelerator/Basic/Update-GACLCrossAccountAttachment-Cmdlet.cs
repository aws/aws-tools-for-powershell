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
using Amazon.GlobalAccelerator;
using Amazon.GlobalAccelerator.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GACL
{
    /// <summary>
    /// Update a cross-account attachment to add or remove principals or resources. When you
    /// update an attachment to remove a principal (account ID or accelerator) or a resource,
    /// Global Accelerator revokes the permission for specific resources. 
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/global-accelerator/latest/dg/cross-account-resources.html">
    /// Working with cross-account attachments and resources in Global Accelerator</a> in
    /// the <i> Global Accelerator Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "GACLCrossAccountAttachment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GlobalAccelerator.Model.Attachment")]
    [AWSCmdlet("Calls the AWS Global Accelerator UpdateCrossAccountAttachment API operation.", Operation = new[] {"UpdateCrossAccountAttachment"}, SelectReturnType = typeof(Amazon.GlobalAccelerator.Model.UpdateCrossAccountAttachmentResponse))]
    [AWSCmdletOutput("Amazon.GlobalAccelerator.Model.Attachment or Amazon.GlobalAccelerator.Model.UpdateCrossAccountAttachmentResponse",
        "This cmdlet returns an Amazon.GlobalAccelerator.Model.Attachment object.",
        "The service call response (type Amazon.GlobalAccelerator.Model.UpdateCrossAccountAttachmentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateGACLCrossAccountAttachmentCmdlet : AmazonGlobalAcceleratorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AddPrincipal
        /// <summary>
        /// <para>
        /// <para>The principals to add to the cross-account attachment. A principal is an account or
        /// the Amazon Resource Name (ARN) of an accelerator that the attachment gives permission
        /// to work with resources from another account. The resources are also listed in the
        /// attachment.</para><para>To add more than one principal, separate the account numbers or accelerator ARNs,
        /// or both, with commas.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddPrincipals")]
        public System.String[] AddPrincipal { get; set; }
        #endregion
        
        #region Parameter AddResource
        /// <summary>
        /// <para>
        /// <para>The resources to add to the cross-account attachment. A resource listed in a cross-account
        /// attachment can be used with an accelerator by the principals that are listed in the
        /// attachment.</para><para>To add more than one resource, separate the resource ARNs with commas.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddResources")]
        public Amazon.GlobalAccelerator.Model.Resource[] AddResource { get; set; }
        #endregion
        
        #region Parameter AttachmentArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the cross-account attachment to update.</para>
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
        public System.String AttachmentArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the cross-account attachment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RemovePrincipal
        /// <summary>
        /// <para>
        /// <para>The principals to remove from the cross-account attachment. A principal is an account
        /// or the Amazon Resource Name (ARN) of an accelerator that the attachment gives permission
        /// to work with resources from another account. The resources are also listed in the
        /// attachment.</para><para>To remove more than one principal, separate the account numbers or accelerator ARNs,
        /// or both, with commas.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemovePrincipals")]
        public System.String[] RemovePrincipal { get; set; }
        #endregion
        
        #region Parameter RemoveResource
        /// <summary>
        /// <para>
        /// <para>The resources to remove from the cross-account attachment. A resource listed in a
        /// cross-account attachment can be used with an accelerator by the principals that are
        /// listed in the attachment.</para><para>To remove more than one resource, separate the resource ARNs with commas.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveResources")]
        public Amazon.GlobalAccelerator.Model.Resource[] RemoveResource { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CrossAccountAttachment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GlobalAccelerator.Model.UpdateCrossAccountAttachmentResponse).
        /// Specifying the name of a property of type Amazon.GlobalAccelerator.Model.UpdateCrossAccountAttachmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CrossAccountAttachment";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AttachmentArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GACLCrossAccountAttachment (UpdateCrossAccountAttachment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GlobalAccelerator.Model.UpdateCrossAccountAttachmentResponse, UpdateGACLCrossAccountAttachmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AddPrincipal != null)
            {
                context.AddPrincipal = new List<System.String>(this.AddPrincipal);
            }
            if (this.AddResource != null)
            {
                context.AddResource = new List<Amazon.GlobalAccelerator.Model.Resource>(this.AddResource);
            }
            context.AttachmentArn = this.AttachmentArn;
            #if MODULAR
            if (this.AttachmentArn == null && ParameterWasBound(nameof(this.AttachmentArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AttachmentArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            if (this.RemovePrincipal != null)
            {
                context.RemovePrincipal = new List<System.String>(this.RemovePrincipal);
            }
            if (this.RemoveResource != null)
            {
                context.RemoveResource = new List<Amazon.GlobalAccelerator.Model.Resource>(this.RemoveResource);
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
            var request = new Amazon.GlobalAccelerator.Model.UpdateCrossAccountAttachmentRequest();
            
            if (cmdletContext.AddPrincipal != null)
            {
                request.AddPrincipals = cmdletContext.AddPrincipal;
            }
            if (cmdletContext.AddResource != null)
            {
                request.AddResources = cmdletContext.AddResource;
            }
            if (cmdletContext.AttachmentArn != null)
            {
                request.AttachmentArn = cmdletContext.AttachmentArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RemovePrincipal != null)
            {
                request.RemovePrincipals = cmdletContext.RemovePrincipal;
            }
            if (cmdletContext.RemoveResource != null)
            {
                request.RemoveResources = cmdletContext.RemoveResource;
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
        
        private Amazon.GlobalAccelerator.Model.UpdateCrossAccountAttachmentResponse CallAWSServiceOperation(IAmazonGlobalAccelerator client, Amazon.GlobalAccelerator.Model.UpdateCrossAccountAttachmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Global Accelerator", "UpdateCrossAccountAttachment");
            try
            {
                return client.UpdateCrossAccountAttachmentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AddPrincipal { get; set; }
            public List<Amazon.GlobalAccelerator.Model.Resource> AddResource { get; set; }
            public System.String AttachmentArn { get; set; }
            public System.String Name { get; set; }
            public List<System.String> RemovePrincipal { get; set; }
            public List<Amazon.GlobalAccelerator.Model.Resource> RemoveResource { get; set; }
            public System.Func<Amazon.GlobalAccelerator.Model.UpdateCrossAccountAttachmentResponse, UpdateGACLCrossAccountAttachmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CrossAccountAttachment;
        }
        
    }
}
