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
using Amazon.GlobalAccelerator;
using Amazon.GlobalAccelerator.Model;

namespace Amazon.PowerShell.Cmdlets.GACL
{
    /// <summary>
    /// Create a cross-account attachment in Global Accelerator. You create a cross-account
    /// attachment to specify the <i>principals</i> who have permission to work with <i>resources</i>
    /// in accelerators in their own account. You specify, in the same attachment, the resources
    /// that are shared.
    /// 
    ///  
    /// <para>
    /// A principal can be an Amazon Web Services account number or the Amazon Resource Name
    /// (ARN) for an accelerator. For account numbers that are listed as principals, to work
    /// with a resource listed in the attachment, you must sign in to an account specified
    /// as a principal. Then, you can work with resources that are listed, with any of your
    /// accelerators. If an accelerator ARN is listed in the cross-account attachment as a
    /// principal, anyone with permission to make updates to the accelerator can work with
    /// resources that are listed in the attachment. 
    /// </para><para>
    /// Specify each principal and resource separately. To specify two CIDR address pools,
    /// list them individually under <c>Resources</c>, and so on. For a command line operation,
    /// for example, you might use a statement like the following:
    /// </para><para><c> "Resources": [{"Cidr": "169.254.60.0/24"},{"Cidr": "169.254.59.0/24"}]</c></para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/global-accelerator/latest/dg/cross-account-resources.html">
    /// Working with cross-account attachments and resources in Global Accelerator</a> in
    /// the <i> Global Accelerator Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "GACLCrossAccountAttachment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GlobalAccelerator.Model.Attachment")]
    [AWSCmdlet("Calls the AWS Global Accelerator CreateCrossAccountAttachment API operation.", Operation = new[] {"CreateCrossAccountAttachment"}, SelectReturnType = typeof(Amazon.GlobalAccelerator.Model.CreateCrossAccountAttachmentResponse))]
    [AWSCmdletOutput("Amazon.GlobalAccelerator.Model.Attachment or Amazon.GlobalAccelerator.Model.CreateCrossAccountAttachmentResponse",
        "This cmdlet returns an Amazon.GlobalAccelerator.Model.Attachment object.",
        "The service call response (type Amazon.GlobalAccelerator.Model.CreateCrossAccountAttachmentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewGACLCrossAccountAttachmentCmdlet : AmazonGlobalAcceleratorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency—that
        /// is, the uniqueness—of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the cross-account attachment. </para>
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
        
        #region Parameter Principal
        /// <summary>
        /// <para>
        /// <para>The principals to include in the cross-account attachment. A principal can be an Amazon
        /// Web Services account number or the Amazon Resource Name (ARN) for an accelerator.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Principals")]
        public System.String[] Principal { get; set; }
        #endregion
        
        #region Parameter Resource
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) for the resources to include in the cross-account
        /// attachment. A resource can be any supported Amazon Web Services resource type for
        /// Global Accelerator or a CIDR range for a bring your own IP address (BYOIP) address
        /// pool. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resources")]
        public Amazon.GlobalAccelerator.Model.Resource[] Resource { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Add tags for a cross-account attachment.</para><para>For more information, see <a href="https://docs.aws.amazon.com/global-accelerator/latest/dg/tagging-in-global-accelerator.html">Tagging
        /// in Global Accelerator</a> in the <i>Global Accelerator Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.GlobalAccelerator.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CrossAccountAttachment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GlobalAccelerator.Model.CreateCrossAccountAttachmentResponse).
        /// Specifying the name of a property of type Amazon.GlobalAccelerator.Model.CreateCrossAccountAttachmentResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GACLCrossAccountAttachment (CreateCrossAccountAttachment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GlobalAccelerator.Model.CreateCrossAccountAttachmentResponse, NewGACLCrossAccountAttachmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IdempotencyToken = this.IdempotencyToken;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Principal != null)
            {
                context.Principal = new List<System.String>(this.Principal);
            }
            if (this.Resource != null)
            {
                context.Resource = new List<Amazon.GlobalAccelerator.Model.Resource>(this.Resource);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.GlobalAccelerator.Model.Tag>(this.Tag);
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
            var request = new Amazon.GlobalAccelerator.Model.CreateCrossAccountAttachmentRequest();
            
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Principal != null)
            {
                request.Principals = cmdletContext.Principal;
            }
            if (cmdletContext.Resource != null)
            {
                request.Resources = cmdletContext.Resource;
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
        
        private Amazon.GlobalAccelerator.Model.CreateCrossAccountAttachmentResponse CallAWSServiceOperation(IAmazonGlobalAccelerator client, Amazon.GlobalAccelerator.Model.CreateCrossAccountAttachmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Global Accelerator", "CreateCrossAccountAttachment");
            try
            {
                #if DESKTOP
                return client.CreateCrossAccountAttachment(request);
                #elif CORECLR
                return client.CreateCrossAccountAttachmentAsync(request).GetAwaiter().GetResult();
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
            public System.String IdempotencyToken { get; set; }
            public System.String Name { get; set; }
            public List<System.String> Principal { get; set; }
            public List<Amazon.GlobalAccelerator.Model.Resource> Resource { get; set; }
            public List<Amazon.GlobalAccelerator.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.GlobalAccelerator.Model.CreateCrossAccountAttachmentResponse, NewGACLCrossAccountAttachmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CrossAccountAttachment;
        }
        
    }
}
