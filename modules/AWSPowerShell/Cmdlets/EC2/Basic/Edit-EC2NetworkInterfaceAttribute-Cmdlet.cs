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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the specified network interface attribute. You can specify only one attribute
    /// at a time. You can use this action to attach and detach security groups from an existing
    /// EC2 instance.
    /// </summary>
    [Cmdlet("Edit", "EC2NetworkInterfaceAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyNetworkInterfaceAttribute API operation.", Operation = new[] {"ModifyNetworkInterfaceAttribute"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyNetworkInterfaceAttributeResponse))]
    [AWSCmdletOutput("None or Amazon.EC2.Model.ModifyNetworkInterfaceAttributeResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.EC2.Model.ModifyNetworkInterfaceAttributeResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2NetworkInterfaceAttributeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Attachment_AttachmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the network interface attachment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Attachment_AttachmentId { get; set; }
        #endregion
        
        #region Parameter Attachment_DeleteOnTermination
        /// <summary>
        /// <para>
        /// <para>Indicates whether the network interface is deleted when the instance is terminated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Attachment_DeleteOnTermination { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the network interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EnablePrimaryIpv6
        /// <summary>
        /// <para>
        /// <para>If you’re modifying a network interface in a dual-stack or IPv6-only subnet, you have
        /// the option to assign a primary IPv6 IP address. A primary IPv6 address is an IPv6
        /// GUA address associated with an ENI that you have enabled to use a primary IPv6 address.
        /// Use this option if the instance that this ENI will be attached to relies on its IPv6
        /// address not changing. Amazon Web Services will automatically assign an IPv6 address
        /// associated with the ENI attached to your instance to be the primary IPv6 address.
        /// Once you enable an IPv6 GUA address to be a primary IPv6, you cannot disable it. When
        /// you enable an IPv6 GUA address to be a primary IPv6, the first IPv6 GUA will be made
        /// the primary IPv6 address until the instance is terminated or the network interface
        /// is detached. If you have multiple IPv6 addresses associated with an ENI attached to
        /// your instance and you enable a primary IPv6 address, the first IPv6 GUA address associated
        /// with the ENI becomes the primary IPv6 address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnablePrimaryIpv6 { get; set; }
        #endregion
        
        #region Parameter EnaSrdSpecification_EnaSrdEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether ENA Express is enabled for the network interface.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnaSrdSpecification_EnaSrdEnabled { get; set; }
        #endregion
        
        #region Parameter EnaSrdUdpSpecification_EnaSrdUdpEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether UDP traffic to and from the instance uses ENA Express. To specify
        /// this setting, you must first enable ENA Express.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnaSrdSpecification_EnaSrdUdpSpecification_EnaSrdUdpEnabled")]
        public System.Boolean? EnaSrdUdpSpecification_EnaSrdUdpEnabled { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GroupId","Groups")]
        public System.String[] Group { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the network interface.</para>
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
        public System.String NetworkInterfaceId { get; set; }
        #endregion
        
        #region Parameter SourceDestCheck
        /// <summary>
        /// <para>
        /// <para>Enable or disable source/destination checks, which ensure that the instance is either
        /// the source or the destination of any traffic that it receives. If the value is <c>true</c>,
        /// source/destination checks are enabled; otherwise, they are disabled. The default value
        /// is <c>true</c>. You must disable source/destination checks if the instance runs services
        /// such as network address translation, routing, or firewalls.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SourceDestCheck { get; set; }
        #endregion
        
        #region Parameter ConnectionTrackingSpecification_TcpEstablishedTimeout
        /// <summary>
        /// <para>
        /// <para>Timeout (in seconds) for idle TCP connections in an established state. Min: 60 seconds.
        /// Max: 432000 seconds (5 days). Default: 432000 seconds. Recommended: Less than 432000
        /// seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ConnectionTrackingSpecification_TcpEstablishedTimeout { get; set; }
        #endregion
        
        #region Parameter ConnectionTrackingSpecification_UdpStreamTimeout
        /// <summary>
        /// <para>
        /// <para>Timeout (in seconds) for idle UDP flows classified as streams which have seen more
        /// than one request-response transaction. Min: 60 seconds. Max: 180 seconds (3 minutes).
        /// Default: 180 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ConnectionTrackingSpecification_UdpStreamTimeout { get; set; }
        #endregion
        
        #region Parameter ConnectionTrackingSpecification_UdpTimeout
        /// <summary>
        /// <para>
        /// <para>Timeout (in seconds) for idle UDP flows that have seen traffic only in a single direction
        /// or a single request-response transaction. Min: 30 seconds. Max: 60 seconds. Default:
        /// 30 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ConnectionTrackingSpecification_UdpTimeout { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyNetworkInterfaceAttributeResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NetworkInterfaceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NetworkInterfaceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NetworkInterfaceId' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NetworkInterfaceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2NetworkInterfaceAttribute (ModifyNetworkInterfaceAttribute)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyNetworkInterfaceAttributeResponse, EditEC2NetworkInterfaceAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NetworkInterfaceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Attachment_AttachmentId = this.Attachment_AttachmentId;
            context.Attachment_DeleteOnTermination = this.Attachment_DeleteOnTermination;
            context.ConnectionTrackingSpecification_TcpEstablishedTimeout = this.ConnectionTrackingSpecification_TcpEstablishedTimeout;
            context.ConnectionTrackingSpecification_UdpStreamTimeout = this.ConnectionTrackingSpecification_UdpStreamTimeout;
            context.ConnectionTrackingSpecification_UdpTimeout = this.ConnectionTrackingSpecification_UdpTimeout;
            context.Description = this.Description;
            context.EnablePrimaryIpv6 = this.EnablePrimaryIpv6;
            context.EnaSrdSpecification_EnaSrdEnabled = this.EnaSrdSpecification_EnaSrdEnabled;
            context.EnaSrdUdpSpecification_EnaSrdUdpEnabled = this.EnaSrdUdpSpecification_EnaSrdUdpEnabled;
            if (this.Group != null)
            {
                context.Group = new List<System.String>(this.Group);
            }
            context.NetworkInterfaceId = this.NetworkInterfaceId;
            #if MODULAR
            if (this.NetworkInterfaceId == null && ParameterWasBound(nameof(this.NetworkInterfaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkInterfaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceDestCheck = this.SourceDestCheck;
            
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
            var request = new Amazon.EC2.Model.ModifyNetworkInterfaceAttributeRequest();
            
            
             // populate Attachment
            var requestAttachmentIsNull = true;
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
            
             // populate ConnectionTrackingSpecification
            var requestConnectionTrackingSpecificationIsNull = true;
            request.ConnectionTrackingSpecification = new Amazon.EC2.Model.ConnectionTrackingSpecificationRequest();
            System.Int32? requestConnectionTrackingSpecification_connectionTrackingSpecification_TcpEstablishedTimeout = null;
            if (cmdletContext.ConnectionTrackingSpecification_TcpEstablishedTimeout != null)
            {
                requestConnectionTrackingSpecification_connectionTrackingSpecification_TcpEstablishedTimeout = cmdletContext.ConnectionTrackingSpecification_TcpEstablishedTimeout.Value;
            }
            if (requestConnectionTrackingSpecification_connectionTrackingSpecification_TcpEstablishedTimeout != null)
            {
                request.ConnectionTrackingSpecification.TcpEstablishedTimeout = requestConnectionTrackingSpecification_connectionTrackingSpecification_TcpEstablishedTimeout.Value;
                requestConnectionTrackingSpecificationIsNull = false;
            }
            System.Int32? requestConnectionTrackingSpecification_connectionTrackingSpecification_UdpStreamTimeout = null;
            if (cmdletContext.ConnectionTrackingSpecification_UdpStreamTimeout != null)
            {
                requestConnectionTrackingSpecification_connectionTrackingSpecification_UdpStreamTimeout = cmdletContext.ConnectionTrackingSpecification_UdpStreamTimeout.Value;
            }
            if (requestConnectionTrackingSpecification_connectionTrackingSpecification_UdpStreamTimeout != null)
            {
                request.ConnectionTrackingSpecification.UdpStreamTimeout = requestConnectionTrackingSpecification_connectionTrackingSpecification_UdpStreamTimeout.Value;
                requestConnectionTrackingSpecificationIsNull = false;
            }
            System.Int32? requestConnectionTrackingSpecification_connectionTrackingSpecification_UdpTimeout = null;
            if (cmdletContext.ConnectionTrackingSpecification_UdpTimeout != null)
            {
                requestConnectionTrackingSpecification_connectionTrackingSpecification_UdpTimeout = cmdletContext.ConnectionTrackingSpecification_UdpTimeout.Value;
            }
            if (requestConnectionTrackingSpecification_connectionTrackingSpecification_UdpTimeout != null)
            {
                request.ConnectionTrackingSpecification.UdpTimeout = requestConnectionTrackingSpecification_connectionTrackingSpecification_UdpTimeout.Value;
                requestConnectionTrackingSpecificationIsNull = false;
            }
             // determine if request.ConnectionTrackingSpecification should be set to null
            if (requestConnectionTrackingSpecificationIsNull)
            {
                request.ConnectionTrackingSpecification = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EnablePrimaryIpv6 != null)
            {
                request.EnablePrimaryIpv6 = cmdletContext.EnablePrimaryIpv6.Value;
            }
            
             // populate EnaSrdSpecification
            var requestEnaSrdSpecificationIsNull = true;
            request.EnaSrdSpecification = new Amazon.EC2.Model.EnaSrdSpecification();
            System.Boolean? requestEnaSrdSpecification_enaSrdSpecification_EnaSrdEnabled = null;
            if (cmdletContext.EnaSrdSpecification_EnaSrdEnabled != null)
            {
                requestEnaSrdSpecification_enaSrdSpecification_EnaSrdEnabled = cmdletContext.EnaSrdSpecification_EnaSrdEnabled.Value;
            }
            if (requestEnaSrdSpecification_enaSrdSpecification_EnaSrdEnabled != null)
            {
                request.EnaSrdSpecification.EnaSrdEnabled = requestEnaSrdSpecification_enaSrdSpecification_EnaSrdEnabled.Value;
                requestEnaSrdSpecificationIsNull = false;
            }
            Amazon.EC2.Model.EnaSrdUdpSpecification requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecification = null;
            
             // populate EnaSrdUdpSpecification
            var requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecificationIsNull = true;
            requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecification = new Amazon.EC2.Model.EnaSrdUdpSpecification();
            System.Boolean? requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecification_enaSrdUdpSpecification_EnaSrdUdpEnabled = null;
            if (cmdletContext.EnaSrdUdpSpecification_EnaSrdUdpEnabled != null)
            {
                requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecification_enaSrdUdpSpecification_EnaSrdUdpEnabled = cmdletContext.EnaSrdUdpSpecification_EnaSrdUdpEnabled.Value;
            }
            if (requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecification_enaSrdUdpSpecification_EnaSrdUdpEnabled != null)
            {
                requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecification.EnaSrdUdpEnabled = requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecification_enaSrdUdpSpecification_EnaSrdUdpEnabled.Value;
                requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecificationIsNull = false;
            }
             // determine if requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecification should be set to null
            if (requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecificationIsNull)
            {
                requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecification = null;
            }
            if (requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecification != null)
            {
                request.EnaSrdSpecification.EnaSrdUdpSpecification = requestEnaSrdSpecification_enaSrdSpecification_EnaSrdUdpSpecification;
                requestEnaSrdSpecificationIsNull = false;
            }
             // determine if request.EnaSrdSpecification should be set to null
            if (requestEnaSrdSpecificationIsNull)
            {
                request.EnaSrdSpecification = null;
            }
            if (cmdletContext.Group != null)
            {
                request.Groups = cmdletContext.Group;
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
        
        private Amazon.EC2.Model.ModifyNetworkInterfaceAttributeResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyNetworkInterfaceAttributeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyNetworkInterfaceAttribute");
            try
            {
                #if DESKTOP
                return client.ModifyNetworkInterfaceAttribute(request);
                #elif CORECLR
                return client.ModifyNetworkInterfaceAttributeAsync(request).GetAwaiter().GetResult();
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
            public System.String Attachment_AttachmentId { get; set; }
            public System.Boolean? Attachment_DeleteOnTermination { get; set; }
            public System.Int32? ConnectionTrackingSpecification_TcpEstablishedTimeout { get; set; }
            public System.Int32? ConnectionTrackingSpecification_UdpStreamTimeout { get; set; }
            public System.Int32? ConnectionTrackingSpecification_UdpTimeout { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? EnablePrimaryIpv6 { get; set; }
            public System.Boolean? EnaSrdSpecification_EnaSrdEnabled { get; set; }
            public System.Boolean? EnaSrdUdpSpecification_EnaSrdUdpEnabled { get; set; }
            public List<System.String> Group { get; set; }
            public System.String NetworkInterfaceId { get; set; }
            public System.Boolean? SourceDestCheck { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyNetworkInterfaceAttributeResponse, EditEC2NetworkInterfaceAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
