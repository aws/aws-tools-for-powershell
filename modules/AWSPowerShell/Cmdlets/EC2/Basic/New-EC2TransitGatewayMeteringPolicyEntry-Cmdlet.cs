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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates an entry in a transit gateway metering policy to define traffic measurement
    /// rules.
    /// </summary>
    [Cmdlet("New", "EC2TransitGatewayMeteringPolicyEntry", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.TransitGatewayMeteringPolicyEntry")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateTransitGatewayMeteringPolicyEntry API operation.", Operation = new[] {"CreateTransitGatewayMeteringPolicyEntry"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateTransitGatewayMeteringPolicyEntryResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TransitGatewayMeteringPolicyEntry or Amazon.EC2.Model.CreateTransitGatewayMeteringPolicyEntryResponse",
        "This cmdlet returns an Amazon.EC2.Model.TransitGatewayMeteringPolicyEntry object.",
        "The service call response (type Amazon.EC2.Model.CreateTransitGatewayMeteringPolicyEntryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2TransitGatewayMeteringPolicyEntryCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DestinationCidrBlock
        /// <summary>
        /// <para>
        /// <para>The destination CIDR block for traffic matching.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationCidrBlock { get; set; }
        #endregion
        
        #region Parameter DestinationPortRange
        /// <summary>
        /// <para>
        /// <para>The destination port range for traffic matching.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationPortRange { get; set; }
        #endregion
        
        #region Parameter DestinationTransitGatewayAttachmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the destination transit gateway attachment for traffic matching.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationTransitGatewayAttachmentId { get; set; }
        #endregion
        
        #region Parameter DestinationTransitGatewayAttachmentType
        /// <summary>
        /// <para>
        /// <para>The type of the destination transit gateway attachment for traffic matching. Note
        /// that the <c>tgw-peering</c> resource type has been deprecated. To configure metering
        /// policies for Connect, use the transport attachment type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.TransitGatewayAttachmentResourceType")]
        public Amazon.EC2.TransitGatewayAttachmentResourceType DestinationTransitGatewayAttachmentType { get; set; }
        #endregion
        
        #region Parameter MeteredAccount
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID to which the metered traffic should be attributed.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.TransitGatewayMeteringPayerType")]
        public Amazon.EC2.TransitGatewayMeteringPayerType MeteredAccount { get; set; }
        #endregion
        
        #region Parameter PolicyRuleNumber
        /// <summary>
        /// <para>
        /// <para>The rule number for the metering policy entry. Rules are processed in order from lowest
        /// to highest number.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? PolicyRuleNumber { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol for traffic matching (1, 6, 17, etc.).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Protocol { get; set; }
        #endregion
        
        #region Parameter SourceCidrBlock
        /// <summary>
        /// <para>
        /// <para>The source CIDR block for traffic matching.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceCidrBlock { get; set; }
        #endregion
        
        #region Parameter SourcePortRange
        /// <summary>
        /// <para>
        /// <para>The source port range for traffic matching.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourcePortRange { get; set; }
        #endregion
        
        #region Parameter SourceTransitGatewayAttachmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the source transit gateway attachment for traffic matching.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceTransitGatewayAttachmentId { get; set; }
        #endregion
        
        #region Parameter SourceTransitGatewayAttachmentType
        /// <summary>
        /// <para>
        /// <para>The type of the source transit gateway attachment for traffic matching. Note that
        /// the <c>tgw-peering</c> resource type has been deprecated. To configure metering policies
        /// for Connect, use the transport attachment type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.TransitGatewayAttachmentResourceType")]
        public Amazon.EC2.TransitGatewayAttachmentResourceType SourceTransitGatewayAttachmentType { get; set; }
        #endregion
        
        #region Parameter TransitGatewayMeteringPolicyId
        /// <summary>
        /// <para>
        /// <para>The ID of the transit gateway metering policy to add the entry to.</para>
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
        public System.String TransitGatewayMeteringPolicyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TransitGatewayMeteringPolicyEntry'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateTransitGatewayMeteringPolicyEntryResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateTransitGatewayMeteringPolicyEntryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TransitGatewayMeteringPolicyEntry";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TransitGatewayMeteringPolicyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2TransitGatewayMeteringPolicyEntry (CreateTransitGatewayMeteringPolicyEntry)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateTransitGatewayMeteringPolicyEntryResponse, NewEC2TransitGatewayMeteringPolicyEntryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DestinationCidrBlock = this.DestinationCidrBlock;
            context.DestinationPortRange = this.DestinationPortRange;
            context.DestinationTransitGatewayAttachmentId = this.DestinationTransitGatewayAttachmentId;
            context.DestinationTransitGatewayAttachmentType = this.DestinationTransitGatewayAttachmentType;
            context.MeteredAccount = this.MeteredAccount;
            #if MODULAR
            if (this.MeteredAccount == null && ParameterWasBound(nameof(this.MeteredAccount)))
            {
                WriteWarning("You are passing $null as a value for parameter MeteredAccount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyRuleNumber = this.PolicyRuleNumber;
            #if MODULAR
            if (this.PolicyRuleNumber == null && ParameterWasBound(nameof(this.PolicyRuleNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyRuleNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Protocol = this.Protocol;
            context.SourceCidrBlock = this.SourceCidrBlock;
            context.SourcePortRange = this.SourcePortRange;
            context.SourceTransitGatewayAttachmentId = this.SourceTransitGatewayAttachmentId;
            context.SourceTransitGatewayAttachmentType = this.SourceTransitGatewayAttachmentType;
            context.TransitGatewayMeteringPolicyId = this.TransitGatewayMeteringPolicyId;
            #if MODULAR
            if (this.TransitGatewayMeteringPolicyId == null && ParameterWasBound(nameof(this.TransitGatewayMeteringPolicyId)))
            {
                WriteWarning("You are passing $null as a value for parameter TransitGatewayMeteringPolicyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.CreateTransitGatewayMeteringPolicyEntryRequest();
            
            if (cmdletContext.DestinationCidrBlock != null)
            {
                request.DestinationCidrBlock = cmdletContext.DestinationCidrBlock;
            }
            if (cmdletContext.DestinationPortRange != null)
            {
                request.DestinationPortRange = cmdletContext.DestinationPortRange;
            }
            if (cmdletContext.DestinationTransitGatewayAttachmentId != null)
            {
                request.DestinationTransitGatewayAttachmentId = cmdletContext.DestinationTransitGatewayAttachmentId;
            }
            if (cmdletContext.DestinationTransitGatewayAttachmentType != null)
            {
                request.DestinationTransitGatewayAttachmentType = cmdletContext.DestinationTransitGatewayAttachmentType;
            }
            if (cmdletContext.MeteredAccount != null)
            {
                request.MeteredAccount = cmdletContext.MeteredAccount;
            }
            if (cmdletContext.PolicyRuleNumber != null)
            {
                request.PolicyRuleNumber = cmdletContext.PolicyRuleNumber.Value;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol;
            }
            if (cmdletContext.SourceCidrBlock != null)
            {
                request.SourceCidrBlock = cmdletContext.SourceCidrBlock;
            }
            if (cmdletContext.SourcePortRange != null)
            {
                request.SourcePortRange = cmdletContext.SourcePortRange;
            }
            if (cmdletContext.SourceTransitGatewayAttachmentId != null)
            {
                request.SourceTransitGatewayAttachmentId = cmdletContext.SourceTransitGatewayAttachmentId;
            }
            if (cmdletContext.SourceTransitGatewayAttachmentType != null)
            {
                request.SourceTransitGatewayAttachmentType = cmdletContext.SourceTransitGatewayAttachmentType;
            }
            if (cmdletContext.TransitGatewayMeteringPolicyId != null)
            {
                request.TransitGatewayMeteringPolicyId = cmdletContext.TransitGatewayMeteringPolicyId;
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
        
        private Amazon.EC2.Model.CreateTransitGatewayMeteringPolicyEntryResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateTransitGatewayMeteringPolicyEntryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateTransitGatewayMeteringPolicyEntry");
            try
            {
                #if DESKTOP
                return client.CreateTransitGatewayMeteringPolicyEntry(request);
                #elif CORECLR
                return client.CreateTransitGatewayMeteringPolicyEntryAsync(request).GetAwaiter().GetResult();
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
            public System.String DestinationCidrBlock { get; set; }
            public System.String DestinationPortRange { get; set; }
            public System.String DestinationTransitGatewayAttachmentId { get; set; }
            public Amazon.EC2.TransitGatewayAttachmentResourceType DestinationTransitGatewayAttachmentType { get; set; }
            public Amazon.EC2.TransitGatewayMeteringPayerType MeteredAccount { get; set; }
            public System.Int32? PolicyRuleNumber { get; set; }
            public System.String Protocol { get; set; }
            public System.String SourceCidrBlock { get; set; }
            public System.String SourcePortRange { get; set; }
            public System.String SourceTransitGatewayAttachmentId { get; set; }
            public Amazon.EC2.TransitGatewayAttachmentResourceType SourceTransitGatewayAttachmentType { get; set; }
            public System.String TransitGatewayMeteringPolicyId { get; set; }
            public System.Func<Amazon.EC2.Model.CreateTransitGatewayMeteringPolicyEntryResponse, NewEC2TransitGatewayMeteringPolicyEntryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TransitGatewayMeteringPolicyEntry;
        }
        
    }
}
