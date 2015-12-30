/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Modifies the specified network interface attribute. You can specify only one attribute
    /// at a time.
    /// </summary>
    [Cmdlet("Edit", "EC2NetworkInterfaceAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the ModifyNetworkInterfaceAttribute operation against Amazon Elastic Compute Cloud.", Operation = new[] {"ModifyNetworkInterfaceAttribute"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the NetworkInterfaceId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.EC2.Model.ModifyNetworkInterfaceAttributeResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class EditEC2NetworkInterfaceAttributeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Attachment_AttachmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the network interface attachment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Attachment_AttachmentId { get; set; }
        #endregion
        
        #region Parameter Attachment_DeleteOnTermination
        /// <summary>
        /// <para>
        /// <para>Indicates whether the network interface is deleted when the instance is terminated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Attachment_DeleteOnTermination { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the network interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Group
        /// <summary>
        /// <para>
        /// <para>Changes the security groups for the network interface. The new set of groups you specify
        /// replaces the current set. You must specify at least one group, even if it's just the
        /// default security group in the VPC. You must specify the ID of the security group,
        /// not the name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GroupId","Groups")]
        public System.String[] Group { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the network interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String NetworkInterfaceId { get; set; }
        #endregion
        
        #region Parameter SourceDestCheck
        /// <summary>
        /// <para>
        /// <para>Indicates whether source/destination checking is enabled. A value of <code>true</code>
        /// means checking is enabled, and <code>false</code> means checking is disabled. This
        /// value must be <code>false</code> for a NAT instance to perform NAT. For more information,
        /// see <a href="http://docs.aws.amazon.com/AmazonVPC/latest/UserGuide/VPC_NAT_Instance.html">NAT
        /// Instances</a> in the <i>Amazon Virtual Private Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean SourceDestCheck { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the NetworkInterfaceId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("NetworkInterfaceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2NetworkInterfaceAttribute (ModifyNetworkInterfaceAttribute)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Attachment_AttachmentId = this.Attachment_AttachmentId;
            if (ParameterWasBound("Attachment_DeleteOnTermination"))
                context.Attachment_DeleteOnTermination = this.Attachment_DeleteOnTermination;
            context.Description = this.Description;
            if (this.Group != null)
            {
                context.Groups = new List<System.String>(this.Group);
            }
            context.NetworkInterfaceId = this.NetworkInterfaceId;
            if (ParameterWasBound("SourceDestCheck"))
                context.SourceDestCheck = this.SourceDestCheck;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.ModifyNetworkInterfaceAttributeRequest();
            
            
             // populate Attachment
            bool requestAttachmentIsNull = true;
            request.Attachment = new Amazon.EC2.Model.NetworkInterfaceAttachmentChanges();
            System.String requestAttachment_attachment_AttachmentId = null;
            if (cmdletContext.Attachment_AttachmentId != null)
            {
                requestAttachment_attachment_AttachmentId = cmdletContext.Attachment_AttachmentId;
            }
            if (requestAttachment_attachment_AttachmentId != null)
            {
                request.Attachment.AttachmentId = requestAttachment_attachment_AttachmentId;
                requestAttachmentIsNull = false;
            }
            System.Boolean? requestAttachment_attachment_DeleteOnTermination = null;
            if (cmdletContext.Attachment_DeleteOnTermination != null)
            {
                requestAttachment_attachment_DeleteOnTermination = cmdletContext.Attachment_DeleteOnTermination.Value;
            }
            if (requestAttachment_attachment_DeleteOnTermination != null)
            {
                request.Attachment.DeleteOnTermination = requestAttachment_attachment_DeleteOnTermination.Value;
                requestAttachmentIsNull = false;
            }
             // determine if request.Attachment should be set to null
            if (requestAttachmentIsNull)
            {
                request.Attachment = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Groups != null)
            {
                request.Groups = cmdletContext.Groups;
            }
            if (cmdletContext.NetworkInterfaceId != null)
            {
                request.NetworkInterfaceId = cmdletContext.NetworkInterfaceId;
            }
            if (cmdletContext.SourceDestCheck != null)
            {
                request.SourceDestCheck = cmdletContext.SourceDestCheck.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ModifyNetworkInterfaceAttribute(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.NetworkInterfaceId;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Attachment_AttachmentId { get; set; }
            public System.Boolean? Attachment_DeleteOnTermination { get; set; }
            public System.String Description { get; set; }
            public List<System.String> Groups { get; set; }
            public System.String NetworkInterfaceId { get; set; }
            public System.Boolean? SourceDestCheck { get; set; }
        }
        
    }
}
