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
using Amazon.NetworkManager;
using Amazon.NetworkManager.Model;

namespace Amazon.PowerShell.Cmdlets.NMGR
{
    /// <summary>
    /// Updates a VPC attachment.
    /// </summary>
    [Cmdlet("Update", "NMGRVpcAttachment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkManager.Model.VpcAttachment")]
    [AWSCmdlet("Calls the AWS Network Manager UpdateVpcAttachment API operation.", Operation = new[] {"UpdateVpcAttachment"}, SelectReturnType = typeof(Amazon.NetworkManager.Model.UpdateVpcAttachmentResponse))]
    [AWSCmdletOutput("Amazon.NetworkManager.Model.VpcAttachment or Amazon.NetworkManager.Model.UpdateVpcAttachmentResponse",
        "This cmdlet returns an Amazon.NetworkManager.Model.VpcAttachment object.",
        "The service call response (type Amazon.NetworkManager.Model.UpdateVpcAttachmentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateNMGRVpcAttachmentCmdlet : AmazonNetworkManagerClientCmdlet, IExecutor
    {
        
        #region Parameter AddSubnetArn
        /// <summary>
        /// <para>
        /// <para>Adds a subnet ARN to the VPC attachment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddSubnetArns")]
        public System.String[] AddSubnetArn { get; set; }
        #endregion
        
        #region Parameter AttachmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the attachment.</para>
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
        public System.String AttachmentId { get; set; }
        #endregion
        
        #region Parameter Options_Ipv6Support
        /// <summary>
        /// <para>
        /// <para>Indicates whether IPv6 is supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Options_Ipv6Support { get; set; }
        #endregion
        
        #region Parameter RemoveSubnetArn
        /// <summary>
        /// <para>
        /// <para>Removes a subnet ARN from the attachment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveSubnetArns")]
        public System.String[] RemoveSubnetArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpcAttachment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkManager.Model.UpdateVpcAttachmentResponse).
        /// Specifying the name of a property of type Amazon.NetworkManager.Model.UpdateVpcAttachmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpcAttachment";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AttachmentId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AttachmentId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AttachmentId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AttachmentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-NMGRVpcAttachment (UpdateVpcAttachment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkManager.Model.UpdateVpcAttachmentResponse, UpdateNMGRVpcAttachmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AttachmentId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AddSubnetArn != null)
            {
                context.AddSubnetArn = new List<System.String>(this.AddSubnetArn);
            }
            context.AttachmentId = this.AttachmentId;
            #if MODULAR
            if (this.AttachmentId == null && ParameterWasBound(nameof(this.AttachmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter AttachmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Options_Ipv6Support = this.Options_Ipv6Support;
            if (this.RemoveSubnetArn != null)
            {
                context.RemoveSubnetArn = new List<System.String>(this.RemoveSubnetArn);
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
            var request = new Amazon.NetworkManager.Model.UpdateVpcAttachmentRequest();
            
            if (cmdletContext.AddSubnetArn != null)
            {
                request.AddSubnetArns = cmdletContext.AddSubnetArn;
            }
            if (cmdletContext.AttachmentId != null)
            {
                request.AttachmentId = cmdletContext.AttachmentId;
            }
            
             // populate Options
            var requestOptionsIsNull = true;
            request.Options = new Amazon.NetworkManager.Model.VpcOptions();
            System.Boolean? requestOptions_options_Ipv6Support = null;
            if (cmdletContext.Options_Ipv6Support != null)
            {
                requestOptions_options_Ipv6Support = cmdletContext.Options_Ipv6Support.Value;
            }
            if (requestOptions_options_Ipv6Support != null)
            {
                request.Options.Ipv6Support = requestOptions_options_Ipv6Support.Value;
                requestOptionsIsNull = false;
            }
             // determine if request.Options should be set to null
            if (requestOptionsIsNull)
            {
                request.Options = null;
            }
            if (cmdletContext.RemoveSubnetArn != null)
            {
                request.RemoveSubnetArns = cmdletContext.RemoveSubnetArn;
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
        
        private Amazon.NetworkManager.Model.UpdateVpcAttachmentResponse CallAWSServiceOperation(IAmazonNetworkManager client, Amazon.NetworkManager.Model.UpdateVpcAttachmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Manager", "UpdateVpcAttachment");
            try
            {
                #if DESKTOP
                return client.UpdateVpcAttachment(request);
                #elif CORECLR
                return client.UpdateVpcAttachmentAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AddSubnetArn { get; set; }
            public System.String AttachmentId { get; set; }
            public System.Boolean? Options_Ipv6Support { get; set; }
            public List<System.String> RemoveSubnetArn { get; set; }
            public System.Func<Amazon.NetworkManager.Model.UpdateVpcAttachmentResponse, UpdateNMGRVpcAttachmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpcAttachment;
        }
        
    }
}
