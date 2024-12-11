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
    /// Modifies a Traffic Mirror session.
    /// </summary>
    [Cmdlet("Edit", "EC2TrafficMirrorSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.TrafficMirrorSession")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyTrafficMirrorSession API operation.", Operation = new[] {"ModifyTrafficMirrorSession"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyTrafficMirrorSessionResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TrafficMirrorSession or Amazon.EC2.Model.ModifyTrafficMirrorSessionResponse",
        "This cmdlet returns an Amazon.EC2.Model.TrafficMirrorSession object.",
        "The service call response (type Amazon.EC2.Model.ModifyTrafficMirrorSessionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2TrafficMirrorSessionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description to assign to the Traffic Mirror session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter PacketLength
        /// <summary>
        /// <para>
        /// <para>The number of bytes in each packet to mirror. These are bytes after the VXLAN header.
        /// To mirror a subset, set this to the length (in bytes) to mirror. For example, if you
        /// set this value to 100, then the first 100 bytes that meet the filter criteria are
        /// copied to the target. Do not specify this parameter when you want to mirror the entire
        /// packet.</para><para>For sessions with Network Load Balancer (NLB) traffic mirror targets, the default
        /// <c>PacketLength</c> will be set to 8500. Valid values are 1-8500. Setting a <c>PacketLength</c>
        /// greater than 8500 will result in an error response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PacketLength { get; set; }
        #endregion
        
        #region Parameter RemoveField
        /// <summary>
        /// <para>
        /// <para>The properties that you want to remove from the Traffic Mirror session.</para><para>When you remove a property from a Traffic Mirror session, the property is set to the
        /// default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoveFields")]
        public System.String[] RemoveField { get; set; }
        #endregion
        
        #region Parameter SessionNumber
        /// <summary>
        /// <para>
        /// <para>The session number determines the order in which sessions are evaluated when an interface
        /// is used by multiple sessions. The first session with a matching filter is the one
        /// that mirrors the packets.</para><para>Valid values are 1-32766.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SessionNumber { get; set; }
        #endregion
        
        #region Parameter TrafficMirrorFilterId
        /// <summary>
        /// <para>
        /// <para>The ID of the Traffic Mirror filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TrafficMirrorFilterId { get; set; }
        #endregion
        
        #region Parameter TrafficMirrorSessionId
        /// <summary>
        /// <para>
        /// <para>The ID of the Traffic Mirror session.</para>
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
        public System.String TrafficMirrorSessionId { get; set; }
        #endregion
        
        #region Parameter TrafficMirrorTargetId
        /// <summary>
        /// <para>
        /// <para>The Traffic Mirror target. The target must be in the same VPC as the source, or have
        /// a VPC peering connection with the source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TrafficMirrorTargetId { get; set; }
        #endregion
        
        #region Parameter VirtualNetworkId
        /// <summary>
        /// <para>
        /// <para>The virtual network ID of the Traffic Mirror session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? VirtualNetworkId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrafficMirrorSession'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyTrafficMirrorSessionResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyTrafficMirrorSessionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrafficMirrorSession";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrafficMirrorSessionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2TrafficMirrorSession (ModifyTrafficMirrorSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyTrafficMirrorSessionResponse, EditEC2TrafficMirrorSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.PacketLength = this.PacketLength;
            if (this.RemoveField != null)
            {
                context.RemoveField = new List<System.String>(this.RemoveField);
            }
            context.SessionNumber = this.SessionNumber;
            context.TrafficMirrorFilterId = this.TrafficMirrorFilterId;
            context.TrafficMirrorSessionId = this.TrafficMirrorSessionId;
            #if MODULAR
            if (this.TrafficMirrorSessionId == null && ParameterWasBound(nameof(this.TrafficMirrorSessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter TrafficMirrorSessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrafficMirrorTargetId = this.TrafficMirrorTargetId;
            context.VirtualNetworkId = this.VirtualNetworkId;
            
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
            var request = new Amazon.EC2.Model.ModifyTrafficMirrorSessionRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.PacketLength != null)
            {
                request.PacketLength = cmdletContext.PacketLength.Value;
            }
            if (cmdletContext.RemoveField != null)
            {
                request.RemoveFields = cmdletContext.RemoveField;
            }
            if (cmdletContext.SessionNumber != null)
            {
                request.SessionNumber = cmdletContext.SessionNumber.Value;
            }
            if (cmdletContext.TrafficMirrorFilterId != null)
            {
                request.TrafficMirrorFilterId = cmdletContext.TrafficMirrorFilterId;
            }
            if (cmdletContext.TrafficMirrorSessionId != null)
            {
                request.TrafficMirrorSessionId = cmdletContext.TrafficMirrorSessionId;
            }
            if (cmdletContext.TrafficMirrorTargetId != null)
            {
                request.TrafficMirrorTargetId = cmdletContext.TrafficMirrorTargetId;
            }
            if (cmdletContext.VirtualNetworkId != null)
            {
                request.VirtualNetworkId = cmdletContext.VirtualNetworkId.Value;
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
        
        private Amazon.EC2.Model.ModifyTrafficMirrorSessionResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyTrafficMirrorSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyTrafficMirrorSession");
            try
            {
                #if DESKTOP
                return client.ModifyTrafficMirrorSession(request);
                #elif CORECLR
                return client.ModifyTrafficMirrorSessionAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.Int32? PacketLength { get; set; }
            public List<System.String> RemoveField { get; set; }
            public System.Int32? SessionNumber { get; set; }
            public System.String TrafficMirrorFilterId { get; set; }
            public System.String TrafficMirrorSessionId { get; set; }
            public System.String TrafficMirrorTargetId { get; set; }
            public System.Int32? VirtualNetworkId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyTrafficMirrorSessionResponse, EditEC2TrafficMirrorSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrafficMirrorSession;
        }
        
    }
}
