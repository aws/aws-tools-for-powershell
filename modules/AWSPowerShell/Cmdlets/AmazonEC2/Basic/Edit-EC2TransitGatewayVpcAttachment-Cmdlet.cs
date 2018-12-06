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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the specified VPC attachment.
    /// </summary>
    [Cmdlet("Edit", "EC2TransitGatewayVpcAttachment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.TransitGatewayVpcAttachment")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud ModifyTransitGatewayVpcAttachment API operation.", Operation = new[] {"ModifyTransitGatewayVpcAttachment"})]
    [AWSCmdletOutput("Amazon.EC2.Model.TransitGatewayVpcAttachment",
        "This cmdlet returns a TransitGatewayVpcAttachment object.",
        "The service call response (type Amazon.EC2.Model.ModifyTransitGatewayVpcAttachmentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2TransitGatewayVpcAttachmentCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AddSubnetId
        /// <summary>
        /// <para>
        /// <para>The IDs of one or more subnets to add. You can specify at most one subnet per Availability
        /// Zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AddSubnetIds")]
        public System.String[] AddSubnetId { get; set; }
        #endregion
        
        #region Parameter Options_DnsSupport
        /// <summary>
        /// <para>
        /// <para>Enable or disable DNS support. The default is <code>enable</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.DnsSupportValue")]
        public Amazon.EC2.DnsSupportValue Options_DnsSupport { get; set; }
        #endregion
        
        #region Parameter Options_Ipv6Support
        /// <summary>
        /// <para>
        /// <para>Enable or disable IPv6 support. The default is <code>enable</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.Ipv6SupportValue")]
        public Amazon.EC2.Ipv6SupportValue Options_Ipv6Support { get; set; }
        #endregion
        
        #region Parameter RemoveSubnetId
        /// <summary>
        /// <para>
        /// <para>The IDs of one or more subnets to remove.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RemoveSubnetIds")]
        public System.String[] RemoveSubnetId { get; set; }
        #endregion
        
        #region Parameter TransitGatewayAttachmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the attachment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String TransitGatewayAttachmentId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TransitGatewayAttachmentId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2TransitGatewayVpcAttachment (ModifyTransitGatewayVpcAttachment)"))
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
            
            if (this.AddSubnetId != null)
            {
                context.AddSubnetIds = new List<System.String>(this.AddSubnetId);
            }
            context.Options_DnsSupport = this.Options_DnsSupport;
            context.Options_Ipv6Support = this.Options_Ipv6Support;
            if (this.RemoveSubnetId != null)
            {
                context.RemoveSubnetIds = new List<System.String>(this.RemoveSubnetId);
            }
            context.TransitGatewayAttachmentId = this.TransitGatewayAttachmentId;
            
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
            var request = new Amazon.EC2.Model.ModifyTransitGatewayVpcAttachmentRequest();
            
            if (cmdletContext.AddSubnetIds != null)
            {
                request.AddSubnetIds = cmdletContext.AddSubnetIds;
            }
            
             // populate Options
            bool requestOptionsIsNull = true;
            request.Options = new Amazon.EC2.Model.ModifyTransitGatewayVpcAttachmentRequestOptions();
            Amazon.EC2.DnsSupportValue requestOptions_options_DnsSupport = null;
            if (cmdletContext.Options_DnsSupport != null)
            {
                requestOptions_options_DnsSupport = cmdletContext.Options_DnsSupport;
            }
            if (requestOptions_options_DnsSupport != null)
            {
                request.Options.DnsSupport = requestOptions_options_DnsSupport;
                requestOptionsIsNull = false;
            }
            Amazon.EC2.Ipv6SupportValue requestOptions_options_Ipv6Support = null;
            if (cmdletContext.Options_Ipv6Support != null)
            {
                requestOptions_options_Ipv6Support = cmdletContext.Options_Ipv6Support;
            }
            if (requestOptions_options_Ipv6Support != null)
            {
                request.Options.Ipv6Support = requestOptions_options_Ipv6Support;
                requestOptionsIsNull = false;
            }
             // determine if request.Options should be set to null
            if (requestOptionsIsNull)
            {
                request.Options = null;
            }
            if (cmdletContext.RemoveSubnetIds != null)
            {
                request.RemoveSubnetIds = cmdletContext.RemoveSubnetIds;
            }
            if (cmdletContext.TransitGatewayAttachmentId != null)
            {
                request.TransitGatewayAttachmentId = cmdletContext.TransitGatewayAttachmentId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.TransitGatewayVpcAttachment;
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
        
        private Amazon.EC2.Model.ModifyTransitGatewayVpcAttachmentResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyTransitGatewayVpcAttachmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "ModifyTransitGatewayVpcAttachment");
            try
            {
                #if DESKTOP
                return client.ModifyTransitGatewayVpcAttachment(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ModifyTransitGatewayVpcAttachmentAsync(request);
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
            public List<System.String> AddSubnetIds { get; set; }
            public Amazon.EC2.DnsSupportValue Options_DnsSupport { get; set; }
            public Amazon.EC2.Ipv6SupportValue Options_Ipv6Support { get; set; }
            public List<System.String> RemoveSubnetIds { get; set; }
            public System.String TransitGatewayAttachmentId { get; set; }
        }
        
    }
}
