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
using Amazon.NetworkManager;
using Amazon.NetworkManager.Model;

#pragma warning disable CS0618, CS0612
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
        "The service call response (type Amazon.NetworkManager.Model.UpdateVpcAttachmentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateNMGRVpcAttachmentCmdlet : AmazonNetworkManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AddSubnetArn
        /// <summary>
        /// <para>
        /// <para>Adds a subnet ARN to the VPC attachment.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AddSubnetArns")]
        public System.String[] AddSubnetArn { get; set; }
        #endregion
        
        #region Parameter Options_ApplianceModeSupport
        /// <summary>
        /// <para>
        /// <para>Indicates whether appliance mode is supported. If enabled, traffic flow between a
        /// source and destination use the same Availability Zone for the VPC attachment for the
        /// lifetime of that flow. The default value is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Options_ApplianceModeSupport { get; set; }
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
        
        #region Parameter Options_DnsSupport
        /// <summary>
        /// <para>
        /// <para>Indicates whether DNS is supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Options_DnsSupport { get; set; }
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
        /// <para>Removes a subnet ARN from the attachment.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveSubnetArns")]
        public System.String[] RemoveSubnetArn { get; set; }
        #endregion
        
        #region Parameter Options_SecurityGroupReferencingSupport
        /// <summary>
        /// <para>
        /// <para>Indicates whether security group referencing is enabled for this VPC attachment. The
        /// default is <c>true</c>. However, at the core network policy-level the default is set
        /// to <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Options_SecurityGroupReferencingSupport { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AttachmentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-NMGRVpcAttachment (UpdateVpcAttachment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkManager.Model.UpdateVpcAttachmentResponse, UpdateNMGRVpcAttachmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.Options_ApplianceModeSupport = this.Options_ApplianceModeSupport;
            context.Options_DnsSupport = this.Options_DnsSupport;
            context.Options_Ipv6Support = this.Options_Ipv6Support;
            context.Options_SecurityGroupReferencingSupport = this.Options_SecurityGroupReferencingSupport;
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
            System.Boolean? requestOptions_options_ApplianceModeSupport = null;
            if (cmdletContext.Options_ApplianceModeSupport != null)
            {
                requestOptions_options_ApplianceModeSupport = cmdletContext.Options_ApplianceModeSupport.Value;
            }
            if (requestOptions_options_ApplianceModeSupport != null)
            {
                request.Options.ApplianceModeSupport = requestOptions_options_ApplianceModeSupport.Value;
                requestOptionsIsNull = false;
            }
            System.Boolean? requestOptions_options_DnsSupport = null;
            if (cmdletContext.Options_DnsSupport != null)
            {
                requestOptions_options_DnsSupport = cmdletContext.Options_DnsSupport.Value;
            }
            if (requestOptions_options_DnsSupport != null)
            {
                request.Options.DnsSupport = requestOptions_options_DnsSupport.Value;
                requestOptionsIsNull = false;
            }
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
            System.Boolean? requestOptions_options_SecurityGroupReferencingSupport = null;
            if (cmdletContext.Options_SecurityGroupReferencingSupport != null)
            {
                requestOptions_options_SecurityGroupReferencingSupport = cmdletContext.Options_SecurityGroupReferencingSupport.Value;
            }
            if (requestOptions_options_SecurityGroupReferencingSupport != null)
            {
                request.Options.SecurityGroupReferencingSupport = requestOptions_options_SecurityGroupReferencingSupport.Value;
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
                return client.UpdateVpcAttachmentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? Options_ApplianceModeSupport { get; set; }
            public System.Boolean? Options_DnsSupport { get; set; }
            public System.Boolean? Options_Ipv6Support { get; set; }
            public System.Boolean? Options_SecurityGroupReferencingSupport { get; set; }
            public List<System.String> RemoveSubnetArn { get; set; }
            public System.Func<Amazon.NetworkManager.Model.UpdateVpcAttachmentResponse, UpdateNMGRVpcAttachmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpcAttachment;
        }
        
    }
}
