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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Lists all the private hosted zones that a specified VPC is associated with, regardless
    /// of which Amazon Web Services account or Amazon Web Services service owns the hosted
    /// zones. The <c>HostedZoneOwner</c> structure in the response contains one of the following
    /// values:
    /// 
    ///  <ul><li><para>
    /// An <c>OwningAccount</c> element, which contains the account number of either the current
    /// Amazon Web Services account or another Amazon Web Services account. Some services,
    /// such as Cloud Map, create hosted zones using the current account. 
    /// </para></li><li><para>
    /// An <c>OwningService</c> element, which identifies the Amazon Web Services service
    /// that created and owns the hosted zone. For example, if a hosted zone was created by
    /// Amazon Elastic File System (Amazon EFS), the value of <c>Owner</c> is <c>efs.amazonaws.com</c>.
    /// 
    /// </para></li></ul><note><para>
    /// When listing private hosted zones, the hosted zone and the Amazon VPC must belong
    /// to the same partition where the hosted zones were created. A partition is a group
    /// of Amazon Web Services Regions. Each Amazon Web Services account is scoped to one
    /// partition.
    /// </para><para>
    /// The following are the supported partitions:
    /// </para><ul><li><para><c>aws</c> - Amazon Web Services Regions
    /// </para></li><li><para><c>aws-cn</c> - China Regions
    /// </para></li><li><para><c>aws-us-gov</c> - Amazon Web Services GovCloud (US) Region
    /// </para></li></ul><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Access
    /// Management</a> in the <i>Amazon Web Services General Reference</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "R53HostedZonesByVPC")]
    [OutputType("Amazon.Route53.Model.HostedZoneSummary")]
    [AWSCmdlet("Calls the Amazon Route 53 ListHostedZonesByVPC API operation.", Operation = new[] {"ListHostedZonesByVPC"}, SelectReturnType = typeof(Amazon.Route53.Model.ListHostedZonesByVPCResponse))]
    [AWSCmdletOutput("Amazon.Route53.Model.HostedZoneSummary or Amazon.Route53.Model.ListHostedZonesByVPCResponse",
        "This cmdlet returns a collection of Amazon.Route53.Model.HostedZoneSummary objects.",
        "The service call response (type Amazon.Route53.Model.ListHostedZonesByVPCResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetR53HostedZonesByVPCCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter VPCId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon VPC that you want to list hosted zones for.</para>
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
        public System.String VPCId { get; set; }
        #endregion
        
        #region Parameter VPCRegion
        /// <summary>
        /// <para>
        /// <para>For the Amazon VPC that you specified for <c>VPCId</c>, the Amazon Web Services Region
        /// that you created the VPC in. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Route53.VPCRegion")]
        public Amazon.Route53.VPCRegion VPCRegion { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>(Optional) The maximum number of hosted zones that you want Amazon Route 53 to return.
        /// If the specified VPC is associated with more than <c>MaxItems</c> hosted zones, the
        /// response includes a <c>NextToken</c> element. <c>NextToken</c> contains an encrypted
        /// token that identifies the first hosted zone that Route 53 will return if you submit
        /// another request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public System.String MaxItem { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the previous response included a <c>NextToken</c> element, the specified VPC is
        /// associated with more hosted zones. To get more hosted zones, submit another <c>ListHostedZonesByVPC</c>
        /// request. </para><para>For the value of <c>NextToken</c>, specify the value of <c>NextToken</c> from the
        /// previous response.</para><para>If the previous response didn't include a <c>NextToken</c> element, there are no more
        /// hosted zones to get.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'HostedZoneSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.ListHostedZonesByVPCResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.ListHostedZonesByVPCResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "HostedZoneSummaries";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.ListHostedZonesByVPCResponse, GetR53HostedZonesByVPCCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.VPCId = this.VPCId;
            #if MODULAR
            if (this.VPCId == null && ParameterWasBound(nameof(this.VPCId)))
            {
                WriteWarning("You are passing $null as a value for parameter VPCId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VPCRegion = this.VPCRegion;
            #if MODULAR
            if (this.VPCRegion == null && ParameterWasBound(nameof(this.VPCRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter VPCRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxItem = this.MaxItem;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.Route53.Model.ListHostedZonesByVPCRequest();
            
            if (cmdletContext.VPCId != null)
            {
                request.VPCId = cmdletContext.VPCId;
            }
            if (cmdletContext.VPCRegion != null)
            {
                request.VPCRegion = cmdletContext.VPCRegion;
            }
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = cmdletContext.MaxItem;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.Route53.Model.ListHostedZonesByVPCResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ListHostedZonesByVPCRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "ListHostedZonesByVPC");
            try
            {
                #if DESKTOP
                return client.ListHostedZonesByVPC(request);
                #elif CORECLR
                return client.ListHostedZonesByVPCAsync(request).GetAwaiter().GetResult();
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
            public System.String VPCId { get; set; }
            public Amazon.Route53.VPCRegion VPCRegion { get; set; }
            public System.String MaxItem { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Route53.Model.ListHostedZonesByVPCResponse, GetR53HostedZonesByVPCCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.HostedZoneSummaries;
        }
        
    }
}
